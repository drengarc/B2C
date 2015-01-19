using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Prodma.DataAccess;
using AlisSatis.Fis.Models;

using System.ComponentModel;
using System.Drawing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Reflection;
using Satis.StokLists.Models;
using LinqKit;
using System.Collections;
using System.Text;
using System.Linq.Dynamic;
using Prodma.Sistem.Models;
using Satis.Listeler.SiparisListeleri.Models;
using DevExpress.XtraEditors;
using Satis.StokAmbar.Models;
using Satis.Listeler.StokListeleri.Models;
using Satis.Cari.Models;
using Satis.StokAmbar.Controllers;
using System.Data.Objects.SqlClient;
using Muhasebe.Listeler.Models;
using MasrafYeri.Listeler.Models;
using Muhasebe.Models;
namespace Prodma.DataAccess
{
    public class ListeYapBase
    {
        public bool KartFiltrelendi = false;
        public string sqlDisaridan = "";
        public string sqlFisIcin = "";
        public bool yetkiBak = true;
        public bool tekSorgu = false;
        public int? tempId;
        public int? degerId;
        decimal usdKur = 0;
        decimal eurKur = 0;
        Dictionary<string, string> parameters1 = new Dictionary<string, string>();
        public ListeYapBase()
        {
        }
        public ListeYapBase(Dictionary<string, string> parameters2)
        {
            parameters1 = parameters2;
        }
        public ListeYapBase(bool parametreli)
        {
        }
        #region helper
        public static string basKod, bitKod;
        public static void DiziSifirla(decimal[] dizi)
        {
            for (int i = 0; i < dizi.Length; i++)
            {
                dizi[i] = 0;
            }
        }
        public static decimal DiziTopla(decimal[] dizi)
        {
            decimal toplam = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                toplam += dizi[i];
            }
            return toplam;
        }
        public static void DictionarySifirla(Dictionary<int, decimal> dic)
        {
            List<int> list = new List<int>(dic.Keys);

            foreach (int item in list)
            {
                dic[item] = 0;
            }
        }
        public static void DictionaryDiziSifirla(Dictionary<int, decimal>[] dic)
        {
            for (int i = 0; i < dic.Length; i++)
            {
                List<int> list = new List<int>(dic[i].Keys);

                foreach (int item in list)
                {
                    dic[i][item] = 0;
                }
            }

        }
        public static bool IcindeVarMi(string parameter, string id)
        {
            string[] idler = parameter.Split(',');
            return idler.Contains<String>(id);
        }
        #endregion
    
    }
}
