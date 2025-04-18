using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApplication.DataAccess.Data;
using ToDoListApplication.DataAccess.Models;

namespace ToDoListApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly ToDoContext _db;

        public ToDosController(ToDoContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItem>>> GetAllItem()
        {
            var todos = await _db.ToDoItems.ToListAsync();

            return Ok(todos);
        }


        [HttpPost]
        public async Task<ActionResult<ToDoItem>> CreateToDo(ToDoItem todo)
        {
            var todoToCreate = todo;

            _db.ToDoItems.Add(todoToCreate);
            await _db.SaveChangesAsync();

            return Ok(todoToCreate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDoItem>> DeleteTodo(int id)
        {
            var todo = await _db.ToDoItems.FindAsync(id);

            if (todo == null)
                return NotFound();

            _db.ToDoItems.Remove(todo);
            await _db.SaveChangesAsync();

            return Ok("Delete Complete");
        }
    }
}
