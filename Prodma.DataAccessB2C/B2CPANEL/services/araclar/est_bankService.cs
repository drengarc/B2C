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
    public class est_bankService : AService<est_bank, int, est_bankVm>  
    {

        public override void doService_Guncelle(est_bank entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(est_bank entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(est_bank entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToest_bank(entity);
                context.SaveChanges();
            }
           
        }
        public override List<est_bankVm> doService_Liste_Al(est_bankVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.est_bank
                            select new est_bankVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                    image = kul.image,
                                });
                if (fVm != null)
                {
                    List<est_bankVm> t;
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
