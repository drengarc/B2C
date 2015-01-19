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
    public class vehicle_currencyService : AService<vehicle_currency, int, vehicle_currencyVm>  
    {

        public override void doService_Guncelle(vehicle_currency entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(vehicle_currency entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(vehicle_currency entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTovehicle_currency(entity);
                context.SaveChanges();
            }
           
        }
        public override List<vehicle_currencyVm> doService_Liste_Al(vehicle_currencyVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.vehicle_currency
                            select new vehicle_currencyVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                    code = kul.code,
                                    symbol = kul.symbol,
                                    parity = kul.parity,
                                });
                if (fVm != null)
                {
                    List<vehicle_currencyVm> t;
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
