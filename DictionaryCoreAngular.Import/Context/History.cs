
namespace DictionaryCoreAngular.Import.Context
{
    public class History
    {
        public int HistoryId { get; set; }
        public decimal? ErrorLevel { get; set; }
        public bool IsPass { get; set; } = false;
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? WordListId { get; set; }
        public WordList? WordList { get; set; }
        public int? ComparisonTypeId { get; set; }
        public ComparisonType? ComparisonType { get; set; }
        public virtual ICollection<HistoryRound> HistoryRounds { get; set; }
    }
}
