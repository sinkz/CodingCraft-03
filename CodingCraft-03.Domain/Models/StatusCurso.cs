using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingCraft_03.Domain.Models
{
    public class StatusCurso
    {
        [Key]
        public Guid StatusCursoId { get; set; }
        public Guid CursoId { get; set; }
        public string Id { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }

        public virtual ApplicationUser Usuario { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
