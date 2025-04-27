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
        public int ID { get; set; }

        public string Description { get; set; }

        public Boolean IsCleared { get; set; }

        public string Priority { get; set; }

        public string Title {  get; set; }

        public DateTime DueDate { get; set; }
    }
}
