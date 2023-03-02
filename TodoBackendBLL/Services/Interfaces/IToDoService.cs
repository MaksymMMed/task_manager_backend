using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendBLL.DTO.Request;
using TodoBackendBLL.DTO.Response;

namespace TodoBackendBLL.Services.Interfaces
{
    public interface IToDoService
    {
        public Task AddToDo(ToDoRequest toDo);
        public Task UpdateToDo(ToDoRequest toDo);
        public Task DeleteToDo(int id);
        public Task<ToDoCollectionResponse> GetToDo(int id);
    }
}
