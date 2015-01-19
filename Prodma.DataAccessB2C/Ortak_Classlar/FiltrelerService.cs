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
     public class FiltrelerService : AService<FILTRELER, int, FiltrelerVm>
    {
        
        public override void doService_Guncelle(FILTRELER entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                 context.SaveChanges();
             }

        }
        public override void doService_Sil(FILTRELER entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                 context.SaveChanges();
             }



        }
        public override void doService_Ekle(FILTRELER entity)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.AddToFILTRELER(entity);
                 context.SaveChanges();
                 insertId = entity.ID;
             }

        }
 
        public override List<FiltrelerVm> doService_Liste_Al(FiltrelerVm fVm)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 var list = (from kul in context.FILTRELER
                             select new FiltrelerVm
                             {
                                 ID = kul.ID,
                                 KULLANICI_ID = kul.KULLANICI_ID,
                                 FORM_ADI = kul.FORM_ADI,
                                 RAPOR_ADI = kul.RAPOR_ADI,
                                 DEGER_ALANI = kul.DEGER_ALANI,
                                 LK_DURUM_ID = kul.LK_DURUM_ID,
                                 FILTRE_OLUSTURAN_KULLANICI_ID = kul.FILTRE_OLUSTURAN_KULLANICI_ID,
                                 FILTRE_TIP_ID = kul.FILTRE_TIP_ID
                             });
                 if (fVm != null)
                 {
                     List<FiltrelerVm> t;
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
