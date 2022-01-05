using System;
using System.Collections.Generic;

namespace GameMarktDBF2.DAL.Models
{
    public partial class Musteri
    {
        public int MusteriId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string EmailId { get; set; }
        public int? RolId { get; set; }
        public string Password { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
