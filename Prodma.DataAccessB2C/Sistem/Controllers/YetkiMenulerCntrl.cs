using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.SistemB2C.Models;
using Prodma.SistemB2C.Services;
using Prodma.DataAccessB2C;
using System.Windows.Forms;

namespace Prodma.SistemB2C.Controllers
{
    public class YetkiMenulerCntrl : BaseCtrl<YetkiMenulerVm, int>
    {
        YetkiMenulerService Service = new YetkiMenulerService();
        public override List<YetkiMenulerVm> doListe_Al(YetkiMenulerVm entity)
        {

            return Service.Service_Liste_Al(entity);  
             
        }         
         public override void doEkle(YetkiMenulerVm entity)
        {
                YETKI ekle = new YETKI();
                ekle.KULLANICI_ID = entity.KULLANICI_ID;
                ekle.M_MENU_ID = entity.M_MENU_ID;
                ekle.OKU_E_H = entity.OKU_E_H;
                ekle.YAZ_E_H = entity.YAZ_E_H;
                ekle.GUNCELLE_E_H = entity.GUNCELLE_E_H;
                ekle.SIL_E_H = entity.SIL_E_H;
                ekle.GORMESIN_E_H = entity.GORMESIN_E_H;
                ekle.LK_DURUM_ID = entity.LK_DURUM_ID==0 ? (int)DurumEn.Aktif : entity.LK_DURUM_ID;   
                entity.tabloAdi = "Yetki Menuler";
                entity.ayrimAlan = "AD:" + entity.KULLANICI_ID; 
                Service.Service_Ekle(ekle); entity.ID = ekle.ID;

        }
         public override void doGuncelle(YetkiMenulerVm entity, int id)
        {
            YETKI guncelle = new YETKI();
            EntityKey guncelleId = new EntityKey("b2cEntities.YETKI", "ID", entity.ID);
            guncelle.EntityKey = guncelleId;
            guncelle.ID = entity.ID;
            guncelle.KULLANICI_ID = entity.KULLANICI_ID;
            guncelle.M_MENU_ID = entity.M_MENU_ID;
            guncelle.OKU_E_H = entity.OKU_E_H;
            guncelle.YAZ_E_H = entity.YAZ_E_H;
            guncelle.GUNCELLE_E_H = entity.GUNCELLE_E_H;
            guncelle.SIL_E_H = entity.SIL_E_H;
            guncelle.GORMESIN_E_H = entity.GORMESIN_E_H;
            guncelle.LK_DURUM_ID = entity.LK_DURUM_ID;
            entity.tabloAdi = "Yetki Menuler";
            entity.ayrimAlan = "AD:" + entity.KULLANICI_ID;
             Service.Service_Guncelle(guncelle, id);
         
        }
         public override void doSil(int id, YetkiMenulerVm  entity)
        {
            YETKI sil = new YETKI();
            EntityKey silId = new EntityKey("b2cEntities.YETKI", "ID", entity.ID);
            sil.EntityKey = silId;
            sil.ID = entity.ID;
            entity.tabloAdi = "Yetki Menuler";
            entity.ayrimAlan = "AD:" + entity.KULLANICI_ID;
            Service.Service_Sil(sil, id);

        }
        

    }
}
