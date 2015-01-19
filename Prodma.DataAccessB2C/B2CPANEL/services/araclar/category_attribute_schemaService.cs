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
    public class category_attribute_schemaService : AService<category_attribute_schema, int, category_attribute_schemaVm>  
    {
        public override void doService_Guncelle(category_attribute_schema entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(category_attribute_schema entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(category_attribute_schema entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTocategory_attribute_schema(entity);
                context.SaveChanges();
            }
           
        }
        public override List<category_attribute_schemaVm> doService_Liste_Al(category_attribute_schemaVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.category_attribute_schema
                            select new category_attribute_schemaVm
                                {
                                    id = kul.id,
                                    title = kul.title,
                                    name = kul.name,
                                    help_text = kul.help_text,
                                    datatype = kul.datatype,
                                    required = kul.required,
                                    searched = kul.searched,
                                    filtered = kul.filtered,
                                    sortable = kul.sortable,
                                });
                if (fVm != null)
                {
                    List<category_attribute_schemaVm> t;
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
