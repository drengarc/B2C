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
    public class categoryService : AService<category, int, categoryVm>  
    {

        public override void doService_Guncelle(category entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(category entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(category entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTocategory(entity);
                context.SaveChanges();
            }
           
        }
        public override List<categoryVm> doService_Liste_Al(categoryVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.category
                            select new categoryVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                    image = kul.image,
                                    parent_id = kul.parent_id,
                                    description = kul.description,
                                    slug = kul.slug,
                                    lft = kul.lft,
                                    rght = kul.rght,
                                    tree_id = kul.tree_id,
                                    level = kul.level,
                                    vehicle_category = kul.vehicle_category,
                                  
                                });
                if (fVm != null)
                {
                    List<categoryVm> t;
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
