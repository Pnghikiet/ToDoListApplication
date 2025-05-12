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
                    new ToDoItem { Description = "Do homework", IsCleared = false, Priority= Priority.HighPriority, Title = "Homework", DueDate = DateTime.Now.AddDays(3), UserId = "101af0c8-7bd7-4918-a3e9-362659550411"},
                    new ToDoItem { Description = "Clean house", IsCleared = false, Priority= Priority.MediumPriority, Title = "Housework", DueDate = DateTime.Now.AddDays(4), UserId = "101af0c8-7bd7-4918-a3e9-362659550411"},
                    new ToDoItem { Description = "Do Exercise", IsCleared = false, Priority= Priority.LowPriority, Title = "Exercise" ,DueDate = DateTime.Now.AddDays(4), UserId = "40ce2ee5-65ed-456b-94df-434801365be7"},                
                    new ToDoItem { Description = "Play chess", IsCleared = false, Priority= Priority.MediumPriority, Title = "Relax" ,DueDate = DateTime.Now.AddDays(5), UserId = "40ce2ee5-65ed-456b-94df-434801365be7"},                
                    new ToDoItem { Description = "Reading book", IsCleared = false, Priority= Priority.LowPriority, Title = "Reading book" ,DueDate = DateTime.Now.AddDays(2), UserId = "101af0c8-7bd7-4918-a3e9-362659550411"},                
                };
                context.ToDoItems.AddRange(todos);
            }
            await context.SaveChangesAsync();
        }
    }
}
