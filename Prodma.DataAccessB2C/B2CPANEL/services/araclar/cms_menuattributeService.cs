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
    public class cms_menuattributeService : AService<cms_menuattribute, int, cms_menuattributeVm>  
    {

        public override void doService_Guncelle(cms_menuattribute entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(cms_menuattribute entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(cms_menuattribute entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTocms_menuattribute(entity);
                context.SaveChanges();
            }
           
        }
        public override List<cms_menuattributeVm> doService_Liste_Al(cms_menuattributeVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.cms_menuattribute
                            select new cms_menuattributeVm
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
                    List<cms_menuattributeVm> t;
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
