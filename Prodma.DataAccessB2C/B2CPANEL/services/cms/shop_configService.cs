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
    public class shop_configService : AService<shop_config, int, shop_configVm>  
    {

        public override void doService_Guncelle(shop_config entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(shop_config entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(shop_config entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToshop_config(entity);
                context.SaveChanges();
            }
           
        }
        public override List<shop_configVm> doService_Liste_Al(shop_configVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.shop_config
                            select new shop_configVm
                                {
                                    id = kul.id,
                                    key = kul.key,
                                    value = kul.value,
                                });
                if (fVm != null)
                {
                    List<shop_configVm> t;
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
