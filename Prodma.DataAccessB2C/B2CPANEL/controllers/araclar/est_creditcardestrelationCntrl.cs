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
    public class est_creditcardestrelationCntrl : BaseCtrl<est_creditcardestrelationVm, int>
    {
        est_creditcardestrelationService Service = new est_creditcardestrelationService();
        public override List<est_creditcardestrelationVm> doListe_Al(est_creditcardestrelationVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(est_creditcardestrelationVm entity)
        {
            est_creditcardestrelation ekle = new est_creditcardestrelation();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(est_creditcardestrelationVm entity, int id)
        {
            est_creditcardestrelation islem = new est_creditcardestrelation();
            EntityKey guncelleId = new EntityKey("b2cEntities.est_creditcardestrelation", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(est_creditcardestrelation islem, est_creditcardestrelationVm entity)
        {
            islem.bin_id = entity.bin_id;
            islem.est_cash_id = entity.est_cash_id;
            islem.est_installment_id = entity.est_installment_id;
        }
        public override void doSil(int id, est_creditcardestrelationVm entity)
        {
            est_creditcardestrelation sil = new est_creditcardestrelation();
            EntityKey silId = new EntityKey("b2cEntities.est_creditcardestrelation", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
