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
    public class InnerToDoConfiguration : IEntityTypeConfiguration<InnerToDo>
    {
        public void Configure(EntityTypeBuilder<InnerToDo> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(x => x.ParentToDo)
                .WithMany(x => x.InnerToDoList);

            new InnerToDoSeeding().Seeding(builder);
        }
    }
}
