﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingCraft_03.Domain.Models
{
    public class SolicitacaoCurso
    {
        [Key]
        public Guid SolicitacaoCursoId { get; set; }
        public Guid CursoId { get; set; }
        public Guid SolicitacaoId { get; set; }
        
        public virtual Curso Curso { get; set; }
        public virtual Solicitacao Solicitacao { get; set; }
    }
}
