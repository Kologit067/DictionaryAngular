using DictionaryCoreAngular.Import.Context.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DictionaryCoreAngular.Import.Context
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class DictionaryContext
    //------------------------------------------------------------------------------------------------------------------------------
    public class DictionaryContext : DbContext
    {
        private readonly IConfiguration _configuration;
        //------------------------------------------------------------------------------------------------------------------------------
        public DictionaryContext() : base() {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _configuration = configuration;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Dictionary")).EnableSensitiveDataLogging(true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ComparisonTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DictionaryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DictionarySourceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DictionarySourceWordEntityConfiguration());
            modelBuilder.ApplyConfiguration(new HistoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new HistoryRoundEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StepEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StepWordEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TranslationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new WordEntityConfiguration());
            modelBuilder.ApplyConfiguration(new WordListEntityConfiguration());
            modelBuilder.ApplyConfiguration(new WordListGroupEntityConfiguration());
            modelBuilder.ApplyConfiguration(new WordListWordEntityConfiguration());
            modelBuilder.ApplyConfiguration(new WordStatusEntityConfiguration());

            modelBuilder.ApplyConfiguration(new WordEntityConfiguration());
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public DbSet<ComparisonType> ComparisonTypes { get; set; }
        public DbSet<DictionaryCoreAngular.Import.Context.Dictionary> Dictionaries { get; set; }
        public DbSet<DictionarySource> DictionarySources { get; set; }
        public DbSet<DictionarySourceWord> DictionarySourceWords { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<HistoryRound> HistoryRounds { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<StepWord> StepWords { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WordList> WordLists { get; set; }
        public DbSet<WordListGroup> WordListGroups { get; set; }
        public DbSet<WordListWord> WordListWords { get; set; }
        public DbSet<WordStatus> WordStatuses { get; set; }

        public DbSet<Word> Words { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
