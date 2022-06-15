using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class Klijent
    {
        public int KId { get; set; }
        public string KIme { get; set; } = null!;
        public string KPrezime { get; set; } = null!;
        public int? ToId { get; set; }
        public int? IId { get; set; }

        public virtual Ispit? IIdNavigation { get; set; }
        public virtual TeorijskaObuka? To { get; set; }
    }
}
