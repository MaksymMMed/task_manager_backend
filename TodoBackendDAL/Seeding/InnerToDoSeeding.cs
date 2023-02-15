using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TodoBackendDAL.Entities;

namespace TodoBackendDAL.Seeding
{
    internal class InnerToDoSeeding
    {
        public List<InnerToDo> InnerToDoList = new List<InnerToDo>()
        {
            new InnerToDo()
            {
                Id = 1,
                Name = "Do english",
                IsComplete = true,
                CreationDate = DateTime.Now - TimeSpan.FromHours(11.5),
                ToDoId = 1
            },
            new InnerToDo()
            {
                Id = 2,
                Name = "Do math",
                IsComplete = false,
                CreationDate = DateTime.Now - TimeSpan.FromHours(11.6),
                ToDoId = 1
            },
        };

        public void Seeding(EntityTypeBuilder<InnerToDo> builder) => builder.HasData(InnerToDoList);
    }
}
