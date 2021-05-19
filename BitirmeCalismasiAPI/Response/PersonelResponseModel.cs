using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeCalismasiAPI.Response
{
    public class PersonelResponseModel
    {
        public int PersonelID { get; set; }
        public string PersonelAd { get; set; }
        public string PersonelSoyad { get; set; }
        public string PersonelMail { get; set; }
        public List<HastaResponseModel> Hastas { get; set; }
    }
}
