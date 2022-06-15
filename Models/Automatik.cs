using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class Automatik
    {
        public Automatik()
        {
            IIds = new HashSet<KategorijaA>();
        }

        public int VId { get; set; }

        public virtual Vozilo VIdNavigation { get; set; } = null!;

        public virtual ICollection<KategorijaA> IIds { get; set; }
    }
}
