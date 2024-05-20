using System.ComponentModel.DataAnnotations;

namespace TodoApp.ViewModels
{
    public class AddTodoModel
    {
        [Required]
        public string? Title { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
