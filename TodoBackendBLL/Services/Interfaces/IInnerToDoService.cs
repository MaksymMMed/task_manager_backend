using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendBLL.DTO.Request;
using TodoBackendBLL.DTO.Response;
using TodoBackendDAL.Entities;

namespace TodoBackendBLL.Services.Interfaces
{
    public interface IInnerToDoService
    {
        public Task AddInnerToDo(InnerToDoRequest request);
        public Task UpdateInnerToDo(InnerToDoRequest request);
        public Task DeleteInnerToDo(int id);
        //public Task<InnerToDoResponse> GetInnerToDoById(int id);
    }
}
