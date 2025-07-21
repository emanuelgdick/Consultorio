using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ConsultaDiagnostico
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Consulta")]
        public int IdConsulta { get; set; }
        public Consulta? Consulta { get; set; }

        [ForeignKey("Diagnostico")]
        public int IdDiagnostico { get; set; }
        public Diagnostico? Diagnostico { get; set; }
    }
}
