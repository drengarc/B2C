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
    public class admin_tools_dashboard_preferencesService : AService<admin_tools_dashboard_preferences, int, admin_tools_dashboard_preferencesVm>  
    {

        public override void doService_Guncelle(admin_tools_dashboard_preferences entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(admin_tools_dashboard_preferences entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(admin_tools_dashboard_preferences entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToadmin_tools_dashboard_preferences(entity);
                context.SaveChanges();
            }
           
        }
        public override List<admin_tools_dashboard_preferencesVm> doService_Liste_Al(admin_tools_dashboard_preferencesVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.admin_tools_dashboard_preferences
                            select new admin_tools_dashboard_preferencesVm
                                {
                                    id = kul.id,
                                    user_id = kul.user_id,
                                    data = kul.data,
                                    dashboard_id = kul.dashboard_id,
                                });
                if (fVm != null)
                {
                    List<admin_tools_dashboard_preferencesVm> t;
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
