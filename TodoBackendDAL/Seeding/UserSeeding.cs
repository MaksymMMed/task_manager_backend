using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendDAL.Entities;

namespace TodoBackendDAL.Seeding
{
    public class UserSeeding
    {
        public List<User> UserList = new List<User>()
        {
            new User()
            {
                Id = 1,
                Login = "BenderRobot",
                Password = "qwerty01",
                Email = "Bender03@gmail.com"
            },
            new User()
            {
                Id = 2,
                Login = "Jack",
                Password = "qwerty02",
                Email = "JackD@gmail.com"
            },
        };

        public void Seeding(EntityTypeBuilder<User> builder) => builder.HasData(UserList);
    }
}
