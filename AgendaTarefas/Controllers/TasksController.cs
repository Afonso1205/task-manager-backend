using AgendaTarefas.Controllers.DTOs;
using AgendaTarefas.Models;
using AgendaTarefas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<TaskItem>> Get([FromQuery] bool? completed, [FromQuery] int? priority)
        {
            return await _service.GetAllTasksAsync(completed, priority);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> Get(string id)
        {
            var task = await _service.GetTaskByIdAsync(id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TaskDto task)
        {
            await _service.CreateTaskAsync(task);
            return CreatedAtAction(nameof(Get), task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, TaskUpdateDto task)
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
    }
}