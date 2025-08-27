namespace FrontEnd.Models.DTOs
{
    public class PacienteDTO
    {
        public int Id { get; set; } 
        public int? NroHC { get; set; }
        public string? CodAflp { get; set; }
        public int? IdMutual { get; set; }
        public int? IdMedico { get; set; }
        public string?  Historia { get; set; }

    }
}
