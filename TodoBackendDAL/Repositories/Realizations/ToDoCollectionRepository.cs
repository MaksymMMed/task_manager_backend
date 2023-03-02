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
    public class ToDoCollectionRepository : GenericRepository<ToDoCollection>,IToDoCollectionRepository
    {
        public ToDoCollectionRepository(ToDoContext context) : base(context)
        {
        }

        public async override Task<ToDoCollection> GetById(int id)
        {
            var item = await Table.Include(x => x.ToDoList).Where(x => x.Id == id).FirstOrDefaultAsync();
            return item;
        }
    }
}
