﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoBackendDAL.Entities
{
    public class ToDoCollection
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int UserId { get; set; }
        public string IconColor { get; set; }
        public string IconType { get; set; }
        public User User { get; set; }
        public List<ToDo> ToDoList { get; set; }

    }
}
