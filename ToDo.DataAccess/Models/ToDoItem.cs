using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApplication.DataAccess.Models
{
    public class ToDoItem
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public bool IsCleared { get; set; }
    }
}
