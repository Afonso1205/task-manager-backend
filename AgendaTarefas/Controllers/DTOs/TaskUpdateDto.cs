using AgendaTarefas.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AgendaTarefas.Controllers.DTOs
{
    public class TaskUpdateDto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public int? Priority { get; set; }

        public bool? IsCompleted { get; set; }
    }
}
