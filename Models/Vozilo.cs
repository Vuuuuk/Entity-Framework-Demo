using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class Vozilo
    {
        public int VId { get; set; }
        public string VProizvodjac { get; set; } = null!;
        public int? VKilometraza { get; set; }
        public string VTip { get; set; } = null!;
        public int? AId { get; set; }
        public int? RaId { get; set; }

        public virtual AutoSkola? AIdNavigation { get; set; }
        public virtual Radnik? Ra { get; set; }
        public virtual Automatik Automatik { get; set; } = null!;
        public virtual Manuelni Manuelni { get; set; } = null!;
    }
}
