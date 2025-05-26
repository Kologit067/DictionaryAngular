

using System.Runtime.CompilerServices;
using DictionaryCoreAngular.Import.Context;
using Microsoft.Extensions.Configuration;

namespace DictionaryCoreAngular.Import.CustomDictionary
{
    public class WordListGroupMaker
    {
        private readonly DirectoryInfo _directory;
        private readonly IConfiguration _configuration;
        public WordListGroupMaker(DirectoryInfo directory, IConfiguration configuration) 
        {
            _directory = directory;
            _configuration = configuration;
        }

        public async Task  Process()
        {
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
        }
    }
}
