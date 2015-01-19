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
    public class south_migrationhistoryService : AService<south_migrationhistory, int, south_migrationhistoryVm>  
    {

        public override void doService_Guncelle(south_migrationhistory entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(south_migrationhistory entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(south_migrationhistory entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTosouth_migrationhistory(entity);
                context.SaveChanges();
            }
           
        }
        public override List<south_migrationhistoryVm> doService_Liste_Al(south_migrationhistoryVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.south_migrationhistory
                            select new south_migrationhistoryVm
                                {
                                    id = kul.id,
                                    app_name = kul.app_name,
                                    migration = kul.migration,
                                    applied = kul.applied,
                                });
                if (fVm != null)
                {
                    List<south_migrationhistoryVm> t;
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
