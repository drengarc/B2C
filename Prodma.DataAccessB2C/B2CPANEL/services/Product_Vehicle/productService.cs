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
using System.Linq.DynamicB2C;

namespace B2C.Services
{
    public class productService : AService<product, int, productVm>  
    {

        public override void doService_Guncelle(product entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            }
        }
        public override void doService_Sil(product entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(product entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToproduct(entity);
                context.SaveChanges();
            }
           
        }
        public override List<productVm> doService_Liste_Al(productVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (fVm != null && fVm.ListeFiltresi != "")
                {
                    var list = (from kul in context.product
                                select new productVm
                                {
                                    id = kul.id,
                                    quantity = kul.quantity,
                                    name = kul.name,
                                    category_id = kul.category_id,
                                    price = kul.price,
                                    date_added = kul.date_added,
                                    discount_price = kul.discount_price,
                                    cargo_price = kul.cargo_price,
                                    last_modified = kul.last_modified,
                                    active = kul.active,
                                   // shipment_package_id = kul.shipment_package_id,
                                    manufacturer_id = kul.manufacturer_id,
                                    description = kul.description,
                                    //fulltext = kul.fulltext,
                                    sync_ege = kul.sync_ege,
                                    kdv = kul.kdv,
                                    //currency_id = kul.currency_id,
                                    //currency_value = kul.currency_value,
                                    volume = kul.volume,
                                    weight = kul.weight,
                                    partner_code = kul.partner_code,
                                    toptanci_id = kul.toptanci_id,
                                    minimum_order_amount = kul.minimum_order_amount,
                                    grup_id = kul.grup_id,
                                }).Where(fVm.ListeFiltresi).ToList();
                    return list;
                }
                else
                {
                    var list = (from kul in context.product
                                select new productVm
                                    {
                                        id = kul.id,
                                        quantity = kul.quantity,
                                        name = kul.name,
                                        category_id = kul.category_id,
                                        price = kul.price,
                                        date_added = kul.date_added,
                                        discount_price = kul.discount_price,
                                        cargo_price = kul.cargo_price,
                                        last_modified = kul.last_modified,
                                        active = kul.active,
                                        //shipment_package_id = kul.shipment_package_id,
                                        manufacturer_id = kul.manufacturer_id,
                                        description = kul.description,
                                        //fulltext = kul.fulltext,
                                        sync_ege = kul.sync_ege,
                                        kdv = kul.kdv,
                                        //currency_id = kul.currency_id,
                                        //currency_value = kul.currency_value,
                                        volume = kul.volume,
                                        weight = kul.weight,
                                        partner_code = kul.partner_code,
                                        toptanci_id = kul.toptanci_id,
                                        grup_id = kul.grup_id,
                                    });
                    if (fVm != null)
                    {
                        List<productVm> t;
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
}
