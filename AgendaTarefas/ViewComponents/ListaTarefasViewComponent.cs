using AgendaTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace AgendaTarefas.ViewComponents
{
    public class ListaTarefasViewComponent : ViewComponent
    {
        private readonly IMongoCollection<Tarefa> _tarefas;

        public ListaTarefasViewComponent(MongoContext context)
        {
            _tarefas = context.Tarefas;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var lista = await _tarefas.Find(t => true).ToListAsync();
            return View(lista);
        }
    }
}
