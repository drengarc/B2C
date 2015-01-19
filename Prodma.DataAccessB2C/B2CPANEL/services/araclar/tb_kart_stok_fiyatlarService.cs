using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using System.Configuration;
using Prodma.DataAccessB2C;
using System.ComponentModel;
using System.Drawing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using B2C.Models;
namespace B2C.Services
{
    public class tb_kart_stok_fiyatlarService : AService<tb_kart_stok_fiyatlar, int, tb_kart_stok_fiyatlarVm>  
    {

        public override void doService_Guncelle(tb_kart_stok_fiyatlar entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(tb_kart_stok_fiyatlar entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(tb_kart_stok_fiyatlar entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTotb_kart_stok_fiyatlar(entity);
                context.SaveChanges();
            }
           
        }
        public override List<tb_kart_stok_fiyatlarVm> doService_Liste_Al(tb_kart_stok_fiyatlarVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.tb_kart_stok_fiyatlar
                            select new tb_kart_stok_fiyatlarVm
                                {
                                    //id = kul.id,
                                    artis = kul.artis,
                                    stok_kodu = kul.stok_kodu,
                                    tedarikci_kodu = kul.tedarikci_kodu,
                                    paket_stok_id = kul.paket_stok_id,
                                    minumum_adet = kul.minumum_adet,
                                    tedarikci = kul.tedarikci,
                                    birimi = kul.birimi,
                                    grup_id = kul.grup_id,
                                    depo1 = kul.depo1,
                                    depo2 = kul.depo2,
                                    yeni_urun = kul.yeni_urun,
                                    fiyat = kul.fiyat,
                                    fiyat_doviz_id = kul.fiyat_doviz_id,
                                    kdv = kul.kdv,
                                    isk1 = kul.isk1,
                                    isk2 = kul.isk2,
                                    isk3 = kul.isk3,
                                    isk4 = kul.isk4,
                                    kmp_isk = kul.kmp_isk,
                                    net_fiyat_aktifmi = kul.net_fiyat_aktifmi,
                                    ege_stok_id = kul.ege_stok_id,
                                    toptanci_id = kul.toptanci_id,
                                });
                if (fVm != null)
                {
                    List<tb_kart_stok_fiyatlarVm> t = new List<tb_kart_stok_fiyatlarVm>();
                    //t = fVm.id == 0 ? list.WhereByExample(fVm, "id").ToList() : list.Where(x => x.id == fVm.id).ToList();
                    return t;
                }
                else
                {
                    return list.ToList();
                }
            }
 
        }
        
    }
}
