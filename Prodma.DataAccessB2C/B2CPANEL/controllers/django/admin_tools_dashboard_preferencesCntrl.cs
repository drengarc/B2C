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
    public class admin_tools_dashboard_preferencesCntrl : BaseCtrl<admin_tools_dashboard_preferencesVm, int>
    {
        admin_tools_dashboard_preferencesService Service = new admin_tools_dashboard_preferencesService();
        public override List<admin_tools_dashboard_preferencesVm> doListe_Al(admin_tools_dashboard_preferencesVm entity)
        {
            return Service.Service_Liste_Al(entity);
        }
        public override void doEkle(admin_tools_dashboard_preferencesVm entity)
        {
            admin_tools_dashboard_preferences ekle = new admin_tools_dashboard_preferences();
            EkleGuncelle(ekle, entity);
            Service.Service_Ekle(ekle); entity.id = ekle.id;
        }
        public override void doGuncelle(admin_tools_dashboard_preferencesVm entity, int id)
        {
            admin_tools_dashboard_preferences islem = new admin_tools_dashboard_preferences();
            EntityKey guncelleId = new EntityKey("b2cEntities.admin_tools_dashboard_preferences", "id", entity.id);
            islem.EntityKey = guncelleId;
            islem.id = id;
            EkleGuncelle(islem, entity);
            Service.Service_Guncelle(islem, islem.id);
        }
        void EkleGuncelle(admin_tools_dashboard_preferences islem, admin_tools_dashboard_preferencesVm entity)
        {
            islem.user_id = entity.user_id;
            islem.data = entity.data;
            islem.dashboard_id = entity.dashboard_id;
        }
        public override void doSil(int id, admin_tools_dashboard_preferencesVm entity)
        {
            admin_tools_dashboard_preferences sil = new admin_tools_dashboard_preferences();
            EntityKey silId = new EntityKey("b2cEntities.admin_tools_dashboard_preferences", "id", entity.id);
            sil.EntityKey = silId;
            sil.id = entity.id; 
            Service.Service_Sil(sil, id);
        }
    }    
 
}
