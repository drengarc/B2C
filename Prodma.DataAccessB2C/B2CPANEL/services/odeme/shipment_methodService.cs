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
    public class shipment_methodService : AService<shipment_method, int, shipment_methodVm>  
    {

        public override void doService_Guncelle(shipment_method entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(shipment_method entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(shipment_method entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToshipment_method(entity);
                context.SaveChanges();
            }
           
        }
        public override List<shipment_methodVm> doService_Liste_Al(shipment_methodVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.shipment_method
                            select new shipment_methodVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                    is_active = kul.is_active,
                                    image = kul.image,
                                });
                if (fVm != null)
                {
                    List<shipment_methodVm> t;
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
