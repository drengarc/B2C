using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.SistemB2C.Models;
using Prodma.DataAccessB2C;
namespace Prodma.DataAccessB2C
{
    public class ListViewModelListe
    {
        [Tip(listViewModel = false, griddeGorunmesin = true)]
        public int ID { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = false)]
        public string GRUP_SECIM { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = true)]
        public string LISTE_TIP { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = false)]
        public string GRUP_SECIM1 { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = false)]
        public string GRUP_SECIM2 { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = true)]
        public DateTime? GRUP_SECIM_TARIH { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = true)]
        public string GRUP_SECIM_DETAY_GOSTER { get; set; }
        [Tip(listViewModel = false,griddeGorunmesin=true)]
        public int LK_DURUM_ID { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = true)]
        public int LISTE_SIRAtemp { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = true)]
        public string KULLANICI_KODtemp { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = false)]
        public string GRUP_SECIM_KOD_1 { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = false)]
        public string GRUP_SECIM_AD_1 { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = false)]
        public string GRUP_SECIM_KOD_2 { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = false)]
        public string GRUP_SECIM_AD_2 { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = true)]
        public string KODtemp { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = true)]
        public string ADtemp { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = true)]
        public string KODADtemp { get; set; }
        [Tip(listViewModel = false, griddeGorunmesin = true)]
        public int? PERSONEL_IDtemp { get; set; }
    }
  
}
