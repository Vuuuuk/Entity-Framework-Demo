using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class TeorijskaObuka
    {
        public TeorijskaObuka()
        {
            Klijents = new HashSet<Klijent>();
            Ras = new HashSet<Nastavnik>();
        }

        public int ToId { get; set; }
        public int ToFond { get; set; }
        public int ToBrk { get; set; }

        public virtual ICollection<Klijent> Klijents { get; set; }

        public virtual ICollection<Nastavnik> Ras { get; set; }
    }
}
