using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoApp.Core.Models;

namespace TodoApp.Models
{
    public class Todo : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
        
        public bool IsDone { get; set; }
    }
}
