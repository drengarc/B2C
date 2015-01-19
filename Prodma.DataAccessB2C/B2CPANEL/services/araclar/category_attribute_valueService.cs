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
    public class category_attribute_valueService : AService<category_attribute_value, int, category_attribute_valueVm>  
    {

        public override void doService_Guncelle(category_attribute_value entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(category_attribute_value entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(category_attribute_value entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTocategory_attribute_value(entity);
                context.SaveChanges();
            }
           
        }
        public override List<category_attribute_valueVm> doService_Liste_Al(category_attribute_valueVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.category_attribute_value
                            select new category_attribute_valueVm
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
                                });
                if (fVm != null)
                {
                    List<category_attribute_valueVm> t;
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
