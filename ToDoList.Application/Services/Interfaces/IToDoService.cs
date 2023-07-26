using ToDoList.Application.DTOS;

namespace ToDoList.Application.Services.Interfaces
{
    public interface IToDoService
    {
        Task<ResultService<ToDoDTO>> CreateAsync(ToDoDTO toDoDTO);

        Task<ResultService<ICollection<ToDoDTO>>> GetAllAsync();

        Task<ResultService<ToDoDTO>> GetByIdAsync(int id);

        Task<ResultService> UpdateAsync(ToDoDTO toDoDTO);

        Task<ResultService> DeleteAsync(int id);
    }
}