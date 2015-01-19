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
    public class LogService : AService<Log, int, Prodma.SistemB2C.Models.LogVm>
    {

        public override void doService_Guncelle(Log entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                 context.SaveChanges();
             }
            
        }
        public override void doService_Sil(Log entity, int id)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.Attach(entity);
                 context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                 context.SaveChanges();
             }
             
         
    
        }
        public override void doService_Ekle(Log entity)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 context.AddToLog(entity);
                 context.SaveChanges();
             }
           
        }
        public override List<Prodma.SistemB2C.Models.LogVm> doService_Liste_Al(Prodma.SistemB2C.Models.LogVm fVm)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
                 var list = (from kul in context.Log
                             select new Prodma.SistemB2C.Models.LogVm
                                 {
                                      Id  = kul.Id,
                                      Date = kul.Date,
                                      Logger = kul.Logger,
                                      Level = kul.Level,
                                      Message = kul.Message,
                                      Exception = kul.Exception,
                                 });
                 if (fVm != null)
                 {
                     List<Prodma.SistemB2C.Models.LogVm> t;
                     t = fVm.Id == 0 ? list.WhereByExample(fVm, "ID").ToList() : list.Where(x => x.Id == fVm.ID).ToList();
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
