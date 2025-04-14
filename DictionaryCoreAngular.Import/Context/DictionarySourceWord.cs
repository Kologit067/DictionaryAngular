
namespace DictionaryCoreAngular.Import.Context
{
    public class DictionarySourceWord
    {
        public int DictionarySourceWordId {  get; set; }
        public int? DictionarySourceId { get; set; }
        public DictionarySource? DictionarySource { get; set; }
        public int? WordId { get; set; }
        public Word? Word { get; set; }
        public string Transcription { get; set; }
        public string Translation { get; set; }
    }
}
