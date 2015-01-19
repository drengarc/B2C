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
    public class discount_customer_groupService : AService<discount_customer_group, int, discount_customer_groupVm>  
    {

        public override void doService_Guncelle(discount_customer_group entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(discount_customer_group entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(discount_customer_group entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTodiscount_customer_group(entity);
                context.SaveChanges();
            }
           
        }
        public override List<discount_customer_groupVm> doService_Liste_Al(discount_customer_groupVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.discount_customer_group
                            select new discount_customer_groupVm
                                {
                                    id = kul.id,
                                    discount_id = kul.discount_id,
                                    customergroup_id = kul.customergroup_id,
                                });
                if (fVm != null)
                {
                    List<discount_customer_groupVm> t;
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
