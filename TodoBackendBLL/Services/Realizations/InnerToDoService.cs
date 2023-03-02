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
    public class InnerToDoService : IInnerToDoService
    {
        private readonly IInnerToDoRepository Repository;
        private readonly IMapper Mapper;

        public InnerToDoService(IInnerToDoRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task AddInnerToDo(InnerToDoRequest request)
        {
            var Item = Mapper.Map<InnerToDo>(request);
            await Repository.Insert(Item);
        }

        public async Task DeleteInnerToDo(int id)
        {
            await Repository.Delete(id);
        }

        /*public async Task<InnerToDoResponse> GetInnerToDoById(int id)
        {
            var Item = await Repository.GetById(id);
            return Mapper.Map<InnerToDoResponse>(Item);
        }*/

        public async Task UpdateInnerToDo(InnerToDoRequest request)
        {
            var Item = Mapper.Map<InnerToDo>(request);
            await Repository.Update(Item);
        }
    }
}
