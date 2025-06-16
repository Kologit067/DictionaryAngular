

using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using DictionaryCoreAngular.Import.Context;
using Microsoft.Extensions.Configuration;

namespace DictionaryCoreAngular.Import.CustomDictionary
{
    public class UserHistoryMaker
    {
        private readonly DirectoryInfo _directory;
        private readonly IConfiguration _configuration;
        public UserHistoryMaker(DirectoryInfo directory, IConfiguration configuration)
        {
            _directory = directory;
            _configuration = configuration;
        }

        public async Task Process()
        {
            using (DictionaryContext dictionaryContext = new DictionaryContext())
            {
                foreach (FileInfo file in _directory.GetFiles())
                {
                    FileProcess(file, dictionaryContext);

                }
            }
            /*


            WordListGroup? group;
            int dictionaryId = 0;
            using (DictionaryContext dictionaryContext = new DictionaryContext())
            {
                dictionaryId = dictionaryContext.Dictionaries.First(d => d.Name == "English").DictionaryId;
                group = dictionaryContext.WordListGroups.FirstOrDefault(d => d.Name == _directory.Name);
                if (group == null)
                {
                    group = new WordListGroup() { Name = _directory.Name, DictionaryId = dictionaryId };
                    dictionaryContext.WordListGroups.Add(group);
                    await dictionaryContext.SaveChangesAsync();
                }
            }
            if (group != null)
            {

                foreach (FileInfo file in _directory.GetFiles())
                {
                    WordListMaker listMaker = new WordListMaker(file, _configuration);
                    listMaker.Process(group.WordListGroupId, dictionaryId);
                }
            }
            */
        }

        private void FileProcess(FileInfo file, DictionaryContext dictionaryContext)
        {
            XElement elUserHistory = XElement.Load(file.FullName);
            IEnumerable<XElement> userHistories = from el in elUserHistory.Elements("History") select el;
            foreach (XElement userHistory in userHistories)
            {
                try
                {
                    XElement userNameElement = (from e in userHistory.Elements("UserName") select e).FirstOrDefault();
                    string userName = (string)userNameElement;
                    if (userName == "Kolo")
                    {
                        IEnumerable<XElement> histories = from el in userHistory.Elements("DictionaryHistory") select el;

                        foreach (XElement historyElement in histories)
                        {
                            XElement listNameElement = (from e in historyElement.Elements("DictionaryName") select e).FirstOrDefault();
                            string listName = (string)listNameElement;
                            WordList wordList = dictionaryContext.WordLists.FirstOrDefault(l => l.Name == listName);
                            if (wordList != null)
                            {
                                History history = new History()
                                {
                                    UserId = 1,
                                    ComparisonTypeId = 1,
                                    WordListId = wordList.WordListId
                                };
                                dictionaryContext.Histories.Add(history);
                                dictionaryContext.SaveChanges();
                                XElement seansesElement = (from e in historyElement.Elements("Seanses") select e).FirstOrDefault();
                                IEnumerable<XElement> historyRounds = from el in seansesElement.Elements("Seans") select el;
                                foreach (XElement historyRoundElement in historyRounds)
                                {
                                    XElement startTimeElement = (from e in historyRoundElement.Elements("StartTime") select e).FirstOrDefault();
                                    DateTime startTime = (DateTime)startTimeElement;
                                    XElement endTimeElement = (from e in historyRoundElement.Elements("EndTime") select e).FirstOrDefault();
                                    DateTime endTime = (DateTime)endTimeElement;
                                    XElement roundErrorLevelElement = (from e in historyRoundElement.Elements("ErrorLevel") select e).FirstOrDefault();
                                    int roundErrorLevel = (int)roundErrorLevelElement;
                                    IEnumerable<XElement> steps = from el in historyRoundElement.Elements("Attempt") select el;
                                    HistoryRound historyRound = new HistoryRound()
                                    {
                                        DateFrom = startTime,
                                        DateTo = endTime,
                                        ErrorLevel = roundErrorLevel,
                                        NumberOfAttepts = steps.Count(),
                                        HistoryId = history.HistoryId
                                    };
                                    dictionaryContext.HistoryRounds.Add(historyRound);
                                    dictionaryContext.SaveChanges();
                                    foreach (XElement stepElement in steps)
                                    {
                                        XElement stepErrorLevelElement = (from e in stepElement.Elements("ErrorLevel") select e).FirstOrDefault();
                                        int stepErrorLevel = (int)stepErrorLevelElement;
                                        XElement passNumberElement = (from e in stepElement.Elements("PassNumber") select e).FirstOrDefault();
                                        int passNumber = (int)passNumberElement;
                                        XElement remainNumberElement = (from e in stepElement.Elements("RemainNumber") select e).FirstOrDefault();
                                        int remainNumber = (int)remainNumberElement;
                                        Step step = new Step()
                                        {
                                            PassNumber = passNumber,
                                            ErrorLevel = roundErrorLevel,
                                            RemainNumber = remainNumber,
                                            HistoryRoundId = historyRound.HistoryRoundId
                                        };
                                        dictionaryContext.Steps.Add(step);
                                    }
                                    dictionaryContext.SaveChanges();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }

        }
    }

}
