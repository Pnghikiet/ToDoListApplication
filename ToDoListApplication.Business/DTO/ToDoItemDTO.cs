using System.ComponentModel.DataAnnotations;

namespace ToDoListApplication.Business.DTO
{
    public class ToDoItemDTO
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsCleared { get; set; }

        [Required]
        public string Priority { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime DueDate { get; set; }
    }
}
