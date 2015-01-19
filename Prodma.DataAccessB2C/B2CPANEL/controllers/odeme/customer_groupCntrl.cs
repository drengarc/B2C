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
    public class customer_groupCntrl : BaseCtrl<customer_groupVm, int>
    {
        customer_groupService Service = new customer_groupService();
        public override List<customer_groupVm> doListe_Al(customer_groupVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(customer_groupVm entity)
        {
            customer_group ekle = new customer_group();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(customer_groupVm entity, int id)
        {
            customer_group islem = new customer_group();
            EntityKey guncelleId = new EntityKey("b2cEntities.customer_group", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(customer_group islem, customer_groupVm entity)
        {
            islem.name = entity.name;
        }
        public override void doSil(int id, customer_groupVm entity)
        {
            customer_group sil = new customer_group();
            EntityKey silId = new EntityKey("b2cEntities.customer_group", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
