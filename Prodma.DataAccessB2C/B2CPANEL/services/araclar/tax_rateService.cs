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
    public class tax_rateService : AService<tax_rate, int, tax_rateVm>  
    {

        public override void doService_Guncelle(tax_rate entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(tax_rate entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(tax_rate entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTotax_rate(entity);
                context.SaveChanges();
            }
           
        }
        public override List<tax_rateVm> doService_Liste_Al(tax_rateVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.tax_rate
                            select new tax_rateVm
                                {
                                    id = kul.id,
                                    category_id = kul.category_id,
                                    tax_rate = kul.tax_rate1,
                                    date_added = kul.date_added,
                                });
                if (fVm != null)
                {
                    List<tax_rateVm> t;
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
