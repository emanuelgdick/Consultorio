using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Api.Models
{
    [DataContract(IsReference = true)]
    public class Diagnostico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public virtual ICollection<ConsultaDiagnostico> Consultas { get; set; }
        
    }
}
