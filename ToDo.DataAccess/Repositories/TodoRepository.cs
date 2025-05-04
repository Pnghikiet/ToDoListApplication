using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApplication.Business.Services.Interface;
using ToDoListApplication.DataAccess.Data;
using ToDoListApplication.DataAccess.Models;
using ToDoListApplication.DataAccess.Parammeters;

namespace ToDoListApplication.DataAccess.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ToDoContext _db;

        public TodoRepository(ToDoContext db)
        {
            _db = db;
        }

        public async Task<ToDoItem> CreateAsync(ToDoItem todoItem)
        {
            _db.ToDoItems.Add(todoItem);
            await _db.SaveChangesAsync();

            return todoItem;
        }

        public async Task DeleteAsync(int id)
        {
            var todoToDelete = await _db.ToDoItems.FindAsync(id);

            if(todoToDelete == null) 
                throw new KeyNotFoundException($"The Todo wih {id} is not found");

            _db.ToDoItems.Remove(todoToDelete);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ToDoItem>> GetAllAsync(Params? param = null)
        {
            if (param == null)
                return await _db.ToDoItems.ToListAsync();
            var query = _db.ToDoItems.AsQueryable();

            var result  = await query.Skip((param.PageIndex - 1) * param.PageSize).Take(param.PageSize).ToListAsync();

            return result;
        }

        public async Task<int> CountItemAsync()
        {
            return await _db.ToDoItems.CountAsync();
        }

        public async Task<ToDoItem> UpdateAsync(ToDoItem todoItem)
        {
            _db.ToDoItems.Update(todoItem);

            await _db.SaveChangesAsync();

            return todoItem;
        }
    }
}
