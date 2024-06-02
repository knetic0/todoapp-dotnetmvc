using System.ComponentModel.DataAnnotations;

namespace TodoApp.ViewModels
{
    public class AddTodoModel
    {
        [Required(ErrorMessage = "Title is required!")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Title must be between 5 and 100 characters.")]
        public string? Title { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
