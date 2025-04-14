

namespace DictionaryCoreAngular.Import.Context
{
    public class WordStatus
    {
        public int WordStatusId { get; set; }
        public int? ErrorLevel { get; set; }
        public bool IsPass { get; set; } = false;
        public int? WordListWordId { get; set; }
        public WordListWord? WordListWord { get; set; }
        public int? HistoryRoundId { get; set; }
        public HistoryRound? HistoryRound { get; set; }
    }
}
