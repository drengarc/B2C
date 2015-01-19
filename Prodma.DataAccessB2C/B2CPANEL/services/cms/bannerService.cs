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
    public class bannerService : AService<banner, int, bannerVm>  
    {

        public override void doService_Guncelle(banner entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(banner entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(banner entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTobanner(entity);
                context.SaveChanges();
            }
           
        }
        public override List<bannerVm> doService_Liste_Al(bannerVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.banner
                            select new bannerVm
                                {
                                    id = kul.id,
                                    title = kul.title,
                                    url = kul.url,
                                //    language_id = kul.language_id,
                                    image = kul.image,
                                    html_text = kul.html_text,
                                    end_date = kul.end_date,
                                    start_date = kul.start_date,
                                    date_added = kul.date_added,
                                    is_active = kul.is_active,
                                    area_id = kul.area_id,
                                });
                if (fVm != null)
                {
                    List<bannerVm> t;
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
