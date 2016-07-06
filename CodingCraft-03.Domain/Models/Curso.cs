using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingCraft_03.Domain.Models
{
    public class Curso
    {
        public Guid CursoId { get; set; }
        public string curso { get; set; }
        public string descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal Preco { get; set; }
        public bool acessoLivre { get; set; }

        public List<StatusCurso> StatusCursos { get; set; }

    }
}
