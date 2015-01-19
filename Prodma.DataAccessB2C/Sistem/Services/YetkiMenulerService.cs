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
     public class YetkiMenulerService :  AService<YETKI,int,YetkiMenulerVm>
    {
        b2cEntities context = new  b2cEntities();
        public override void doService_Guncelle(YETKI entity, int id)
        {
            b2cEntities context = new b2cEntities();
             using (context)
             {
            context.Attach(entity);
            context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            context.SaveChanges(); 
             }
        }
        public override void doService_Sil(YETKI entity, int id)
        {

             b2cEntities context = new  b2cEntities();
             using (context)
             {
            context.Attach(entity);
            context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
            context.SaveChanges();
         
             }
        }
        public override void doService_Ekle(YETKI entity)
        { b2cEntities context = new  b2cEntities();
             using (context)
             {
                context.AddToYETKI(entity);
                context.SaveChanges();
             }
        }
        public override List<YetkiMenulerVm> doService_Liste_Al(YetkiMenulerVm fVm)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (fVm.ListeFiltresi == "1")
                {
                    var list = (from ya in context.YETKI
                                join ma in context.M_MENU
                                on ya.M_MENU_ID equals ma.ID
                                where ya.KULLANICI_ID == fVm.KULLANICI_ID && ma.M_MENU_ID == fVm.M_MENU_ID
                                select new YetkiMenulerVm
                                    {
                                        ID = ya.ID,
                                        KULLANICI_ID = ya.KULLANICI_ID,
                                        M_MENU_UST_ID = ma.M_MENU_ID,
                                        M_MENU_ID = ya.M_MENU_ID,
                                        OKU_E_H = ya.OKU_E_H,
                                        YAZ_E_H = ya.YAZ_E_H,
                                        GUNCELLE_E_H = ya.GUNCELLE_E_H,
                                        GORMESIN_E_H = ya.GORMESIN_E_H,
                                        SIL_E_H = ya.SIL_E_H,
                                        LK_DURUM_ID = ya.LK_DURUM_ID,
                                    });
                    if (fVm != null)
                    {
                        return list.ToList();
                    }
                    else
                    {
                        return list.ToList();
                    }
                }
                else if ( fVm.M_MENU_ID != 0)
                {
                    var list = (from ya in context.YETKI
                                join ma in context.M_MENU
                                on ya.M_MENU_ID equals ma.ID
                                where ya.KULLANICI_ID == fVm.KULLANICI_ID && ya.M_MENU_ID == fVm.M_MENU_ID
                                select new YetkiMenulerVm
                                {
                                    ID = ya.ID,
                                    KULLANICI_ID = ya.KULLANICI_ID,
                                    M_MENU_UST_ID = ma.M_MENU_ID,
                                    M_MENU_ID = ya.M_MENU_ID,
                                    OKU_E_H = ya.OKU_E_H,
                                    YAZ_E_H = ya.YAZ_E_H,
                                    GUNCELLE_E_H = ya.GUNCELLE_E_H,
                                    GORMESIN_E_H = ya.GORMESIN_E_H,
                                    SIL_E_H = ya.SIL_E_H,
                                    LK_DURUM_ID = ya.LK_DURUM_ID,
                                });
                    if (fVm != null)
                    {
                        return list.ToList();
                    }
                    else
                    {
                        return list.ToList();
                    }
                }
                else
                {
                    var list = (from ya in context.YETKI
                                join ma in context.M_MENU
                                on ya.M_MENU_ID equals ma.ID
                                where ya.KULLANICI_ID == fVm.KULLANICI_ID
                                select new YetkiMenulerVm
                                {
                                    ID = ya.ID,
                                    KULLANICI_ID = ya.KULLANICI_ID,
                                    M_MENU_UST_ID = ma.M_MENU_ID,
                                    M_MENU_ID = ya.M_MENU_ID,
                                    OKU_E_H = ya.OKU_E_H,
                                    YAZ_E_H = ya.YAZ_E_H,
                                    GUNCELLE_E_H = ya.GUNCELLE_E_H,
                                    SIL_E_H = ya.SIL_E_H,
                                    GORMESIN_E_H = ya.GORMESIN_E_H,
                                    LK_DURUM_ID = ya.LK_DURUM_ID,
                                });
                    //if (fVm != null)
                    //{
                    //    List<YetkiMenulerVm> t;
                    //    t = fVm.ID == 0 ? list.WhereByExample(fVm, "ID").ToList() : list.Where(x => x.ID == fVm.ID).ToList();
                    //    return t;
                    //}
                    //else
                    //{
                        return list.ToList();
                    //}
                }
            }

        }
        public  List<YetkiMenulerVm> Service_Liste_Al_Filtreli(YetkiMenulerVm fVm)
        {
             b2cEntities context = new  b2cEntities();
             using (context)
             {
            if (fVm.M_MENU_ID != 0)
            {
                var list = (from ya in context.YETKI
                            join ma in context.M_MENU
                            on ya.M_MENU_ID equals ma.ID
                            where ya.KULLANICI_ID == fVm.KULLANICI_ID && ma.M_MENU_ID == fVm.M_MENU_ID 
                            select new YetkiMenulerVm
                            {
                                ID = ya.ID,
                                KULLANICI_ID = ya.KULLANICI_ID,
                                M_MENU_UST_ID = ma.M_MENU_ID,
                                M_MENU_ID = ya.M_MENU_ID,
                                OKU_E_H = ya.OKU_E_H,
                                YAZ_E_H = ya.YAZ_E_H,
                                GUNCELLE_E_H = ya.GUNCELLE_E_H,
                                GORMESIN_E_H = ya.GORMESIN_E_H,
                                SIL_E_H = ya.SIL_E_H,
                                LK_DURUM_ID = ya.LK_DURUM_ID,
                            });
                if (fVm != null)
                {
                    return list.ToList();
                }
                else
                {
                    return list.ToList();
                }
            }
            return null;
        }
      }
     }
}
