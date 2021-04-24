using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeCalismasiAPI.Models
{
    public class Personel
    {
        public int PersonelID { get; set; }
        public string PersonelAd { get; set; }
        public string PersonelSoyad { get; set; }
        public string PersonelMail { get; set; }
        public string PersonelSifre { get; set; }
        public List<Hasta> PersonelHastalar { get; set; }
    }


}
