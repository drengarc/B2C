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
    public class product_originalService : AService<product_original, int, product_originalVm>  
    {

        public override void doService_Guncelle(product_original entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(product_original entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(product_original entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToproduct_original(entity);
                context.SaveChanges();
            }
           
        }
        public override List<product_originalVm> doService_Liste_Al(product_originalVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.product_original
                            select new product_originalVm
                                {
                                    id = kul.id,
                                    product_id = kul.product_id,
                                    oem_no = kul.oem_no,
                                    oem_no_original = kul.oem_no_original,
                                    brand_id = kul.brand_id,
                                });
                if (fVm != null)
                {
                    List<product_originalVm> t;
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
