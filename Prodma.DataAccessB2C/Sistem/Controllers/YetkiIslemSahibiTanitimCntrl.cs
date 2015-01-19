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
    public class YetkiIslemSahibiTanitimCntrl : BaseCtrl<YetkiIslemSahibiTanitimVm, int>
    {
        YetkiIslemSahibiTanitimService Service = new YetkiIslemSahibiTanitimService();
        public override List<YetkiIslemSahibiTanitimVm> doListe_Al(YetkiIslemSahibiTanitimVm entity)
        {

            return Service.Service_Liste_Al(entity);  
             
        }
        public override void doEkle(YetkiIslemSahibiTanitimVm entity)
        {
            YETKI_ISLEM_SAHIBI_TANITIM ekle = new YETKI_ISLEM_SAHIBI_TANITIM();
                ekle.KOD = entity.KOD;
                ekle.AD = entity.AD;
                ekle.YETKI_ISLEM_SAHIBI_TIP_ID = entity.YETKI_ISLEM_SAHIBI_TIP_ID;
                entity.tabloAdi = "Yetki İşlem Sahibi";
                Service.Service_Ekle(ekle); entity.ID = ekle.ID;

        }
         public override void doGuncelle(YetkiIslemSahibiTanitimVm entity, int id)
        {
            YETKI_ISLEM_SAHIBI_TANITIM guncelle = new YETKI_ISLEM_SAHIBI_TANITIM();
            EntityKey guncelleId = new EntityKey("b2cEntities.YETKI_ISLEM_SAHIBI_TANITIM", "ID", entity.ID);
            guncelle.EntityKey = guncelleId;
            guncelle.ID = entity.ID;
            guncelle.KOD = entity.KOD;
            guncelle.AD = entity.AD;
            guncelle.YETKI_ISLEM_SAHIBI_TIP_ID = entity.YETKI_ISLEM_SAHIBI_TIP_ID;
            entity.tabloAdi = "Yetki İşlem Sahibi";
             Service.Service_Guncelle(guncelle, id);
         
        }
         public override void doSil(int id, YetkiIslemSahibiTanitimVm entity)
        {
            YETKI_ISLEM_SAHIBI_TANITIM sil = new YETKI_ISLEM_SAHIBI_TANITIM();
            EntityKey silId = new EntityKey("b2cEntities.YETKI_ISLEM_SAHIBI_TANITIM", "ID", entity.ID);
            sil.EntityKey = silId;
            sil.ID = entity.ID;
            entity.tabloAdi = "Yetki Menuler";
            Service.Service_Sil(sil, id);

        }
        

    }
}
