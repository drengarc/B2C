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
    public class simit_menuService : AService<simit_menu, int, simit_menuVm>  
    {

        public override void doService_Guncelle(simit_menu entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(simit_menu entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(simit_menu entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTosimit_menu(entity);
                context.SaveChanges();
            }
           
        }
        public override List<simit_menuVm> doService_Liste_Al(simit_menuVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.simit_menu
                            select new simit_menuVm
                                {
                                    id = kul.id,
                                    title = kul.title,
                                    parent_id = kul.parent_id,
                                    description = kul.description,
                                    url = kul.url,
                                    page_id = kul.page_id,
                                    url_name = kul.url_name,
                                    section_id = kul.section_id,
                                    is_active = kul.is_active,
                                    lft = kul.lft,
                                    rght = kul.rght,
                                    tree_id = kul.tree_id,
                                    level = kul.level,
                                });
                if (fVm != null)
                {
                    List<simit_menuVm> t;
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
