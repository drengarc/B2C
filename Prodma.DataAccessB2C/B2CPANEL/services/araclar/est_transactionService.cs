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
    public class est_transactionService : AService<est_transaction, int, est_transactionVm>  
    {

        public override void doService_Guncelle(est_transaction entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(est_transaction entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(est_transaction entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToest_transaction(entity);
                context.SaveChanges();
            }
           
        }
        public override List<est_transactionVm> doService_Liste_Al(est_transactionVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.est_transaction
                            select new est_transactionVm
                                {
                                    id = kul.id,
                                    date = kul.date,
                                    //ip = kul.,
                                    type = kul.type,
                                    customer_id = kul.customer_id,
                                    order_id = kul.order_id,
                                    est_id = kul.est_id,
                                    amount = kul.amount,
                                    error_message = kul.error_message,
                                });
                if (fVm != null)
                {
                    List<est_transactionVm> t;
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
