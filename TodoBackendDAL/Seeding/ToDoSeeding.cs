using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendDAL.Entities;

namespace TodoBackendDAL.Seeding
{
    public class ToDoSeeding
    {
        public List<ToDo> ToDoList = new List<ToDo>()
        {
            new ToDo()
            {
                Id = 1,
                Name = "Do homework",
                CreationDate = DateTime.Now - TimeSpan.FromHours(12),
                IsComplete = false,
                About = "Do math and english",
                CollectionId = 4
            },
            new ToDo()
            {
                Id = 2,
                Name = "Do homework",
                CreationDate = DateTime.Now - TimeSpan.FromHours(36),
                IsComplete = true,
                About = "Do history",
                CollectionId = 4
            },
            new ToDo()
            {
                Id = 3,
                Name = "Cook supper",
                CreationDate = DateTime.Now - TimeSpan.FromHours(2),
                IsComplete = false,
                About = "Bake chiken and potato ",
                CollectionId = 3
            },
            new ToDo()
            {
                Id = 4,
                Name = "Clean up home",
                CreationDate = DateTime.Now - TimeSpan.FromHours(12),
                IsComplete = false,
                About = "-",
                CollectionId = 3
            },
            new ToDo()
            {
                Id = 5,
                Name = "Training",
                CreationDate = DateTime.Now - TimeSpan.FromHours(1),
                IsComplete = false,
                About = "Go on training at next tuesday",
                CollectionId = 2
            },
        };

        public void Seeding(EntityTypeBuilder<ToDo> builder) => builder.HasData(ToDoList);
    }
}
