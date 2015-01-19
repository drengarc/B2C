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
    public class payment_packageService : AService<payment_package, int, payment_packageVm>  
    {

        public override void doService_Guncelle(payment_package entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(payment_package entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(payment_package entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTopayment_package(entity);
                context.SaveChanges();
            }
           
        }
        public override List<payment_packageVm> doService_Liste_Al(payment_packageVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.payment_package
                            select new payment_packageVm
                                {
                                    id = kul.id,
                                    money_order_amount = kul.money_order_amount,
                                    money_order_percentage = kul.money_order_percentage,
                                    name = kul.name,
                                });
                if (fVm != null)
                {
                    List<payment_packageVm> t;
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
