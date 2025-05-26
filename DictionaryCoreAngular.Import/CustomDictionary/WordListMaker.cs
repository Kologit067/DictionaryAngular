
using DictionaryCoreAngular.Import.Context;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DictionaryCoreAngular.Import.CustomDictionary
{
    //-------------------------------------------------------------------------------------------------------------------
    // class WordListMaker
    //-------------------------------------------------------------------------------------------------------------------
    public class WordListMaker
    {
        private readonly FileInfo _file;
        private readonly IConfiguration _configuration;
        //-------------------------------------------------------------------------------------------------------------------
        public WordListMaker(FileInfo file, IConfiguration configuration)
        {
            _file = file;
            _configuration = configuration;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public async Task Process(int groupId, int dictionaryId)
        {
            using (DictionaryContext dictionaryContext = new DictionaryContext())
            {
                CreateWordListFromXML(groupId, dictionaryContext, dictionaryId);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void CreateWordListFromXML(int groupId, DictionaryContext dictionaryContext, int dictionaryId)
        {
            XElement elDictionary = XElement.Load(_file.FullName);
            IEnumerable<XElement> dictionaries = from el in elDictionary.Elements("Dictionary") select el;
            foreach (XElement el in dictionaries)
            {
                try
                {
                    XElement dictNameElement = (from e in el.Elements("DictionaryName") select e).FirstOrDefault();
                    string dictName = (string)dictNameElement;
                    List<Word> wordList = new System.Collections.Generic.List<Word>();
                    var list = dictionaryContext.WordLists.FirstOrDefault(l => l.Name == dictName);
                    if (list == null)
                    {
                        list = new WordList() { Name = dictName, WordListGroupId = groupId  };
                        dictionaryContext.WordLists.Add(list);
                        CreateWordInWordList(el, list, dictionaryContext, dictionaryId);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());   
                    throw;
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void CreateWordInWordList(XElement element, WordList list, DictionaryContext dictionaryContext, int dictionaryId)
        {
            IEnumerable<XElement> wordsElement = from e in element.Elements("Word") select e;
            foreach (XElement e in wordsElement)
            {
                XElement nativeElement = (from eo in e.Elements("Native") select eo).FirstOrDefault();
                XElement translationElement = (from et in e.Elements("Translation") select et).FirstOrDefault();
                string native = (string)nativeElement;
                string translation = (string)translationElement;
                Word? word = dictionaryContext.Words.Include(w => w.Translations).FirstOrDefault(w => w.WordText == native);
                if (word == null)
                {
                    word = new Word() { DictionaryId = dictionaryId};
                }
                if (word.Translations == null)
                {
                    word.Translations = new List<Translation>();
                }
                Translation? translationWord = word.Translations.FirstOrDefault(t => t.DictionaryId == dictionaryId);
                if (translationWord == null)
                {
                    translationWord = new Translation() { 
                        DictionaryId = dictionaryId,
                        Short = translation
                    };
                    word.Translations.Add(translationWord);
                    dictionaryContext.Translations.Add(translationWord);
                }
                else if (!translationWord.Short.Contains(translation))
                {
                    translationWord.Short += Environment.NewLine + translation;
                }
                WordListWord? wordListWord = dictionaryContext.WordListWords.FirstOrDefault(w => w.WordId == word.WordId && w.WordListId == list.WordListId);
                if (wordListWord == null) 
                {
                    wordListWord = new WordListWord()
                    {
                        Word = word,
                        WordList = list
                    };
                    dictionaryContext.WordListWords.Add(wordListWord);
                }

            }
            dictionaryContext.SaveChanges();
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
