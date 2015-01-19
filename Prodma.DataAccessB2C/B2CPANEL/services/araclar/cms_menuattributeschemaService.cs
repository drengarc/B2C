using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using System.Configuration;
using Prodma.DataAccess;
using System.ComponentModel;
using System.Drawing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using B2C.Models;
namespace B2C.Services
{
    public class cms_menuattributeschemaService : AService<cms_menuattributeschema, int, cms_menuattributeschemaVm>  
    {

        public override void doService_Guncelle(cms_menuattributeschema entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(cms_menuattributeschema entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(cms_menuattributeschema entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTocms_menuattributeschema(entity);
                context.SaveChanges();
            }
           
        }
        public override List<cms_menuattributeschemaVm> doService_Liste_Al(cms_menuattributeschemaVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.cms_menuattributeschema
                            select new cms_menuattributeschemaVm
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
                    List<cms_menuattributeschemaVm> t;
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
