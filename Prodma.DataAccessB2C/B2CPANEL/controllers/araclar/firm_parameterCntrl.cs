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
    public class firm_parameterCntrl : BaseCtrl<firm_parameterVm, int>
    {
        firm_parameterService Service = new firm_parameterService();
        public override List<firm_parameterVm> doListe_Al(firm_parameterVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(firm_parameterVm entity)
        {
            firm_parameter ekle = new firm_parameter();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(firm_parameterVm entity, int id)
        {
            firm_parameter islem = new firm_parameter();
            EntityKey guncelleId = new EntityKey("b2cEntities.firm_parameter", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(firm_parameter islem, firm_parameterVm entity)
        {
            islem.name = entity.name;
            islem.redirect_to_basket = entity.redirect_to_basket;
            islem.min_price_for_cargo = entity.min_price_for_cargo;
        }
        public override void doSil(int id, firm_parameterVm entity)
        {
            firm_parameter sil = new firm_parameter();
            EntityKey silId = new EntityKey("b2cEntities.firm_parameter", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
