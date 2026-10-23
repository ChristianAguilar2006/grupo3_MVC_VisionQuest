using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VisionQuest.Models
{
    [Table("Recuerdos")]
    public class Recuerdo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string TituloRecuerdo { get; set; }

        [Display(Name = "Tipo")]
        public string TipoRecuerdo { get; set; }

        [Display(Name = "Claridad")]
        public int Claridad { get; set; }

        [Display(Name = "Sintezoide")]
        public int SintezoideId { get; set; }

        public virtual Sintezoide Sintezoide { get; set; }
    }
}
