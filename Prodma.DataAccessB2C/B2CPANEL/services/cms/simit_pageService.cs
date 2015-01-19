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
    public class simit_pageService : AService<simit_page, int, simit_pageVm>  
    {

        public override void doService_Guncelle(simit_page entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(simit_page entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(simit_page entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTosimit_page(entity);
                context.SaveChanges();
            }
           
        }
        public override List<simit_pageVm> doService_Liste_Al(simit_pageVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.simit_page
                            select new simit_pageVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                    content = kul.content,
                                    slug = kul.slug,
                                    tags = kul.tags,
                                    description = kul.description,
                                    title = kul.title,
                                    last_modified = kul.last_modified,
                                    is_active = kul.is_active,
                                });
                if (fVm != null)
                {
                    List<simit_pageVm> t;
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
