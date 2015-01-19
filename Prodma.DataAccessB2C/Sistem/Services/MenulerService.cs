using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using System.Configuration;
using Prodma.DataAccessB2C;
using System.ComponentModel;
using System.Drawing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Prodma.SistemB2C.Models;
namespace Prodma.SistemB2C.Services
{
     public class MenulerService : AService<M_MENU, int, MenulerVm>
    {
        
        public override void doService_Guncelle(M_MENU entity, int id)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            { 
            context.Attach(entity);
            context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            context.SaveChanges();
            }
        }
        public override void doService_Sil(M_MENU entity, int id)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                context.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
                context.SaveChanges();
            }


        }
        public override void doService_Ekle(M_MENU entity)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                context.AddToM_MENU(entity);
                context.SaveChanges();
            }
        }
        public override List<MenulerVm> doService_Liste_Al(MenulerVm fVm)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                var list = (from kul in context.M_MENU
                            select new MenulerVm
                                {
                                    ID = kul.ID,
                                    M_MENU_ID = kul.M_MENU_ID,
                                    M_MENU_TIP_ID = kul.M_MENU_TIP_ID,
                                    AD = kul.AD,
                                    URL = kul.URL,
                                    HEDEF = kul.HEDEF,
                                    DIL_ID = kul.DIL_ID,
                                    LK_DURUM_ID = kul.LK_DURUM_ID,
                                    MENU_SIRA = kul.MENU_SIRA,
                                    ASSEMBLY_NAME = kul.ASSEMBLY_NAME
                                }).OrderBy(x => x.M_MENU_ID).ThenBy(x => x.MENU_SIRA);
                if (fVm != null)
                {
                    List<MenulerVm> t;
                    t = fVm.ID == 0 ? list.WhereByExample(fVm, "ID").ToList() : list.Where(x => x.ID == fVm.ID).ToList();
                    return t;
                }
                else
                {
                    return list.ToList();
                }
            }
        }


        public  List<MenulerVm> Liste_Al(MenulerVm fVm,int kullaniciId)
        {
            //from sonuc in j1.Where(w=>w.KULLANICI_ID== kullaniciId && w.GORMESIN_E_H != true).DefaultIfEmpty()
            //    YETKILER = new YetkilerVm { ID = sonuc.ID, GORMESIN_E_H = sonuc.GORMESIN_E_H },
            //insertId = yet.ID,
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                var list = (from kul in context.M_MENU
                            join yet in context.YETKI
                            on kul.ID equals yet.M_MENU_ID into j1
                            from sonuc in j1.Where(w=>w.KULLANICI_ID==kullaniciId && w.LK_DURUM_ID==(int)DurumEn.Aktif).DefaultIfEmpty()
                            where kul.LK_DURUM_ID==(int)DurumEn.Aktif
                            select new MenulerVm
                            {
                                ID = kul.ID,
                                M_MENU_ID = kul.M_MENU_ID,
                                M_MENU_TIP_ID = kul.M_MENU_TIP_ID,
                                AD = kul.AD,
                                URL = kul.URL,
                                HEDEF = kul.HEDEF,
                                DIL_ID = kul.DIL_ID,
                                LK_DURUM_ID = kul.LK_DURUM_ID,
                                MENU_SIRA = kul.MENU_SIRA,
                                ASSEMBLY_NAME = kul.ASSEMBLY_NAME,
                                KULLANICI_GORMESIN = sonuc.GORMESIN_E_H,
                            }).OrderBy(x => x.M_MENU_ID).ThenBy(x => x.MENU_SIRA).ToList();
                //if (fVm != null)
                //{
                //    List<MenulerVm> t;
                //    t = fVm.ID == 0 ? list.WhereByExample(fVm, "ID").ToList() : list.Where(x => x.ID == fVm.ID).ToList();
                //    return t;
                //}
                //else
                //{
                    return list;
                //}
                //return list;
            }
        }
    }
}
