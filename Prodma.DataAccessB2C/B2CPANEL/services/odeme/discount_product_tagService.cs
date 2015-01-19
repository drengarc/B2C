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
    public class discount_product_tagService : AService<discount_product_tag, int, discount_product_tagVm>  
    {

        public override void doService_Guncelle(discount_product_tag entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(discount_product_tag entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(discount_product_tag entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTodiscount_product_tag(entity);
                context.SaveChanges();
            }
           
        }
        public override List<discount_product_tagVm> doService_Liste_Al(discount_product_tagVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.discount_product_tag
                            select new discount_product_tagVm
                                {
                                    id = kul.id,
                                    discount_id = kul.discount_id,
                                    producttag_id = kul.producttag_id,
                                });
                if (fVm != null)
                {
                    List<discount_product_tagVm> t;
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
