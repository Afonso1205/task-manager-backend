using AgendaTarefas.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AgendaTarefas.Controllers.DTOs
{
    public class TaskUpdateDto
    {
        [StringLength(100, ErrorMessage = "Title must be at most 100 characters.")]
        public string? Title { get; set; }

        [StringLength(200, ErrorMessage = "Description must be at most 200 characters.")]
        public string? Description { get; set; }

        [Range(1, 3, ErrorMessage = "Priority must be 1 (Low), 2 (Medium), or 3 (High).")]
        public int? Priority { get; set; }

        public bool? IsCompleted { get; set; }
    }
}
