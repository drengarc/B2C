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
    public class firm_parameterService : AService<firm_parameter, int, firm_parameterVm>  
    {

        public override void doService_Guncelle(firm_parameter entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(firm_parameter entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(firm_parameter entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTofirm_parameter(entity);
                context.SaveChanges();
            }
           
        }
        public override List<firm_parameterVm> doService_Liste_Al(firm_parameterVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.firm_parameter
                            select new firm_parameterVm
                                {
                                    id = kul.id,
                                    name = kul.name,
                                    redirect_to_basket = kul.redirect_to_basket,
                                    min_price_for_cargo = kul.min_price_for_cargo,
                                });
                if (fVm != null)
                {
                    List<firm_parameterVm> t;
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
