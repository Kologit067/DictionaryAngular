using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class WordStatusEntityConfiguration : IEntityTypeConfiguration<WordStatus>
    {
        public void Configure(EntityTypeBuilder<WordStatus> builder)
        {
            builder.HasKey(e => e.WordStatusId);
            builder.ToTable("WordStatus");

            builder.HasOne(x => x.WordListWord)
            .WithMany(x => x.WordStatuses)
            .HasForeignKey(x => x.WordListWordId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.HistoryRound)
            .WithMany(x => x.WordStatuses)
            .HasForeignKey(x => x.HistoryRoundId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
