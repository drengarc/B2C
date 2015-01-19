using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.SistemB2C.Models;
using Prodma.SistemB2C.Services;
using Prodma.DataAccessB2C;
using System.Windows.Forms;  
namespace Prodma.SistemB2C.Controllers
{
    public class ExcelFiltreCntrl : BaseCtrl<ExcelFiltreVm, int>
    {
        ExcelFiltreService Service = new ExcelFiltreService();
        public override List<ExcelFiltreVm> doListe_Al(ExcelFiltreVm entity){
            return Service.Service_Liste_Al(entity);  
        }
        public override void doEkle(ExcelFiltreVm entity)
        {
                EXCEL_ALANLAR ekle = new EXCEL_ALANLAR();
                ekle.FILTRELER_ID = entity.FILTRELER_ID;
                ekle.ALAN_1 = entity.ALAN_1;
                ekle.ALAN_2 = entity.ALAN_2;
                ekle.ALAN_3 = entity.ALAN_3;
                ekle.ALAN_4 = entity.ALAN_4;
                ekle.ALAN_5 = entity.ALAN_5;
                ekle.ALAN_6 = entity.ALAN_6;
                ekle.ALAN_7 = entity.ALAN_7;
                ekle.ALAN_8 = entity.ALAN_8;
                ekle.ALAN_9 = entity.ALAN_9;
                ekle.ALAN_10 = entity.ALAN_10;
                entity.tabloAdi = "İç Dış";
                entity.ayrimAlan = "AD:" + entity.ALAN_1;
                Service.Service_Ekle(ekle); entity.ID = ekle.ID;
                entity.insertId = Service.insertId;
        }
        public override void doGuncelle(ExcelFiltreVm entity, int id)
        {
            EXCEL_ALANLAR guncelle = new EXCEL_ALANLAR();
            EntityKey guncelleId = new EntityKey("b2cEntities.EXCEL_ALANLAR", "ID", entity.ID);
            guncelle.EntityKey = guncelleId;
            guncelle.ID = entity.ID;
            guncelle.FILTRELER_ID = entity.FILTRELER_ID;
            guncelle.ALAN_1 = entity.ALAN_1;
            guncelle.ALAN_2 = entity.ALAN_2;
            guncelle.ALAN_3 = entity.ALAN_3;
            guncelle.ALAN_4 = entity.ALAN_4;
            guncelle.ALAN_5 = entity.ALAN_5;
            guncelle.ALAN_6 = entity.ALAN_6;
            guncelle.ALAN_7 = entity.ALAN_7;
            guncelle.ALAN_8 = entity.ALAN_8;
            guncelle.ALAN_9 = entity.ALAN_9;
            guncelle.ALAN_10 = entity.ALAN_10;
            entity.tabloAdi = "İç Dış";
            entity.ayrimAlan = "AD:" + entity.ALAN_1;
            Service.Service_Guncelle(guncelle, id);

        }
        public override void doSil(int id, ExcelFiltreVm entity)
        {

            EXCEL_ALANLAR sil = new EXCEL_ALANLAR();
            EntityKey silId = new EntityKey("b2cEntities.EXCEL_ALANLAR", "ID", entity.ID);
            sil.EntityKey = silId;
            sil.ID = entity.ID;
            entity.tabloAdi = "İç Dış";
            entity.ayrimAlan = "AD:" + entity.ALAN_1;
            Service.Service_Sil(sil, id);
            
        }

    }
}
