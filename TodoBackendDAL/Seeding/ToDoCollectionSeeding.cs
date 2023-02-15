using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendDAL.Entities;

namespace TodoBackendDAL.Seeding
{
    public class ToDoCollectionSeeding
    {
        public List<ToDoCollection> ToDoCollectionList = new List<ToDoCollection>()
        {
            new ToDoCollection()
            {
                Id = 1,
                Name = "Home",
                UserId = 1,
                IconColor = "Red",
                IconType = "Home"
                
            },
            new ToDoCollection()
            {
                Id = 2,
                Name = "Sport",
                UserId = 1,
                IconColor = "Red",
                IconType = "Home"
            },
            new ToDoCollection()
            {
                Id = 3,
                Name = "Home",
                UserId = 2,
                IconColor = "Red",
                IconType = "Home"
            },
            new ToDoCollection()
            {
                Id = 4,
                Name = "Learn",
                UserId = 2,
                IconColor = "Red",
                IconType = "Home"
            },
        };

        public void Seeding(EntityTypeBuilder<ToDoCollection> builder) => builder.HasData(ToDoCollectionList);
    }
}
