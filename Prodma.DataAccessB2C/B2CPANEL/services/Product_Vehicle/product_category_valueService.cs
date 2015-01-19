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
    public class product_category_valueService : AService<product_category_value, int, product_category_valueVm>  
    {

        public override void doService_Guncelle(product_category_value entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(product_category_value entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(product_category_value entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToproduct_category_value(entity);
                context.SaveChanges();
            }
           
        }
        public override List<product_category_valueVm> doService_Liste_Al(product_category_valueVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.product_category_value
                            select new product_category_valueVm
                                {
                                    id = kul.id,
                                    entity_type_id = kul.entity_type_id,
                                    entity_id = kul.entity_id,
                                    value_text = kul.value_text,
                                    value_float = kul.value_float,
                                    value_date = kul.value_date,
                                    value_bool = kul.value_bool,
                                    schema_id = kul.schema_id,
                                    choice_id = kul.choice_id,
                                    category_id = kul.category_id,
                                });
                if (fVm != null)
                {
                    List<product_category_valueVm> t;
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
