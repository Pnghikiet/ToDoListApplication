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
        public async Task<ActionResult<IReadOnlyList<ToDoItemDTO>>> GetAllItem([FromQuery]Params param)
        {
            Debug.WriteLine($"Page index is : {param.PageIndex}, Page size is: {param.PageSize}");


            var todos = await _repo.GetAllAsync(param);

            var total = await _repo.CountItemAsync();

            var totalPage = (int)Math.Ceiling(total * 1.0/ param.PageSize);

            var todoDto = _mapper.Map<List<ToDoItem>, List<ToDoItemDTO>>(todos);

            return Ok(new Pagination<ToDoItemDTO>(param.PageSize, param.PageIndex,total,totalPage,todoDto));
        }


        [HttpPost]
        public async Task<ActionResult<ToDoItemDTO>> CreateToDo(ToDoItemDTO todo)
        {
            var todoToCreate = _mapper.Map<ToDoItemDTO,ToDoItem>(todo);

            var todoCreated = await _repo.CreateAsync(todoToCreate);

            return Ok(_mapper.Map<ToDoItem, ToDoItemDTO>(todoCreated));
        }

        [HttpPut]
        public async Task<ActionResult<ToDoItemDTO>> UpdateToDo(ToDoItemDTO todoDto)
        {
            var todoToUpdate = _mapper.Map<ToDoItemDTO, ToDoItem>(todoDto);

            var todoUpdated = await _repo.UpdateAsync(todoToUpdate);

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
    }
}
