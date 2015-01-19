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
    public class order_productService : AService<order_product, int, order_productVm>  
    {

        public override void doService_Guncelle(order_product entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(order_product entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(order_product entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToorder_product(entity);
                context.SaveChanges();
            }
           
        }
        public override List<order_productVm> doService_Liste_Al(order_productVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.order_product
                            select new order_productVm
                                {
                                    id = kul.id,
                                    order_id = kul.order_id,
                                    product_id = kul.product_id,
                                    quantity = kul.quantity,
                                    price = kul.price,
                                    discount = kul.discount,
                                    vehicle_toptanci_id = kul.vehicle_toptanci_id,
                                    sase_code = kul.sase_code,
                                    STOK = new productVm() { ID = (int)kul.product_id, name = kul.product.name },
                                    SIFIRLI = new orderVm() { ID = (int)kul.order_id, customer_id = kul.order.auth_user.id},
                                });
                if (fVm != null)
                {
                    List<order_productVm> t;
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
