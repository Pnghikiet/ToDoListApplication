using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDoListApplication.DataAccess.Data;
using ToDoListApplication.DataAccess.Models;
using ToDoListApplication.Business.DTO;
using ToDoListApplication.DataAccess.Repositories;
using ToDoListApplication.Business.Services.Interface;

namespace ToDoListApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly ITodoRepository _repo;
        private readonly IMapper _mapper;

        public ToDosController(ITodoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ToDoItemDTO>>> GetAllItem()
        {
            var todos = await _repo.GetAllAsync();

            var todoDto = _mapper.Map<List<ToDoItem>, List<ToDoItemDTO>>(todos);

            return Ok(todoDto);
        }


        [HttpPost]
        public async Task<ActionResult<ToDoItemDTO>> CreateToDo(ToDoItemDTO todo)
        {
            var todoToCreate = _mapper.Map<ToDoItemDTO,ToDoItem>(todo);

            var todoCreated = await _repo.CreateAsync(todoToCreate);

            return Ok(todoCreated);
        }

        [HttpPut]
        public async Task<ActionResult<ToDoItemDTO>> UpdateToDo(ToDoItemDTO todoDto)
        {
            try
            {
                var todoToUpdate = _mapper.Map<ToDoItemDTO, ToDoItem>(todoDto);

                var todoUpdated = _repo.UpdateAsync(todoToUpdate);

                return Ok(todoUpdated);
            }
            catch(Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            try
            {
                await _repo.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new {message = ex.Message});
            }
        }
    }
}
