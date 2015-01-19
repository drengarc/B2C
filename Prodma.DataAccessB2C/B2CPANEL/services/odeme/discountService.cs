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
    public class discountService : AService<discount, int, discountVm>  
    {

        public override void doService_Guncelle(discount entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(discount entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(discount entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTodiscount(entity);
                context.SaveChanges();
            }
           
        }
        public override List<discountVm> doService_Liste_Al(discountVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.discount
                            select new discountVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                    percentage = kul.percentage,
                                    amount = kul.amount,
                                    date_added = kul.date_added,
                                    start_date = kul.start_date,
                                    end_date = kul.end_date,
                                    is_active = kul.is_active,
                                    minimum_order_price = kul.minimum_order_price,
                                });
                if (fVm != null)
                {
                    List<discountVm> t;
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
