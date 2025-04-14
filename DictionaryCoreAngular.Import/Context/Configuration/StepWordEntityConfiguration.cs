
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class StepWordEntityConfiguration : IEntityTypeConfiguration<StepWord>
    {
        public void Configure(EntityTypeBuilder<StepWord> builder)
        {
            builder.HasKey(e => e.StepdWordId);
            builder.ToTable("StepWord");

            builder.HasOne(x => x.Step)
            .WithMany(x => x.StepWords)
            .HasForeignKey(x => x.StepdId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.WordListWord)
            .WithMany(x => x.StepWords)
            .HasForeignKey(x => x.WordListWordId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
