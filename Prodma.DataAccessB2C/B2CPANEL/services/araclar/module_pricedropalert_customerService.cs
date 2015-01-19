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
    public class module_pricedropalert_customerService : AService<module_pricedropalert_customer, int, module_pricedropalert_customerVm>  
    {

        public override void doService_Guncelle(module_pricedropalert_customer entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(module_pricedropalert_customer entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(module_pricedropalert_customer entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTomodule_pricedropalert_customer(entity);
                context.SaveChanges();
            }
           
        }
        public override List<module_pricedropalert_customerVm> doService_Liste_Al(module_pricedropalert_customerVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.module_pricedropalert_customer
                            select new module_pricedropalert_customerVm
                                {
                                    id = kul.id,
                                    saved_time = kul.saved_time,
                                    customer_id = kul.customer_id,
                                    product_id = kul.product_id,
                                    checkpoint_price = kul.checkpoint_price,
                                });
                if (fVm != null)
                {
                    List<module_pricedropalert_customerVm> t;
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
