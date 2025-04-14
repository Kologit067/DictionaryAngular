
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class StepEntityConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.HasKey(e => e.StepdId);
            builder.ToTable("Step");

            builder.HasOne(x => x.HistoryRound)
            .WithMany(x => x.Steps)
            .HasForeignKey(x => x.HistoryRoundId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.StepWords)
                .WithOne(s => s.Step)
                .HasForeignKey(s => s.StepdId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
