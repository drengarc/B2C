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
    public class shipment_alternativeService : AService<shipment_alternative, int, shipment_alternativeVm>  
    {

        public override void doService_Guncelle(shipment_alternative entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(shipment_alternative entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(shipment_alternative entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToshipment_alternative(entity);
                context.SaveChanges();
            }
           
        }
        public override List<shipment_alternativeVm> doService_Liste_Al(shipment_alternativeVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.shipment_alternative
                            select new shipment_alternativeVm
                                {
                                    id = kul.id,
                                    package_id = kul.package_id,
                                    shipmentmethod_id = kul.shipmentmethod_id,
                                    fixed_price = kul.fixed_price,
                                    price_by_kg = kul.price_by_kg,
                                });
                if (fVm != null)
                {
                    List<shipment_alternativeVm> t;
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
