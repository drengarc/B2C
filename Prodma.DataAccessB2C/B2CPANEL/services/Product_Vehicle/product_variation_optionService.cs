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
    public class product_variation_optionService : AService<product_variation_option, int, product_variation_optionVm>  
    {

        public override void doService_Guncelle(product_variation_option entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(product_variation_option entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(product_variation_option entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToproduct_variation_option(entity);
                context.SaveChanges();
            }
           
        }
        public override List<product_variation_optionVm> doService_Liste_Al(product_variation_optionVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.product_variation_option
                            select new product_variation_optionVm
                                {
                                    id = kul.id,
                                    product_variation_id = kul.product_variation_id,
                                    variation_id = kul.variation_id,
                                    value = kul.value,
                                });
                if (fVm != null)
                {
                    List<product_variation_optionVm> t;
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
