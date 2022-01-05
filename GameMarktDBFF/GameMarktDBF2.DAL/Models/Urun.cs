using System;
using System.Collections.Generic;

namespace GameMarktDBF2.DAL.Models
{
    public partial class Urun
    {
        public Urun()
        {
            Stok = new HashSet<Stok>();
        }

        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public int? KategoriId { get; set; }
        public int? Miktar { get; set; }
        public decimal? Fiyat { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual ICollection<Stok> Stok { get; set; }

        public string KategoriAdi { get {
                if(Kategori != null)
                return Kategori.KategoriAd;
                else { 
                    return "Kategori yok";
                }
            } }

        
    }
}
