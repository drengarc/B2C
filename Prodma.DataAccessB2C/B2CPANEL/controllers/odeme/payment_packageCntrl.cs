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
    public class payment_packageCntrl : BaseCtrl<payment_packageVm, int>
    {
        payment_packageService Service = new payment_packageService();
        public override List<payment_packageVm> doListe_Al(payment_packageVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(payment_packageVm entity)
        {
            payment_package ekle = new payment_package();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(payment_packageVm entity, int id)
        {
            payment_package islem = new payment_package();
            EntityKey guncelleId = new EntityKey("b2cEntities.payment_package", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(payment_package islem, payment_packageVm entity)
        {
            islem.money_order_amount = entity.money_order_amount;
            islem.money_order_percentage = entity.money_order_percentage;
            islem.name = entity.name;
        }
        public override void doSil(int id, payment_packageVm entity)
        {
            payment_package sil = new payment_package();
            EntityKey silId = new EntityKey("b2cEntities.payment_package", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
