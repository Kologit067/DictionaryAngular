
namespace DictionaryCoreAngular.Import.Context
{
    public enum StepWordStatusEnum {NotProcessed, Passed, Error }
    public class StepWord
    {
        public int StepdWordId { get; set; }
        public decimal ErrorLevel { get; set; }
        public StepWordStatusEnum StepWordStatus { get; set; }
        public int? StepdId { get; set; }
        public Step? Step { get; set; }
        public int? WordListWordId { get; set; }
        public WordListWord? WordListWord { get; set; }
    }
}
