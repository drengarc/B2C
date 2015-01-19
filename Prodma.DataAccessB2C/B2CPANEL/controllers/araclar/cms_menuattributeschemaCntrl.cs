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
    public class cms_menuattributeschemaCntrl : BaseCtrl<cms_menuattributeschemaVm, int>
    {
        cms_menuattributeschemaService Service = new cms_menuattributeschemaService();
        public override List<cms_menuattributeschemaVm> doListe_Al(cms_menuattributeschemaVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(cms_menuattributeschemaVm entity)
        {
            cms_menuattributeschema ekle = new cms_menuattributeschema();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(cms_menuattributeschemaVm entity, int id)
        {
            cms_menuattributeschema islem = new cms_menuattributeschema();
            EntityKey guncelleId = new EntityKey("b2cEntities.cms_menuattributeschema", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(cms_menuattributeschema islem, cms_menuattributeschemaVm entity)
        {
            islem.title = entity.title;
            islem.name = entity.name;
            islem.help_text = entity.help_text;
            islem.datatype = entity.datatype;
            islem.required = entity.required;
            islem.searched = entity.searched;
            islem.filtered = entity.filtered;
            islem.sortable = entity.sortable;
        }
        public override void doSil(int id, cms_menuattributeschemaVm entity)
        {
            cms_menuattributeschema sil = new cms_menuattributeschema();
            EntityKey silId = new EntityKey("b2cEntities.cms_menuattributeschema", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
