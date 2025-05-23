using AgendaTarefas.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AgendaTarefas.Controllers.DTOs
{
    public class TaskDto
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [StringLength(200, ErrorMessage = "Description must be 200 characters or fewer.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Priority is required.")]
        [EnumDataType(typeof(PriorityLevel), ErrorMessage = "Priority must be a valid value (Low, Medium, High).")]
        public PriorityLevel Priority { get; set; }
    }
}
