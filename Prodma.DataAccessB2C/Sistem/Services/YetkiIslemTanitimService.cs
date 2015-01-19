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
    public class YetkiIslemTanitimService : AService<YETKI_ISLEM_TANITIM, int, YetkiIslemTanitimVm>
    {
        
        public override void doService_Guncelle(YETKI_ISLEM_TANITIM entity, int id)
        {

             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                 context.SaveChanges();
             }

        }
        public override void doService_Sil(YETKI_ISLEM_TANITIM entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                 context.SaveChanges();
             }


        }
        public override void doService_Ekle(YETKI_ISLEM_TANITIM entity)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.AddToYETKI_ISLEM_TANITIM(entity);
                 context.SaveChanges();
             }

        }
        public override List<YetkiIslemTanitimVm> doService_Liste_Al(YetkiIslemTanitimVm fVm)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 var list = (from kul in context.YETKI_ISLEM_TANITIM
                             select new YetkiIslemTanitimVm
                                 {
                                     ID = kul.ID,
                                     YETKI_ISLEM_SAHIBI_TANITIM_ID = kul.YETKI_ISLEM_SAHIBI_TANITIM_ID,
                                     KOD = kul.KOD  ,
                                     AD = kul.AD,
                                     TAG_NAME = kul.TAG_NAME,
                                     HINT_NAME = kul.HINT_NAME,
                                     IMAGE_NAME = kul.IMAGE_NAME,
                                     LK_DURUM_ID = kul.LK_DURUM_ID,
                                     YETKI_ISLEM_SAHIBI_TIP_ID = kul.YETKI_ISLEM_SAHIBI_TIP_ID,
                                 });
                 if (fVm != null)
                 {
                     List<YetkiIslemTanitimVm> t;
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
