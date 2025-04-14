
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class HistoryRoundEntityConfiguration : IEntityTypeConfiguration<HistoryRound>
    {
        public void Configure(EntityTypeBuilder<HistoryRound> builder)
        {
            builder.HasKey(e => e.HistoryRoundId);
            builder.ToTable("HistoryRound");

            builder.HasOne(x => x.History)
            .WithMany(x => x.HistoryRounds)
            .HasForeignKey(x => x.HistoryId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.Steps)
                .WithOne(s => s.HistoryRound)
                .HasForeignKey(s => s.HistoryRoundId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.WordStatuses)
                .WithOne(s => s.HistoryRound)
                .HasForeignKey(s => s.HistoryRoundId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
