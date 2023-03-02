using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TodoBackendBLL.DTO.Request;
using TodoBackendBLL.DTO.Response;
using TodoBackendBLL.Services.Interfaces;
using TodoBackendDAL.Entities;
using TodoBackendDAL.Repositories.Interfaces;

namespace TodoBackendBLL.Services.Realizations
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository Repository;
        private readonly IMapper Mapper;

        public ToDoService(IToDoRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task AddToDo(ToDoRequest toDo)
        {
            var Item = Mapper.Map<ToDo>(toDo);
            await Repository.Insert(Item);
        }

        public async Task DeleteToDo(int id)
        {
            await Repository.Delete(id);
        }

        public async Task<ToDoCollectionResponse> GetToDo(int id)
        {
            var Item = await Repository.GetById(id);
            return Mapper.Map<ToDoCollectionResponse>(Item);
        }

        public async Task UpdateToDo(ToDoRequest toDo)
        {
            var Item = Mapper.Map<ToDo>(toDo);
            await Repository.Update(Item);
        }
    }
}
