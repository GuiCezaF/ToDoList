using AutoMapper;
using ToDoList.Application.DTOS;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mapping
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<ToDoDTO, ToDo>();
        }
    }
}