using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendDAL.Entities;
using TodoBackendDAL.Seeding;

namespace TodoBackendDAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(75);

            builder
                .Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .HasMany(x => x.Collections)
                .WithOne(x => x.User);

            new UserSeeding().Seeding(builder);
        }
    }
}
