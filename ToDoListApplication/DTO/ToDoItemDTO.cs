using System.ComponentModel.DataAnnotations;
using ToDoListApplication.DataAccess.Models.StaticModels;

namespace ToDoListApplication.DTO
{
    public class ToDoItemDTO
    {
        public int ID { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsCleared { get; set; }

        public string Priority { get; set; }
    }
}
