
namespace DictionaryCoreAngular.Import.Context
{
    public class WordListGroup
    {
        public int WordListGroupId { get; set; }
        public string Name { get; set; }
        public int? DictionaryId { get; set; }
        public Dictionary? Dictionary { get; set; }
        public virtual ICollection<WordList> WordLists { get; set; }
    }
}
