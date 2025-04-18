using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApplication.DataAccess.Data;

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

    }
}
