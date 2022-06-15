using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class KategorijaB
    {
        public KategorijaB()
        {
            VIds = new HashSet<Manuelni>();
        }

        public int IId { get; set; }

        public virtual Ispit IIdNavigation { get; set; } = null!;

        public virtual ICollection<Manuelni> VIds { get; set; }
    }
}
