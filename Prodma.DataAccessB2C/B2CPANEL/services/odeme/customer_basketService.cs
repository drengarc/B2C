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
    public class customer_basketService : AService<customer_basket, int, customer_basketVm>  
    {

        public override void doService_Guncelle(customer_basket entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(customer_basket entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(customer_basket entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTocustomer_basket(entity);
                context.SaveChanges();
            }
           
        }
        public override List<customer_basketVm> doService_Liste_Al(customer_basketVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.customer_basket
                            select new customer_basketVm
                                {
                                    id = kul.id,
                                    customer_id = kul.customer_id,
                                    product_id = kul.product_id,
                                    quantity = kul.quantity,
                                    date_added = kul.date_added,
                                    STOK = new productVm() { ID = (int)kul.product_id, name = kul.product.name },
                                });
                if (fVm != null)
                {
                    List<customer_basketVm> t;
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
