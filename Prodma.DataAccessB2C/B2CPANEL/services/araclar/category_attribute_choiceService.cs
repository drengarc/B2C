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
    public class category_attribute_choiceService : AService<category_attribute_choice, int, category_attribute_choiceVm>  
    {

        public override void doService_Guncelle(category_attribute_choice entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(category_attribute_choice entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(category_attribute_choice entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTocategory_attribute_choice(entity);
                context.SaveChanges();
            }
           
        }
        public override List<category_attribute_choiceVm> doService_Liste_Al(category_attribute_choiceVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.category_attribute_choice
                            select new category_attribute_choiceVm
                                {
                                    id = kul.id,
                                    title = kul.title,
                                    schema_id = kul.schema_id,
                                });
                if (fVm != null)
                {
                    List<category_attribute_choiceVm> t;
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
