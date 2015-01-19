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
    public class product_vehicleService : AService<product_vehicle, int, product_vehicleVm>  
    {

        public override void doService_Guncelle(product_vehicle entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(product_vehicle entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(product_vehicle entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToproduct_vehicle(entity);
                context.SaveChanges();
            }
           
        }
        public override List<product_vehicleVm> doService_Liste_Al(product_vehicleVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.product_vehicle
                            select new product_vehicleVm
                                {
                                    id = kul.id,
                                    product_id = kul.product_id,
                                    vehicle_id = kul.vehicle_id,
                                });
                if (fVm != null)
                {
                    List<product_vehicleVm> t;
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
