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
    public class vehicle_toptanciService : AService<vehicle_toptanci, int, vehicle_toptanciVm>  
    {

        public override void doService_Guncelle(vehicle_toptanci entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(vehicle_toptanci entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(vehicle_toptanci entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTovehicle_toptanci(entity);
                context.SaveChanges();
            }
           
        }
        public override List<vehicle_toptanciVm> doService_Liste_Al(vehicle_toptanciVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.vehicle_toptanci
                            select new vehicle_toptanciVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                });
                if (fVm != null)
                {
                    List<vehicle_toptanciVm> t;
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
