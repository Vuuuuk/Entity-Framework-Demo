using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class Nastavnik
    {
        public Nastavnik()
        {
            Tos = new HashSet<TeorijskaObuka>();
        }

        public int RaId { get; set; }

        public virtual Radnik Ra { get; set; } = null!;

        public virtual ICollection<TeorijskaObuka> Tos { get; set; }
    }
}
