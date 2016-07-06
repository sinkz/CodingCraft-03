using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingCraft_03.Domain.Models
{
    public class Solicitacao
    {
        public Guid SolicitacaoID { get; set; }
        public DateTime DataCriacao { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
        public virtual ICollection<SolicitacaoCurso> SolicitacaoCursos { get; set; }
    }
}
