using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApplication.DataAccess.Models.StaticModels;

namespace ToDoListApplication.DataAccess.Models
{
    public class ToDoItem
    {
        public ToDoItem()
        {
        }

        public ToDoItem(string description)
        {
            Description = description;
        }

        public int ID { get; set; }

        public string Description { get; set; }

        public bool IsCleared { get; set; } = false;

        public Priority Priority { get; set; } = Priority.Low;
    }
}
