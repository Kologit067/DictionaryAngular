
namespace DictionaryCoreAngular.Import.Context
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int? HistoryId { get; set; }
        public virtual ICollection<History> Histories { get; set; }
    }
}
