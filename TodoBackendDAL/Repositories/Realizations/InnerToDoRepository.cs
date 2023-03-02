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
    public class InnerToDoRepository : GenericRepository<InnerToDo>,IInnerToDoRepository
    {
        public InnerToDoRepository(ToDoContext context) : base(context)
        {
        }

        public override async Task<InnerToDo> GetById(int id)
        {
            //var item = await Table.Where(x=>x.Id == id).FirstOrDefaultAsync();
            //return item;
            throw new NotImplementedException();
        }
    }
}
