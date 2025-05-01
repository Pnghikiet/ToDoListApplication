using System.ComponentModel.DataAnnotations;

namespace ToDoListApplication.Business.DTO
{
    public class ToDoItemDTO
    {
        public int? ID { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsCleared { get; set; }

        [Required]
        public string Priority { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}
