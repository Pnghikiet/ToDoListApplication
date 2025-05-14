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
using ToDoListApplication.DataAccess.Specifications;

namespace ToDoListApplication.DataAccess.Repositories
{
    public class TodoRepository<T> : ITodoRepository<T> where T : class
    {
        private readonly ToDoContext _db;

        public TodoRepository(ToDoContext db)
        {
            _db = db;
        }

        public async Task<ToDoItem> CreateAsync(ToDoItem todoItem,string userId)
        {
            todoItem.UserId = userId;
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

        public async Task<IReadOnlyList<T>> GetAllAsync(Ispecification<T> spec)
        {
            return await SpecificationEveluator<T>.GetQuery(_db.Set<T>().AsQueryable(), spec).ToListAsync();
        }

        public async Task<int> CountItemAsync(Ispecification<T> spec)
        {
            return await SpecificationEveluator<T>.GetQuery(_db.Set<T>().AsQueryable(), spec).CountAsync();
        }

        public async Task<ToDoItem> UpdateAsync(ToDoItem todoItem, string userId)
        {
            todoItem.UserId = userId;


            _db.ToDoItems.Update(todoItem);

            await _db.SaveChangesAsync();

            return todoItem;
        }

        public async Task<ToDoItem> ClearItemAsync(ToDoItem todoItem)
        {
            todoItem.IsCleared = true;

            _db.Update(todoItem);
            await _db.SaveChangesAsync();

            return todoItem;
        }
    }
}
