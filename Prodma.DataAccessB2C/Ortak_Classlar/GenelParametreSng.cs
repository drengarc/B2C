using System.Collections.Generic;
using Prodma.DataAccessB2C;
using Prodma.SistemB2C.Models;
namespace Prodma.DataAccessB2C
{
    public class GenelParametreSng 

    {
        
        private static GenelParametreSng nesne = new GenelParametreSng();

        private GenelParametreSng() 
        {

        }

        public static GenelParametreSng Nesne()
        { 
          return nesne; 
        }
        public KontrolVm donusDegerleri { get; set; }
        public KullaniciVm kullaniciBilgileri { get; set; }
        public KullaniciYetkileriVm kullaniciYetkileri { get; set; }
        public FirmaParametreVm firmaBilgileri { get; set; }
        public List<YetkiMenulerVm> kullaniciMenuYetkiBilgileri { get; set; }
        public bool blnFormAcma { get; set; }
    }
}
