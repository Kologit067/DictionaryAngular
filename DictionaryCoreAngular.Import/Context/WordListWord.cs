

namespace DictionaryCoreAngular.Import.Context
{
    public class WordListWord
    {
        public int WordListWordId { get; set; }
        public int? WordListId { get; set; }
        public WordList? WordList { get; set; }
        public int? WordId { get; set; }
        public Word? Word { get; set; }
        public virtual ICollection<WordStatus> WordStatuses { get; set; }
        public virtual ICollection<StepWord> StepWords { get; set; }
    }
}
