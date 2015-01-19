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
    public class simit_menusectionService : AService<simit_menusection, int, simit_menusectionVm>  
    {

        public override void doService_Guncelle(simit_menusection entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(simit_menusection entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(simit_menusection entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTosimit_menusection(entity);
                context.SaveChanges();
            }
           
        }
        public override List<simit_menusectionVm> doService_Liste_Al(simit_menusectionVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.simit_menusection
                            select new simit_menusectionVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                });
                if (fVm != null)
                {
                    List<simit_menusectionVm> t;
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
