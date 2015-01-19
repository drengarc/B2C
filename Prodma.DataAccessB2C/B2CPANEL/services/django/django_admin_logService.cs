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
    public class django_admin_logService : AService<django_admin_log, int, django_admin_logVm>  
    {

        public override void doService_Guncelle(django_admin_log entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(django_admin_log entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(django_admin_log entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTodjango_admin_log(entity);
                context.SaveChanges();
            }
           
        }
        public override List<django_admin_logVm> doService_Liste_Al(django_admin_logVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.django_admin_log
                            select new django_admin_logVm
                                {
                                    id = kul.id,
                                    action_time = kul.action_time,
                                    user_id = kul.user_id,
                                    content_type_id = kul.content_type_id,
                                    object_id = kul.object_id,
                                    object_repr = kul.object_repr,
                                    action_flag = kul.action_flag,
                                    change_message = kul.change_message,
                                });
                if (fVm != null)
                {
                    List<django_admin_logVm> t;
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
