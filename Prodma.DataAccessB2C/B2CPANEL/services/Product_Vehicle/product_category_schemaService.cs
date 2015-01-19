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
    public class product_category_schemaService : AService<product_category_schema, int, product_category_schemaVm>  
    {

        public override void doService_Guncelle(product_category_schema entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(product_category_schema entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(product_category_schema entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToproduct_category_schema(entity);
                context.SaveChanges();
            }
           
        }
        public override List<product_category_schemaVm> doService_Liste_Al(product_category_schemaVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.product_category_schema
                            select new product_category_schemaVm
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
                                    category_id = kul.category_id,
                                });
                if (fVm != null)
                {
                    List<product_category_schemaVm> t;
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
