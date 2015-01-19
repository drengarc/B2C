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
    public class YetkiAlanlarCntrl : BaseCtrl<YetkiAlanlarVm, int>
    {
        YetkiAlanlarService Service = new YetkiAlanlarService();
        public override List<YetkiAlanlarVm> doListe_Al(YetkiAlanlarVm entity)
        {

            return Service.Service_Liste_Al(entity);  
             
        }         
         public override void doEkle(YetkiAlanlarVm entity)
        {
                YETKI_ALANLAR ekle = new YETKI_ALANLAR();
                   
                ekle.KULLANICI_ID = entity.KULLANICI_ID;
                ekle.M_ALANLAR_ID = entity.M_ALANLAR_ID;
                ekle.M_ALANLAR_ALT_ID = entity.M_ALANLAR_ALT_ID;
                ekle.GORMESIN_E_H  = entity.GORMESIN_E_H;
                ekle.YAZMASIN_E_H  = entity.YAZMASIN_E_H;
                ekle.LK_DURUM_ID = entity.LK_DURUM_ID==0 ? (int) DurumEn.Aktif : entity.LK_DURUM_ID;
               
                entity.tabloAdi = "Yetki Alanlar";
                entity.ayrimAlan = "AD:" + entity.KULLANICI_ID;
                Service.Service_Ekle(ekle); entity.ID = ekle.ID;

        }
         public override void doGuncelle(YetkiAlanlarVm entity, int id)
        {
            YETKI_ALANLAR guncelle = new YETKI_ALANLAR();
            EntityKey guncelleId = new EntityKey("b2cEntities.YETKI_ALANLAR", "ID", entity.ID);
            guncelle.EntityKey = guncelleId;
            guncelle.ID = entity.ID;
            guncelle.KULLANICI_ID = entity.KULLANICI_ID;
            guncelle.M_ALANLAR_ID = entity.M_ALANLAR_ID;
            guncelle.M_ALANLAR_ALT_ID = entity.M_ALANLAR_ALT_ID;
            guncelle.GORMESIN_E_H  = entity.GORMESIN_E_H;
            guncelle.YAZMASIN_E_H  = entity.YAZMASIN_E_H;
            guncelle.LK_DURUM_ID = entity.LK_DURUM_ID;
         
            entity.tabloAdi = "Yetki Alanlar";
            entity.ayrimAlan = "AD:" + entity.KULLANICI_ID;
            Service.Service_Guncelle(guncelle, id);

        }
         public override void doSil(int id, YetkiAlanlarVm  entity)
        {

            YETKI_ALANLAR sil = new YETKI_ALANLAR();
            EntityKey silId = new EntityKey("b2cEntities.YETKI_ALANLAR", "ID", entity.ID);
            sil.EntityKey = silId;
            sil.ID = entity.ID;
            entity.tabloAdi = "Yetki Alanlar";
            entity.ayrimAlan = "AD:" + entity.KULLANICI_ID;
            Service.Service_Sil(sil, id);
        }
        

    }
}
