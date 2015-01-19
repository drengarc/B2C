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
    public class est_estcredentialCntrl : BaseCtrl<est_estcredentialVm, int>
    {
        est_estcredentialService Service = new est_estcredentialService();
        public override List<est_estcredentialVm> doListe_Al(est_estcredentialVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(est_estcredentialVm entity)
        {
            est_estcredential ekle = new est_estcredential();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(est_estcredentialVm entity, int id)
        {
            est_estcredential islem = new est_estcredential();
            EntityKey guncelleId = new EntityKey("b2cEntities.est_estcredential", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(est_estcredential islem, est_estcredentialVm entity)
        {
            islem.bank   = entity.bank;
            //islem.company = entity.company;
            islem.username = entity.username;
            islem.password = entity.password;
            islem.client_id = entity.client_id;
            islem.secret_key = entity.secret_key;
        }
        public override void doSil(int id, est_estcredentialVm entity)
        {
            est_estcredential sil = new est_estcredential();
            EntityKey silId = new EntityKey("b2cEntities.est_estcredential", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
