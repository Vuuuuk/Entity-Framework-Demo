using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class Poligon
    {
        public int PId { get; set; }
        public string PAdresa { get; set; } = null!;
        public int PVelicina { get; set; }
        public int AId { get; set; }

        public virtual AutoSkola AIdNavigation { get; set; } = null!;
    }
}
