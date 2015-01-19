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
    public class KullaniciCntrl : BaseCtrl<KullaniciVm, int>
    {
        KullaniciService Service = new KullaniciService();
        public override List<KullaniciVm> doListe_Al(KullaniciVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(KullaniciVm entity)
        {
            KULLANICI ekle = new KULLANICI();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.ID = ekle.ID;
            entity.insertId = Service.insertId;
            entity.tabloAdi = "Kullanıcı";
            entity.ayrimAlan = "AD:" + entity.AD;
        }
        public override void doGuncelle(KullaniciVm entity, int id)
        {
            KULLANICI guncelle = new KULLANICI();
            EntityKey guncelleId = new EntityKey("b2cEntities.KULLANICI", "ID", entity.ID);
            guncelle.EntityKey = guncelleId;
            guncelle.ID = entity.ID;
            EkleGuncelle(guncelle, entity);
            Service.Service_Guncelle(guncelle, id);
            entity.tabloAdi = "Kullanıcı";
            entity.ayrimAlan = "AD:" + entity.AD;
        }
        void EkleGuncelle(KULLANICI ekle, KullaniciVm entity)
        {
            ekle.FIRMA_ID = entity.FIRMA_ID;
            ekle.KULLANICI_AD = entity.KULLANICI_AD;
            ekle.SIFRE = entity.SIFRE;
            ekle.AD = entity.AD;
            ekle.SOYAD = entity.SOYAD;
            ekle.MAIL = entity.MAIL != null ? entity.MAIL : "";
            ekle.FOTO = entity.FOTO;
            ekle.ROL_ID = entity.ROL_ID;
            ekle.DIL_ID = entity.DIL_ID;
            //ekle.LOCAL_PATH = entity.LOCAL_PATH;
            //ekle.LK_DURUM_ID = entity.LK_DURUM_ID != 0 ? entity.LK_DURUM_ID : (int)DurumEn.Aktif;
            //ekle.FIRMA_DISI_E_H = entity.FIRMA_DISI_E_H;
            //ekle.FIRMA_DISI_MAX_ISK_YUZ = entity.FIRMA_DISI_MAX_ISK_YUZ;
            //ekle.SARF_AMBAR_ID = entity.SARF_AMBAR_ID;
            //ekle.ILERI_FIS_GIRIS_E_H = entity.ILERI_FIS_GIRIS_E_H;
            //ekle.GERI_FIS_GIRIS_E_H = entity.GERI_FIS_GIRIS_E_H;
            //ekle.BAYI_SIPARIS_ONAY_E_H = entity.BAYI_SIPARIS_ONAY_E_H;
            //ekle.EK_ISK_YUZ = entity.EK_ISK_YUZ;
            //ekle.CARI_PLASIYER_ID = entity.CARI_PLASIYER_ID;
            //ekle.CARI_SATIS_ELEMANI_ID = entity.CARI_SATIS_ELEMANI_ID;
            //ekle.CARI_AGENT_ID = entity.CARI_AGENT_ID;
            //ekle.AGENT_SIFRE = entity.AGENT_SIFRE;
            //ekle.BARKOD_KULLANICI_E_H = entity.BARKOD_KULLANICI_E_H;
            //ekle.KULLANICI_ALANLAR_OZEL_E_H = entity.KULLANICI_ALANLAR_OZEL_E_H;
            //ekle.CARI_GOZLEM_AC_E_H = entity.CARI_GOZLEM_AC_E_H;
            //ekle.UST_KULLANICI_ID = entity.UST_KULLANICI_ID;
            //ekle.ESKI_KULLANICI_KOD = entity.ESKI_KULLANICI_KOD;
            //ekle.INSERT_TAR = entity.INSERT_TAR;
            //ekle.INSERT_KUL_ID = entity.INSERT_KUL_ID;
            //ekle.UPDATE_TAR = entity.UPDATE_TAR;
            //ekle.UPDATE_KUL_ID = entity.UPDATE_KUL_ID;
            //ekle.KULLANICI_FIRMA_TIP_ID = entity.KULLANICI_FIRMA_TIP_ID;
        }
        public override void doSil(int id, KullaniciVm entity)
        {
            KULLANICI sil = new KULLANICI();
            EntityKey silId = new EntityKey("b2cEntities.KULLANICI", "ID", entity.ID);
            sil.EntityKey = silId;
            sil.ID = entity.ID;
            Service.Service_Sil(sil, id);
            entity.tabloAdi = "Kullanıcı";
            entity.ayrimAlan = "AD:" + entity.AD;
        }


    }
}
