
namespace DictionaryCoreAngular.Import.Context
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Passwird { get; set; }
        public virtual History? CurrentHistory { get; set; }
        public virtual ICollection<History> Histories { get; set; }
    }
}
