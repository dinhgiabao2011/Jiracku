using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Services.Models;

namespace UserManagement.Services.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Salt).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.Avatar).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.RefreshToken).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.Role).IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.RoomId).IsRequired(false);
        }
    }
}
