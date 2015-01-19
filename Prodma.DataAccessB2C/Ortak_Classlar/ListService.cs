using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.ComponentModel;
using System.Drawing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Reflection;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Prodma.SistemB2C.Models;
using System.Globalization;
using System.Data.Objects.SqlClient;
using System.Linq.DynamicB2C;
namespace Prodma.DataAccessB2C
{
     public class ListService
    {
        public static Object InvokeMethod(string methodName, int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
         {
             string ns = "Prodma.DataAccessB2C";
             string tn = "ListService";
             string an = "Prodma.DataAccessB2C";
             Type calledType = Type.GetType(ns + "." + tn + "," + an);
             MethodInfo methodInfo = calledType.GetMethod(methodName);
             if (methodInfo != null)
             {
                 object result = null;
                 ParameterInfo[] parameters = methodInfo.GetParameters();
                 object classInstance = Activator.CreateInstance(calledType, null);
                 if (parameters.Length == 0)
                 {
                     //This works fine
                     result = methodInfo.Invoke(classInstance, null);
                     return result;
                 }
                 else 
                 {
                     object[] parametersArray = new object[] {  ListServiceTip,  aktifTipID,   inID,   alan_id,  ust_id,  strAlan, tempStr,  tempInt};

                     //The invoke does NOT work it throws "Object does not match target type"             
                     result = methodInfo.Invoke(classInstance, parametersArray);
                     return result;
                 }
             }
             else  
             { return null; }



             //Object s = (Object)calledType.InvokeMember(methodName, System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static, null, null, null);

         }
        private static object YetkiKontrol(int inID,int alan_id,int kullanici_id)
        {
             b2cEntities context = new  b2cEntities();
            using (context)
            {
                  var list = (from kul in context.YETKI_ALANLAR
                              where kul.KULLANICI_ID == kullanici_id && kul.M_ALANLAR_ALT_ID == inID && kul.M_ALANLAR_ID == alan_id 
                                select kul).ToList();
                  if (list.Count > 0)
                  {
                      return list[0].YAZMASIN_E_H != (int)EvetHayirEn.Evet;
                  }
                  return true;
            }
        }
        public static Object GetFIRMA_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.FIRMA
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.FIRMA
                                where kul.ID == inID
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.FIRMA
                                where kul.AD == strAlan
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAKTIF)
                {
                    var list = (from kul in context.FIRMA
                                where kul.ID == inID// && kul.LK_DURUM_ID == (int)EvetHayirEn.Evet
                                select kul.ID).SingleOrDefault();
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetKULLANICI_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.KULLANICI
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.AD
                                }).OrderBy(o=>o.AD).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.KULLANICI
                                where kul.ID == inID
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.KULLANICI
                                where kul.AD == strAlan
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAKTIF)
                {
                    var list = (from kul in context.KULLANICI
                                where kul.ID == inID && kul.LK_DURUM_ID == (int)EvetHayirEn.Evet
                                select kul.ID).SingleOrDefault();
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetAKTIF_KULLANICI_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.KULLANICI
                                where kul.LK_DURUM_ID == (int)DurumEn.Aktif
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.AD
                                }).OrderBy(o => o.AD).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.KULLANICI
                                where kul.ID == inID && kul.LK_DURUM_ID == (int)DurumEn.Aktif
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.KULLANICI
                                where kul.AD == strAlan && kul.LK_DURUM_ID == (int)DurumEn.Aktif
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAKTIF)
                {
                    var list = (from kul in context.KULLANICI
                                where kul.ID == inID && kul.LK_DURUM_ID == (int)EvetHayirEn.Evet
                                select kul.ID).SingleOrDefault();
                    return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetLog(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.Log
                                select new LogIlkVm  
                                {
                                    id = kul.Id,
                                    Date = kul.Date,
                                    Message = kul.Message,
                                    Level = kul.Level,
                                }).OrderByDescending(x => x.id).ToList();
                    foreach (var item in list)
                    {
                        string[] selected = item.Message.ToString().Split('‡');
                        foreach (var item1 in selected)
                        {
                            if (item1 != "")
                            {
                                string[] a = item1.Split('»');
                                if (a[0] != "Alan" && a[0] != "Işlem" && a[0] != "Kullanici" && a[0] != "IslemNedeni" && a[0] != "ID")
                                {
                                    string[] sonuc = a[0].Split('#');
                                    if (sonuc.Length>1)
                                       item.Tablo = sonuc[0];
                                }
                                else if (a[0] == "Kullanici")
                                {
                                    if (a.Length > 0)
                                    item.Kullanici = a[1];
                                }
                            }
                        }
                    }
                    return list;
                }
            }
            return null;
        }
        public static Object GetLK_DURUM_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.LK_DURUM
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.LK_DURUM
                                where kul.ID == inID
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.LK_DURUM
                                where kul.AD == strAlan
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
                
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetM_ALANLAR_ALAN_TABLOSU_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.M_ALANLAR_ID == 0
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.ALAN_AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ID == inID && kul.M_ALANLAR_ID == 0
                                select kul.ALAN_AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ALAN_AD == strAlan && kul.M_ALANLAR_ID == 0
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAKTIF)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ID == inID && kul.LK_DURUM_ID == (int)EvetHayirEn.Evet && kul.M_ALANLAR_ID == 0
                                select kul.ID).SingleOrDefault();
                    return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetALANLAR_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.M_ALANLAR
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.ALAN_AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ID == inID
                                select kul.ALAN_AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ALAN_AD == strAlan
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAKTIF)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ID == inID && kul.LK_DURUM_ID == (int)EvetHayirEn.Evet
                                select kul.ID).SingleOrDefault();
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetM_ALANLAR_UST_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.M_ALANLAR_ID == 0
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.ALAN_AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ID == inID && kul.M_ALANLAR_ID == 0
                                select kul.ALAN_AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ALAN_AD == strAlan && kul.M_ALANLAR_ID == 0
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAKTIF)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ID == inID && kul.LK_DURUM_ID == (int)EvetHayirEn.Evet
                                select kul.ID).SingleOrDefault();
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetM_ALANLAR_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.M_ALANLAR
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.ALAN_AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ID == inID
                                select kul.ALAN_AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ALAN_AD == strAlan 
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAKTIF)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ID == inID && kul.LK_DURUM_ID == (int)EvetHayirEn.Evet
                                select kul.ID).SingleOrDefault();
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetM_ALANLAR_ID_BY_PARAM(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.M_ALANLAR_ID == ust_id
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.ALAN_AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ID == inID && kul.M_ALANLAR_ID == ust_id
                                select kul.ALAN_AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ALAN_AD == strAlan && kul.M_ALANLAR_ID == ust_id
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAKTIF)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ID == inID && kul.LK_DURUM_ID == (int)EvetHayirEn.Evet
                                select kul.ID).SingleOrDefault();
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetM_ALANLAR_AD_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {

            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.M_ALANLAR
                                select new IdAdVm
                                {
                                    AD = kul.ALAN_AD
                                }).Distinct().ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.ID == inID
                                select kul.ALAN_AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else
                {
                    var list = (from kul in context.YETKI_ALANLAR
                                where kul.M_ALANLAR_ALT_ID == inID && kul.M_ALANLAR_ID == alan_id
                                select kul).SingleOrDefault();
                    if (list == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    //return Convert.ToString(list);
                }
            }
        }
        public static Object GetM_ALAN_TIP_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                var list = (from kul in context.M_ALAN_TIP
                            select new IdAdVm
                            {
                                ID = kul.ID,
                                AD = kul.AD
                            }).ToList();
                return list;
                          }
                if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.M_ALAN_TIP
                                where kul.ID == inID
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                 else
                 {
                     var list = (from kul in context.YETKI_ALANLAR
                                 where kul.M_ALANLAR_ALT_ID == inID && kul.M_ALANLAR_ID == alan_id
                                 select kul).SingleOrDefault();
                     if (list == null)
                     {
                         return true;
                     }
                     else
                     {
                         return false;
                     }
                     //return Convert.ToString(list);
                 }
            }
        }
        public static Object GetM_ALAN_GOSTERILEN_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.M_ALAN_GOSTERILEN
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.M_ALAN_GOSTERILEN
                                where kul.ID == inID
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.M_ALAN_GOSTERILEN
                                where kul.AD == strAlan
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
               
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        //public static Object GetM_TABLO_TIP_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new  b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.M_TABLO_TIP
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.ID,
        //                            AD = kul.AD
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.M_TABLO_TIP
        //                        where kul.ID == inID
        //                        select kul.AD).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.M_TABLO_TIP
        //                        where kul.AD == strAlan
        //                        select kul.ID).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //             return Convert.ToInt32(list);
        //        }
              
        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        public static Object GetM_MENU_UST_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.M_MENU
                                where kul.M_MENU_ID == 0
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.M_MENU
                                where kul.ID == inID && kul.M_MENU_ID == 0
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.M_MENU
                                where kul.AD == strAlan && kul.M_MENU_ID == 0
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAKTIF)
                {
                    var list = (from kul in context.M_MENU
                                where kul.ID == inID && kul.LK_DURUM_ID == (int)EvetHayirEn.Evet
                                select kul.ID).SingleOrDefault();
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetM_MENU_TIP_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.M_MENU_TIP
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.M_MENU_TIP
                                where kul.ID == inID
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.M_MENU_TIP
                                where kul.AD == strAlan
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAKTIF)
                {
                    var list = (from kul in context.M_MENU_TIP
                                where kul.ID == inID //&& kul.LK_DURUM_ID == (int)EvetHayirEn.Evet
                                select kul.ID).SingleOrDefault();
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetM_MENU_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            //MessageBox.Show("data1");
            b2cEntities context = new  b2cEntities();
           // MessageBox.Show("data3");
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                  //  MessageBox.Show("data4");
                  //  MessageBox.Show("data4_1");
                    try
                    {
                        var list = (from kul in context.M_MENU
                                    select new IdAdVm
                                    {
                                        ID = kul.ID,
                                        AD = kul.AD
                                    }).ToList();
                        return list;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message.ToString());
                        MessageBox.Show(ex.InnerException.Message.ToString());
                    }
                  
                  //  MessageBox.Show("data5");
                    
                    
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.M_MENU
                                where kul.ID == inID
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.M_MENU
                                where kul.AD == strAlan
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAKTIF)
                {
                    var list = (from kul in context.M_MENU
                                where kul.ID == inID && kul.LK_DURUM_ID == (int)EvetHayirEn.Evet
                                select kul.ID).SingleOrDefault();
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }

            return null;
        }
        public static Object GetM_MENU_ID_BY_PARAM(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.M_MENU
                                where kul.M_MENU_ID == ust_id
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.M_MENU
                                where kul.ID == inID && kul.M_MENU_ID == ust_id
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.M_MENU
                                where kul.AD == strAlan && kul.M_MENU_ID == ust_id
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAKTIF)
                {
                    var list = (from kul in context.M_MENU
                                where kul.ID == inID && kul.LK_DURUM_ID == (int)EvetHayirEn.Evet
                                select kul.ID).SingleOrDefault();
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        //public static Object GetRENK_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new  b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.RENK
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.ID,
        //                            AD = kul.AD
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.RENK
        //                        where kul.ID == inID
        //                        select kul.AD ).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            var list = (from kul in context.RENK
        //                        where kul.ID == inID
        //                        select kul.AD).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.RENK
        //                        where kul.ID == inID
        //                        select kul.AD).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            var list = (from kul in context.RENK
        //                        where kul.AD == strAlan
        //                        select kul.ID).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //             return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.RENK
        //                        where kul.AD == strAlan
        //                        select kul.ID).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //             return Convert.ToInt32(list);
        //        }
            
        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        public static Object GetROL_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.ROL
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.ROL
                                where kul.ID == inID
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.ROL
                                where kul.AD == strAlan
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAKTIF)
                {
                    var list = (from kul in context.ROL
                                where kul.ID == inID && kul.LK_DURUM_ID == (int)EvetHayirEn.Evet
                                select kul.ID).SingleOrDefault();
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetDurumID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.LK_DURUM
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.LK_DURUM
                                where kul.ID == inID
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.LK_DURUM
                                where kul.AD == strAlan
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAKTIF)
                {
                    //var list = (from kul in context.LK_DURUM
                    //            where kul.ID == inID && kul.LK_DURUM_ID == (int)EvetHayirEn.Evet
                    //            select kul.ID).SingleOrDefault();
                    return 0;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetYETKI_ISLEM_SAHIBI_TANITIM_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.YETKI_ISLEM_SAHIBI_TANITIM
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.KOD + "-" + kul.AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.YETKI_ISLEM_SAHIBI_TANITIM
                                where kul.ID == inID
                                select kul.KOD + "-" + kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    var list = (from kul in context.YETKI_ISLEM_SAHIBI_TANITIM
                                where kul.ID == inID
                                select kul.KOD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.YETKI_ISLEM_SAHIBI_TANITIM
                                where kul.ID == inID
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    var list = (from kul in context.YETKI_ISLEM_SAHIBI_TANITIM
                                where kul.KOD == strAlan
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.YETKI_ISLEM_SAHIBI_TANITIM
                                where kul.AD == strAlan
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
               
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetYETKI_ISLEM_TANTIM_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.YETKI_ISLEM_TANITIM
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.KOD + "-" + kul.AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.YETKI_ISLEM_TANITIM
                                where kul.ID == inID
                                select kul.KOD + "-" + kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    var list = (from kul in context.YETKI_ISLEM_TANITIM
                                where kul.ID == inID
                                select kul.KOD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.YETKI_ISLEM_TANITIM
                                where kul.ID == inID
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    var list = (from kul in context.YETKI_ISLEM_TANITIM
                                where kul.KOD == strAlan
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.YETKI_ISLEM_TANITIM
                                where kul.AD == strAlan
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                     return Convert.ToInt32(list);
                }
               
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object GetYETKI_ISLEM_SAHIBI_TIP_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD =  kul.AD
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                                where kul.ID == inID
                                select   kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                                where kul.ID == inID
                                select kul.AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                                where kul.AD == strAlan
                                select kul.ID).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        //public static Object GetLK_HAYIR_EVET_ID(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.LK_HAYIR_EVET
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.ID,
        //                            AD = kul.AD
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.LK_HAYIR_EVET
        //                        where kul.ID == inID
        //                        select kul.AD).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.LK_HAYIR_EVET
        //                        where kul.AD == strAlan
        //                        select kul.ID).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}

        
        public static object GetLK_HAYIR_EVET_ID(int p, int p_2, int p_3, int p_4, int p_5, string p_6, string p_7, int p_8)
        {
              b2cEntities context = new b2cEntities();
              using (context)
              {
                var list = (from kul in context.LK_HAYIR_EVET
                            select new IdAdVm
                            {
                                ID = kul.ID,
                                AD = kul.AD
                            }).ToList();
                return list;
              }
        }


        public static Object Getauth_group_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.auth_group
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.auth_group
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.auth_group
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.auth_group
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }

        //public static Object Getauth_group_permissions_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.auth_group_permissions
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.auth_group_permissions
        //                        where kul.id == inID
        //                        select kul.name).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.auth_group_permissions
        //                        where kul.id == inID
        //                        select kul.name).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.auth_group_permissions
        //                        where kul.name == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        public static Object Getauth_permission_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.auth_permission
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.codename
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.auth_permission
                                where kul.id == inID
                                select kul.codename).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.auth_permission
                                where kul.id == inID
                                select kul.codename).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.auth_permission
                                where kul.codename == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getdjango_content_type_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.django_content_type
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.django_content_type
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.django_content_type
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.django_content_type
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getauth_user_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.auth_user
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.email
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.auth_user
                                where kul.id == inID
                                select kul.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.auth_user
                                where kul.id == inID
                                select kul.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.auth_user
                                where kul.email == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getuser_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.auth_user
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.email
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.auth_user
                                where kul.id == inID
                                select kul.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.auth_user
                                where kul.id == inID
                                select kul.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.auth_user
                                where kul.email == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getcustomer_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.auth_user
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.email
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.auth_user
                                where kul.id == inID
                                select kul.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.auth_user
                                where kul.id == inID
                                select kul.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.auth_user
                                where kul.email == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getauth_user_groups_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.auth_user_groups
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.auth_user.email,
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.auth_user_groups
                                where kul.id == inID
                                select kul.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.auth_user_groups
                                where kul.id == inID
                                select kul.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.auth_user_groups
                                where kul.auth_user.email == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getauth_user_user_permissions_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.auth_user_user_permissions
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.auth_user.email
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.auth_user_user_permissions
                                where kul.id == inID
                                select kul.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.auth_user_user_permissions
                                where kul.id == inID
                                select kul.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.auth_user_user_permissions
                                where kul.auth_user.email == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getbanner_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.banner
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.title
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.banner
                                where kul.id == inID
                                select kul.title).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.banner
                                where kul.id == inID
                                select kul.title).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.banner
                                where kul.title == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getbanner_area_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.banner_area
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.banner_area
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.banner_area
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.banner_area
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getcategory_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.category
                                where kul.level == 2
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.category2.category2.name + ">>>" + kul.category2.name + ">>>" + kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.category
                                where kul.id == inID && kul.level == 1
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.category
                                where kul.id == inID && kul.level == 1
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.category
                                where kul.name == strAlan && kul.level == 1
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getcategory_alt_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.category
                                where kul.level == 1
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.category
                                where kul.id == inID && kul.level == 1
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.category
                                where kul.id == inID && kul.level == 1
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.category
                                where kul.name == strAlan && kul.level == 1
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getcategory_ust_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.category
                                where kul.level == 0
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.category
                                where kul.id == inID && kul.level == 0
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.category
                                where kul.id == inID && kul.level == 0
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.category
                                where kul.name == strAlan && kul.level == 1
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        //public static Object Getcategory_attribute_choice_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.category_attribute_choice
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.title
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.category_attribute_choice
        //                        where kul.id == inID
        //                        select kul.title).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.category_attribute_choice
        //                        where kul.id == inID
        //                        select kul.title).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.category_attribute_choice
        //                        where kul.title == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        //public static Object Getcategory_attribute_schema_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.category_attribute_schema
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.name
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.category_attribute_schema
        //                        where kul.id == inID
        //                        select kul.name).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.category_attribute_schema
        //                        where kul.id == inID
        //                        select kul.name).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.category_attribute_schema
        //                        where kul.name == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        //public static Object Getcategory_attribute_value_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.category_attribute_value
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.django_content_type.name
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.category_attribute_value
        //                        where kul.id == inID
        //                        select kul.django_content_type.name).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.category_attribute_value
        //                        where kul.id == inID
        //                        select kul.django_content_type.name).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.category_attribute_value
        //                        where kul.django_content_type.name == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        public static Object Getcity_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.city
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.city
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.city
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.city
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getsimit_customarea_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.simit_customarea
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.simit_customarea
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.simit_customarea
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.simit_customarea
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getsimit_customareacategory_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.simit_customareacategory
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.simit_customareacategory
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.simit_customareacategory
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.simit_customareacategory
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getsimit_menu_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.simit_menu
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.description
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.simit_menu
                                where kul.id == inID
                                select kul.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.simit_menu
                                where kul.id == inID
                                select kul.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.simit_menu
                                where kul.description == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getsimit_menusection_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.simit_menusection
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.simit_menusection
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.simit_menusection
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.simit_menusection
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getsimit_page_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.simit_page
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.simit_page
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.simit_page
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.simit_page
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getcountry_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.country
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.country
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.country
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.country
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getcustomer_address_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.customer_address
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.auth_user.email
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.customer_address
                                where kul.id == inID
                                select kul.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.customer_address
                                where kul.id == inID
                                select kul.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.customer_address
                                where kul.auth_user.email == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getcustomer_basket_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.customer_basket
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.auth_user.email
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.customer_basket
                                where kul.id == inID
                                select kul.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.customer_basket
                                where kul.id == inID
                                select kul.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.customer_basket
                                where kul.auth_user.email == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getcustomer_group_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.customer_group
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.customer_group
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.customer_group
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.customer_group
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getcustomergroup_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.customer_group
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.customer_group
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.customer_group
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.customer_group
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getdiscount_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.discount
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.discount
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.discount
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.discount
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getdiscount_category_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.discount_category
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.discount.name,
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.discount_category
                                where kul.id == inID
                                select kul.discount.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.discount_category
                                where kul.id == inID
                                select kul.discount.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.discount_category
                                where kul.discount.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getdiscount_customer_group_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.discount_customer_group
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.discount.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.discount_customer_group
                                where kul.id == inID
                                select kul.discount.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.discount_customer_group
                                where kul.id == inID
                                select kul.discount.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.discount_customer_group
                                where kul.discount.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getdiscount_product_tag_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.discount_product_tag
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.discount.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.discount_product_tag
                                where kul.id == inID
                                select kul.discount.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.discount_product_tag
                                where kul.id == inID
                                select kul.discount.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.discount_product_tag
                                where kul.discount.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getdjango_admin_log_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.django_admin_log
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.django_content_type.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.django_admin_log
                                where kul.id == inID
                                select kul.django_content_type.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.django_admin_log
                                where kul.id == inID
                                select kul.django_content_type.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.django_admin_log
                                where kul.django_content_type.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getdjango_session_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            //b2cEntities context = new b2cEntities();
            //using (context)
            //{
            //    if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
            //    {
            //        var list = (from kul in context.django_session
            //                    select new IdAdVm
            //                    {
            //                        ID = kul.id,
            //                        AD = kul.session_key
            //                    }).ToList();
            //        return list;
            //    }
            //    else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
            //    {
            //        var list = (from kul in context.django_session
            //                    where kul.id == inID
            //                    select kul.session_key).SingleOrDefault();
            //        return Convert.ToString(list);
            //    }
            //    else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
            //    {
            //        //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
            //        //            where kul.ID == inID
            //        //            select kul.KOD).SingleOrDefault();
            //        //return Convert.ToString(list);
            //    }
            //    else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
            //    {
            //        var list = (from kul in context.django_session
            //                    where kul.id == inID
            //                    select kul.session_key).SingleOrDefault();
            //        return Convert.ToString(list);
            //    }
            //    else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
            //    {
            //        //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
            //        //            where kul.KOD == strAlan
            //        //            select kul.ID).SingleOrDefault();
            //        ////if (list == null) { return false; } else { return true; }
            //        //return Convert.ToInt32(list);
            //    }
            //    else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
            //    {
            //        var list = (from kul in context.django_session
            //                    where kul.session_key == strAlan
            //                    select kul.id).SingleOrDefault();
            //        //if (list == null) { return false; } else { return true; }
            //        return Convert.ToInt32(list);
            //    }

            //    else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
            //    {
            //        return YetkiKontrol(inID, alan_id, ust_id);
            //    }
            //}
            return null;
        }
        //public static Object Getege_integration_activitylog_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.ege_integration_activitylog
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.@event
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.ege_integration_activitylog
        //                        where kul.id == inID
        //                        select kul.@event).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.ege_integration_activitylog
        //                        where kul.id == inID
        //                        select kul.@event).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.ege_integration_activitylog
        //                        where kul.@event == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        //public static Object Getege_integration_productcompetitorrelation_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.ege_integration_productcompetitorrelation
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.product.description
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.ege_integration_productcompetitorrelation
        //                        where kul.id == inID
        //                        select kul.product.description).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.ege_integration_productcompetitorrelation
        //                        where kul.id == inID
        //                        select kul.product.description).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.ege_integration_productcompetitorrelation
        //                        where kul.product.description == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        //public static Object Getege_integration_relation_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.ege_integration_relation
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.ege_code
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.ege_integration_relation
        //                        where kul.id == inID
        //                        select kul.ege_code).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.ege_integration_relation
        //                        where kul.id == inID
        //                        select kul.ege_code).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.ege_integration_relation
        //                        where kul.ege_code == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        public static Object Getest_bank_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.est_bank
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.est_bank
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.est_bank
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.est_bank
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getest_creditcardestrelation_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.est_creditcardestrelation
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.est_creditcardtype.type
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.est_creditcardestrelation
                                where kul.id == inID
                                select kul.est_creditcardtype.type).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.est_creditcardestrelation
                                where kul.id == inID
                                select kul.est_creditcardtype.type).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.est_creditcardestrelation
                                where kul.est_creditcardtype.type == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getest_creditcardtype_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.est_creditcardtype
                                select new IdAdVm
                                {
                                    ID = kul.bin,
                                    AD = kul.type
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.est_creditcardtype
                                where kul.bin == inID
                                select kul.type).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.est_creditcardtype
                                where kul.bin == inID
                                select kul.type).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.est_creditcardtype
                                where kul.type == strAlan
                                select kul.bin).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getbin_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.est_creditcardtype
                                select new IdAdVm
                                {
                                    ID = kul.bin,
                                    AD = kul.type
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.est_creditcardtype
                                where kul.bin == inID
                                select kul.type).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.est_creditcardtype
                                where kul.bin == inID
                                select kul.type).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.est_creditcardtype
                                where kul.type == strAlan
                                select kul.bin).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
           return null;
        }
        public static Object Getest_estcredential_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.est_estcredential
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.bank
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.est_estcredential
                                where kul.id == inID
                                select kul.bank).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.est_estcredential
                                where kul.id == inID
                                select kul.bank).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.est_estcredential
                                where kul.bank == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getest_cash_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.est_estcredential
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.bank
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.est_estcredential
                                where kul.id == inID
                                select kul.bank).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.est_estcredential
                                where kul.id == inID
                                select kul.bank).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.est_estcredential
                                where kul.bank == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getest_installment_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.est_estcredential
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.bank
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.est_estcredential
                                where kul.id == inID
                                select kul.bank).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.est_estcredential
                                where kul.id == inID
                                select kul.bank).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.est_estcredential
                                where kul.bank == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getest_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.est_estcredential
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.bank
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.est_estcredential
                                where kul.id == inID
                                select kul.bank).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.est_estcredential
                                where kul.id == inID
                                select kul.bank).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.est_estcredential
                                where kul.bank == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getbank_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.est_bank
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.est_bank
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.est_bank
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.est_bank
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getpackage_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.payment_package
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.payment_package
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.payment_package
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.payment_package
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getest_installmentalternative_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.est_installmentalternative
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.description
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.est_installmentalternative
                                where kul.id == inID
                                select kul.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.est_installmentalternative
                                where kul.id == inID
                                select kul.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.est_installmentalternative
                                where kul.description == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getest_transaction_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.est_transaction
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.order_id
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.est_transaction
                                where kul.id == inID
                                select kul.order_id).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.est_transaction
                                where kul.id == inID
                                select kul.order_id).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.est_transaction
                                where kul.order_id == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getfirm_parameter_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.firm_parameter
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.firm_parameter
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.firm_parameter
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.firm_parameter
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getvehicle_fuel_type_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.vehicle_fuel_type
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.vehicle_fuel_type
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.vehicle_fuel_type
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.vehicle_fuel_type
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getfuel_type_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.vehicle_fuel_type
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.vehicle_fuel_type
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.vehicle_fuel_type
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.vehicle_fuel_type
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getilce_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.ilce
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.ilce
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.ilce
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.ilce
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getlanguage_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.language
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.language
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.language
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.language
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getmanufacturer_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.manufacturer
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.manufacturer
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.manufacturer
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.manufacturer
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getmessaging_customermessage_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.messaging_customermessage
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.auth_user.email
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.messaging_customermessage
                                where kul.id == inID
                                select kul.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.messaging_customermessage
                                where kul.id == inID
                                select kul.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.messaging_customermessage
                                where kul.auth_user.email == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getmessaging_messagedepartment_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.messaging_messagedepartment
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.messaging_messagedepartment
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.messaging_messagedepartment
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.messaging_messagedepartment
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
         public static Object Getmodule_pricedropalert_customer_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.module_pricedropalert_customer
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.auth_user.email
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.module_pricedropalert_customer
                                where kul.id == inID
                                select kul.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.module_pricedropalert_customer
                                where kul.id == inID
                                select kul.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.module_pricedropalert_customer
                                where kul.auth_user.email == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getmodule_pricedropalert_email_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.module_pricedropalert_email
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.email
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.module_pricedropalert_email
                                where kul.id == inID
                                select kul.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.module_pricedropalert_email
                                where kul.id == inID
                                select kul.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.module_pricedropalert_email
                                where kul.email == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getvehicle_motor_type_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.vehicle_motor_type
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.vehicle_motor_type
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.vehicle_motor_type
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.vehicle_motor_type
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getmotor_type_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.vehicle_motor_type
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.vehicle_motor_type
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.vehicle_motor_type
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.vehicle_motor_type
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getnewsletter_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.newsletter
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.title
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.newsletter
                                where kul.id == inID
                                select kul.title).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.newsletter
                                where kul.id == inID
                                select kul.title).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.newsletter
                                where kul.title == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getorder_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.order
                                select new IdAdVm
                                {
                                    ID =  kul.id,
                                    AD =  kul.auth_user.email + " No : " + kul.receipt_id
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.order
                                where kul.id == inID
                                select kul.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.order
                                where kul.id == inID
                                select kul.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.order
                                where kul.auth_user.email == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
         public static Object Getorder_product_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.order_product
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.order.auth_user.email
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.order_product
                                where kul.id == inID
                                select kul.order.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.order_product
                                where kul.id == inID
                                select kul.order.auth_user.email).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.order_product
                                where kul.order.auth_user.email == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getorder_status_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.order_status
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.comments
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.order_status
                                where kul.id == inID
                                select kul.order_id).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.order_status
                                where kul.id == inID
                                select kul.order_id).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    //var list = (from kul in context.order_status
                    //            where kul.order_id == strAlan
                    //            select kul.id).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getorder_status_type_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.order_status_type
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.order_status_type
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.order_status_type
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    //var list = (from kul in context.order_status
                    //            where kul.order_id == strAlan
                    //            select kul.id).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getpayment_package_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.payment_package
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.payment_package
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.payment_package
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.payment_package
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getpayment_type(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            List<IdAdVm> vmList = new List<IdAdVm>();
            vmList.Add(new IdAdVm{ID=1,AD ="Kredi Kartı"});
            vmList.Add(new IdAdVm{ID=2,AD ="Havale"});
            vmList.Add(new IdAdVm{ID=3,AD ="3D"});
            return vmList;
        }
        //public static Object Getproduct_category_choice_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.product_category_choice
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.title
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.product_category_choice
        //                        where kul.id == inID
        //                        select kul.title).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.product_category_choice
        //                        where kul.id == inID
        //                        select kul.title).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.product_category_choice
        //                        where kul.title == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        //public static Object Getproduct_category_schema_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.product_category_schema
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.name
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.product_category_schema
        //                        where kul.id == inID
        //                        select kul.name).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.product_category_schema
        //                        where kul.id == inID
        //                        select kul.name).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.product_category_schema
        //                        where kul.name == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        //public static Object Getproduct_category_value_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.product_category_value
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.product_category_schema.name
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.product_category_value
        //                        where kul.id == inID
        //                        select kul.product_category_schema.name).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.product_category_value
        //                        where kul.id == inID
        //                        select kul.product_category_schema.name).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.product_category_value
        //                        where kul.product_category_schema.name == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        public static Object Getproduct_images_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.product_images
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.product.description
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.product_images
                                where kul.id == inID
                                select kul.product.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.product_images
                                where kul.id == inID
                                select kul.product.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.product_images
                                where kul.product.description == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getproduct_original_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.product_original
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.oem_no
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.product_original
                                where kul.id == inID
                                select kul.oem_no).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.product_original
                                where kul.id == inID
                                select kul.oem_no).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.product_original
                                where kul.oem_no == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getproduct_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.product
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.partner_code + "-" + kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.product
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.product
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.product
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getproduct_review_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.product_review
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.product.description
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.product_review
                                where kul.id == inID
                                select kul.product.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.product_review
                                where kul.id == inID
                                select kul.product.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.product_review
                                where kul.product.description == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getproduct_tag_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.product_tag
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.product_tag
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.product_tag
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.product_tag
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getproducttag_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.product_tag
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.product_tag
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.product_tag
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.product_tag
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getproduct_tags_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.product_tags
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.product.description
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.product_tags
                                where kul.id == inID
                                select kul.product.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.product_tags
                                where kul.id == inID
                                select kul.product.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.product_tags
                                where kul.product.description == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getproduct_grup_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.vehicle
                                select new IdAdVm
                                {
                                    ID = kul.grup_id,
                                    AD = kul.vehicle_motor_type.name + "-" + kul.vehicle_fuel_type.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.product_review
                                where kul.id == inID
                                select kul.product.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.product_review
                                where kul.id == inID
                                select kul.product.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.product_review
                                where kul.product.description == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        //public static Object Getproduct_variation_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.product_variation
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.product.description
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.product_variation
        //                        where kul.id == inID
        //                        select kul.product.description).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.product_variation
        //                        where kul.id == inID
        //                        select kul.product.description).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.product_variation
        //                        where kul.product.description == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        //public static Object Getproduct_variation_option_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.product_variation_option
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.value
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.product_variation_option
        //                        where kul.id == inID
        //                        select kul.value).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.product_variation_option
        //                        where kul.id == inID
        //                        select kul.value).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.product_variation_option
        //                        where kul.value == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        //public static Object Getproduct_variation_type_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.product_variation_type
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.name
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.product_variation_type
        //                        where kul.id == inID
        //                        select kul.name).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.product_variation_type
        //                        where kul.id == inID
        //                        select kul.name).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.product_variation_type
        //                        where kul.name == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        public static Object Getproduct_vehicle_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.product_vehicle
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.product.description
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.product_vehicle
                                where kul.id == inID
                                select kul.product.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.product_vehicle
                                where kul.id == inID
                                select kul.product.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.product_vehicle
                                where kul.product.description == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getshipment_alternative_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.shipment_alternative
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.shipment_method.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.shipment_alternative
                                where kul.id == inID
                                select kul.shipment_method.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.shipment_alternative
                                where kul.id == inID
                                select kul.shipment_method.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.shipment_alternative
                                where kul.shipment_method.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getshipment_method_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.shipment_method
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.shipment_method
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.shipment_method
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.shipment_method
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getshipment_package_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.shipment_package
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.shipment_package
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.shipment_package
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.shipment_package
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getshop_config_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.shop_config
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.key
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.shop_config
                                where kul.id == inID
                                select kul.key).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.shop_config
                                where kul.id == inID
                                select kul.key).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.shop_config
                                where kul.key == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getshop_synonym_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.shop_synonym
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.from_text
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.shop_synonym
                                where kul.id == inID
                                select kul.from_text).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.shop_synonym
                                where kul.id == inID
                                select kul.from_text).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.shop_synonym
                                where kul.from_text == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        //public static Object Getsouth_migrationhistory_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.south_migrationhistory
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.migration
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.south_migrationhistory
        //                        where kul.id == inID
        //                        select kul.migration).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.south_migrationhistory
        //                        where kul.id == inID
        //                        select kul.migration).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.south_migrationhistory
        //                        where kul.migration == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        public static Object Gettax_rate_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.tax_rate
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.category.description
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.tax_rate
                                where kul.id == inID
                                select kul.category.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.tax_rate
                                where kul.id == inID
                                select kul.category.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.tax_rate
                                where kul.category.description == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getvehicle_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    //var list = (from kul in context.vehicle
                    //            select new IdAdVm
                    //            {
                    //                ID = kul.id,
                    //                AD = kul.vehicle_tree.vehicle_tree2.vehicle_tree2.name + " >>> " + kul.vehicle_tree.vehicle_tree2.name + " >>> " + kul.vehicle_motor_type.name + " >>> " + kul.vehicle_fuel_type.name + " >>> " + kul.begin_year != null ? SqlFunctions.StringConvert((double)kul.begin_year).Trim() : "" + " >>> " + kul.end_year != null ? SqlFunctions.StringConvert((double)kul.end_year).Trim() : ""
                    //            }).ToList();
                    //return list;

                    var listx = (from kul in context.vehicle
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.vehicle_tree.vehicle_tree2.vehicle_tree2.name + " >>> " + kul.vehicle_tree.vehicle_tree2.name + " >>> " + kul.vehicle_motor_type.name + " >>> " + kul.vehicle_fuel_type.name //+ " >>> " +  SqlFunctions.StringConvert((double)kul.begin_year).Trim()
                                }).ToList();
                    return listx;

                    var list1 = (from kul in context.vehicle
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.vehicle_tree.vehicle_tree2.vehicle_tree2.name + " >>> " + kul.vehicle_tree.vehicle_tree2.name + " >>> " + kul.vehicle_motor_type.name  
                                }).ToList();
                    return list1;

                    var list2 = (from kul in context.vehicle
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.vehicle_tree.vehicle_tree2.vehicle_tree2.name + " >>> " + kul.vehicle_tree.vehicle_tree2.name + " >>> " + kul.vehicle_motor_type.name + " >>> " + kul.vehicle_fuel_type.name 
                                }).ToList();
                    return list2;

                    var list3 = (from kul in context.vehicle
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.vehicle_tree.vehicle_tree2.vehicle_tree2.name + " >>> " + kul.vehicle_tree.vehicle_tree2.name + " >>> " + kul.vehicle_motor_type.name + " >>> " + kul.vehicle_fuel_type.name + " >>> " + kul.begin_year != null ? SqlFunctions.StringConvert((double)kul.begin_year).Trim() : ""
                                }).ToList();
                    return list3;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.vehicle
                                where kul.id == inID
                                select kul.vehicle_tree.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.vehicle
                                where kul.id == inID
                                select kul.vehicle_tree.description).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.vehicle
                                where kul.vehicle_tree.description == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getvehicle_currency_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.vehicle_currency
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.vehicle_currency
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.vehicle_currency
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.vehicle_currency
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        //public static Object Getvehicle_kdv_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        //{
        //    b2cEntities context = new b2cEntities();
        //    using (context)
        //    {
        //        if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
        //        {
        //            var list = (from kul in context.vehicle_kdv
        //                        select new IdAdVm
        //                        {
        //                            ID = kul.id,
        //                            AD = kul.name
        //                        }).ToList();
        //            return list;
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
        //        {
        //            var list = (from kul in context.vehicle_kdv
        //                        where kul.id == inID
        //                        select kul.name).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.ID == inID
        //            //            select kul.KOD).SingleOrDefault();
        //            //return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
        //        {
        //            var list = (from kul in context.vehicle_kdv
        //                        where kul.id == inID
        //                        select kul.name).SingleOrDefault();
        //            return Convert.ToString(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
        //        {
        //            //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
        //            //            where kul.KOD == strAlan
        //            //            select kul.ID).SingleOrDefault();
        //            ////if (list == null) { return false; } else { return true; }
        //            //return Convert.ToInt32(list);
        //        }
        //        else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
        //        {
        //            var list = (from kul in context.vehicle_kdv
        //                        where kul.name == strAlan
        //                        select kul.id).SingleOrDefault();
        //            //if (list == null) { return false; } else { return true; }
        //            return Convert.ToInt32(list);
        //        }

        //        else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
        //        {
        //            return YetkiKontrol(inID, alan_id, ust_id);
        //        }
        //    }
        //    return null;
        //}
        public static Object Getvehicle_tree_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.vehicle_tree
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.id == inID
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.name == strAlan
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getmarka_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.level == 0
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.id == inID && kul.level == 0
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.id == inID && kul.level == 0
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.name == strAlan && kul.level == 0
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getmodel_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.level == 1
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.id == inID && kul.level == 1
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.id == inID && kul.level == 1
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.name == strAlan && kul.level == 1
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getvehicle_model_type_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.level == 2
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.vehicle_tree2.vehicle_tree2.name + " >>> " + kul.vehicle_tree2.name + " >>> " + kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.id == inID && kul.level == 1
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.id == inID && kul.level == 1
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.name == strAlan && kul.level == 1
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getbrand_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.level == 0
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.id == inID && kul.level == 0
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.id == inID && kul.level == 0
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.name == strAlan && kul.level == 0
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
        public static Object Getmodel_type_id(int ListServiceTip, int aktifTipID, int inID, int alan_id, int ust_id, string strAlan, string tempStr, int tempInt)
        {
            b2cEntities context = new b2cEntities();
            using (context)
            {
                if (ListServiceTip == (int)ListServiceTipEn.LISTE || ListServiceTip == (int)ListServiceTipEn.LISTEKIRILIMSIZ || ListServiceTip == (int)ListServiceTipEn.LISTEKODSIRALAMALI)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.level == 2
                                select new IdAdVm
                                {
                                    ID = kul.id,
                                    AD = kul.vehicle_tree2.vehicle_tree2.name + " >>> " + kul.vehicle_tree2.name + " >>> " + kul.name
                                }).ToList();
                    return list;
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKODAD)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.id == inID && kul.level == 1
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDKOD)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.ID == inID
                    //            select kul.KOD).SingleOrDefault();
                    //return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYIDAD)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.id == inID && kul.level == 1
                                select kul.name).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYKODID)
                {
                    //var list = (from kul in context.YETKI_ISLEM_SAHIBI_TIP
                    //            where kul.KOD == strAlan
                    //            select kul.ID).SingleOrDefault();
                    ////if (list == null) { return false; } else { return true; }
                    //return Convert.ToInt32(list);
                }
                else if (ListServiceTip == (int)ListServiceTipEn.LISTEBYADID)
                {
                    var list = (from kul in context.vehicle_tree
                                where kul.name == strAlan && kul.level == 1
                                select kul.id).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return Convert.ToInt32(list);
                }

                else if (ListServiceTip == (int)ListServiceTipEn.YETKIKONTROL)
                {
                    return YetkiKontrol(inID, alan_id, ust_id);
                }
            }
            return null;
        }
    }

}
