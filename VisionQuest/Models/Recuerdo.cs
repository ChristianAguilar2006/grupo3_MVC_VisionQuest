using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VisionQuest.Models
{
    public class Recuerdo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TituloRecuerdo { get; set; }

       
        public string TipoRecuerdo { get; set; }

        
        public int Claridad { get; set; }

        public int SintezoideId { get; set; }

        public virtual Sintezoide Sintezoide { get; set; }
    }
}
