using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Data.Entities;
using ToDoApi.Resource.CategoriesResource;
using ToDoApi.Resources.TasksResource;

namespace ToDoApi.Infrasturcture.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categories, CategoriesResource>();

            CreateMap<Tasks, TasksResource>();
        }
    }
}
