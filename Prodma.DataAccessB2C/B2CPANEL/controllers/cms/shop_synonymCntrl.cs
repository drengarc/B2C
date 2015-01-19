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
    public class shop_synonymCntrl : BaseCtrl<shop_synonymVm, int>
    {
        shop_synonymService Service = new shop_synonymService();
        public override List<shop_synonymVm> doListe_Al(shop_synonymVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(shop_synonymVm entity)
        {
            shop_synonym ekle = new shop_synonym();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(shop_synonymVm entity, int id)
        {
            shop_synonym islem = new shop_synonym();
            EntityKey guncelleId = new EntityKey("b2cEntities.shop_synonym", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(shop_synonym islem, shop_synonymVm entity)
        {
            islem.from_text = entity.from_text;
            islem.to_text = entity.to_text;
        }
        public override void doSil(int id, shop_synonymVm entity)
        {
            shop_synonym sil = new shop_synonym();
            EntityKey silId = new EntityKey("b2cEntities.shop_synonym", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
