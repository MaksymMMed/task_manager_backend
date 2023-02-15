using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendDAL.Configuration;
using TodoBackendDAL.Entities;

namespace TodoBackendDAL
{
    public class ToDoContext:DbContext
    {

        public DbSet<ToDo> ToDoTable { get; set; }
        public DbSet<InnerToDo> InnerToDoTable { get; set; }
        public DbSet<ToDoCollection> ToDoCollectionTable { get; set; }
        public DbSet<User> UserTable { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ToDoCollectionConfiguration());
            builder.ApplyConfiguration(new ToDoConfiguration());
            builder.ApplyConfiguration(new InnerToDoConfiguration());
        }
    }
}
