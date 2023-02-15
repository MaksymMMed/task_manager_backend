using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendDAL.Entities;

namespace TodoBackendDAL.Repositories.Realizations
{
    public class ToDoRepository : GenericRepository<ToDo>
    {
        public ToDoRepository(ToDoContext context) : base(context)
        {
        }

        public override Task<ToDo> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
