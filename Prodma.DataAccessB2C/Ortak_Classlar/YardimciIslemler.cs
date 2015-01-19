using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using Microsoft.Reporting.WinForms;
using Prodma.SistemB2C.Controllers;
using Prodma.SistemB2C.Models;
using System.Data.SqlClient;

namespace Prodma.DataAccessB2C
{
    public class YardimciIslemler
    {
        #region diziislemleri
        public static void DiziSifirla(decimal[] dizi)
        {
            for (int i = 0; i < dizi.Length; i++)
            {
                dizi[i] = 0;
            }
        }
        public static void DiziSifirla(int[] dizi)
        {
            for (int i = 0; i < dizi.Length; i++)
            {
                dizi[i] = 0;
            }
        }
        public static void DiziSifirla(string[] dizi)
        {
            for (int i = 0; i < dizi.Length; i++)
            {
                dizi[i] = "";
            }
        }
        public static string[] DizidenCikart(string diziElemani, string[] dizi)
        {
            return dizi.Where(val => val != diziElemani).ToArray();
        }
        public static string[] AyniKayitlariCikar(string[] tarihTemp)
        {
            string[] tempArr = new string[1500];
            int tempArrIndex = 0;
            Dictionary<string, string> mevcutlar = new Dictionary<string, string>();
            for (int i = 0; i < tarihTemp.Length; i++)
            {
                if (Array.IndexOf(tempArr, tarihTemp[i]) == -1)
                {
                    tempArr[tempArrIndex] = tarihTemp[i]; tempArrIndex++;
                }
            }
            return tempArr;
        }
        public static string AyniKayitlariCikarBirlestir(string[] tarihTemp)
        {
            string temp = "";
            string[] tempArr = AyniKayitlariCikar(tarihTemp);
            for (int i = 0; i < tempArr.Length; i++)
            {
                temp += tempArr[i] + ",";
                if (tempArr[i] == null) break;
            }
            return ListHelper.SonKarakteriSil(temp);
        }
        public static string[] TumAlanlariSec(string p)
        {
            string[] a = new string[2];
            return a;
            //DevExpress.XtraEditors.CheckedComboBoxEdit chlTemp = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            //InvokeChlSet(p, chlTemp);
            //chlTemp.CheckAll();
             //return YardimciIslemler.SplitTrim(chlTemp.EditValue.ToString());
        }
        #endregion
        #region tarihISlemleri
        public static DateTime SetTarihDefault()
        {
            return Convert.ToDateTime("01.01.1900");
        }
        public static DateTime TarihSetBugun()
        {
            return DateTime.Today;
        }
        public static DateTime TarihSet1900()
        {
            return Convert.ToDateTime("01.01.1900");
        }
        public static DateTime TarihSet2049()
        {
            return Convert.ToDateTime("31.12.2049");
        }
        public static DateTime TarihSetIlkGun()
        {
            return Convert.ToDateTime("01.01.2012");
        }
        public static DateTime TarihSetYilSonGun()
        {
            return Convert.ToDateTime("31.12.2012");
        }
        public static DateTime TarihSetAySonGun(string ay)
        {
            return Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(ay)) + "." + ay + "." + DateTime.Now.Year.ToString());
        }
        public static DateTime TarihSetAyIlkGun(string ay)
        {
            return Convert.ToDateTime("01." + ay + "." + DateTime.Now.Year.ToString());
        }
        public static DateTime TarihSetIlkAy()
        {
            return Convert.ToDateTime("01.01.2012");
        }
        public static DateTime TarihSetBugunAy()
        {
            return Convert.ToDateTime("31.12.2012");
        }
        public static DateTime TarihSetBugunYil()
        {
            return Convert.ToDateTime("31.12.2012");
        }
        public static DateTime TarihSetSonIslemGun()
        {
            return DateTime.Today;
        }
           public static int GetYilHafta(DateTime dtDate)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dtDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }
        public static int GetAyHafta(DateTime dtDate)
        {

            string tarih = Convert.ToString(dtDate).Substring(0, 2);
            int hafta = (Convert.ToInt32(tarih) / 7)+1;
            return hafta;
        }
        public static string GetAyGun(DateTime dtDate)
        {

            string gun = Convert.ToString(dtDate).Substring(0, 2);
            return gun;
        }
        public static bool TarihMi(DateTime dateTime)
        {
            if (dateTime.Year == 1)
            {
                return false;
            }
            return true;
        }
        public static bool TarihMi(string dateTime)
        {
            DateTime tarih;
            try
            {
                tarih = Convert.ToDateTime(dateTime);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion
        //// DEGISKEN ISLEMLERI
        #region fonksiyonYardimari
        public static string[] SplitTrim(string str)
        {
            return Array.ConvertAll(str.Split(','), p => p.Trim());
        }
        public static Int64 Strip(string value)
        {
            string returnVal = string.Empty;
            if (value.Length > 10) return 0;
            MatchCollection collection = Regex.Matches(value, "\\d+");
            foreach (Match match in collection)
            {
                returnVal += match.ToString();
            }
            //if (returnVal.ToString().Length != value.Length)
            //{
            //    returnVal = "";
            //}
            return returnVal == "" ? 0 : Convert.ToInt64(returnVal);
        }
        public static bool IcindeVarMi(string parameter, string id)
        {

            string[] idler = SplitTrim(parameter);
            return idler.Contains<String>(id);
        }
        public static string DecimalFormatla(decimal deger, int rakam)
        {
            string sonuc = "";
            if (rakam == 0) { sonuc = Convert.ToInt32(deger).ToString(); }
            else if (rakam == 1) { sonuc = String.Format("{0:0.00}", deger); }
            else if (rakam == 2) { sonuc = String.Format("{0:#,###,###.00}", deger); }
            else if (rakam == 3) { sonuc = String.Format("{0:#,###,###.000}", deger); }
            else if (rakam == 4) { sonuc = String.Format("{0:#,###,###.0000}", deger); }
            else if (rakam == 5) { sonuc = String.Format("{0:#.###.###,00000}", deger); }
            else if (rakam == 6) { sonuc = String.Format("{0:#,###,###.000000}", deger); }
            
            // sonuc = deger.ToString("#.####", CultureInfo.InvariantCulture);
            return sonuc;
        }
        public static string DecimalFormatlaYaziIcin(decimal deger, int rakam)
        {
            string sonuc = "";
            if (deger >= 1)
            {
                sonuc = DecimalFormatla(deger, rakam);
                return sonuc;
            }
            else            
            {
                sonuc = DecimalFormatla(deger, rakam);
                return sonuc = "0" + sonuc;
            }

            if (rakam == 0) { return sonuc; }
            else if (rakam == 1) { sonuc = String.Format("{0:0.0}", Convert.ToDecimal(sonuc)); }
            else if (rakam == 2) { sonuc = String.Format("{0:0.00}", Convert.ToDecimal(sonuc)); }
            else if (rakam == 3) { sonuc = String.Format("{0:0.000}", Convert.ToDecimal(sonuc)); }
            else if (rakam == 4) { sonuc = String.Format("{0:0.0000}", Convert.ToDecimal(sonuc)); }
            else if (rakam == 5) { sonuc = String.Format("{0:0.00000}", Convert.ToDecimal(sonuc)); }
            return sonuc;
        }
        public static string DecimalFormatla(decimal deger, int rakam, string seperator)
        {
            return String.Format("{0:#,###.00}", deger);
        }
        public static decimal DecimalFormatlaDec(decimal deger, int rakam)
        {
            if (rakam == 1) return Convert.ToDecimal(String.Format("{0:#,###.0}", deger));
            if (rakam == 2) return Convert.ToDecimal(String.Format("{0:#,###.00}", deger));
            if (rakam == 3) return Convert.ToDecimal(String.Format("{0:#,###.000}", deger));
            if (rakam == 4) return Convert.ToDecimal(String.Format("{0:#,###.0000}", deger));
            if (rakam == 5) return Convert.ToDecimal(String.Format("{0:#,###.00000}", deger));
            if (rakam == 6) return Convert.ToDecimal(String.Format("{0:#,###.000000}", deger));
            return deger;
            //return Convert.ToString(rakam);
            //return Convert.ToDecimal(String.Format("{0:#,###.00}", deger));
        }
        public static string BasaSifirEkle(int gelen, int p)
        {
            string sonuc = Convert.ToString(gelen);
            if (sonuc.Length != p + 1 && gelen != 0)
            {
                sonuc = String.Format("{0:" + new string('0', p + 1) + "}", gelen);
            }
            return sonuc;
        }
        public static string ListiVirguleGoreAyir(List<IdAdVm> listStok)
        {
            string a = "";
            foreach (var item in listStok)
            {
                a += item.ID.ToString() + ",";
            }
            return ListHelper.SonKarakteriSil(a);
        }
        public static void TransactSqlSil(string tabloAdi, string kriter)
        {
            //if (kriter == "") return;
            //string strCon = "Data Source={0};Persist Security Info=True;User ID={1};Password={2};Initial Catalog={3};MultipleActiveResultSets=True; Timeout=60";
            //SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = String.Format(strCon, ".", "sa", "bgssup", Globals.db);
            //cn.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = cn;
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "Delete FROM " + tabloAdi + " where " + kriter;
            //cmd.ExecuteNonQuery();
        }
        public static bool IsInteger (decimal deger)
        {
            return deger % 1 ==0;
        }
        public static string getNewString(string data)
        {
            if (data == null) return "";
            string[] strArrays = new string[12];
            strArrays[0] = "Ğ";
            strArrays[1] = "ğ";
            strArrays[2] = "Ü";
            strArrays[3] = "ü";
            strArrays[4] = "Ş";
            strArrays[5] = "ş";
            strArrays[6] = "İ";
            strArrays[7] = "ı";
            strArrays[8] = "Ö";
            strArrays[9] = "ö";
            strArrays[10] = "Ç";
            strArrays[11] = "ç";
            string[] strArrays1 = strArrays;
            strArrays = new string[12];
            strArrays[0] = "G";
            strArrays[1] = "g";
            strArrays[2] = "U";
            strArrays[3] = "u";
            strArrays[4] = "S";
            strArrays[5] = "s";
            strArrays[6] = "I";
            strArrays[7] = "i";
            strArrays[8] = "O";
            strArrays[9] = "o";
            strArrays[10] = "C";
            strArrays[11] = "c";
            string[] strArrays2 = strArrays;
            int ınt32 = 0;
            while (true)
            {
                bool length = ınt32 < (int)strArrays1.Length;
                if (!length)
                {
                    break;
                }
                data = data.Replace(strArrays1[ınt32], strArrays2[ınt32]);
                ınt32++;
            }
            string str = data;
            return str;
        }
        #endregion
        #region mantıksal yardımlar
        public static string[] BasBitKodAl(string strBas,string strBit,string separator)
        {
            string[] _st = strBas.Split('-');
            string[] _st1 = strBit.Split('-');
            string bas = _st[0].Replace(" ", "") != "" ? _st[0].Replace(" ", "") : "";
            string bit = _st1[0].Replace(" ", "") != "" ? _st1[0].Replace(" ", "") : "zzzzzzzzzzzzzzzzzzzzz";
            string[] sonuc =  { bas, bit };
            return sonuc;
        }
        public static int[] BasBitKodAl(string strBas, string strBit)
        {
            int bas = strBas != "" ? Convert.ToInt32(strBas) : 0;
            int bit = strBit != "" ? Convert.ToInt32(strBit) : 99999999;
            int[] sonuc = { bas, bit };
            return sonuc;
        }
        public static string NumberToTextForMoney(decimal tmpNumber, int dilId, string strUnit, string strDecimalUnit)
        {
            tmpNumber = YardimciIslemler.DecimalFormatlaDec(tmpNumber, 2);
            string strDecimalPart = String.Empty;
            string strIntegerPart = String.Empty;
            string strDecimalsep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (tmpNumber.ToString().IndexOf(strDecimalsep) > -1)
            {
                strIntegerPart = tmpNumber.ToString().Substring(0, tmpNumber.ToString().IndexOf(strDecimalsep));
                strDecimalPart = tmpNumber.ToString().Substring(tmpNumber.ToString().IndexOf(strDecimalsep) + 1);
            }
            else
            {
                strIntegerPart = tmpNumber.ToString();
                strDecimalPart = "";
            }
            if (dilId == (int)Dil.Turkce)
            { 
                if (strDecimalPart != "" && strDecimalPart != "00")
                    return NumberToText(long.Parse(strIntegerPart), dilId, strUnit) + " " + strUnit + " " + NumberToText(long.Parse(strDecimalPart), dilId, strUnit) + " " + strDecimalUnit;
                else
                    return NumberToText(long.Parse(strIntegerPart), dilId, strUnit) + " " + strUnit;
            }
            else
            {
                if (strDecimalPart != "" && strDecimalPart != "00")
                    return NumberToWords(long.Parse(strIntegerPart), dilId, strUnit) + " " + strUnit + " " + NumberToWords(long.Parse(strDecimalPart), dilId, strUnit) + " " + strDecimalUnit;
                else
                    return NumberToWords(long.Parse(strIntegerPart), dilId, strUnit) + " " + strUnit;
            }
        }
        public static string NumberToText(long tmpNumber, int dilId, string unit)
        {

            int LenOfNumber;

            int LenMod3;

            int MaxAmount = 0;

            int i, B;

            string Text = string.Empty;

            string strNumber;

            string[,] Numbers = new string[4, 10];

            string[] Steps = new string[5];

            string x;

            string y;

            int lstX;



            //Numbers dizisine değerleri ata

            if (dilId == (int)Dil.Turkce)
            {

                Numbers[3, 1] = "BİR";

                Numbers[3, 2] = "İKİ";

                Numbers[3, 3] = "ÜÇ";

                Numbers[3, 4] = "DÖRT";

                Numbers[3, 5] = "BEŞ";

                Numbers[3, 6] = "ALTI";

                Numbers[3, 7] = "YEDİ";

                Numbers[3, 8] = "SEKİZ";

                Numbers[3, 9] = "DOKUZ";



                Numbers[2, 1] = "ON";

                Numbers[2, 2] = "YİRMİ";

                Numbers[2, 3] = "OTUZ";

                Numbers[2, 4] = "KIRK";

                Numbers[2, 5] = "ELLİ";

                Numbers[2, 6] = "ALTMIŞ";

                Numbers[2, 7] = "YETMİŞ";

                Numbers[2, 8] = "SEKSEN";

                Numbers[2, 9] = "DOKSAN";



                Numbers[1, 1] = "YÜZ";

                Numbers[1, 2] = "İKİYÜZ";

                Numbers[1, 3] = "ÜÇYÜZ";

                Numbers[1, 4] = "DÖRTYÜZ";

                Numbers[1, 5] = "BEŞYÜZ";

                Numbers[1, 6] = "ALTIYÜZ";

                Numbers[1, 7] = "YEDİYÜZ";

                Numbers[1, 8] = "SEKİZYÜZ";

                Numbers[1, 9] = "DOKUZYÜZ";



                //Steps dizisine değerleri ata

                Steps[0] = "";

                Steps[1] = "BİN";

                Steps[2] = "MİLYON";

                Steps[3] = "MİLYAR";

                Steps[4] = "TİRİLYON";

            }

            else
            {

                Numbers[3, 1] = "ONE";

                Numbers[3, 2] = "TWO";

                Numbers[3, 3] = "THREE";

                Numbers[3, 4] = "FOUR";

                Numbers[3, 5] = "FIVE";

                Numbers[3, 6] = "SIX";

                Numbers[3, 7] = "SEVEN";

                Numbers[3, 8] = "EIGHT";

                Numbers[3, 9] = "NINE";



                Numbers[2, 1] = "TEN";

                Numbers[2, 2] = "TWENTY";

                Numbers[2, 3] = "THIRTY";

                Numbers[2, 4] = "FOURTY";

                Numbers[2, 5] = "FIFTY";

                Numbers[2, 6] = "SIXTY";

                Numbers[2, 7] = "SEVENTY";

                Numbers[2, 8] = "EIGHTY";

                Numbers[2, 9] = "NINETY";



                Numbers[1, 1] = "ONEHUNDRED";

                Numbers[1, 2] = "TWOHUNDRED";

                Numbers[1, 3] = "THREEHUNDRED";

                Numbers[1, 4] = "FOURHUNDRED";

                Numbers[1, 5] = "FIVEHUNDRED";

                Numbers[1, 6] = "SIXHUNDRED";

                Numbers[1, 7] = "SEVENHUNDRED";

                Numbers[1, 8] = "EIGHTHUNDRED";

                Numbers[1, 9] = "NINEHUNDRED";



                //Steps dizisine değerleri ata

                Steps[0] = "";

                Steps[1] = "THOUSAND";

                Steps[2] = "MILLION";

                Steps[3] = "BILLION";

                Steps[4] = "TRILYON";

            }

            //Sayıyı stringe çevir

            strNumber = tmpNumber.ToString();

            //Stringin uzunluğunu bul

            LenOfNumber = strNumber.Length;

            LenMod3 = LenOfNumber % 3;

            //İlk basamağı üçe tamamla

            if (LenMod3 != 0)
            {

                for (i = 1; i <= (3 - LenMod3); i++)
                {

                    strNumber = "0" + strNumber;

                }

                LenOfNumber = LenOfNumber + (3 - LenMod3);

            }



            if (LenOfNumber >= 1 && LenOfNumber <= 3)

                MaxAmount = 0;

            else if (LenOfNumber >= 4 && LenOfNumber <= 6)

                MaxAmount = 1;

            else if (LenOfNumber >= 7 && LenOfNumber <= 9)

                MaxAmount = 2;

            else if (LenOfNumber >= 10 && LenOfNumber <= 12)

                MaxAmount = 3;

            else if (LenOfNumber >= 13 && LenOfNumber <= 15)

                MaxAmount = 4;



            B = 0;



            while (MaxAmount >= 0)
            {



                y = strNumber.Substring(B, 3);

                for (i = 0; i < 3; i++)
                {

                    x = y.Substring(i, 1);

                    if (int.Parse(x) == 0)

                        Text = Text + "";

                    else
                    {

                        Text = Text + Numbers[i + 1, int.Parse(x)];

                        lstX = int.Parse(x);

                    }

                }

                if (y != "000")

                    Text = Text + Steps[MaxAmount] + " ";



                MaxAmount = MaxAmount - 1;

                B = B + 3;

            }

            //texti uygun hale getir

            if (Text.StartsWith("birbin")) Text = Text.Substring(3);

            return Text;

        }
        public static string NumberToWords(long number, int dilId, string unit)
        {
            string words = "";
            if (dilId == (int)Dil.Ingilizce)
            {
                if (number == 0)
                    return "ZERO";

                if (number < 0)
                    return "mMINUS " + NumberToWords(Math.Abs(number), dilId,unit);

                words = "";

                if ((number / 1000000) > 0)
                {
                    words += NumberToWords(number / 1000000, dilId, unit) + " MILLION ";
                    number %= 1000000;
                }

                if ((number / 1000) > 0)
                {
                    words += NumberToWords(number / 1000, dilId, unit) + " THOUSAND ";
                    number %= 1000;
                }

                if ((number / 100) > 0)
                {
                    words += NumberToWords(number / 100, dilId, unit) + " HUNDRED ";
                    number %= 100;
                }

                if (number > 0)
                {
                    if (words != "")
                        words += "and ";

                    var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                    var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                    if (number < 20)
                        words += unitsMap[number];
                    else
                    {
                        words += tensMap[number / 10];
                        if ((number % 10) > 0)
                            words += "-" + unitsMap[number % 10];
                    }
                }
            }
            else if (dilId == (int)Dil.Turkce)
            {
                if (number == 0)
                    return "SIFIR";

                if (number < 0)
                    return "- " + NumberToWords(Math.Abs(number), dilId, unit);

                words = "";

                if ((number / 1000000) > 0)
                {
                    words += NumberToWords(number / 1000000, dilId, unit) + " milyon ";
                    number %= 1000000;
                }

                if ((number / 1000) > 0)
                {
                    words += NumberToWords(number / 1000, dilId, unit) + " bin ";
                    number %= 1000;
                }

                if ((number / 100) > 0)
                {
                    words += NumberToWords(number / 100, dilId, unit) + " yüz ";
                    number %= 100;
                }

                if (number > 0)
                {
                    if (words != "")
                        words += "and ";

                    var unitsMap = new[] { "sıfır", "bir", "iki", "üç", "dört", "beş", "altı", "yedi", "sekiz", "dokuz", "on", "onbir", "oniki", "onüç", "ondort", "onbeş", "onaltı", "onyedi", "onsekiz", "ondokuz" };
                    var tensMap = new[] { "sıfır", "on", "yirmi", "otuz", "kırk", "elli", "altmış", "yetmiş", "seksen", "doksan" };

                    if (number < 20)
                        words += unitsMap[number];
                    else
                    {
                        words += tensMap[number / 10];
                        if ((number % 10) > 0)
                            words += "-" + unitsMap[number % 10];
                    }
                }
            }
            return words;
        }
     
        public static decimal iskontoHesapla(decimal tutar, decimal yuzde, decimal? yuzde2)
        {
            decimal temp = tutar * yuzde / 100;
            if (yuzde2 != null && yuzde2 != 0)
            {
                temp= temp * (decimal)yuzde2 / 100;
            }
            return Convert.ToDecimal(String.Format("{0:0.00}",temp));
        }
        public static decimal kdvHesapla(int? kdvYuzdeId, decimal netTutar)
        {
            decimal kdvYuzde = 0;
            if (kdvYuzdeId == (int)KdvEn.BIR)
                kdvYuzde = 1;
            else if (kdvYuzdeId == (int)KdvEn.SEKIZ)
                kdvYuzde = 8;
            else if (kdvYuzdeId == (int)KdvEn.ONSEKIZ)
                kdvYuzde = 18;
            else if (kdvYuzdeId == (int)KdvEn.BIRSEKSEN)
                kdvYuzde = Convert.ToDecimal(1.8);
            return Convert.ToDecimal(String.Format("{0:0.00}",netTutar * kdvYuzde / 100));
        }
        public static int[] KirilimDegerDon(int? id)
        {
            int[] kirilimDeger = new int[5];
            //using (b2cEntities context = new  b2cEntities())
            //{
            //    var list = (from k in context.KIRILIM_TIP
            //                where k.ID == id
            //                select k).FirstOrDefault();
            //    if (list != null)
            //    {
            //        for (int i = 0; i < 5; i++)
            //        {
            //            kirilimDeger[i] = Convert.ToInt32(list.SEKIL.Substring(i, 1));
            //        }
            //        //"\\w\\w\\w-\\w\\w-\\w\\w\\w\\w");
            //    }
                return kirilimDeger;
            //}
        }
        public static string KirilimUygula(int? id)
        {
            string temp="";
            //using (b2cEntities context = new  b2cEntities())
            //{
            //    int sayi=0;
            //    var list = (from k in context.KIRILIM_TIP
            //                where k.ID == id
            //                select k).FirstOrDefault();
            //    if (list != null)
            //    {
            //        for (int i = 0; i < 5; i++)
            //        {
            //            sayi = Convert.ToInt32(list.SEKIL.Substring(i,1));
            //            if (sayi > 0)
            //            {
            //                for (int j = 0; j < sayi; j++)
            //                {
            //                    temp += "\\w";
            //                }
            //                temp+=" ";
            //            }
            //        }
            //        //"\\w\\w\\w-\\w\\w-\\w\\w\\w\\w");
            //    }

            //}
            //temp =ListHelper.SonKarakteriSil(temp);
            return temp;
        }
        public static string KirilimUygula(int? id,string gelen,string Kirilim)
        {
            if (Kirilim == "") return gelen; 
            string temp = "";
            int ilkIndex = 0;
                int sayi = 0;
                sayi = Convert.ToInt32(Kirilim.Substring(0, 1));
                if (gelen.Length < sayi) return gelen;
                for (int i = 0; i < 5; i++)
                {
                    if (Kirilim.Length <= i) return temp;
                    sayi = Convert.ToInt32(Kirilim.Substring(i, 1));
                    if (sayi == 0)
                    {
                        if (gelen.Length > ilkIndex)  temp += gelen.Substring(ilkIndex, gelen.Length - ilkIndex) + " ";
                    }
                    else if (gelen.Length - (temp.Replace(" ", "").Length) >= sayi)
                    {
                        temp += gelen.Substring(ilkIndex, sayi) + " ";
                    }
                    else if (temp.Replace(" ", "").Length > 0 && gelen.Length - (temp.Replace(" ", "").Length) > 0)
                    {
                        temp += gelen.Substring(ilkIndex, gelen.Length - (temp.Replace(" ", "").Length));
                    }
                    

                    //if ((temp.Length - (gelen.Length-1)<0) && temp.Length - (gelen.Length-1) > sayi)
                    //{
                    //sonuc += gelen.Substring(ilkIndex, sayi) + " ";
                    //temp += gelen.Substring(ilkIndex, sayi) + " ";
                   // }
                    //else
                    //{
                    //    temp += gelen.Substring(ilkIndex, temp.Length - (gelen.Length-1)) + " ";
                    //    break;
                    //}
                    ilkIndex += sayi;
                    if (sayi == 0) break;
                }
            //temp =ListHelper.SonKarakteriSil(temp);
            temp = temp.Trim();
            return temp;
        }        
        public static void RaporParametersiSet(Dictionary<string, string> dictionary, Microsoft.Reporting.WinForms.ReportParameter[] reportParameter, string alanAdi, string deger)
        {
            if (dictionary.ContainsKey(alanAdi))
            {
                for (int i = 0; i < reportParameter.Length; i++)
                {
                    if (reportParameter[i]!=null && reportParameter[i].Name == alanAdi)
                    {
                        reportParameter[i] = new ReportParameter(alanAdi, deger);
                    }
                }
            }
        }
         
        #endregion
        #region Prodmadan istenenler
        public static void ButonDurumu(Button button1)
        {
            button1.Enabled = true;
        }
        public static bool SetTabliCalis()
        {
            return true;
        }
        public static void SirketDoldur(LookUpEdit SIRKETlke)
        {
            Dictionary<string, string> a = new Dictionary<string, string>();
            a.Add("01", "DEGA");
            a.Add("10", "EUROBUMP");
            //WinFormsHelper.GridLookUpEditDuzenle(lke, a);

            SIRKETlke.EditValue = "01";
        }
        //public static void SirketDoldur(GridLookUpEdit SIRKETgle)
        //{
        //    Dictionary<string, string> a = new Dictionary<string, string>();
        //    a.Add("02", "Takosan Taysad");
        //    a.Add("10", "Takosan Tepeören");
        //    //a.Add("20", "TAKOSAN");
        //    //WinFormsHelper.GridLookUpEditDuzenle(SIRKETgle, a);
        //    SIRKETgle.EditValue = "02";
        //}
        public static void SirketDoldur(GridLookUpEdit SIRKETgle)
        {
            Dictionary<string, string> a = new Dictionary<string, string>();
            a.Add("02", "Takosan Taysad");
             a.Add("10", "Takosan Tepeören");
            //a.Add("20", "TAKOSAN");
            ListHelper.GridLookUpEditDuzenle(SIRKETgle, a);
            SIRKETgle.EditValue = "02";
        }
        #endregion
        public static string[] KullaniciMesajYaz()
        {
            string[] mesaj = { "", "", "","" };
            MesajCntrl cn = new MesajCntrl();
            List<MesajVm> list = cn.Liste_Al(new MesajVm
                {
                    KIME_KULLANICI_ID = Globals.gnKullaniciId,
                    OKUNDU_E_H = (int)EvetHayirEn.Hayir
                }).ToList();
            if (list != null && list.Count > 0)
            {
                mesaj[0] = Convert.ToString(list[0].ID);
                mesaj[1] = list[0].MESAJ != null ? list[0].MESAJ : "";
                mesaj[2] = list[0].MESAJ_2 != null ? list[0].MESAJ_2 : "";
                mesaj[3] = list[0].MESAJ_3 != null ? list[0].MESAJ_3 : "";

            }
            return mesaj;
        }
        public static string IstenilenDileCevir(string gelen)
        {
            string temp = "";
            temp = Globals.rman.GetString(gelen);
            if (temp == null) { temp = gelen; }
            if (temp.Trim() == "") { temp = gelen; }
            
            return temp;
        }
         
        public static void TransactSqlGuncelle(string update, string kriter)
       {
           //if (kriter == "") return;
           //string strCon = "Data Source={0};Persist Security Info=True;User ID={1};Password={2};Initial Catalog={3};MultipleActiveResultSets=True; Timeout=60";
           //SqlConnection cn = new SqlConnection();
           //cn.ConnectionString = String.Format(strCon, ".", "sa", "bgssup", Globals.db);
           //cn.Open();
           //SqlCommand cmd = new SqlCommand();
           //cmd.Connection = cn;
           //cmd.CommandType = CommandType.Text;
           //cmd.CommandText = update + kriter;
           //cmd.ExecuteNonQuery();
       }
        internal static void TransactSqlGuncelle(string sqlGuncelleme, SqlCommand sqlCmd, string p)
       {
           throw new NotImplementedException();
       }
        public static void TransactSqlGuncelle(string sqlGuncelleme, SqlCommand sqlCmd)
       {
           if (sqlGuncelleme == "") return;
           string strCon = "Data Source={0};Persist Security Info=True;User ID={1};Password={2};Initial Catalog={3};MultipleActiveResultSets=True; Timeout=60";
           SqlConnection cn = new SqlConnection();
           cn.ConnectionString = String.Format(strCon, Globals.serverIp, "sa", "bgssup",Globals.db);
           cn.Open();
           //SqlCommand cmd = new SqlCommand();
           sqlCmd.Connection = cn;
           sqlCmd.CommandType = CommandType.Text;
           sqlCmd.CommandText  = "update STOK_FIS_SATIR SET " + sqlGuncelleme;
           sqlCmd.ExecuteNonQuery();
           cn.Close();
           cn.Dispose();
           sqlCmd.Dispose();
       }
        public static void UserControlKayitSonucu(int hataKod)
        {
            if (hataKod != 100)
            {
                MessageBox.Show(Globals.rman.GetString("KAYIT_BASARISIZ") + " " + Globals.rman.GetString(Globals.hataMesaji));
            }
            else
            {
                MessageBox.Show(Globals.rman.GetString("KAYIT_BASARILI"));
            }
        }
        public static void ProgramBeklet()
        {
            for (long i = 0; i < 1000000000; i++)
            {

            }
        }
        public static void ProgramBeklet(long j)
        {
            for (long i = 0; i < j; i++)
            {

            }
        }

        public static string GetGuncellemeYolu()
        {
            return @"\\192.168.1.13\bordro/";
        }
    }
}
