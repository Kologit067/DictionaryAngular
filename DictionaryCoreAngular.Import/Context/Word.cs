

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DictionaryCoreAngular.Import.Context
{
    public class Word
    {
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int WordId { get; set; }

        public string WordText { get; set; }
        public string? Transcription { get; set; }
        public int? DictionaryId { get; set; }
        public Dictionary? Dictionary { get; set; }
        public virtual ICollection<DictionarySourceWord> DictionarySourceWords { get; set; }
        public virtual ICollection<WordListWord> WordListWords { get; set; }
        public virtual ICollection<Translation> Translations { get; set; }
    }
}
