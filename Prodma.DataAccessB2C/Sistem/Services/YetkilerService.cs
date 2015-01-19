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
     public class YetkilerService : AService<YETKI, int, YetkilerVm>
    {
        
        public override void doService_Guncelle(YETKI entity, int id)
        {

             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                 context.SaveChanges();
             }

        }
        public override void doService_Sil(YETKI entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                 context.SaveChanges();
             }


        }
        public override void doService_Ekle(YETKI entity)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.AddToYETKI(entity);
                 context.SaveChanges();
             }

        }
        public override List<YetkilerVm> doService_Liste_Al(YetkilerVm fVm)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 var list = (from kul in context.YETKI
                             select new YetkilerVm
                                 {
                                     ID = kul.ID,
                                     KULLANICI_ID = kul.KULLANICI_ID,
                                     M_MENU_ID = kul.M_MENU_ID,
                                     OKU_E_H = kul.OKU_E_H,
                                     YAZ_E_H = kul.YAZ_E_H,
                                     GUNCELLE_E_H = kul.GUNCELLE_E_H,
                                     SIL_E_H = kul.SIL_E_H,
                                     GORMESIN_E_H = kul.GORMESIN_E_H,
                                 });
                 if (fVm != null)
                 {
                     List<YetkilerVm> t;
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
