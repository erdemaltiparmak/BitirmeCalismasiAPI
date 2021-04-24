using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeCalismasiAPI.Models
{
    public class Bileklik
    {
        public int BileklikID { get; set; }
        public DateTime TakilmaTarihi{ get; set; }
        public Hasta BileklikHasta { get; set; }
    }
}
