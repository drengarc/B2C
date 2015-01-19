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
    public class est_creditcardestrelationService : AService<est_creditcardestrelation, int, est_creditcardestrelationVm>  
    {

        public override void doService_Guncelle(est_creditcardestrelation entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(est_creditcardestrelation entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(est_creditcardestrelation entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToest_creditcardestrelation(entity);
                context.SaveChanges();
            }
           
        }
        public override List<est_creditcardestrelationVm> doService_Liste_Al(est_creditcardestrelationVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.est_creditcardestrelation
                            select new est_creditcardestrelationVm
                                {
                                    id = kul.id,
                                    bin_id = kul.bin_id,
                                    est_cash_id = kul.est_cash_id,
                                    est_installment_id = kul.est_installment_id,
                                });
                if (fVm != null)
                {
                    List<est_creditcardestrelationVm> t;
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
