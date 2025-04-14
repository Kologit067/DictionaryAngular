
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);
            builder.ToTable("User");

            builder.HasMany(g => g.Histories)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
