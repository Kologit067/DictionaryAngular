
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class TranslationEntityConfiguration : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> builder)
        {
            builder.HasKey(e => e.TranslationId);
            builder.ToTable("Translation");

            builder.Property(e => e.RawA).IsRequired(false);
            builder.Property(e => e.RawB).IsRequired(false);
            builder.Property(e => e.RawC).IsRequired(false);
            builder.Property(e => e.Long).IsRequired(false);
            builder.HasOne(x => x.Dictionary)
            .WithMany(x => x.Translations)
            .HasForeignKey(x => x.DictionaryId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Word)
            .WithMany(x => x.Translations)
            .HasForeignKey(x => x.WordId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
