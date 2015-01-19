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
using Prodma.SistemB2C.Models;
namespace Prodma.SistemB2C.Services
{
     public class AlanlarService : AService<M_ALANLAR, int, AlanlarVm>
    {
        
        public override void doService_Guncelle(M_ALANLAR entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                 context.SaveChanges();
             }

        }
        public override void doService_Sil(M_ALANLAR entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                 context.SaveChanges();
             }



        }
        public override void doService_Ekle(M_ALANLAR entity)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.AddToM_ALANLAR(entity);
                 context.SaveChanges();
                 insertId = entity.ID;
             }

        }
 
        public override List<AlanlarVm> doService_Liste_Al(AlanlarVm fVm)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 var list = (from kul in context.M_ALANLAR
                             select new AlanlarVm
                             {
                                 ID = kul.ID,
                                 KULLANICI_ID = kul.KULLANICI_ID,
                                 M_ALANLAR_ID = kul.M_ALANLAR_ID,
                                 ALAN_AD = kul.ALAN_AD,
                                 ALAN_LISTE_AD = kul.ALAN_LISTE_AD,
                                 ALAN_LISTE_GENISLIK = kul.ALAN_LISTE_GENISLIK,
                                 ALAN_UZUNLUK = kul.ALAN_UZUNLUK,
                                 ALAN_DECIMAL = kul.ALAN_DECIMAL,
                                 ALAN_SIRA = kul.ALAN_SIRA,
                                 M_ALAN_TIP_ID = kul.M_ALAN_TIP_ID,
                                 M_ALAN_GOSTERILEN_ID = kul.M_ALAN_GOSTERILEN_ID,
                                 M_TABLO_TIP_ID = kul.M_ALAN_GOSTERILEN_ID,
                                 M_ALAN_CLASS_NAME = kul.M_ALAN_CLASS_NAME,
                                 LK_DURUM_ID = kul.LK_DURUM_ID,
                                 KIRILIM_TIP_ID = kul.KIRILIM_TIP_ID,
                                 M_ALAN_ARAMA_TIP_ID = kul.M_ALAN_ARAMA_TIP_ID,
                                 M_ALAN_KOPYALAMA_E_H = kul.M_ALAN_KOPYALAMA_E_H,
                                 M_ALANLAR_ALAN_TABLOSU_ID = kul.M_ALANLAR_ID,
                             });
                 if (fVm != null)
                 {
                     List<AlanlarVm> t;
                     t = fVm.ID == 0 ? list.WhereByExample(fVm, "ID").ToList() : list.Where(x => x.ID == fVm.ID).ToList();
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
