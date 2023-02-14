using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoBackendDAL.Entities
{
    public class InnerToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreationDate { get; set; }
        public int ToDoId { get; set; }
        public ToDo ParentToDo { get; set; }
    }
}
