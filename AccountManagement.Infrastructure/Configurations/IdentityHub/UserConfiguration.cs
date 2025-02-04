using AccountManagement.Application.Utils;
using AccountManagement.Domain.IdentityHub;
using AccountManagement.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.Configurations.IdentityHub
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(CHURCHDatabaseContext.Users), schema:
                ApplicationConstants.IDENTITY_SCHEMA);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.LastLoggedIn);


            builder.HasMany(x => x.RefreshTokens)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(x => x.ProfilePictureMeta, m =>
            {
                m.Property(x => x.FileName).IsRequired();
                m.Property(x => x.ContentType);
            });
        }
    }
}
