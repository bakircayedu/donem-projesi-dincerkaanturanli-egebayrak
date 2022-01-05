using System;
using System.Collections.Generic;

namespace GameMarktDBF2.DAL.Models
{
    public partial class Kategori
    {
        public Kategori()
        {
            Urun = new HashSet<Urun>();
        }

        public int KategoriId { get; set; }
        public string KategoriAd { get; set; }

        public virtual ICollection<Urun> Urun { get; set; }
    }
}
