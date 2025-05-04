using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApplication.DataAccess.Models;
using ToDoListApplication.DataAccess.Parammeters;

namespace ToDoListApplication.Business.Services.Interface
{
    public interface ITodoRepository
    {
        Task<List<ToDoItem>> GetAllAsync(Params? param = null);
        Task<ToDoItem> CreateAsync(ToDoItem todoItem);
        Task<ToDoItem> UpdateAsync(ToDoItem todoItem);
        Task DeleteAsync(int id);
        Task<int> CountItemAsync();
    }
}
