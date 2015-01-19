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
    public class est_installmentalternativeCntrl : BaseCtrl<est_installmentalternativeVm, int>
    {
        est_installmentalternativeService Service = new est_installmentalternativeService();
        public override List<est_installmentalternativeVm> doListe_Al(est_installmentalternativeVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(est_installmentalternativeVm entity)
        {
            est_installmentalternative ekle = new est_installmentalternative();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(est_installmentalternativeVm entity, int id)
        {
            est_installmentalternative islem = new est_installmentalternative();
            EntityKey guncelleId = new EntityKey("b2cEntities.est_installmentalternative", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(est_installmentalternative islem, est_installmentalternativeVm entity)
        {
            islem.package_id = entity.package_id;
            islem.bank_id = entity.bank_id;
            islem.discount_percentage = entity.discount_percentage;
            islem.discount_amount = entity.discount_amount;
            islem.installment = entity.installment;
            islem.minimum_price = entity.minimum_price;
            islem.maximum_price = entity.maximum_price;
            islem.description = entity.description;
        }
        public override void doSil(int id, est_installmentalternativeVm entity)
        {
            est_installmentalternative sil = new est_installmentalternative();
            EntityKey silId = new EntityKey("b2cEntities.est_installmentalternative", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
