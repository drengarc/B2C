using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.Sistem.Models;
using Prodma.Sistem.Services;
using Prodma.DataAccessB2C;
using System.Windows.Forms;  
namespace Prodma.Sistem.Controllers
{
    public class FiltrelerCntrl : BaseCtrl<FiltrelerVm, int>
    {
        FiltrelerService Service = new FiltrelerService();
        public override List<FiltrelerVm> doListe_Al(FiltrelerVm entity){
            return Service.Service_Liste_Al(entity);  
        }
        public override void doEkle(FiltrelerVm entity)
        {
                FILTRELER ekle = new FILTRELER();
                ekle.KULLANICI_ID = entity.KULLANICI_ID;
                ekle.FORM_ADI = entity.FORM_ADI;
                ekle.RAPOR_ADI = entity.RAPOR_ADI;
                ekle.DEGER_ALANI = entity.DEGER_ALANI;
                ekle.LK_DURUM_ID = entity.LK_DURUM_ID == 0 ? (int)DurumEn.Aktif : entity.LK_DURUM_ID;
                ekle.FILTRE_OLUSTURAN_KULLANICI_ID = entity.FILTRE_OLUSTURAN_KULLANICI_ID == 0 ? Globals.gnKullaniciId : entity.FILTRE_OLUSTURAN_KULLANICI_ID;
                ekle.FILTRE_TIP_ID = entity.FILTRE_TIP_ID == 0 ? 1 : entity.FILTRE_TIP_ID;
                entity.tabloAdi = "İç Dış";
                entity.ayrimAlan = "AD:" + entity.FORM_ADI;
                Service.Service_Ekle(ekle); entity.ID = ekle.ID;  
            
        }
        public override void doGuncelle(FiltrelerVm entity, int id)
        {
            FILTRELER guncelle = new FILTRELER();
            EntityKey guncelleId = new EntityKey("ProdmaEntities.FILTRELER", "ID", entity.ID);
            guncelle.EntityKey = guncelleId;
            guncelle.ID = entity.ID;
            guncelle.KULLANICI_ID = entity.KULLANICI_ID;
            guncelle.FORM_ADI = entity.FORM_ADI;
            guncelle.RAPOR_ADI = entity.RAPOR_ADI;
            guncelle.DEGER_ALANI = entity.DEGER_ALANI;
            guncelle.LK_DURUM_ID = entity.LK_DURUM_ID == 0 ? (int)DurumEn.Aktif : entity.LK_DURUM_ID;
            guncelle.FILTRE_OLUSTURAN_KULLANICI_ID = entity.FILTRE_OLUSTURAN_KULLANICI_ID == 0 ? Globals.gnKullaniciId : entity.FILTRE_OLUSTURAN_KULLANICI_ID;
            guncelle.FILTRE_TIP_ID = entity.FILTRE_TIP_ID == 0 ? 1 : entity.FILTRE_TIP_ID;
            entity.tabloAdi = "Filtreler";
            entity.ayrimAlan = "AD:" + entity.FORM_ADI;
            Service.Service_Guncelle(guncelle, id);

        }
        public override void doSil(int id, FiltrelerVm entity)
        {

            FILTRELER sil = new FILTRELER();
            EntityKey silId = new EntityKey("ProdmaEntities.FILTRELER", "ID", entity.ID);
            sil.EntityKey = silId;
            sil.ID = entity.ID;
            entity.tabloAdi = "İç Dış";
            entity.ayrimAlan = "AD:" + entity.FORM_ADI;
            Service.Service_Sil(sil, id);
            
        }

    }
}
