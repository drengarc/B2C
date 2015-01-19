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
    public class est_creditcardtypeService : AService<est_creditcardtype, int, est_creditcardtypeVm>  
    {

        public override void doService_Guncelle(est_creditcardtype entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(est_creditcardtype entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(est_creditcardtype entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToest_creditcardtype(entity);
                context.SaveChanges();
            }
           
        }
        public override List<est_creditcardtypeVm> doService_Liste_Al(est_creditcardtypeVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.est_creditcardtype
                            select new est_creditcardtypeVm
                                {
                                    bank_id = kul.bank_id,
                                    image = kul.image,
                                    bin = kul.bin,
                                    type = kul.type,
                                    subtype = kul.subtype,
                                });
                if (fVm != null)
                {
                    List<est_creditcardtypeVm> t;
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
