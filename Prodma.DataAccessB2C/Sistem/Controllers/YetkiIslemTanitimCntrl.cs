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
    public class YetkiIslemTanitimCntrl : BaseCtrl<YetkiIslemTanitimVm, int>
    {
        YetkiIslemTanitimService Service = new YetkiIslemTanitimService();
        public override List<YetkiIslemTanitimVm> doListe_Al(YetkiIslemTanitimVm entity)
        {

            return Service.Service_Liste_Al(entity);  
             
        }         
         public override void doEkle(YetkiIslemTanitimVm entity)
        {
            YETKI_ISLEM_TANITIM ekle = new YETKI_ISLEM_TANITIM();
            ekle.YETKI_ISLEM_SAHIBI_TANITIM_ID = entity.YETKI_ISLEM_SAHIBI_TANITIM_ID;
            ekle.KOD = entity.KOD;
            ekle.AD = entity.AD;
            ekle.TAG_NAME = entity.TAG_NAME ;
            ekle.HINT_NAME = entity.HINT_NAME;
            ekle.IMAGE_NAME = entity.IMAGE_NAME;
            ekle.LK_DURUM_ID = (int)DurumEn.Aktif;
            ekle.YETKI_ISLEM_SAHIBI_TIP_ID = entity.YETKI_ISLEM_SAHIBI_TIP_ID;
                entity.tabloAdi = "Yetki Menuler";
                Service.Service_Ekle(ekle); entity.ID = ekle.ID;

        }
         public override void doGuncelle(YetkiIslemTanitimVm entity, int id)
        {
            YETKI_ISLEM_TANITIM guncelle = new YETKI_ISLEM_TANITIM();
            EntityKey guncelleId = new EntityKey("b2cEntities.YETKI_ISLEM_TANITIM", "ID", entity.ID);
            guncelle.EntityKey = guncelleId;
            guncelle.ID = entity.ID;
            guncelle.YETKI_ISLEM_SAHIBI_TANITIM_ID = entity.YETKI_ISLEM_SAHIBI_TANITIM_ID;
            guncelle.KOD = entity.KOD;
            guncelle.AD = entity.AD;
            guncelle.TAG_NAME = entity.TAG_NAME;
            guncelle.HINT_NAME = entity.HINT_NAME;
            guncelle.LK_DURUM_ID = entity.LK_DURUM_ID;
            guncelle.YETKI_ISLEM_SAHIBI_TIP_ID = entity.YETKI_ISLEM_SAHIBI_TIP_ID;
            guncelle.IMAGE_NAME = entity.IMAGE_NAME;
             Service.Service_Guncelle(guncelle, id);
         
        }
         public override void doSil(int id, YetkiIslemTanitimVm  entity)
        {
            YETKI_ISLEM_TANITIM sil = new YETKI_ISLEM_TANITIM();
            EntityKey silId = new EntityKey("b2cEntities.YETKI_ISLEM_TANITIM", "ID", entity.ID);
            sil.EntityKey = silId;
            sil.ID = entity.ID;
            entity.tabloAdi = "Yetki Menuler";
            Service.Service_Sil(sil, id);

        }
        

    }
}
