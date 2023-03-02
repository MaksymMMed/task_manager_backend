using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendDAL.Entities;

namespace TodoBackendBLL.DTO.Request
{
    public class InnerToDoRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreationDate { get; set; }
        public int ToDoId { get; set; }
    }
}
