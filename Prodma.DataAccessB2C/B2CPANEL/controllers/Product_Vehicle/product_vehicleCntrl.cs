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
    public class product_vehicleCntrl : BaseCtrl<product_vehicleVm, int>
    {
        product_vehicleService Service = new product_vehicleService();
        public override List<product_vehicleVm> doListe_Al(product_vehicleVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(product_vehicleVm entity)
        {
            product_vehicle ekle = new product_vehicle();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(product_vehicleVm entity, int id)
        {
            product_vehicle islem = new product_vehicle();
            EntityKey guncelleId = new EntityKey("b2cEntities.product_vehicle", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(product_vehicle islem, product_vehicleVm entity)
        {
            islem.product_id = entity.product_id;
            islem.vehicle_id = entity.vehicle_id;
        }
        public override void doSil(int id, product_vehicleVm entity)
        {
            product_vehicle sil = new product_vehicle();
            EntityKey silId = new EntityKey("b2cEntities.product_vehicle", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
