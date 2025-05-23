using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AgendaTarefas.Models
{
    public class Tarefa
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TarefaId { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caracteres")]
        public string Nome { get; set; }

        public string Data { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [DataType(DataType.Time)]
        public string Horario { get; set; }
    }
}
