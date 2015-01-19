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
    public class customer_addressService : AService<customer_address, int, customer_addressVm>  
    {

        public override void doService_Guncelle(customer_address entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using(context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                context.SaveChanges(); 
            
            }
          
            
        }
        public override void doService_Sil(customer_address entity, int id)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }
           
        }
        public override void doService_Ekle(customer_address entity)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                context.AddTocustomer_address(entity);
                context.SaveChanges();
            }
           
        }
        public override List<customer_addressVm> doService_Liste_Al(customer_addressVm fVm)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                var list = (from kul in context.customer_address
                            select new customer_addressVm
                                {
                                    id = kul.id,
                                    customer_id = kul.customer_id,
                                    address_name = kul.address_name,
                                    first_name = kul.first_name,
                                    last_name = kul.last_name,
                                    address = kul.address,
                                    postcode = kul.postcode,
                                    land_line = kul.land_line,
                                    cell_phone = kul.cell_phone,
                                    ilce_id = kul.ilce_id,
                                    //country_id = kul.country_id,
                                    identity_number = kul.identity_number,
                                    tax_authority = kul.tax_authority,
                                    tax_no = kul.tax_no,
                                });
                if (fVm != null)
                {
                    List<customer_addressVm> t;
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
