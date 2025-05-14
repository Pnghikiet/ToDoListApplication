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
using ToDoListApplication.Helpers;
using ToDoListApplication.DataAccess.Parammeters;
using Microsoft.AspNetCore.Authorization;
using ToDoListApplication.DataAccess.Specifications;

namespace ToDoListApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ToDosController : ControllerBase
    {
        private readonly ITodoRepository<ToDoItem> _repo;
        private readonly IMapper _mapper;

        public ToDosController(ITodoRepository<ToDoItem> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Pagination<ToDoItemDTO>>>> GetAllItem([FromQuery]Params param)
        {
            var spec = new TodoWithUserIdAndPagination(param);

            var todos = await _repo.GetAllAsync(spec);

            var countspec = new TodoWithFilterForCount(param);

            var total = await _repo.CountItemAsync(countspec);

            var totalPage = (int)Math.Ceiling(total * 1.0/ param.PageSize);

            var todoDto = _mapper.Map<IReadOnlyList<ToDoItem>, List<ToDoItemDTO>>(todos);

            return Ok(new Pagination<ToDoItemDTO>(param.PageSize, param.PageIndex,total,totalPage,todoDto));
        }


        [HttpPost]
        public async Task<ActionResult<ToDoItemDTO>> CreateToDo([FromBody]ToDoItemDTO todo, [FromQuery] string userId)
        {
            var todoToCreate = _mapper.Map<ToDoItemDTO,ToDoItem>(todo);

            var todoCreated = await _repo.CreateAsync(todoToCreate,userId);

            return Ok(_mapper.Map<ToDoItem, ToDoItemDTO>(todoCreated));
        }

        [HttpPut]
        public async Task<ActionResult<ToDoItemDTO>> UpdateToDo(ToDoItemDTO todoDto, [FromQuery] string userId)
        {
            var todoToUpdate = _mapper.Map<ToDoItemDTO, ToDoItem>(todoDto);

            var todoUpdated = await _repo.UpdateAsync(todoToUpdate,userId);

            return Ok(_mapper.Map<ToDoItem,ToDoItemDTO>(todoUpdated));
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

        [HttpPatch]
        public async Task<ActionResult<ToDoItemDTO>> TodoClear(ToDoItemDTO todoDto)
        {
            var todoItemClear = _mapper.Map<ToDoItemDTO, ToDoItem>(todoDto);

            var todoToClear = await _repo.ClearItemAsync(todoItemClear);

            return Ok(_mapper.Map<ToDoItem,ToDoItemDTO>(todoToClear));
        }
    }
}
