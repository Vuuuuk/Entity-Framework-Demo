using System;
using System.Collections.Generic;

namespace IFZA_Auto_Skola.Models
{
    public partial class Ispit
    {
        public Ispit()
        {
            Klijents = new HashSet<Klijent>();
            Rus = new HashSet<Rutum>();
        }

        public int IId { get; set; }
        public int ITrajanje { get; set; }
        public string ITip { get; set; } = null!;

        public virtual KategorijaA KategorijaA { get; set; } = null!;
        public virtual KategorijaB KategorijaB { get; set; } = null!;
        public virtual ICollection<Klijent> Klijents { get; set; }

        public virtual ICollection<Rutum> Rus { get; set; }
    }
}
