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
     public class YetkiAlanlarBilgiService :  AService<YETKI_ALANLAR,int,YetkiAlanlarBilgiVm>
    {
        
        public override void doService_Guncelle(YETKI_ALANLAR entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {

                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                 context.SaveChanges();
             }
            
        }
        public override void doService_Sil(YETKI_ALANLAR entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                 context.SaveChanges();
             }
         
    
        }
        public override void doService_Ekle(YETKI_ALANLAR entity)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.AddToYETKI_ALANLAR(entity);
                 context.SaveChanges();
             }
           
        }
        public override List<YetkiAlanlarBilgiVm> doService_Liste_Al(YetkiAlanlarBilgiVm fVm)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 if (fVm == null)
                 {
                     var list = (from ya in context.YETKI_ALANLAR
                                 where ya.M_ALANLAR_ALT_ID != null
                                 join ma in context.M_ALANLAR
                                 on ya.M_ALANLAR_ID equals ma.ID
                                 select new YetkiAlanlarBilgiVm
                                     {
                                         ID = ya.ID,
                                         KULLANICI_ID = ya.KULLANICI_ID,
                                         M_ALANLAR_UST_ID = (int)ma.M_ALANLAR_ID,
                                         M_ALANLAR_ALT_ID = ya.M_ALANLAR_ALT_ID,
                                         M_ALANLAR_ID = ya.M_ALANLAR_ID,
                                         GORMESIN_E_H = ya.GORMESIN_E_H,
                                         YAZMASIN_E_H = ya.YAZMASIN_E_H,
                                         LK_DURUM_ID = ya.LK_DURUM_ID,
                                     });
                     if (fVm != null)
                     {
                         List<YetkiAlanlarBilgiVm> t;
                         t = fVm.ID == 0 ? list.WhereByExample(fVm, "ID").ToList() : list.Where(x => x.ID == fVm.ID).ToList();
                         return t;
                     }
                     else
                     {
                         return list.ToList();
                     }
                 }
                 else
                 {
                     var list = (from ya in context.YETKI_ALANLAR
                                 where ya.M_ALANLAR_ALT_ID != null && ya.KULLANICI_ID == fVm.KULLANICI_ID 
                                 && ya.M_ALANLAR_ID == fVm.M_ALANLAR_ID 
                                 join ma in context.M_ALANLAR
                                 on ya.M_ALANLAR_ID equals ma.ID
                                 select new YetkiAlanlarBilgiVm
                                 {
                                     ID = ya.ID,
                                     KULLANICI_ID = ya.KULLANICI_ID,
                                     M_ALANLAR_UST_ID = (int)ma.M_ALANLAR_ID,
                                     M_ALANLAR_ALT_ID = ya.M_ALANLAR_ALT_ID,
                                     M_ALANLAR_ID = ya.M_ALANLAR_ID,
                                     GORMESIN_E_H = ya.GORMESIN_E_H,
                                     YAZMASIN_E_H = ya.YAZMASIN_E_H,
                                     LK_DURUM_ID = ya.LK_DURUM_ID,
                                 });
                     if (fVm != null)
                     {
                         List<YetkiAlanlarBilgiVm> t;
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
}
