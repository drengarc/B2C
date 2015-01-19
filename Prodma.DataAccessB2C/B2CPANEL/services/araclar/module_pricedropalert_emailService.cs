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
    public class module_pricedropalert_emailService : AService<module_pricedropalert_email, int, module_pricedropalert_emailVm>  
    {

        public override void doService_Guncelle(module_pricedropalert_email entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(module_pricedropalert_email entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(module_pricedropalert_email entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTomodule_pricedropalert_email(entity);
                context.SaveChanges();
            }
           
        }
        public override List<module_pricedropalert_emailVm> doService_Liste_Al(module_pricedropalert_emailVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.module_pricedropalert_email
                            select new module_pricedropalert_emailVm
                                {
                                    id = kul.id,
                                    saved_time = kul.saved_time,
                                    email = kul.email,
                                    product_id = kul.product_id,
                                    checkpoint_price = kul.checkpoint_price,
                                });
                if (fVm != null)
                {
                    List<module_pricedropalert_emailVm> t;
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
