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
    public class vehicle_motor_typeService : AService<vehicle_motor_type, int, vehicle_motor_typeVm>  
    {

        public override void doService_Guncelle(vehicle_motor_type entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(vehicle_motor_type entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(vehicle_motor_type entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTovehicle_motor_type(entity);
                context.SaveChanges();
            }
           
        }
        public override List<vehicle_motor_typeVm> doService_Liste_Al(vehicle_motor_typeVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.vehicle_motor_type
                            select new vehicle_motor_typeVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                    slug = kul.slug,
                                });
                if (fVm != null)
                {
                    List<vehicle_motor_typeVm> t;
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
