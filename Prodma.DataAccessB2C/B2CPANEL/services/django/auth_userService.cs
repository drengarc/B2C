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
using System.Linq.DynamicB2C;
namespace B2C.Services
{
    public class auth_userService : AService<auth_user, int, auth_userVm>  
    {

        public override void doService_Guncelle(auth_user entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(auth_user entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(auth_user entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToauth_user(entity);
                context.SaveChanges();
            }
           
        }
        public override List<auth_userVm> doService_Liste_Al(auth_userVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (fVm != null && fVm.ListeFiltresi != "")
                {
                    var list = (from kul in context.auth_user
                                select new auth_userVm
                                {
                                    id = kul.id,
                                    password = kul.password,
                                    last_login = kul.last_login,
                                    is_superuser = kul.is_superuser,
                                    email = kul.email,
                                    first_name = kul.first_name,
                                    last_name = kul.last_name,
                                    is_staff = kul.is_staff,
                                    is_active = kul.is_active,
                                    date_joined = kul.date_joined,
                                    gender = kul.gender,
                                    default_shipment_address_id = kul.default_shipment_address_id,
                                    default_invoice_address_id = kul.default_invoice_address_id,
                                    phone = kul.phone,
                                    group_id = kul.group_id,
                                }).Where(fVm.ListeFiltresi).ToList();
                    return list;
                }
                else
                {
                    var list = (from kul in context.auth_user
                                select new auth_userVm
                                    {
                                        id = kul.id,
                                        password = kul.password,
                                        last_login = kul.last_login,
                                        is_superuser = kul.is_superuser,
                                        email = kul.email,
                                        first_name = kul.first_name,
                                        last_name = kul.last_name,
                                        is_staff = kul.is_staff,
                                        is_active = kul.is_active,
                                        date_joined = kul.date_joined,
                                        gender = kul.gender,
                                        default_shipment_address_id = kul.default_shipment_address_id,
                                        default_invoice_address_id = kul.default_invoice_address_id,
                                        phone = kul.phone,
                                        group_id = kul.group_id,
                                    });
                    if (fVm != null)
                    {
                        List<auth_userVm> t;
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
}
