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
    public class MesajCntrl : BaseCtrl<MesajVm, int>
    {
        MesajService Service = new MesajService();
        public override List<MesajVm> doListe_Al(MesajVm entity)
        {

            return Service.Service_Liste_Al(entity);  
             
        }
        public override void doEkle(MesajVm entity)
        {
            MESAJ ekle = new MESAJ();
            ekle.MESAJ_TIP_ID = entity.MESAJ_TIP_ID;
            ekle.KIMDEN_KULLANICI_ID = entity.KIMDEN_KULLANICI_ID;
            ekle.KIME_KULLANICI_ID = entity.KIME_KULLANICI_ID;
            ekle.MESAJ1 = entity.MESAJ;
            ekle.MESAJ_2 = entity.MESAJ_2;
            ekle.MESAJ_3 = entity.MESAJ_3;
            ekle.KIME_KULLANICI_ID = entity.KIME_KULLANICI_ID;
            ekle.KIME_KULLANICI_ID = entity.KIME_KULLANICI_ID;
            ekle.KIME_KULLANICI_ID = entity.KIME_KULLANICI_ID;
            ekle.OKUNDU_E_H = entity.OKUNDU_E_H;
                Service.Service_Ekle(ekle); entity.ID = ekle.ID;
                
        }
        public override void doGuncelle(MesajVm entity, int id)
        {
            MESAJ guncelle = new MESAJ();
            EntityKey guncelleId = new EntityKey("b2cEntities.MESAJ", "ID", entity.ID);
            guncelle.EntityKey = guncelleId;
            guncelle.ID = entity.ID;
            guncelle.KIMDEN_KULLANICI_ID = entity.KIMDEN_KULLANICI_ID;
            guncelle.KIME_KULLANICI_ID = entity.KIME_KULLANICI_ID;
            guncelle.MESAJ1 = entity.MESAJ;
            guncelle.MESAJ_2 = entity.MESAJ_2;
            guncelle.MESAJ_3 = entity.MESAJ_3;
            guncelle.KIME_KULLANICI_ID = entity.KIME_KULLANICI_ID;
            guncelle.KIME_KULLANICI_ID = entity.KIME_KULLANICI_ID;
            guncelle.KIME_KULLANICI_ID = entity.KIME_KULLANICI_ID;
            guncelle.OKUNDU_E_H = entity.OKUNDU_E_H;
                Service.Service_Guncelle(guncelle, id);
                
        }

        public override void doSil(int id, MesajVm entity)
        {
            MESAJ sil = new MESAJ();
            EntityKey silId = new EntityKey("b2cEntities.MESAJ", "ID", entity.ID);
            sil.EntityKey = silId;
            sil.ID = entity.ID;      
            Service.Service_Sil(sil, id);
        }
        

    }
}
