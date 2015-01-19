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
    public class order_statusService : AService<order_status, int, order_statusVm>  
    {

        public override void doService_Guncelle(order_status entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(order_status entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(order_status entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToorder_status(entity);
                context.SaveChanges();
                insertId = entity.id;
            }
           
        }
        public override List<order_statusVm> doService_Liste_Al(order_statusVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.order_status
                            select new order_statusVm
                                {
                                    id = kul.id,
                                    time = kul.time,
                                    order_id = kul.order_id,
                                    order_status_type_id = kul.order_status_type_id,
                                    comments = kul.comments,
                                    //order_product_id = kul.order_product_id,
                                }).OrderBy(o=>o.order_id).ThenBy(o=>o.order_status_type_id);
                if (fVm != null)
                {
                    List<order_statusVm> t;
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
