using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApplication.DataAccess.Models;

namespace ToDoListApplication.Business.Services.Interface
{
    public interface ITodoRepository
    {
        Task<List<ToDoItem>> GetAllAsync();
        Task<ToDoItem> CreateAsync(ToDoItem todoItem);
        Task<ToDoItem> UpdateAsync(ToDoItem todoItem);
        Task DeleteAsync(int id);
    }
}
