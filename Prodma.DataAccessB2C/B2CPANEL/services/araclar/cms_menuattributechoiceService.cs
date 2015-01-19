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
    public class cms_menuattributechoiceService : AService<cms_menuattributechoice, int, cms_menuattributechoiceVm>  
    {

        public override void doService_Guncelle(cms_menuattributechoice entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(cms_menuattributechoice entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(cms_menuattributechoice entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTocms_menuattributechoice(entity);
                context.SaveChanges();
            }
           
        }
        public override List<cms_menuattributechoiceVm> doService_Liste_Al(cms_menuattributechoiceVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.cms_menuattributechoice
                            select new cms_menuattributechoiceVm
                                {
                                    id = kul.id,
                                    title = kul.title,
                                    schema_id = kul.schema_id,
                                });
                if (fVm != null)
                {
                    List<cms_menuattributechoiceVm> t;
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
