using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class Manuelni
    {
        public Manuelni()
        {
            IIds = new HashSet<KategorijaB>();
        }

        public int VId { get; set; }
        public int VBrb { get; set; }

        public virtual Vozilo VIdNavigation { get; set; } = null!;

        public virtual ICollection<KategorijaB> IIds { get; set; }
    }
}
