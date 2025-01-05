using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class Todos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime DueDate { get; set; } = DateTime.Now;
    }
}
