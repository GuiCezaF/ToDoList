using AutoMapper;
using ToDoList.Application.DTOS;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mapping
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<ToDo, ToDoDTO>();
        }
    }
}