using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryCoreAngular.Import.Context
{
    public class DictionarySource
    {
        public int DictionarySourceId { get; set; }
        public string Name { get; set; }
        public int? DictionaryId { get; set; }
        public Dictionary? Dictionary { get; set; }
        public int? DictionaryTranslationId { get; set; }
        public Dictionary? DictionaryTranslation { get; set; }
        public virtual ICollection<DictionarySourceWord> DictionarySourceWords { get; set; }
    }
}
