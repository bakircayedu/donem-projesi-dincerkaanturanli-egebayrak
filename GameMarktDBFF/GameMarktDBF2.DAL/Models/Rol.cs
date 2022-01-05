using System;
using System.Collections.Generic;

namespace GameMarktDBF2.DAL.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Musteri = new HashSet<Musteri>();
        }

        public int RolId { get; set; }
        public string RolAdi { get; set; }

        public virtual ICollection<Musteri> Musteri { get; set; }
    }
}
