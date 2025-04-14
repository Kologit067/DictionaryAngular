
using System.ComponentModel.DataAnnotations.Schema;

namespace DictionaryCoreAngular.Import.Context
{
    public class Dictionary
    {
        public int DictionaryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Word> Words { get; set; }

        [InverseProperty("Dictionary")]
        public virtual ICollection<DictionarySource> DictionarySources { get; set; }

        [InverseProperty("DictionaryTranslation")]
        public virtual ICollection<DictionarySource> DictionarySourceTranslations { get; set; }
        public virtual ICollection<Translation> Translations { get; set; }
        public virtual ICollection<WordListGroup> WordListGroups { get; set; }
    }
}
