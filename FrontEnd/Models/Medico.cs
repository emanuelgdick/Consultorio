﻿
using System.ComponentModel.DataAnnotations;
namespace FrontEnd.Models
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApeyNom { get; set; }
        public bool TieneAgenda { get; set; }
    }
}
