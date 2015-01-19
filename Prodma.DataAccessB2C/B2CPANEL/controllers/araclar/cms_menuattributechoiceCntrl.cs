using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.DataAccess;
using System.Windows.Forms;
using B2C.Models;
using B2C.Services;
namespace B2C.Controllers
{
    public class cms_menuattributechoiceCntrl : BaseCtrl<cms_menuattributechoiceVm, int>
    {
        cms_menuattributechoiceService Service = new cms_menuattributechoiceService();
        public override List<cms_menuattributechoiceVm> doListe_Al(cms_menuattributechoiceVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(cms_menuattributechoiceVm entity)
        {
            cms_menuattributechoice ekle = new cms_menuattributechoice();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(cms_menuattributechoiceVm entity, int id)
        {
            cms_menuattributechoice islem = new cms_menuattributechoice();
            EntityKey guncelleId = new EntityKey("b2cEntities.cms_menuattributechoice", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(cms_menuattributechoice islem, cms_menuattributechoiceVm entity)
        {
            islem.title = entity.title;
            islem.schema_id = entity.schema_id;
        }
        public override void doSil(int id, cms_menuattributechoiceVm entity)
        {
            cms_menuattributechoice sil = new cms_menuattributechoice();
            EntityKey silId = new EntityKey("b2cEntities.cms_menuattributechoice", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
