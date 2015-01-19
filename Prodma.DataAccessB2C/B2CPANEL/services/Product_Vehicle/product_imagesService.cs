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
    public class product_imagesService : AService<product_images, int, product_imagesVm>  
    {

        public override void doService_Guncelle(product_images entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(product_images entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(product_images entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToproduct_images(entity);
                context.SaveChanges();
            }
           
        }
        public override List<product_imagesVm> doService_Liste_Al(product_imagesVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.product_images
                            select new product_imagesVm
                                {
                                    id = kul.id,
                                    product_id = kul.product_id,
                                    image = kul.image,
                                    order = kul.order,
                                });
                if (fVm != null)
                {
                    List<product_imagesVm> t;
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
