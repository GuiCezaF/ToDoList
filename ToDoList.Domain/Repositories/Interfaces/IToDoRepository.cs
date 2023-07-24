using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Repositories.Interfaces
{
    public interface IToDoRepository
    {
        Task<ToDo> GetByIdAsync(int id);

        Task<ICollection<ToDo>> GetToDosAsync();

        Task<ToDo> CreateAsync(ToDo toDo);

        Task EditAsync(ToDo toDo);

        Task DeleteAsync(ToDo toDo);
    }
}