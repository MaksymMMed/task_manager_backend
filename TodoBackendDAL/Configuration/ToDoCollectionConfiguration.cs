using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendDAL.Entities;
using TodoBackendDAL.Seeding;

namespace TodoBackendDAL.Configuration
{
    public class ToDoCollectionConfiguration : IEntityTypeConfiguration<ToDoCollection>
    {
        public void Configure(EntityTypeBuilder<ToDoCollection> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.IconType)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Property(x => x.IconColor)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .HasMany(x => x.ToDoList)
                .WithOne(x => x.Collection);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Collections);

            new ToDoCollectionSeeding().Seeding(builder);
        }
    }
}
