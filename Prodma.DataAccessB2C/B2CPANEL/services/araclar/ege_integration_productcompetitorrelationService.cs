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
    public class ege_integration_productcompetitorrelationService : AService<ege_integration_productcompetitorrelation, int, ege_integration_productcompetitorrelationVm>  
    {

        public override void doService_Guncelle(ege_integration_productcompetitorrelation entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(ege_integration_productcompetitorrelation entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(ege_integration_productcompetitorrelation entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddToege_integration_productcompetitorrelation(entity);
                context.SaveChanges();
            }
           
        }
        public override List<ege_integration_productcompetitorrelationVm> doService_Liste_Al(ege_integration_productcompetitorrelationVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.ege_integration_productcompetitorrelation
                            select new ege_integration_productcompetitorrelationVm
                                {
                                    id = kul.id,
                                    product_id = kul.product_id,
                                    competitor_product_code = kul.competitor_product_code,
                                    competitor_manufacturer_id = kul.competitor_manufacturer_id,
                                });
                if (fVm != null)
                {
                    List<ege_integration_productcompetitorrelationVm> t;
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
