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
    public class product_pageService : AService<product_page, int, product_pageVm>  
    {

        public override void doService_Guncelle(product_page entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(product_page entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(product_page entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToproduct_page(entity);
                context.SaveChanges();
            }
           
        }
        public override List<product_pageVm> doService_Liste_Al(product_pageVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.product_page
                            select new product_pageVm
                                {
                                    product_id = kul.product_id,
                                    page_title = kul.page_title,
                                    page_description = kul.page_description,
                                    keywords = kul.keywords,
                                });
                if (fVm != null)
                {
                    List<product_pageVm> t;
                    t = fVm.ID == 0 ? list.WhereByExample(fVm, "id").ToList() : list.Where(x => x.ID == fVm.ID).ToList();
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
