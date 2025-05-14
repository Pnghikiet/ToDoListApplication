using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApplication.DataAccess.Models;
using ToDoListApplication.DataAccess.Parammeters;
using ToDoListApplication.DataAccess.Specifications;

namespace ToDoListApplication.Business.Services.Interface
{
    public interface ITodoRepository<T>
    {
        Task<IReadOnlyList<T>> GetAllAsync(Ispecification<T> spec);
        Task<ToDoItem> CreateAsync(ToDoItem todoItem,string userId);
        Task<ToDoItem> UpdateAsync(ToDoItem todoItem,string userId);
        Task DeleteAsync(int id);
        Task<int> CountItemAsync(Ispecification<T> spec);
        Task<ToDoItem> ClearItemAsync(ToDoItem todoItem);
    }
}
