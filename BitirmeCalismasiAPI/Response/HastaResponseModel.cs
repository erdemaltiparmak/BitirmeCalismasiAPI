using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeCalismasiAPI.Response
{
    public class HastaResponseModel
    {
        public int HastaID { get; set; }
        //public int BileklikID { get; set; }
       // public int PersonelID { get; set; }
        public string HastaAd { get; set; }
        public string HastaSoyad { get; set; }
        public int HastaYas { get; set; }
        public List<BileklikResponseModel> Bileklik { get; set; }
        //public string HastaOyku { get; set; }
        //public string HastaIletisimNo { get; set; }
        //public string HastaAcikAdres { get; set; }
        //public double HastaKonumX { get; set; }
        // public double HastaKonumY { get; set; }
    }
}
