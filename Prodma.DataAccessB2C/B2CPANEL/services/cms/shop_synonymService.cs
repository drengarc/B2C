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
    public class shop_synonymService : AService<shop_synonym, int, shop_synonymVm>  
    {

        public override void doService_Guncelle(shop_synonym entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(shop_synonym entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(shop_synonym entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToshop_synonym(entity);
                context.SaveChanges();
            }
           
        }
        public override List<shop_synonymVm> doService_Liste_Al(shop_synonymVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.shop_synonym
                            select new shop_synonymVm
                                {
                                    id = kul.id,
                                    from_text = kul.from_text,
                                    to_text = kul.to_text,
                                });
                if (fVm != null)
                {
                    List<shop_synonymVm> t;
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
