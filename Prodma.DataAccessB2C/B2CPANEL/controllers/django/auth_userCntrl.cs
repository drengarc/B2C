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
    public class auth_userCntrl : BaseCtrl<auth_userVm, int>
    {
        auth_userService Service = new auth_userService();
        public override List<auth_userVm> doListe_Al(auth_userVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(auth_userVm entity)
        {
            auth_user ekle = new auth_user();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(auth_userVm entity, int id)
        {
            auth_user islem = new auth_user();
            EntityKey guncelleId = new EntityKey("b2cEntities.auth_user", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(auth_user islem, auth_userVm entity)
        {
            islem.password = entity.password;
            islem.last_login = entity.last_login;
            islem.is_superuser = entity.is_superuser;
            islem.email = entity.email;
            islem.first_name = entity.first_name;
            islem.last_name = entity.last_name;
            islem.is_staff = entity.is_staff;
            islem.is_active = entity.is_active;
            islem.date_joined = entity.date_joined;
            islem.gender = entity.gender;
            islem.default_shipment_address_id = entity.default_shipment_address_id;
            islem.default_invoice_address_id = entity.default_invoice_address_id;
            islem.phone = entity.phone;
            islem.group_id = entity.group_id;
        }
        public override void doSil(int id, auth_userVm entity)
        {
            auth_user sil = new auth_user();
            EntityKey silId = new EntityKey("b2cEntities.auth_user", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
