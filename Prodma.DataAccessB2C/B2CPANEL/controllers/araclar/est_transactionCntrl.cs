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
    public class est_transactionCntrl : BaseCtrl<est_transactionVm, int>
    {
        est_transactionService Service = new est_transactionService();
        public override List<est_transactionVm> doListe_Al(est_transactionVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(est_transactionVm entity)
        {
            est_transaction ekle = new est_transaction();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(est_transactionVm entity, int id)
        {
            est_transaction islem = new est_transaction();
            EntityKey guncelleId = new EntityKey("b2cEntities.est_transaction", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(est_transaction islem, est_transactionVm entity)
        {
            islem.date = entity.date;
            //islem.ip = entity.ip;
            islem.type = entity.type;
            islem.customer_id = entity.customer_id;
            islem.order_id = entity.order_id;
            islem.est_id = entity.est_id;
            islem.amount = entity.amount;
            islem.error_message = entity.error_message;
        }
        public override void doSil(int id, est_transactionVm entity)
        {
            est_transaction sil = new est_transaction();
            EntityKey silId = new EntityKey("b2cEntities.est_transaction", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
