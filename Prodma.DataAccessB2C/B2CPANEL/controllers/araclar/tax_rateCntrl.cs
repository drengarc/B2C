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
    public class tax_rateCntrl : BaseCtrl<tax_rateVm, int>
    {
        tax_rateService Service = new tax_rateService();
        public override List<tax_rateVm> doListe_Al(tax_rateVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(tax_rateVm entity)
        {
            tax_rate ekle = new tax_rate();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(tax_rateVm entity, int id)
        {
            tax_rate islem = new tax_rate();
            EntityKey guncelleId = new EntityKey("b2cEntities.tax_rate", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(tax_rate islem, tax_rateVm entity)
        {
            islem.category_id = entity.category_id;
            islem.tax_rate1 = entity.tax_rate;
            islem.date_added = entity.date_added;
        }
        public override void doSil(int id, tax_rateVm entity)
        {
            tax_rate sil = new tax_rate();
            EntityKey silId = new EntityKey("b2cEntities.tax_rate", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
