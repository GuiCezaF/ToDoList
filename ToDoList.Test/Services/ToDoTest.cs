using AutoMapper;
using Moq;
using ToDoList.Application.DTOS;
using ToDoList.Application.Services;
using ToDoList.Domain.Repositories.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ToDoList.Test.Services
{
    public class ToDoTest
    {
        private ToDoService _toDoService;
        private IMapper _mapper;
        private Mock<IToDoRepository> _toDoRepository;

        public ToDoTest()
        {
            _toDoService = new ToDoService(new Mock<IToDoRepository>().Object,
                new Mock<IMapper>().Object);
        }

        [Fact]
        public async void CreateToDo()
        {
            ToDoDTO toDoDto = new ToDoDTO
            {
                Id = 1,
                Name = "test",
                Description = "test",
                Finished = false
            };
            var data = await _toDoService.CreateAsync(toDoDto);

            Assert.Equal(true, data.IsSuccess);
        }

        [Fact]
        public async void GetAllToDos()
        {
            var getAll = await _toDoService.GetAllAsync();
            Assert.Equal(true, getAll.IsSuccess);

        }
    }
}