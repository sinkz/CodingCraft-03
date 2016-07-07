using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingCraft_03.Domain.Models
{
    public class Curso
    {
        [Key]
        public Guid CursoId { get; set; }
        public string NomeCurso { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public bool AcessoLivre { get; set; }

        public virtual ICollection<SolicitacaoCurso> Solicitacoes { get; set; }
        public virtual ICollection<StatusCurso> StatusCursos { get; set; }

    }
}
