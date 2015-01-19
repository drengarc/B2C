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
    public class ege_integration_activitylogService : AService<ege_integration_activitylog, int, ege_integration_activitylogVm>  
    {

        public override void doService_Guncelle(ege_integration_activitylog entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(ege_integration_activitylog entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(ege_integration_activitylog entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToege_integration_activitylog(entity);
                context.SaveChanges();
            }
           
        }
        public override List<ege_integration_activitylogVm> doService_Liste_Al(ege_integration_activitylogVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.ege_integration_activitylog
                            select new ege_integration_activitylogVm
                                {
                                    id = kul.id,
                                    event1 = kul.@event,
                                    level = kul.level,
                                    message = kul.message,
                                    timestamp = kul.timestamp,
                                });
                if (fVm != null)
                {
                    List<ege_integration_activitylogVm> t;
                    t = fVm.id == 0 ? list.WhereByExample(fVm, "id").ToList() : list.Where(x => x.id == fVm.id).ToList();
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
