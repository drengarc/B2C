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
    public class shipment_alternativeCntrl : BaseCtrl<shipment_alternativeVm, int>
    {
        shipment_alternativeService Service = new shipment_alternativeService();
        public override List<shipment_alternativeVm> doListe_Al(shipment_alternativeVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(shipment_alternativeVm entity)
        {
            shipment_alternative ekle = new shipment_alternative();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(shipment_alternativeVm entity, int id)
        {
            shipment_alternative islem = new shipment_alternative();
            EntityKey guncelleId = new EntityKey("b2cEntities.shipment_alternative", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(shipment_alternative islem, shipment_alternativeVm entity)
        {
            islem.package_id = entity.package_id;
            islem.shipmentmethod_id = entity.shipmentmethod_id;
            islem.fixed_price = entity.fixed_price;
            islem.price_by_kg = entity.price_by_kg;
        }
        public override void doSil(int id, shipment_alternativeVm entity)
        {
            shipment_alternative sil = new shipment_alternative();
            EntityKey silId = new EntityKey("b2cEntities.shipment_alternative", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
