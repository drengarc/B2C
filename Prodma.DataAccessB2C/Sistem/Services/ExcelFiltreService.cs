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
     public class ExcelFiltreService : AService<EXCEL_ALANLAR, int, ExcelFiltreVm>
    {
        
        public override void doService_Guncelle(EXCEL_ALANLAR entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                 context.SaveChanges();
             }

        }
        public override void doService_Sil(EXCEL_ALANLAR entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                 context.SaveChanges();
             }



        }
        public override void doService_Ekle(EXCEL_ALANLAR entity)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.AddToEXCEL_ALANLAR(entity);
                 context.SaveChanges();
                 insertId = entity.ID;
             }

        }
 
        public override List<ExcelFiltreVm> doService_Liste_Al(ExcelFiltreVm fVm)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 var list = (from kul in context.EXCEL_ALANLAR
                             select new ExcelFiltreVm
                             {
                                 ID = kul.ID,
                                 FILTRELER_ID = kul.FILTRELER_ID,
                                 ALAN_1 = kul.ALAN_1,
                                 ALAN_2 = kul.ALAN_2,
                                 ALAN_3 = kul.ALAN_3,
                                 ALAN_4 = kul.ALAN_4,
                                 ALAN_5 = kul.ALAN_5,
                                 ALAN_6 = kul.ALAN_6,
                                 ALAN_7 = kul.ALAN_7,
                                 ALAN_8 = kul.ALAN_8,
                                 ALAN_9 = kul.ALAN_9,
                                 ALAN_10 = kul.ALAN_10
                             });
                 if (fVm != null)
                 {
                     List<ExcelFiltreVm> t;
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
