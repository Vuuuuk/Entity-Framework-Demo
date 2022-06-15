using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class KategorijaA
    {
        public KategorijaA()
        {
            VIds = new HashSet<Automatik>();
        }

        public int IId { get; set; }

        public virtual Ispit IIdNavigation { get; set; } = null!;

        public virtual ICollection<Automatik> VIds { get; set; }
    }
}
