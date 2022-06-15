using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class Pripadum
    {
        public int PId { get; set; }
        public int AId { get; set; }
        public int RuId { get; set; }

        public virtual AutoSkola AIdNavigation { get; set; } = null!;
        public virtual Rutum Ru { get; set; } = null!;
    }
}
