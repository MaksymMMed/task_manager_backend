using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendDAL.Entities;

namespace TodoBackendBLL.DTO.Request
{
    public class ToDoCollectionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string IconColor { get; set; }
        public string IconType { get; set; }
    }
}
