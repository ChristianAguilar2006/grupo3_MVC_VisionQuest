using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VisionQuest.Models
{
    public class Sintezoide
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Nivel de IA")]
        public int NivelIA { get; set; }

        [Required]
        [Display(Name = "Fuente de energía")]
        public string FuenteEnergia { get; set; }
        public virtual ICollection<Recuerdo> Recuerdos { get; set; }
    }
}
