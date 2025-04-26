using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDoListApplication.DataAccess.Data;
using ToDoListApplication.DataAccess.Models;
using ToDoListApplication.DTO;

namespace ToDoListApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly ToDoContext _db;
        private readonly IMapper _mapper;

        public ToDosController(ToDoContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItemDTO>>> GetAllItem()
        {
            var todos = await _db.ToDoItems.ToListAsync();

            var todoDto = _mapper.Map<List<ToDoItem>, List<ToDoItemDTO>>(todos);

            return Ok(todoDto);
        }


        [HttpPost]
        public async Task<ActionResult<ToDoItemDTO>> CreateToDo(ToDoItemDTO todo)
        {
            var todoToCreate = _mapper.Map<ToDoItemDTO,ToDoItem>(todo);

            _db.ToDoItems.Add(todoToCreate);
            await _db.SaveChangesAsync();

            return Ok(todoToCreate);
        }

        [HttpPut]
        public async Task<ActionResult<ToDoItemDTO>> UpdateToDo(ToDoItemDTO todoDto)
        {
            var todoToUpdate = _mapper.Map<ToDoItemDTO, ToDoItem>(todoDto);

            _db.ToDoItems.Update(todoToUpdate);
            await _db.SaveChangesAsync();

            return Ok(todoToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            var todo = await _db.ToDoItems.FindAsync(id);

            if (todo == null)
                return NotFound();

            //_db.ToDoItems.Remove(todo);
            //await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
