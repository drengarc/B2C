using System.Collections.Generic;

using Prodma.DataAccessB2C;
namespace Prodma.SistemB2C.Models
{
    public class MenulerVm : IViewModel
    {
        public int? M_MENU_ID { get; set; }
        public int? M_MENU_TIP_ID { get; set; }
        public string AD { get; set; }
        public string URL { get; set; }
        public int HEDEF { get; set; }
        public int? DIL_ID { get; set; }
        public int LK_DURUM_ID { get; set; }
        public int? MENU_SIRA { get; set; }
        public string ASSEMBLY_NAME { get; set; }
        public int? KULLANICI_GORMESIN { get; set; }
        public YetkilerVm YETKILER { get; set; }
        //public UstMenuVm USTMENU { get; set; }
        //public string AD { get; set; }
        //public MenuTipVm TIP { get; set; }
        //public string URL { get; set; }
        //public int HEDEF { get; set; }
        //public int? MENU_SIRA { get; set; }
        //public string ASSEMBLY_NAME { get; set; }
        //public MenuSiraVm Order { get; set; }
        //public DurumVm DURUM { get; set; }
        //public int SubItemCount { get; set; }
        

    }
}
