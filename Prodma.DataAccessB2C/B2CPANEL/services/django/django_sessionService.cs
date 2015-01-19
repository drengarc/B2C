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
    public class django_sessionService : AService<django_session, int, django_sessionVm>  
    {

        public override void doService_Guncelle(django_session entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(django_session entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(django_session entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTodjango_session(entity);
                context.SaveChanges();
            }
           
        }
        public override List<django_sessionVm> doService_Liste_Al(django_sessionVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.django_session
                            select new django_sessionVm
                                {
                                    session_key = kul.session_key,
                                    session_data = kul.session_data,
                                    expire_date = kul.expire_date,
                                });
                if (fVm != null)
                {
                    List<django_sessionVm> t;
                    t = fVm.ID == 0 ? list.WhereByExample(fVm, "id").ToList() : list.Where(x => x.ID == fVm.ID).ToList();
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
