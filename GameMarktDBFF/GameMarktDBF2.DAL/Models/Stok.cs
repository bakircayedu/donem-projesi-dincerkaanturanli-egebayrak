using System;
using System.Collections.Generic;

namespace GameMarktDBF2.DAL.Models
{
    public partial class Stok
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public int Miktar { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
