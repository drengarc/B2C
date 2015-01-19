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
    public class messaging_messagedepartmentService : AService<messaging_messagedepartment, int, messaging_messagedepartmentVm>  
    {

        public override void doService_Guncelle(messaging_messagedepartment entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(messaging_messagedepartment entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(messaging_messagedepartment entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTomessaging_messagedepartment(entity);
                context.SaveChanges();
            }
           
        }
        public override List<messaging_messagedepartmentVm> doService_Liste_Al(messaging_messagedepartmentVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.messaging_messagedepartment
                            select new messaging_messagedepartmentVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                });
                if (fVm != null)
                {
                    List<messaging_messagedepartmentVm> t;
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
