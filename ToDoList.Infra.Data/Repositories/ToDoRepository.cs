using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories.Interfaces;
using ToDoList.Infra.Data.context;

namespace ToDoList.Infra.Data.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoDbContext _db;

        public async Task<ToDo> CreateAsync(ToDo toDo)
        {
            _db.Add(toDo);
            await _db.SaveChangesAsync();
            return toDo;
        }

        public async Task<ICollection<ToDo>> GetToDosAsync()
        {
            return await _db.ToDos.ToListAsync();
        }

        public async Task<ToDo> GetByIdAsync(int id)
        {
            var toDoById = await _db.ToDos.FirstOrDefaultAsync(x => x.Id == id);
            return toDoById;
        }

        public async Task EditAsync(ToDo toDo)
        {
            _db.Update(toDo);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(ToDo toDo)
        {
            _db.Remove(toDo);
            await _db.SaveChangesAsync();
        }
    }
}