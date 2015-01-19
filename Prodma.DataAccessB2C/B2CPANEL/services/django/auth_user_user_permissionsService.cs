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
    public class auth_user_user_permissionsService : AService<auth_user_user_permissions, int, auth_user_user_permissionsVm>  
    {

        public override void doService_Guncelle(auth_user_user_permissions entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(auth_user_user_permissions entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(auth_user_user_permissions entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToauth_user_user_permissions(entity);
                context.SaveChanges();
            }
           
        }
        public override List<auth_user_user_permissionsVm> doService_Liste_Al(auth_user_user_permissionsVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.auth_user_user_permissions
                            select new auth_user_user_permissionsVm
                                {
                                    id = kul.id,
                                    user_id = kul.user_id,
                                    permission_id = kul.permission_id,
                                });
                if (fVm != null)
                {
                    List<auth_user_user_permissionsVm> t;
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
