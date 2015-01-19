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
    public class YetkiIslemlerCntrl : BaseCtrl<YetkiIslemlerVm, int>
    {
        YetkiIslemlerService Service = new YetkiIslemlerService();
        public override List<YetkiIslemlerVm> doListe_Al(YetkiIslemlerVm entity)
        {

            return Service.Service_Liste_Al(entity);  
             
        }         
         public override void doEkle(YetkiIslemlerVm entity)
        {
                YETKI_ISLEMLER ekle = new YETKI_ISLEMLER();
                ekle.KULLANICI_ID = entity.KULLANICI_ID;
                ekle.YETKI_ISLEM_TANTIM_ID = entity.YETKI_ISLEM_TANTIM_ID;
                ekle.YETKILI_E_H = entity.YETKILI_E_H;
                ekle.SINIRLI_YETKI_E_H = entity.SINIRLI_YETKI_E_H;
                Service.Service_Ekle(ekle); entity.ID = ekle.ID;

        }
         public override void doGuncelle(YetkiIslemlerVm entity, int id)
        {
            YETKI_ISLEMLER guncelle = new YETKI_ISLEMLER();
            EntityKey guncelleId = new EntityKey("b2cEntities.YETKI_ISLEMLER", "ID", entity.ID);
            guncelle.EntityKey = guncelleId;
            guncelle.ID = entity.ID;
            guncelle.KULLANICI_ID = entity.KULLANICI_ID;
            guncelle.YETKI_ISLEM_TANTIM_ID = entity.YETKI_ISLEM_TANTIM_ID;
            guncelle.YETKILI_E_H = entity.YETKILI_E_H;
            guncelle.SINIRLI_YETKI_E_H = entity.SINIRLI_YETKI_E_H;
            Service.Service_Guncelle(guncelle, id);
         
        }
         public override void doSil(int id, YetkiIslemlerVm  entity)
        {
            YETKI_ISLEMLER sil = new YETKI_ISLEMLER();
            EntityKey silId = new EntityKey("b2cEntities.YETKI_ISLEMLER", "ID", entity.ID);
            sil.EntityKey = silId;
            sil.ID = entity.ID;
            entity.tabloAdi = "Yetki Menuler";
            entity.ayrimAlan = "AD:" + entity.KULLANICI_ID;
            Service.Service_Sil(sil, id);

        }
        public void KullaniciIslemlerKopyala(int kaynakId,int kullaniciId)
        {
            YetkiIslemlerVm vm = new YetkiIslemlerVm();
            vm.KULLANICI_ID = kaynakId;
            List<YetkiIslemlerVm> entityList = doListe_Al(vm);
            foreach (var item in entityList)
            {
                vm.KULLANICI_ID = kullaniciId;
                vm.YETKI_ISLEM_TANTIM_ID = item.YETKI_ISLEM_TANTIM_ID;
                vm.YETKILI_E_H = item.YETKILI_E_H;
                doEkle(vm);
            }

        }

        

    }
}
