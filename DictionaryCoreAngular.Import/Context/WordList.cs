

namespace DictionaryCoreAngular.Import.Context
{
    public class WordList
    {
        public int WordListId { get; set; }
        public string Name { get; set; }
        public int? WordListGroupId { get; set; }
        public WordListGroup? WordListGroup { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<WordListWord> WordListWords { get; set; }
    }
}
