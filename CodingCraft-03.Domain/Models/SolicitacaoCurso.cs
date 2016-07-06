using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingCraft_03.Domain.Models
{
    public class SolicitacaoCurso
    {
        public Guid SolicitacaoCursoID { get; set; }
        public Guid CursoId { get; set; }
        public Guid SolicitacaoId { get; set; }
        public string descricao { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Solicitacao Solicitacao { get; set; }
    }
}
