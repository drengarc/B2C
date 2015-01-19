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
    public class orderService : AService<order, int, orderVm>  
    {

        public override void doService_Guncelle(order entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(order entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(order entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToorder(entity);
                context.SaveChanges();
            }
           
        }
        public override List<orderVm> doService_Liste_Al(orderVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.order
                            select new orderVm
                                {
                                    id = kul.id,
                                    date_processed = kul.date_processed,
                                    receipt_id = kul.receipt_id,
                                    customer_id = kul.customer_id,
                                    discount = kul.discount,
                                    delivery_name = kul.delivery_name,
                                    delivery_address = kul.delivery_address,
                                    delivery_city_id = kul.delivery_city_id,
                                    delivery_phone = kul.delivery_phone,
                                    billing_name = kul.billing_name,
                                    billing_address = kul.billing_address,
                                    billing_city_id = kul.billing_city_id,
                                    billing_phone = kul.billing_phone,
                                    cc_owner = kul.cc_owner,
                                    cc_number_last = kul.cc_number_last,
                                    final_price = kul.final_price,
                                    comment = kul.comment,
                                    cargo_no = kul.cargo_no,
                                    payment_type = kul.payment_type,
                                    final_kdv = kul.final_kdv,
                                    shipment_price = kul.shipment_price,
                                    shipment_alternative_id = kul.shipment_alternative_id,
                                });
                if (fVm != null)
                {
                    List<orderVm> t = new List<orderVm>();
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
