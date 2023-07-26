using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOS;
using ToDoList.Application.Services.Interfaces;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ToDoDTO toDoDTO)
        {
            var result = await _toDoService.CreateAsync(toDoDTO);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await _toDoService.GetAllAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        [Route("id")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _toDoService.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _toDoService.DeleteAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ToDoDTO toDoDTO)
        {
            var result = await _toDoService.UpdateAsync(toDoDTO);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}