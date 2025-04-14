
namespace DictionaryCoreAngular.Import.Context
{
    public class ComparisonType
    {
        public int ComparisonTypeId { get; set; }
        public int Name { get; set; }
        public virtual ICollection<History> Histories { get; set; }
    }
}
