using ToDoList.Application.DTOS;

namespace ToDoList.Application.Services.Interfaces
{
    public interface IToDoService
    {
        Task<ResultService<ToDoDTO>> CreateAsync(ToDoDTO toDoDTO);
    }
}