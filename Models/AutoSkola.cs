using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class AutoSkola
    {
        public AutoSkola()
        {
            Poligons = new HashSet<Poligon>();
            Pripada = new HashSet<Pripadum>();
            Radniks = new HashSet<Radnik>();
            Vozilos = new HashSet<Vozilo>();
        }

        public int AId { get; set; }
        public string AIme { get; set; } = null!;
        public string AAdresa { get; set; } = null!;

        public virtual ICollection<Poligon> Poligons { get; set; }
        public virtual ICollection<Pripadum> Pripada { get; set; }
        public virtual ICollection<Radnik> Radniks { get; set; }
        public virtual ICollection<Vozilo> Vozilos { get; set; }
    }
}
