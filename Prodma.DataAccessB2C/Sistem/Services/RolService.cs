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
     public class RolService :  AService<ROL,int, RolVm>
    {
        
        public override void doService_Guncelle(ROL entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                 context.SaveChanges();
             }
            
        }
        public override void doService_Sil(ROL entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                 context.SaveChanges();
             }
             
         
    
        }
        public override void doService_Ekle(ROL entity)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.AddToROL(entity);
                 context.SaveChanges();
             }
           
        }
        public override List<RolVm> doService_Liste_Al(RolVm fVm)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 var list = (from kul in context.ROL
                             select new RolVm
                                 {
                                     ID = kul.ID,
                                     AD = kul.AD,
                                     LK_DURUM_ID = kul.LK_DURUM_ID
                                 });
                 if (fVm != null)
                 {
                     List<RolVm> t;
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
