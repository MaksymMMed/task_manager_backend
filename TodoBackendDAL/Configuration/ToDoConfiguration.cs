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
    internal class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder
                .HasKey(x=>x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder
                .Property(x => x.About)
                .HasMaxLength(200);

            builder
                .Property(x => x.CreationDate)
                .IsRequired();

            builder
                .HasMany(x => x.InnerToDoList)
                .WithOne(x => x.ParentToDo);

            builder
                .HasOne(x => x.Collection)
                .WithMany(x => x.ToDoList);

            new ToDoSeeding().Seeding(builder);
        }
    }
}
