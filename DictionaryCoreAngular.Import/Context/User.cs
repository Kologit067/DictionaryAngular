
namespace DictionaryCoreAngular.Import.Context
{
    public class User
    {
        public int UserId { get; set; }
        public int Name { get; set; }
        public int? HistoryId { get; set; }
        public virtual ICollection<History> Histories { get; set; }
    }
}
