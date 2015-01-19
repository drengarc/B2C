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
    public class manufacturerService : AService<manufacturer, int, manufacturerVm>  
    {

        public override void doService_Guncelle(manufacturer entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(manufacturer entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(manufacturer entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTomanufacturer(entity);
                context.SaveChanges();
            }
           
        }
        public override List<manufacturerVm> doService_Liste_Al(manufacturerVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.manufacturer
                            select new manufacturerVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                    image = kul.image,
                                });
                if (fVm != null)
                {
                    List<manufacturerVm> t;
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
