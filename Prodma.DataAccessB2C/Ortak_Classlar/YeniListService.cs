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
namespace Prodma.DataAccessB2C
{
    public class YeniListService
    {
         // metoda birden fazla parametre gidiyor diye oluşturulan static class
        public static Object InvokeMethod(string methodName, int Id,int alan_id,int ust_id , string TabloAd)
         {
             string ns = "Prodma.DataAccess";
             string tn = "YeniListService";
             string an = "Prodma.DataAccess";
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
                     object[] parametersArray = new object[] { Id,alan_id ,ust_id, TabloAd };

                     //The invoke does NOT work it throws "Object does not match target type"             
                     result = methodInfo.Invoke(classInstance, parametersArray);
                     return result;
                 }
             }
             else  
             { return null; }



             //Object s = (Object)calledType.InvokeMember(methodName, System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static, null, null, null);

         }
        public static Object GetTABLO_ALAN_ID(int inID, int alan_id, int ust_id, string tabloAdi)
        {
            b2cEntities context = new  b2cEntities();
            using (context)
            {
                int tabloId = (from tbl in context.M_ALANLAR
                               where tbl.ALAN_AD == tabloAdi && tbl.M_ALANLAR_ID == 0
                               select tbl.ID).First();

                if (inID == 0)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.M_ALANLAR_ID == tabloId
                                select new IdAdVm
                                {
                                    ID = kul.ID,
                                    AD = kul.ALAN_AD + "-" + kul.ALAN_LISTE_AD
                                }).ToList();
                    return list;
                }
                else if (inID > 0 && alan_id == 0)
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.M_ALANLAR_ID == tabloId
                                select kul.ALAN_AD).SingleOrDefault();
                    return Convert.ToString(list);
                }
                else 
                {
                    var list = (from kul in context.M_ALANLAR
                                where kul.M_ALANLAR_ID == tabloId
                                select kul.ALAN_AD).SingleOrDefault();
                    //if (list == null) { return false; } else { return true; }
                    return list == null ? false : true;
                }

            }
        }
        public static Object GetALAN_TIP_ID(int inID, int alan_id, int ust_id,string tabloAdi)
        {
            List<IdAdVm> alanTipList = new List<IdAdVm>();
            IdAdVm vm = new IdAdVm();
            vm.ID = 1;
            vm.AD = "AD";
            alanTipList.Add(vm);

            vm = new IdAdVm();
            vm.ID = 2;
            vm.AD = "KOD";
            alanTipList.Add(vm);
            
            vm = new IdAdVm();
            vm.ID = 3;
            vm.AD = "KENDİ DEĞERİ";
            alanTipList.Add(vm);

            return alanTipList;
        }
        public static Object GetALAN_DATA_TIP_ID(int inID, int alan_id, int ust_id, string tabloAdi)
        {
            //return YardimciIslemler.EnumToList<DataTipleriEn>();
            List<IdAdVm> alanTipList = new List<IdAdVm>();
            IdAdVm vm = new IdAdVm();
            vm.ID = 0;
            vm.AD = "Tarih";
            alanTipList.Add(vm);

            vm = new IdAdVm();
            vm.ID = 1;
            vm.AD = "Tamsayi";
            alanTipList.Add(vm);

            vm = new IdAdVm();
            vm.ID = 2;
            vm.AD = "Yazi";
            alanTipList.Add(vm);

            vm = new IdAdVm();
            vm.ID = 3;
            vm.AD = "Sayisal";
            alanTipList.Add(vm);

            return alanTipList;
        }
        public static Object GetUZERINE_YAZMA_DURUM_TIP_ID(int inID, int alan_id, int ust_id, string tabloAdi)
        {
            //return YardimciIslemler.EnumToList<DataTipleriEn>();
            List<IdAdVm> alanTipList = new List<IdAdVm>();
            IdAdVm vm = new IdAdVm();
            vm.ID = 0;
            vm.AD = "Değ,ştir";
            alanTipList.Add(vm);

            vm = new IdAdVm();
            vm.ID = 1;
            vm.AD = "Boşsa Değiştir";
            alanTipList.Add(vm);

            vm = new IdAdVm();
            vm.ID = 2;
            vm.AD = "Değiştirme";
            alanTipList.Add(vm);
            return alanTipList;
        }
        
    }
}
