
namespace DictionaryCoreAngular.Import.Context
{
    public class Translation
    {
        public int TranslationId { get; set; }

        public string RawA { get; set; }
        public string RawB { get; set; }
        public string RawC { get; set; }
        public string Short { get; set; }
        public string Long { get; set; }
        public string? Transcription { get; set; }
        public int? WordId { get; set; }
        public Word? Word { get; set; }
        public int? DictionaryId { get; set; }
        public Dictionary? Dictionary { get; set; }
    }
}
