
namespace DictionaryCoreAngular.Import.Context
{
    public class Step
    {
        public int StepdId { get; set; }
        public int PassNumber { get; set; }
        public int RemainNumber { get; set; }
        public decimal ErrorLevel { get; set; }
        public int? HistoryRoundId { get; set; }
        public HistoryRound? HistoryRound { get; set; }
        public virtual ICollection<StepWord> StepWords { get; set; }
    }
}
