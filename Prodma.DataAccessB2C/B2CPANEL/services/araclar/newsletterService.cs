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
    public class newsletterService : AService<newsletter, int, newsletterVm>  
    {

        public override void doService_Guncelle(newsletter entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(newsletter entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(newsletter entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTonewsletter(entity);
                context.SaveChanges();
            }
           
        }
        public override List<newsletterVm> doService_Liste_Al(newsletterVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.newsletter
                            select new newsletterVm
                                {
                                    id = kul.id,
                                    title = kul.title,
                                    content = kul.content,
                                    date_added = kul.date_added,
                                    date_sent = kul.date_sent,
                                    is_active = kul.is_active,
                                    language_id = kul.language_id,
                                });
                if (fVm != null)
                {
                    List<newsletterVm> t;
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
