using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne<RoleEntity>()
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .IsRequired();

            builder.HasData(
                new UserEntity 
                { 
                    Id = Guid.NewGuid(), Name = "Admin777", 
                    Email = "qweasdzxc@gmail.com", PasswordHash = "$2a$11$VPHUgxmNEwBFvHCzQ/4O/eDZfmhzoy.sPtjbsD3oypMAldV9xnpm6", // string
                    RoleId = 1
                }
                );
        }
    }
}
