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
    public class simit_customareaService : AService<simit_customarea, int, simit_customareaVm>  
    {

        public override void doService_Guncelle(simit_customarea entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(simit_customarea entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(simit_customarea entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTosimit_customarea(entity);
                context.SaveChanges();
            }
           
        }
        public override List<simit_customareaVm> doService_Liste_Al(simit_customareaVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.simit_customarea
                            select new simit_customareaVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                    slug = kul.slug,
                                    value = kul.value,
                                    type = kul.type,
                                    category_id = kul.category_id,
                                    extra = kul.extra,
                                    description = kul.description,
                                });
                if (fVm != null)
                {
                    List<simit_customareaVm> t;
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
