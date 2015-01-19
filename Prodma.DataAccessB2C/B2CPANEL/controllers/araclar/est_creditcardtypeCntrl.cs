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
    public class est_creditcardtypeCntrl : BaseCtrl<est_creditcardtypeVm, int>
    {
        est_creditcardtypeService Service = new est_creditcardtypeService();
        public override List<est_creditcardtypeVm> doListe_Al(est_creditcardtypeVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(est_creditcardtypeVm entity)
        {
            est_creditcardtype ekle = new est_creditcardtype();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); //entity.id = ekle.id;
        }
        public override void doGuncelle(est_creditcardtypeVm entity, int id)
        {
            //est_creditcardtype islem = new est_creditcardtype();
            //EntityKey guncelleId = new EntityKey("b2cEntities.est_creditcardtype", "id", entity.id);
            //islem.EntityKey = guncelleId;
            //islem.id = id;
            //EkleGuncelle(islem, entity);
            //Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(est_creditcardtype islem, est_creditcardtypeVm entity)
        {
            islem.bank_id = entity.bank_id;
            islem.image = entity.image;
            islem.bin = entity.bin;
            islem.type = entity.type;
            islem.subtype = entity.subtype;
        }
        public override void doSil(int id, est_creditcardtypeVm entity)
        {
            //est_creditcardtype sil = new est_creditcardtype();
            //EntityKey silId = new EntityKey("b2cEntities.est_creditcardtype", "id", entity.id);
            //sil.EntityKey = silId;
            //sil.id = entity.id; 
            //Service.Service_Sil(sil, id);
        }
    }    
 
}
