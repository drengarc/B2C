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
namespace Prodma.DataAccessB2C
{
     public class QueryOlustur
    {
         public static string SqlQueryPersonelList(Dictionary<string, string> parameters, string strIlk)
         {
             string sql = "";
             if (parameters.ContainsKey("STOK_ID"))
             {
                 sql += querylist(sql, parameters["STOK_ID"].ToString().Split(','), "STOKVM.STOK_ID");
             }
             return (strIlk != "" && sql != "") ? strIlk + " AND " + sql : strIlk +sql ;
         }// MODEL UZERINDEN SORGULAR ICIN KULLANILIYOR
         public static string SqlQueryPersonel(Dictionary<string, string> parameters, string strIlk)
         {
             string sql = "";
             if (parameters== null) return "";
             if (parameters.ContainsKey("ID"))
             {
                 sql += querylist(sql, parameters["ID"].ToString().Split(','), "ID");
             }
             if (parameters.ContainsKey("STOK_ID"))
             {
                 sql += querylist(sql, parameters["STOK_ID"].ToString().Split(','), "STOK_ID");
             }
             if (parameters.ContainsKey("LK_TICARI_MAL_E_H"))
             {
                 sql += querylistHayirEvet(sql, parameters["LK_TICARI_MAL_E_H"].ToString().Split(','), "LK_TICARI_MAL_E_H");
             }

             return (strIlk != "" && sql != "") ? strIlk + " AND " + sql : strIlk +sql ;
         }// STOK TABLOSUNDAN SORGU YAPILDIGINDA KULLANILIYOR.STOK KARTINDA ARAMALRDA KULLANILIYOR
         public static string SqlQueryProduct(Dictionary<string, string> parameters)
         {
             string sql = "";
             if (parameters == null) return "";
             if (parameters.ContainsKey("id"))
             {
                 sql += querylist(sql, parameters["id"].ToString().Split(','), "id");
             }
             if (parameters.ContainsKey("product_id"))
             {
                 sql += querylist(sql, parameters["product_id"].ToString().Split(','), "product_id");
             }
             if (parameters.ContainsKey("manufacturer_id"))
             {
                 sql += querylist(sql, parameters["manufacturer_id"].ToString().Split(','), "manufacturer_id");
             }
             return sql;
         }
         
         public static string queryTekAlan(String sql, string[] Secilenler, string alanAdi)
         {
             if (Secilenler.Length > 0 && Secilenler[0] == "") return "";
             int temp = 0;
             int donguIdex = 0;
             string strSql = "";
             strSql = sql != "" ? sql + " AND " : "";
             foreach (string idler in Secilenler)
             {
                 if (idler != "")
                 {
                     temp = Convert.ToInt32(idler);
                     if (donguIdex == 0)
                     {
                         strSql += "(" + alanAdi + "==" + temp;
                     }
                     else
                     {
                         strSql += " or  " + alanAdi + "==" + temp;
                     }
                 }
                 donguIdex++;
             }
             if (strSql != "") strSql += ")";
             return strSql;
         }
         /// <summary>
         /// String CALISMALARI
         /// </summary>
         /// <param name="Secilenler"></param>
         /// <param name="alanAdi"></param>
         /// <returns></returns>
         public static string queryMiktar(String sql, string[] Secilenler, string alanAdi)
         {
             // sql = " AND ";
             decimal temp = 0;
             int donguIdex = 0;

             string strSql = "";
             strSql = sql != "" ? " AND " : "";
             foreach (string idler in Secilenler)
             {
                 temp = Convert.ToDecimal(idler);
                 if (donguIdex == 0)
                 {
                     strSql += "(" + alanAdi + ">" + temp;

                 }
                 else
                 {
                     strSql += " AND  " + alanAdi + "<" + temp;

                 }
                 donguIdex++;
             }
             if (strSql != "") strSql += ")";
             return strSql;
         }
         public static string querylist(String sql, string[] Secilenler, string alanAdi)
         {
             //if (Secilenler.Length > 0 && Secilenler[0] == "") return "";
             //string temp = "0";
             //int donguIdex = 0;
             //string strSql = "";
             //strSql = sql != "" ? " AND " : "";
             //foreach (string idler in Secilenler)
             //{
             //    if (idler.Trim() != "")
             //    {
             //        temp = idler.Trim();
             //        if (temp == "0") temp = "null";
             //        if (donguIdex == 0)
             //        {
             //            strSql += "(" + alanAdi + "==" + temp;
             //        }
             //        else
             //        {
             //            strSql += " or  " + alanAdi + "==" + temp;
             //        }
             //    }
             //    donguIdex++;
             //}
             //if (strSql != "") strSql += ")";
             //return strSql;
             return querylist(sql, Secilenler, alanAdi, "==");
         }
         public static string querylist(String sql, string[] Secilenler, string alanAdi,string isaret)
         {
             if (Secilenler.Length > 0 && Secilenler[0] == "") return "";
             string temp = "0";
             int donguIdex = 0;
             string strSql = "";
             strSql = sql != "" ? " AND " : "";
             foreach (string idler in Secilenler)
             {
                 if (idler.Trim() != "")
                 {
                     temp = idler.Trim();
                     if (temp == "0") temp = "null";
                     if (donguIdex == 0)
                     {
                         strSql += "(" + alanAdi + isaret + temp;
                     }
                     else
                     {
                         strSql += " or  " + alanAdi + isaret + temp;
                     }
                 }
                 donguIdex++;
             }
             if (strSql != "") strSql += ")";
             return strSql;
         }

         public static string querylistHayirEvet(String sql, string[] Secilenler, string alanAdi)
         {
             //if (Secilenler.Length > 0 && Secilenler[0] == "") return "";
             //string temp = "0";
             //int donguIdex = 0;
             //string strSql = "";
             //strSql = sql != "" ? " AND " : "";
             //foreach (string idler in Secilenler)
             //{
             //    if (idler.Trim() != "")
             //    {
             //        temp = idler.Trim();
             //        if (temp == "0") temp = "null";
             //        if (donguIdex == 0)
             //        {
             //            strSql += "(" + alanAdi + "==" + temp;
             //        }
             //        else
             //        {
             //            strSql += " or  " + alanAdi + "==" + temp;
             //        }
             //    }
             //    donguIdex++;
             //}
             //if (strSql != "") strSql += ")";
             //return strSql;
             return querylistHayirEvet(sql, Secilenler, alanAdi, "==");
         }
         public static string querylistHayirEvet(String sql, string[] Secilenler, string alanAdi, string isaret)
         {
             if (Secilenler.Length > 0 && Secilenler[0] == "") return "";
             string temp = "0";
             int donguIdex = 0;
             string strSql = "";
             strSql = sql != "" ? " AND " : "";
             foreach (string idler in Secilenler)
             {
                 if (idler.Trim() != "")
                 {
                     temp = idler.Trim();
                     //if (temp == "0") temp = "null";
                     if (donguIdex == 0)
                     {
                         strSql += "(" + alanAdi + isaret + temp;
                     }
                     else
                     {
                         strSql += " or  " + alanAdi + isaret + temp;
                     }
                 }
                 donguIdex++;
             }
             if (strSql != "") strSql += ")";
             return strSql;
         }

         public static string querylistString(String sql, string[] Secilenler, string alanAdi)  //String alanlarda çift tırnaklı sorgu için gerekli
         {
             if (Secilenler.Length > 0 && Secilenler[0] == "") return "";
             string temp = "0";
             int donguIdex = 0;
             string strSql = "";
             string strciftTirnak = "\"";
             //string strciftTirnak1 = @""";
             strSql = sql != "" ? " AND " : "";
             foreach (string idler in Secilenler)
             {
                 if (idler.Trim() != "")
                 {
                     temp = idler.Trim();
                     if (temp == "0") temp = "null";
                     if (donguIdex == 0)
                     {
                         strSql += "(" + alanAdi + "==\"" + temp + "\"";
                     }
                     else
                     {
                         strSql += " or  " + alanAdi + "==\"" + temp + "\"";
                     }
                 }
                 donguIdex++;
             }
             if (strSql != "") strSql += ")";
             return strSql;
         }
         public static string querylistTers(String sql, string[] Secilenler, string alanAdi)
         {
             if (Secilenler.Length > 0 && Secilenler[0] == "") return "";
             int temp = 0;
             int donguIdex = 0;
             string strSql = "";
             strSql = sql != "" ? " AND " : "";
             foreach (string idler in Secilenler)
             {
                 if (idler != "")
                 {
                     temp = Convert.ToInt32(idler);
                     if (donguIdex == 0)
                     {
                         strSql += "(" + alanAdi + "!=" + temp + " OR " + alanAdi + " == null)";
                     }
                     else
                     {
                         strSql += " AND  " + alanAdi + "!=" + temp;
                     }
                 }
                 donguIdex++;
             }
            // if (strSql != "") strSql += ")";
             return strSql;
         }

         
    }
}
