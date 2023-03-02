using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendBLL.DTO.Request;
using TodoBackendBLL.DTO.Response;
using TodoBackendBLL.Services.Realizations;
using TodoBackendDAL.Entities;

namespace TodoBackendBLL.Services.Interfaces
{
    public interface IToDoCollectionService
    {
        public Task AddCollection(ToDoCollectionRequest collection);
        public Task UpdateCollection(ToDoCollectionRequest collection);
        public Task DeleteCollection (int id);
        public Task<ToDoCollectionResponse> GetCollection (int id);
    }
}
