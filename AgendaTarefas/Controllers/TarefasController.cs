using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using AgendaTarefas.Models;
using System.Collections.Generic;

namespace AgendaTarefas.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasApiController : ControllerBase
    {
        private readonly IMongoCollection<Tarefa> _tarefas;

        public TarefasApiController(MongoContext context)
        {
            _tarefas = context.Tarefas;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tarefa>> Get()
        {
            var tarefas = _tarefas.Find(t => true).ToList();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public ActionResult<Tarefa> Get(string id)
        {
            var tarefa = _tarefas.Find(t => t.TarefaId == id).FirstOrDefault();
            if (tarefa == null) return NotFound();
            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarefa tarefa)
        {
            _tarefas.InsertOne(tarefa);
            return CreatedAtAction(nameof(Get), new { id = tarefa.TarefaId }, tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tarefa tarefaEditada)
        {
            var result = _tarefas.ReplaceOne(t => t.TarefaId == id, tarefaEditada);
            if (result.MatchedCount == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = _tarefas.DeleteOne(t => t.TarefaId == id);
            if (result.DeletedCount == 0) return NotFound();
            return NoContent();
        }
    }
}
