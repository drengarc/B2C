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
    public class AlanlarCntrl : BaseCtrl<AlanlarVm, int>
    {
        AlanlarService Service = new AlanlarService();
        public override List<AlanlarVm> doListe_Al(AlanlarVm entity){
            return Service.Service_Liste_Al(entity);  
        }
        public override void doEkle(AlanlarVm entity)
        {
                M_ALANLAR ekle = new M_ALANLAR();
                ekle.ID = OrtakIslemlerService.GetMaxAlanId();
                ekle.KULLANICI_ID = entity.KULLANICI_ID;
    //            ekle.M_ALANLAR_ID = entity.M_ALANLAR_ID;
                ekle.M_ALANLAR_ID =entity.M_ALANLAR_ALAN_TABLOSU_ID;
                ekle.ALAN_AD = entity.ALAN_AD;
                ekle.ALAN_LISTE_AD = entity.ALAN_LISTE_AD;
                ekle.ALAN_LISTE_GENISLIK = entity.ALAN_LISTE_GENISLIK;
                ekle.ALAN_UZUNLUK = entity.ALAN_UZUNLUK;
                ekle.ALAN_DECIMAL = entity.ALAN_DECIMAL;
                ekle.ALAN_SIRA  = entity.ALAN_SIRA;
                ekle.M_ALAN_TIP_ID = entity.M_ALAN_TIP_ID;
                ekle.M_ALAN_GOSTERILEN_ID = entity.M_ALAN_GOSTERILEN_ID;
                ekle.M_TABLO_TIP_ID = entity.M_ALAN_GOSTERILEN_ID;
                ekle.M_ALAN_CLASS_NAME = entity.M_ALAN_CLASS_NAME;
                ekle.M_ALAN_TIP_2 = entity.M_ALAN_TIP_2;
                ekle.ALAN_PRECISION = entity.ALAN_PRECISION;
                ekle.ALAN_NULL_ICERIR = entity.ALAN_NULL_ICERIR;
                ekle.M_ALAN_ALT_BILGI = entity.M_ALAN_ALT_BILGI;
                ekle.LK_DURUM_ID = entity.LK_DURUM_ID;
                ekle.KIRILIM_TIP_ID = entity.KIRILIM_TIP_ID;
                ekle.M_ALAN_ARAMA_TIP_ID = Convert.ToByte(entity.M_ALAN_ARAMA_TIP_ID);
                ekle.M_ALAN_KOPYALAMA_E_H = entity.M_ALAN_KOPYALAMA_E_H;
                entity.tabloAdi = "İç Dış";
                entity.ayrimAlan = "AD:" + entity.ALAN_AD;
                Service.Service_Ekle(ekle); entity.ID = ekle.ID;
                entity.insertId = Service.insertId;
        }
        public override void doGuncelle(AlanlarVm entity, int id)
        {
            M_ALANLAR guncelle = new M_ALANLAR();
            EntityKey guncelleId = new EntityKey("b2cEntities.M_ALANLAR", "ID", entity.ID);
            guncelle.EntityKey = guncelleId;
            guncelle.ID = entity.ID;
            guncelle.KULLANICI_ID = entity.KULLANICI_ID;
            guncelle.M_ALANLAR_ID = entity.M_ALANLAR_ALAN_TABLOSU_ID;
            guncelle.ALAN_AD = entity.ALAN_AD;
            guncelle.ALAN_LISTE_AD = entity.ALAN_LISTE_AD;
            guncelle.ALAN_LISTE_GENISLIK = entity.ALAN_LISTE_GENISLIK;
            guncelle.ALAN_UZUNLUK = entity.ALAN_UZUNLUK;
            guncelle.ALAN_DECIMAL = entity.ALAN_DECIMAL;
            guncelle.ALAN_SIRA = entity.ALAN_SIRA;
            guncelle.M_ALAN_TIP_ID = entity.M_ALAN_TIP_ID;
            guncelle.M_ALAN_GOSTERILEN_ID = entity.M_ALAN_GOSTERILEN_ID;
            guncelle.M_TABLO_TIP_ID = entity.M_ALAN_GOSTERILEN_ID;
            guncelle.M_ALAN_CLASS_NAME = entity.M_ALAN_CLASS_NAME;
            guncelle.M_ALAN_TIP_2 = entity.M_ALAN_TIP_2;
            guncelle.ALAN_PRECISION = entity.ALAN_PRECISION;
            guncelle.ALAN_NULL_ICERIR = entity.ALAN_NULL_ICERIR;
            guncelle.M_ALAN_ALT_BILGI = entity.M_ALAN_ALT_BILGI;
            guncelle.LK_DURUM_ID = entity.LK_DURUM_ID;
            guncelle.KIRILIM_TIP_ID = entity.KIRILIM_TIP_ID;
            guncelle.M_ALAN_ARAMA_TIP_ID = Convert.ToByte(entity.M_ALAN_ARAMA_TIP_ID);
            guncelle.M_ALAN_KOPYALAMA_E_H = entity.M_ALAN_KOPYALAMA_E_H;
            entity.tabloAdi = "İç Dış";
            entity.ayrimAlan = "AD:" + entity.ALAN_AD;
            Service.Service_Guncelle(guncelle, id);

        }
        public override void doSil(int id, AlanlarVm entity)
        {

            M_ALANLAR sil = new M_ALANLAR();
            EntityKey silId = new EntityKey("b2cEntities.M_ALANLAR", "ID", entity.ID);
            sil.EntityKey = silId;
            sil.ID = entity.ID;
            entity.tabloAdi = "İç Dış";
            entity.ayrimAlan = "AD:" + entity.ALAN_AD;
            Service.Service_Sil(sil, id);
            
        }
        public void Kopyala(string alan_ad)
        {
            b2cEntities context = new  b2cEntities();
            int id=20041;
            int alan_id = 0;
            int alan_yeni_id = 0;
            using (context)
            {
                var q = (from fis in context.M_ALANLAR
                         where fis.ALAN_AD == alan_ad
                         select fis).ToList();
                foreach (var item in q)
                {
                    alan_id = item.ID;
                    M_ALANLAR ekle = new M_ALANLAR();
                    ekle.ID = id;
                    ekle.ALAN_AD = alan_ad + "_IC_FIS";
                    ekle.M_ALANLAR_ID = item.M_ALANLAR_ID;
                    ekle.ALAN_AD = item.ALAN_AD;
                    ekle.ALAN_LISTE_AD = item.ALAN_LISTE_AD;
                    ekle.ALAN_LISTE_GENISLIK = item.ALAN_LISTE_GENISLIK;
                    ekle.ALAN_UZUNLUK = item.ALAN_UZUNLUK;
                    ekle.ALAN_DECIMAL = item.ALAN_DECIMAL;
                    ekle.ALAN_SIRA = item.ALAN_SIRA;
                    ekle.M_ALAN_TIP_ID = item.M_ALAN_TIP_ID;
                    ekle.M_ALAN_GOSTERILEN_ID = item.M_ALAN_GOSTERILEN_ID;
                    ekle.M_TABLO_TIP_ID = item.M_ALAN_GOSTERILEN_ID;
                    ekle.M_ALAN_CLASS_NAME = item.M_ALAN_CLASS_NAME;
                    ekle.M_ALAN_TIP_2 = item.M_ALAN_TIP_2;
                    ekle.ALAN_PRECISION = item.ALAN_PRECISION;
                    ekle.ALAN_NULL_ICERIR = item.ALAN_NULL_ICERIR;
                    ekle.M_ALAN_ALT_BILGI = item.M_ALAN_ALT_BILGI;
                    ekle.M_ALAN_ARAMA_TIP_ID = item.M_ALAN_ARAMA_TIP_ID;
                    ekle.LK_DURUM_ID = item.LK_DURUM_ID;
                    Service.Service_Ekle(ekle); 
                   // entity.ID = ekle.ID;
                    alan_yeni_id = Service.insertId;
                    id++;
                }

                var q1 = (from fis in context.M_ALANLAR
                         where fis.M_ALANLAR_ID == alan_id
                         select fis).ToList();
                foreach (var item in q1)
                {
                    alan_id = item.ID;
                    M_ALANLAR ekle = new M_ALANLAR();
                    ekle.ID = id;
                    ekle.ALAN_AD = alan_ad + "_IC_FIS";
                    ekle.M_ALANLAR_ID = alan_yeni_id;
                    ekle.ALAN_AD = item.ALAN_AD;
                    ekle.ALAN_LISTE_AD = item.ALAN_LISTE_AD;
                    ekle.ALAN_LISTE_GENISLIK = item.ALAN_LISTE_GENISLIK;
                    ekle.ALAN_UZUNLUK = item.ALAN_UZUNLUK;
                    ekle.ALAN_DECIMAL = item.ALAN_DECIMAL;
                    ekle.ALAN_SIRA = item.ALAN_SIRA;
                    ekle.M_ALAN_TIP_ID = item.M_ALAN_TIP_ID;
                    ekle.M_ALAN_GOSTERILEN_ID = item.M_ALAN_GOSTERILEN_ID;
                    ekle.M_TABLO_TIP_ID = item.M_ALAN_GOSTERILEN_ID;
                    ekle.M_ALAN_CLASS_NAME = item.M_ALAN_CLASS_NAME;
                    ekle.M_ALAN_TIP_2 = item.M_ALAN_TIP_2;
                    ekle.ALAN_PRECISION = item.ALAN_PRECISION;
                    ekle.ALAN_NULL_ICERIR = item.ALAN_NULL_ICERIR;
                    ekle.M_ALAN_ALT_BILGI = item.M_ALAN_ALT_BILGI;
                    ekle.M_ALAN_ARAMA_TIP_ID = item.M_ALAN_ARAMA_TIP_ID;
                    ekle.LK_DURUM_ID = item.LK_DURUM_ID;
                    Service.Service_Ekle(ekle); 
                    //entity.ID = ekle.ID;
                    id++;
                }
            }
        }

    }
}
