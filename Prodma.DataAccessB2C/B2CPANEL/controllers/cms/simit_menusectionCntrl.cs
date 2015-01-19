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
    public class simit_menusectionCntrl : BaseCtrl<simit_menusectionVm, int>
    {
        simit_menusectionService Service = new simit_menusectionService();
        public override List<simit_menusectionVm> doListe_Al(simit_menusectionVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(simit_menusectionVm entity)
        {
            simit_menusection ekle = new simit_menusection();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(simit_menusectionVm entity, int id)
        {
            simit_menusection islem = new simit_menusection();
            EntityKey guncelleId = new EntityKey("b2cEntities.simit_menusection", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(simit_menusection islem, simit_menusectionVm entity)
        {
            islem.name = entity.name;
        }
        public override void doSil(int id, simit_menusectionVm entity)
        {
            simit_menusection sil = new simit_menusection();
            EntityKey silId = new EntityKey("b2cEntities.simit_menusection", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
