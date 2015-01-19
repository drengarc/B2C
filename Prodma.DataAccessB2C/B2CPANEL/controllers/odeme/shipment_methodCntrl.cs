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
    public class shipment_methodCntrl : BaseCtrl<shipment_methodVm, int>
    {
        shipment_methodService Service = new shipment_methodService();
        public override List<shipment_methodVm> doListe_Al(shipment_methodVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(shipment_methodVm entity)
        {
            shipment_method ekle = new shipment_method();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(shipment_methodVm entity, int id)
        {
            shipment_method islem = new shipment_method();
            EntityKey guncelleId = new EntityKey("b2cEntities.shipment_method", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(shipment_method islem, shipment_methodVm entity)
        {
            islem.name = entity.name;
            islem.is_active = entity.is_active;
            islem.image = entity.image;
        }
        public override void doSil(int id, shipment_methodVm entity)
        {
            shipment_method sil = new shipment_method();
            EntityKey silId = new EntityKey("b2cEntities.shipment_method", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
