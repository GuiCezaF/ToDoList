using AutoMapper;
using ToDoList.Application.DTOS;
using ToDoList.Application.DTOS.Validations;
using ToDoList.Application.Services.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories.Interfaces;

namespace ToDoList.Application.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IMapper _mapper;

        public ToDoService(IToDoRepository toDoRepository, IMapper mapper)
        {
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ToDoDTO>> CreateAsync(ToDoDTO toDoDTO)
        {
            if (toDoDTO == null)
            {
                return ResultService.Fail<ToDoDTO>("Objeto deve ser informado");
            }

            var result = new ToDoDTOValidator().Validate(toDoDTO);
            if (!result.IsValid)
            {
                return ResultService.RequestError<ToDoDTO>("Problemas de validação", result);
            }

            var toDo = _mapper.Map<ToDo>(toDoDTO);
            var data = await _toDoRepository.CreateAsync(toDo);

            return ResultService.Ok(_mapper.Map<ToDoDTO>(data));
        }

        public async Task<ResultService<ICollection<ToDoDTO>>> GetAllAsync()
        {
            var toDos = await _toDoRepository.GetToDosAsync();
            return ResultService.Ok(_mapper.Map<ICollection<ToDoDTO>>(toDos));
        }

        public async Task<ResultService<ToDoDTO>> GetByIdAsync(int id)
        {
            var toDo = await _toDoRepository.GetByIdAsync(id);
            if (toDo == null)
            {
                return ResultService.Fail<ToDoDTO>("Tarefa não encontrada");
            }

            return ResultService.Ok(_mapper.Map<ToDoDTO>(toDo));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var toDo = await _toDoRepository.GetByIdAsync(id);
            if (toDo == null)
            {
                return ResultService.Fail<ToDoDTO>("Tarefa não encontrada");
            }

            await _toDoRepository.DeleteAsync(toDo);
            return ResultService.Ok($"A tarefa {toDo.Name} de id: {id} foi deletado com sucesso");
        }

        public async Task<ResultService> UpdateAsync(ToDoDTO toDoDTO)
        {
            if (toDoDTO == null)
            {
                return ResultService.Fail("Objeto deve ser informado");
            }

            var validation = new ToDoDTOValidator().Validate(toDoDTO);
            if (!validation.IsValid)
            {
                return ResultService.RequestError("Problemas de validação", validation);
            }

            var toDo = await _toDoRepository.GetByIdAsync(toDoDTO.Id);
            if (toDo == null)
            {
                return ResultService.Fail<ToDoDTO>("Tarefa não encontrada");
            }

            toDo = _mapper.Map<ToDoDTO, ToDo>(toDoDTO, toDo);
            await _toDoRepository.EditAsync(toDo);
            return ResultService.Ok("A Tarefa foi editada com sucesso");
        }
    }
}