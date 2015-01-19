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
    public class discount_categoryService : AService<discount_category, int, discount_categoryVm>  
    {

        public override void doService_Guncelle(discount_category entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(discount_category entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(discount_category entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTodiscount_category(entity);
                context.SaveChanges();
            }
           
        }
        public override List<discount_categoryVm> doService_Liste_Al(discount_categoryVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.discount_category
                            select new discount_categoryVm
                                {
                                    id = kul.id,
                                    discount_id = kul.discount_id,
                                    category_id = kul.category_id,
                                });
                if (fVm != null)
                {
                    List<discount_categoryVm> t;
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
