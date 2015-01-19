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
    public class ege_integration_productcompetitorrelationCntrl : BaseCtrl<ege_integration_productcompetitorrelationVm, int>
    {
        ege_integration_productcompetitorrelationService Service = new ege_integration_productcompetitorrelationService();
        public override List<ege_integration_productcompetitorrelationVm> doListe_Al(ege_integration_productcompetitorrelationVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(ege_integration_productcompetitorrelationVm entity)
        {
            ege_integration_productcompetitorrelation ekle = new ege_integration_productcompetitorrelation();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(ege_integration_productcompetitorrelationVm entity, int id)
        {
            ege_integration_productcompetitorrelation islem = new ege_integration_productcompetitorrelation();
            EntityKey guncelleId = new EntityKey("b2cEntities.ege_integration_productcompetitorrelation", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(ege_integration_productcompetitorrelation islem, ege_integration_productcompetitorrelationVm entity)
        {
            islem.product_id = entity.product_id;
            islem.competitor_product_code = entity.competitor_product_code;
            islem.competitor_manufacturer_id = entity.competitor_manufacturer_id;
        }
        public override void doSil(int id, ege_integration_productcompetitorrelationVm entity)
        {
            ege_integration_productcompetitorrelation sil = new ege_integration_productcompetitorrelation();
            EntityKey silId = new EntityKey("b2cEntities.ege_integration_productcompetitorrelation", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
