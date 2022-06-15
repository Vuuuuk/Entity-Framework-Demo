using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class Radnik
    {
        public Radnik()
        {
            Vozilos = new HashSet<Vozilo>();
        }

        public int RaId { get; set; }
        public string RaIme { get; set; } = null!;
        public string RaPrezime { get; set; } = null!;
        public int RaPlata { get; set; }
        public string RaTip { get; set; } = null!;
        public int? AId { get; set; }

        public virtual AutoSkola? AIdNavigation { get; set; }
        public virtual Instruktor Instruktor { get; set; } = null!;
        public virtual Nastavnik Nastavnik { get; set; } = null!;
        public virtual ICollection<Vozilo> Vozilos { get; set; }
    }
}
