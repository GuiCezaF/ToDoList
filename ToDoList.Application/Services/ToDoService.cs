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
                return ResultService.Fail<ToDoDTO>("Objeto deve ser informado");

            var result = new ToDoDTOValidator().Validate(toDoDTO);
            if (!result.IsValid)
                return ResultService.RequestError<ToDoDTO>("Problemas de validação", result);

            var toDo = _mapper.Map<ToDo>(toDoDTO);
            var data = await _toDoRepository.CreateAsync(toDo);

            return ResultService.Ok<ToDoDTO>(_mapper.Map<ToDoDTO>(data));
        }

        public async Task<ResultService<ICollection<ToDoDTO>>> GetAllAsync()
        {
            var toDos = await _toDoRepository.GetToDosAsync();
            return ResultService.Ok(_mapper.Map<ICollection<ToDoDTO>>(toDos));
        }
    }
}