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
    public class auth_permissionService : AService<auth_permission, int, auth_permissionVm>  
    {

        public override void doService_Guncelle(auth_permission entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(auth_permission entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(auth_permission entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToauth_permission(entity);
                context.SaveChanges();
            }
           
        }
        public override List<auth_permissionVm> doService_Liste_Al(auth_permissionVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.auth_permission
                            select new auth_permissionVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                    content_type_id = kul.content_type_id,
                                    codename = kul.codename,
                                });
                if (fVm != null)
                {
                    List<auth_permissionVm> t;
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
