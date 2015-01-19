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
    public class product_reviewService : AService<product_review, int, product_reviewVm>  
    {

        public override void doService_Guncelle(product_review entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(product_review entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(product_review entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToproduct_review(entity);
                context.SaveChanges();
            }
           
        }
        public override List<product_reviewVm> doService_Liste_Al(product_reviewVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.product_review
                            select new product_reviewVm
                                {
                                    id = kul.id,
                                    product_id = kul.product_id,
                                    user_id = kul.user_id,
                                    rating = kul.rating,
                                    date_added = kul.date_added,
                                    status = kul.status,
                                    language_id = kul.language_id,
                                    text = kul.text,
                                });
                if (fVm != null)
                {
                    List<product_reviewVm> t;
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
