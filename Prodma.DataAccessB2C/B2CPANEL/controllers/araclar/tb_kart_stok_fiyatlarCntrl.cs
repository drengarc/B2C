using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.DataAccessB2C;
using System.Windows.Forms;
using B2C.Models;
using B2C.Services;
namespace B2C.Controllers
{
    public class tb_kart_stok_fiyatlarCntrl : BaseCtrl<tb_kart_stok_fiyatlarVm, int>
    {
        tb_kart_stok_fiyatlarService Service = new tb_kart_stok_fiyatlarService();
        public override List<tb_kart_stok_fiyatlarVm> doListe_Al(tb_kart_stok_fiyatlarVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(tb_kart_stok_fiyatlarVm entity)
        {
            tb_kart_stok_fiyatlar ekle = new tb_kart_stok_fiyatlar();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle);// entity.id = ekle.id;
        }
        public override void doGuncelle(tb_kart_stok_fiyatlarVm entity, int id)
        {
            tb_kart_stok_fiyatlar islem = new tb_kart_stok_fiyatlar();
            EntityKey guncelleId = new EntityKey("b2cEntities.tb_kart_stok_fiyatlar", "id", 1);
            islem.EntityKey = guncelleId;
            //islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, 1);
        }
        void EkleGuncelle(tb_kart_stok_fiyatlar islem, tb_kart_stok_fiyatlarVm entity)
        {
            islem.artis = entity.artis;
            islem.stok_kodu = entity.stok_kodu;
            islem.tedarikci_kodu = entity.tedarikci_kodu;
            islem.paket_stok_id = entity.paket_stok_id;
            islem.minumum_adet = entity.minumum_adet;
            islem.tedarikci = entity.tedarikci;
            islem.birimi = entity.birimi;
            islem.grup_id = entity.grup_id;
            islem.depo1 = entity.depo1;
            islem.depo2 = entity.depo2;
            islem.fiyat = entity.fiyat;
            islem.fiyat_doviz_id = entity.fiyat_doviz_id;
            islem.kdv = entity.kdv;
            islem.isk1 = entity.isk1;
            islem.isk2 = entity.isk2;
            islem.isk3 = entity.isk3;
            islem.isk4 = entity.isk4;
            islem.kmp_isk = entity.kmp_isk;
            islem.net_fiyat_aktifmi = entity.net_fiyat_aktifmi;
            islem.ege_stok_id = entity.ege_stok_id;
            islem.toptanci_id = entity.toptanci_id;
        }
        public override void doSil(int id, tb_kart_stok_fiyatlarVm entity)
        {
            tb_kart_stok_fiyatlar sil = new tb_kart_stok_fiyatlar();
            EntityKey silId = new EntityKey("b2cEntities.tb_kart_stok_fiyatlar", "id", 1);
            sil.EntityKey = silId;
            //sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
