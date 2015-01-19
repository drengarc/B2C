using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.DataAccessB2C;
using System.Windows.Forms;
using B2C.Models;
using B2C.Services;
namespace B2C.Controllers
{
    public class customer_addressCntrl : BaseCtrl<customer_addressVm, int>
    {
        customer_addressService Service = new customer_addressService();
        public override List<customer_addressVm> doListe_Al(customer_addressVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(customer_addressVm entity)
        {
            customer_address ekle = new customer_address();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(customer_addressVm entity, int id)
        {
            customer_address islem = new customer_address();
            EntityKey guncelleId = new EntityKey("b2cEntities.customer_address", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(customer_address islem, customer_addressVm entity)
        {
            islem.customer_id = entity.customer_id;
            islem.address_name = entity.address_name;
            islem.first_name = entity.first_name;
            islem.last_name = entity.last_name;
            islem.address = entity.address;
            islem.postcode = entity.postcode;
            islem.land_line = entity.land_line;
            islem.cell_phone = entity.cell_phone;
            islem.ilce_id = entity.ilce_id;
            //islem.country_id = entity.country_id;
            islem.identity_number = entity.identity_number;
            islem.tax_authority = entity.tax_authority;
            islem.tax_no = entity.tax_no;
        }
        public override void doSil(int id, customer_addressVm entity)
        {
            customer_address sil = new customer_address();
            EntityKey silId = new EntityKey("b2cEntities.customer_address", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
