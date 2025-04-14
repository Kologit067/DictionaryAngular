using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using DictionaryCoreAngular.Import.Context;
using Microsoft.EntityFrameworkCore;

namespace DictionaryCoreAngular.Import.Process
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class XmlRepository
    //------------------------------------------------------------------------------------------------------------------------------
    public class XmlRepository
    {
        private static readonly Dictionary<string, string> dictionaryNames = new Dictionary<string, string>()
        {
            ["ENG"] = "English",
            ["UKR"] = "Ukrainian",
            ["POL"] = "Polish",
            ["RUS"] = "Russian",
            ["LAT"] = "Latinian",
            ["BEL"] = "Belarussian"
        };
        //------------------------------------------------------------------------------------------------------------------------------
        public static void ProcessXDXFFile(string pFileName)
        {
            string translation = "";
            string lShortTranslation = "";
            string transcript = "";
            string native = "";
            XElement? transcriptElement = null;
            XElement? nativeElement = null;
            try
            {
                if (File.Exists(pFileName))
                {
                    XElement elDictionary = XElement.Load(pFileName);

                    XElement? dictnameElement = (from e in elDictionary.Elements("full_name") select e)?.FirstOrDefault();
                    if (dictnameElement != null)
                    {
                        string dictname = (string)dictnameElement;
                        XElement? xdxfElement = elDictionary;
                        if (xdxfElement.Name.LocalName != "xdxf")
                        {
                            xdxfElement = (from e in elDictionary.Elements("xdxf") select e)?.FirstOrDefault();
                        }
                        if (xdxfElement != null)
                        {
                            string langFrom = (string?)xdxfElement.Attribute("lang_from") ?? "";
                            string langTo = (string?)xdxfElement.Attribute("lang_to") ?? "";
                            string langFromName = dictionaryNames[langFrom];
                            string langToName = dictionaryNames[langTo];

                            List<Word> words = new List<Word>();
                            List<DictionarySourceWord> sourceWords = new List<DictionarySourceWord>();
                            List<XElement> wordElements = new List<XElement>();

                            int dictionaryFromId = 0;
                            int dictionaryToId = 0;
                            int dictionarySourceId = 0;

                            using (DictionaryContext dictionaryContext = new DictionaryContext())
                            {
                                dictionaryContext.Database.EnsureCreated();
                                Dictionary? dictionaryFrom = dictionaryContext.Dictionaries.FirstOrDefault(d => d.Name == langFromName);
                                if (dictionaryFrom == null)
                                {
                                    dictionaryFrom = new Dictionary()
                                    {
                                        Name = langFromName
                                    };
                                    dictionaryContext.Dictionaries.Add(dictionaryFrom);
                                }
                                Dictionary? dictionaryTo = dictionaryContext.Dictionaries.FirstOrDefault(d => d.Name == langToName);
                                if (dictionaryTo == null)
                                {
                                    dictionaryTo = new Dictionary()
                                    {
                                        Name = langToName
                                    };
                                    dictionaryContext.Dictionaries.Add(dictionaryTo);
                                }

                                DictionarySource? dictionarySource = dictionaryContext.DictionarySources.FirstOrDefault(d => d.Name == dictname);
                                if (dictionarySource == null)
                                {
                                    dictionarySource = new DictionarySource()
                                    {
                                        Name = dictname,
                                        Dictionary = dictionaryFrom,
                                        DictionaryTranslation = dictionaryTo
                                    };
                                    dictionaryContext.DictionarySources.Add(dictionarySource);
                                }
                                dictionaryContext.SaveChanges();

                                wordElements = (from el in elDictionary.Elements("ar") select el).ToList();
                                words = dictionaryContext.Words.AsNoTracking().Include(w => w.DictionarySourceWords).Where(w => w.DictionaryId == dictionaryFrom.DictionaryId).ToList();
                                sourceWords = dictionaryContext.DictionarySourceWords.AsNoTracking().Where(s =>
                                    s.DictionarySourceId == dictionarySource.DictionarySourceId).ToList();
                                dictionaryFromId = dictionaryFrom.DictionaryId;
                                dictionaryToId = dictionaryTo.DictionaryId;
                                dictionarySourceId = dictionarySource.DictionarySourceId;
                            }
                            int min = 0;
                            int max = Math.Min(5000, wordElements.Count);
                            Regex regex = new Regex(@"^[\sA-Za-zа-яА-ЯЁёїЇіІєЄ\-\-\']+$");
                            while (max <= wordElements.Count)
                            {
                                using (DictionaryContext dictionaryContext = new DictionaryContext())
                                {
                                    for (int i = min; i < max; i++)
                                    {
                                        XElement el = wordElements[i];
                                        translation = el.Value;
                                        translation = el.Nodes().OfType<XText>().Aggregate(new StringBuilder(),
                                              (s, c) => s.Append(c), s => s.ToString());
                                        transcriptElement = (from e in el.Elements("tr") select e)?.FirstOrDefault();
                                        transcript = (string?)transcriptElement ?? "";
                                        nativeElement = (from e in el.Elements("k") select e).FirstOrDefault();
                                        native = (string?)nativeElement ?? "";
//                                        Regex regex = new Regex(@"^[\sA-Za-zа-яА-ЯЁёїЇіІєЄ\-\-\']+$");
                                        MatchCollection matches = regex.Matches(native);

                                        if (string.IsNullOrWhiteSpace(native) || (matches?.Count ?? 0) == 0)
                                            continue;

                                        translation = translation.Replace(native, "");
                                        lShortTranslation = translation;
                                        if (native != null && native.Length > 200)
                                            continue; // native = native.Substring(0, 200);
                                        if (translation != null && translation.Length > 8000)
                                            translation = translation.Substring(0, 8000);
                                        if (transcript != null && transcript.Length > 200)
                                            transcript = transcript.Substring(0, 200);

                                        // word process
                                        Word? word = words.FirstOrDefault(w => string.Equals( w.WordText.ToLower(), native.ToLower(),StringComparison.CurrentCultureIgnoreCase));
                                        bool isInsert = false;
                                        if (word == null)
                                        {
                                            word = new Word()
                                            {
                                                WordText = native.ToLower() //,
                                                                  //                                        DictionarySourceWords = new List<DictionarySourceWord>()
                                            };
                                            dictionaryContext.Words.Add(word);
                                            words.Add(word);
                                        }
                                        if (word.DictionaryId == null)
                                        {
                                            isInsert = true;
                                            word.DictionaryId = dictionaryFromId;
                                            if (dictionaryContext.Entry(word).State == EntityState.Detached)
                                                dictionaryContext.Entry(word).State = EntityState.Modified;
                                        }

                                        // DictionarySourceWord process
                                        DictionarySourceWord? sourceWord = sourceWords.Where(s => s.WordId == word.WordId).FirstOrDefault();
                                        if (sourceWord == null)
                                        {
                                            if (word.WordId == 0)
                                            {
                                                sourceWord = new DictionarySourceWord()
                                                {
                                                    Word = word,
                                                    DictionarySourceId = dictionarySourceId,
                                                };
                                            }
                                            else
                                            {
                                                sourceWord = new DictionarySourceWord()
                                                {
                                                    WordId = word.WordId,
                                                    DictionarySourceId = dictionarySourceId,
                                                };
                                            }
                                            dictionaryContext.DictionarySourceWords.Add(sourceWord);
                                            sourceWords.Add(sourceWord);
                                            sourceWord.Word = word;
                                            isInsert = true;
                                        }
                                        if (string.IsNullOrEmpty(sourceWord.Transcription) && !string.IsNullOrEmpty(transcript) ||
                                            string.IsNullOrEmpty(sourceWord.Translation))
                                        {
                                            sourceWord.Transcription = transcript;
                                            sourceWord.Translation = translation;
                                            if (dictionaryContext.Entry(sourceWord).State == EntityState.Detached)
                                                dictionaryContext.Entry(sourceWord).State = EntityState.Modified;
                                        }
                                        if (isInsert)
                                        {
                                            dictionaryContext.SaveChanges();
                                        }
                                    }
                                    dictionaryContext.SaveChanges();
                                }

                                if (max == wordElements.Count)
                                    break;

                                min = max + 1;
                                max = Math.Min(max + 5000, wordElements.Count);
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Console.Write(exc.ToString());
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}
