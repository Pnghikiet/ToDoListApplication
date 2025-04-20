using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApplication.DataAccess.Models;
using ToDoListApplication.DataAccess.Models.StaticModels;

namespace ToDoListApplication.DataAccess.Data.SeedData
{
    public static class ToDoItemSeedData
    {
        public static async Task SeedToDoAsync(ToDoContext context)
        {
            if(!context.ToDoItems.Any())
            {
                var todos = new List<ToDoItem>
                {
                    new ToDoItem { Description = "Do homework", IsCleared = false, Priority= Priority.LowPriority},
                    new ToDoItem { Description = "Clean house", IsCleared = false, Priority= Priority.LowPriority},
                    new ToDoItem { Description = "Do Exercise", IsCleared = false, Priority= Priority.LowPriority}
                };

                context.ToDoItems.AddRange(todos);
            }
            await context.SaveChangesAsync();
        }
    }
}
