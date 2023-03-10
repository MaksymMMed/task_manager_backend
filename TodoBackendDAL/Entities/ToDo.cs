using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoBackendDAL.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsComplete { get; set; }
        public string? About { get; set; } 
        public List<InnerToDo> InnerToDoList { get; set;}
        public int CollectionId { get; set; }
        public ToDoCollection Collection { get; set; }
    }
}
