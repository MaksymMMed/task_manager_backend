
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendBLL.DTO.Request;
using TodoBackendBLL.DTO.Response;
using TodoBackendBLL.Services.Interfaces;
using TodoBackendDAL.Entities;
using TodoBackendDAL.Repositories.Interfaces;

namespace TodoBackendBLL.Services.Realizations
{
    public class ToDoCollectionService:IToDoCollectionService
    {
        private readonly IToDoCollectionRepository Repository;
        private readonly IMapper Mapper;

        public ToDoCollectionService(IToDoCollectionRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;

        }

        public async Task AddCollection(ToDoCollectionRequest collection)
        {
            var Item = Mapper.Map<ToDoCollection>(collection);
            await Repository.Insert(Item);
        }

        public async Task DeleteCollection(int id)
        {
            await Repository.Delete(id);
        }

        public async Task<ToDoCollectionResponse> GetCollection(int id)
        {
            var Item =  await Repository.GetById(id);
            return Mapper.Map<ToDoCollectionResponse>(Item);
        }

        public async Task UpdateCollection(ToDoCollectionRequest collection)
        {
            var Item = Mapper.Map<ToDoCollection>(collection);
            await Repository.Update(Item);
        }
    }
}
