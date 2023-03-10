using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendDAL.Entities;
using TodoBackendDAL.Repositories.Interfaces;

namespace TodoBackendDAL.Repositories.Realizations
{
    public class ToDoRepository : GenericRepository<ToDo>,IToDoRepository
    {
        public ToDoRepository(ToDoContext context) : base(context)
        {
        }

        public async override Task<ToDo> GetById(int id)
        {
            var item = await Table.Include(x => x.InnerToDoList).Where(x=>x.Id == id).FirstOrDefaultAsync();
            return item;
        }
    }
}
