using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.DataAccessB2C;
using System.Windows.Forms;
using Prodma.SistemB2C.Models;
using Prodma.SistemB2C.Services;
namespace Prodma.SistemB2C.Controllers
{
    public class MenulerCntrl : BaseCtrl<MenulerVm, int>
    {
        MenulerService Service = new MenulerService();
        public override List<MenulerVm> doListe_Al(MenulerVm entity)
        {

            return Service.Service_Liste_Al(entity);  
             
        }
        public override void doEkle(MenulerVm entity)
        {

            M_MENU ekle = new M_MENU();
            //ekle.ID = 637;
            ekle.M_MENU_ID = entity.M_MENU_ID;
                ekle.M_MENU_TIP_ID = entity.M_MENU_TIP_ID;
                ekle.AD = entity.AD;
                ekle.URL = entity.URL;
                ekle.HEDEF = entity.HEDEF;
                ekle.DIL_ID = entity.DIL_ID;
                ekle.LK_DURUM_ID = entity.LK_DURUM_ID == 0 ? (int)DurumEn.Aktif : entity.LK_DURUM_ID;

                ekle.MENU_SIRA = entity.MENU_SIRA;
                ekle.ASSEMBLY_NAME = entity.ASSEMBLY_NAME;
                entity.tabloAdi = "MENU";
                entity.ayrimAlan = "AD:" + entity.AD;
                Service.Service_Ekle(ekle); entity.ID = ekle.ID;  
             
        }
        public override void doGuncelle(MenulerVm entity, int id)
        {
            M_MENU guncelle = new M_MENU();
            EntityKey guncelleId = new EntityKey("b2cEntities.M_MENU", "ID", entity.ID);
            guncelle.EntityKey = guncelleId;
            guncelle.ID = entity.ID;
            guncelle.M_MENU_ID = entity.M_MENU_ID;
            guncelle.ID = entity.ID;
            guncelle.M_MENU_TIP_ID = entity.M_MENU_TIP_ID;
                guncelle.AD = entity.AD;
                guncelle.URL = entity.URL;
                guncelle.HEDEF = entity.HEDEF;
                guncelle.DIL_ID = entity.DIL_ID;
                guncelle.LK_DURUM_ID = entity.LK_DURUM_ID;
                guncelle.MENU_SIRA = entity.MENU_SIRA;
                guncelle.ASSEMBLY_NAME = entity.ASSEMBLY_NAME;
                entity.tabloAdi = "MENU";
                entity.ayrimAlan = "AD:" + entity.AD;
                Service.Service_Guncelle(guncelle, id);
             
        }
        public override void doSil(int id, MenulerVm entity)
        {

            M_MENU sil = new M_MENU();
            EntityKey silId = new EntityKey("b2cEntities.M_MENU", "ID", entity.ID);
            sil.EntityKey = silId;
            sil.ID = entity.ID;
            entity.tabloAdi = "MENU";
            entity.ayrimAlan = "AD:" + entity.AD;
            Service.Service_Sil(sil, id);
             
        }
        

    }
}
