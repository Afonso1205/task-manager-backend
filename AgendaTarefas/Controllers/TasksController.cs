using Microsoft.AspNetCore.Mvc;
using AgendaTarefas.Models;
using AgendaTarefas.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskItem>> Get() =>
            await _service.GetAllTasksAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> Get(string id)
        {
            var task = await _service.GetTaskByIdAsync(id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TaskItem task)
        {
            await _service.CreateTaskAsync(task);
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, TaskItem task)
        {
            await _service.UpdateTaskAsync(id, task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteTaskAsync(id);
            return NoContent();
        }

        [HttpGet("filter/status/{completed}")]
        public async Task<IEnumerable<TaskItem>> FilterByStatus(bool completed) =>
            await _service.GetByCompletionStatusAsync(completed);

        [HttpGet("filter/priority/{priority}")]
        public async Task<IEnumerable<TaskItem>> FilterByPriority(int priority) =>
            await _service.GetByPriorityAsync(priority);
    }
}