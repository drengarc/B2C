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
    public class est_estcredentialService : AService<est_estcredential, int, est_estcredentialVm>  
    {

        public override void doService_Guncelle(est_estcredential entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(est_estcredential entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(est_estcredential entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToest_estcredential(entity);
                context.SaveChanges();
            }
           
        }
        public override List<est_estcredentialVm> doService_Liste_Al(est_estcredentialVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.est_estcredential
                            select new est_estcredentialVm
                                {
                                    id = kul.id,
                                    bank = kul.bank,
                                    client_id = kul.client_id,
                                    username = kul.username,
                                    password = kul.password,
                                    secret_key = kul.secret_key,
                                });
                if (fVm != null)
                {
                    List<est_estcredentialVm> t;
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
