using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class Instruktor
    {
        public int RaId { get; set; }

        public virtual Radnik Ra { get; set; } = null!;
    }
}
