using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendBLL.DTO.Request;
using TodoBackendBLL.DTO.Response;
using TodoBackendDAL.Entities;

namespace TodoBackendBLL.Mapper
{
    public class MapperProfile:Profile
    {
        private void ToDoCollectionProfile()
        {
            CreateMap<ToDoCollection, ToDoCollectionResponse>();
            CreateMap<ToDoCollectionResponse, ToDoCollection>();
        }
        private void ToDoProfile()
        {
            CreateMap<ToDo, ToDoResponse>();
            CreateMap<ToDoResponse, ToDo>();
        }

        private void InnerToDoProfile()
        {
            CreateMap<ToDo, InnerToDoResponse>();
            CreateMap<InnerToDoRequest,ToDo>();
        }


        public MapperProfile()
        {
            ToDoProfile();
            ToDoCollectionProfile();
            InnerToDoProfile();
        }
    }
}
