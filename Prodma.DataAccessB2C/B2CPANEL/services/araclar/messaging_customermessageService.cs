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
    public class messaging_customermessageService : AService<messaging_customermessage, int, messaging_customermessageVm>  
    {

        public override void doService_Guncelle(messaging_customermessage entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(messaging_customermessage entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(messaging_customermessage entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTomessaging_customermessage(entity);
                context.SaveChanges();
            }
           
        }
        public override List<messaging_customermessageVm> doService_Liste_Al(messaging_customermessageVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.messaging_customermessage
                            select new messaging_customermessageVm
                                {
                                    id = kul.id,
                                    customer_id = kul.customer_id,
                                    topic = kul.topic,
                                    message = kul.message,
                                    top_message_id = kul.top_message_id,
                                    unread = kul.unread,
                                    time = kul.time,
                                    staff_id = kul.staff_id,
                                    order_id = kul.order_id,
                                    department_id = kul.department_id,
                                });
                if (fVm != null)
                {
                    List<messaging_customermessageVm> t;
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
