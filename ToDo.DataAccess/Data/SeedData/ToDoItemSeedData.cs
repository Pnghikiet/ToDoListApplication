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
                    new ToDoItem { Description = "Do homework", IsCleared = false, Priority= Priority.HighPriority, Title = "Homework", DueDate = DateTime.Now.AddDays(3)},
                    new ToDoItem { Description = "Clean house", IsCleared = false, Priority= Priority.MediumPriority, Title = "Housework", DueDate = DateTime.Now.AddDays(4)},
                    new ToDoItem { Description = "Do Exercise", IsCleared = false, Priority= Priority.LowPriority, Title = "Exercise" ,DueDate = DateTime.Now.AddDays(4)},                
                    new ToDoItem { Description = "Play chess", IsCleared = false, Priority= Priority.MediumPriority, Title = "Relax" ,DueDate = DateTime.Now.AddDays(5)},                
                    new ToDoItem { Description = "Reading book", IsCleared = false, Priority= Priority.LowPriority, Title = "Reading book" ,DueDate = DateTime.Now.AddDays(2)},                
                };
                context.ToDoItems.AddRange(todos);
            }
            await context.SaveChangesAsync();
        }
    }
}
