using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.DataAccessB2C;
using System.Windows.Forms;
using Prodma.SistemB2C.Services;
using Prodma.SistemB2C.Models;
namespace Prodma.SistemB2C.Controllers
{
    public class FirmaCntrl : BaseCtrl<FirmaVm, int>
    {
        FirmaService Service = new FirmaService();
        public override List<FirmaVm> doListe_Al(FirmaVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(FirmaVm entity)
        {
            FIRMA ekle = new FIRMA();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.ID = ekle.ID;
        }
        public override void doGuncelle(FirmaVm entity, int id)
        {
            FIRMA islem = new FIRMA();
            EntityKey guncelleId = new EntityKey("b2cEntities.FIRMA", "ID", entity.ID);
            islem.EntityKey = guncelleId;
            islem.ID = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.ID);
        }
        void EkleGuncelle(FIRMA islem, FirmaVm entity)
        {
            islem.AD = entity.AD;
            islem.ADR1 = entity.ADR1;
            //islem.ADR2 = entity.ADR2;

            //islem.ADR3 = entity.ADR3;
            //islem.VERGI_DAIRE = entity.VERGI_DAIRE;
            //islem.VERGI_NO = entity.VERGI_NO;
            //islem.TEL = entity.TEL;
            //islem.FAX = entity.FAX;
            //islem.MAIL = entity.MAIL;
            //islem.LK_DURUM_ID = entity.LK_DURUM_ID != 0 ? entity.LK_DURUM_ID : (int)DurumEn.Aktif;
            //islem.WEB_ADRES = entity.WEB_ADRES;
            //islem.FIRMA_TIP_ID = entity.FIRMA_TIP_ID;
            //islem.FIRMA_TEHLIKE_TIP_ID = entity.FIRMA_TEHLIKE_TIP_ID;
            //islem.ASIL_FIRMA_ID = entity.ASIL_FIRMA_ID;
            //islem.ESKI_KOD = entity.ESKI_KOD;
            //islem.LOGO_PATH = entity.LOGO_PATH;
            //islem.RESIM_PATH = entity.RESIM_PATH;
            //islem.GUNCELLEME_PATH = entity.GUNCELLEME_PATH;
            //islem.RAPOR_PATH = entity.RAPOR_PATH;
            //islem.DESTEK_ELEMAN_SAYISI = entity.DESTEK_ELEMAN_SAYISI;
            //islem.ACIL_DURUM_YENILEME_PERIYOD = entity.ACIL_DURUM_YENILEME_PERIYOD;
            //islem.YILLIK_EGITIM_YENILEME_PERIYOD = entity.YILLIK_EGITIM_YENILEME_PERIYOD;
            //islem.PERIYODIK_EGITIM_DAKIKA = entity.PERIYODIK_EGITIM_DAKIKA;
            //islem.ARSIV_PATH = entity.ARSIV_PATH;
        }
        public override void doSil(int id, FirmaVm entity)
        {
            FIRMA sil = new FIRMA();
            EntityKey silId = new EntityKey("b2cEntities.FIRMA", "ID", entity.ID);
            sil.EntityKey = silId;
            sil.ID = entity.ID; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
