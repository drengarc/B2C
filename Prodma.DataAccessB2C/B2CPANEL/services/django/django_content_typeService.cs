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
    public class django_content_typeService : AService<django_content_type, int, django_content_typeVm>  
    {

        public override void doService_Guncelle(django_content_type entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(django_content_type entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(django_content_type entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTodjango_content_type(entity);
                context.SaveChanges();
            }
           
        }
        public override List<django_content_typeVm> doService_Liste_Al(django_content_typeVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.django_content_type
                            select new django_content_typeVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                    app_label = kul.app_label,
                                    model = kul.model,
                                });
                if (fVm != null)
                {
                    List<django_content_typeVm> t;
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
