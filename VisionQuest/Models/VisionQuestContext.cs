using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VisionQuest.Models
{
    public class VisionQuestContext : DbContext
    {
        public VisionQuestContext() : base("name=VisionQuestContext") { }
        public DbSet<Sintezoide> Sintezoides { get; set; }

        public DbSet<Recuerdo> Recuerdos { get; set; }

    }
}