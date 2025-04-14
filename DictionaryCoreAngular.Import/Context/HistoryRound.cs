
namespace DictionaryCoreAngular.Import.Context
{
    public class HistoryRound
    {
        public int HistoryRoundId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal ErrorLevel { get; set; }
        public int NumberOfAttepts { get; set; }
        public int? HistoryId { get; set; }
        public History? History { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
        public virtual ICollection<WordStatus> WordStatuses { get; set; }

    }
}
