using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class Rutum
    {
        public Rutum()
        {
            Pripada = new HashSet<Pripadum>();
            IIds = new HashSet<Ispit>();
        }

        public int RuId { get; set; }
        public int RuKilometraza { get; set; }

        public virtual ICollection<Pripadum> Pripada { get; set; }

        public virtual ICollection<Ispit> IIds { get; set; }
    }
}
