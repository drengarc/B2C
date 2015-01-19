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
    public class est_installmentalternativeService : AService<est_installmentalternative, int, est_installmentalternativeVm>  
    {

        public override void doService_Guncelle(est_installmentalternative entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(est_installmentalternative entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(est_installmentalternative entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToest_installmentalternative(entity);
                context.SaveChanges();
            }
           
        }
        public override List<est_installmentalternativeVm> doService_Liste_Al(est_installmentalternativeVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.est_installmentalternative
                            select new est_installmentalternativeVm
                                {
                                    id = kul.id,
                                    package_id = kul.package_id,
                                    bank_id = kul.bank_id,
                                    discount_percentage = kul.discount_percentage,
                                    discount_amount = kul.discount_amount,
                                    installment = kul.installment,
                                    minimum_price = kul.minimum_price,
                                    maximum_price = kul.maximum_price,
                                    description = kul.description,
                                });
                if (fVm != null)
                {
                    List<est_installmentalternativeVm> t;
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
