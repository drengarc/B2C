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
    public class vehicleService : AService<vehicle, int, vehicleVm>  
    {

        public override void doService_Guncelle(vehicle entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(vehicle entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(vehicle entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTovehicle(entity);
                context.SaveChanges();
            }
           
        }
        public override List<vehicleVm> doService_Liste_Al(vehicleVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.vehicle
                            select new vehicleVm
                                {
                                    id = kul.id,
                                    model_type_id = kul.model_type_id,
                                    motor_type_id = kul.motor_type_id,
                                    fuel_type_id = kul.fuel_type_id,
                                    begin_year = kul.begin_year,
                                    end_year = kul.end_year,
                                    grup_id = kul.grup_id,
                                    model_id = kul.model_id,
                                    brand_id = kul.brand_id,
                                    //fulltext = kul.fulltext,
                                });
                if (fVm != null)
                {
                    List<vehicleVm> t;
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
