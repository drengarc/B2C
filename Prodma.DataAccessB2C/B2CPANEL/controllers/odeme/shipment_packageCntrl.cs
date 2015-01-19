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
    public class shipment_packageCntrl : BaseCtrl<shipment_packageVm, int>
    {
        shipment_packageService Service = new shipment_packageService();
        public override List<shipment_packageVm> doListe_Al(shipment_packageVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(shipment_packageVm entity)
        {
            shipment_package ekle = new shipment_package();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(shipment_packageVm entity, int id)
        {
            shipment_package islem = new shipment_package();
            EntityKey guncelleId = new EntityKey("b2cEntities.shipment_package", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(shipment_package islem, shipment_packageVm entity)
        {
            islem.name = entity.name;
        }
        public override void doSil(int id, shipment_packageVm entity)
        {
            shipment_package sil = new shipment_package();
            EntityKey silId = new EntityKey("b2cEntities.shipment_package", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
