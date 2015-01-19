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
//using System.Linq.Dynamic;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Prodma.SistemB2C.Models;
using System.Globalization;
using System.Data.Objects.SqlClient;
using Prodma.SistemB2C.Controllers;
using B2C.Models;
using B2C.Controllers;
using Prodma.DataAccessB2C.ozceteFiyatlar;
using System.Web.Script.Serialization;
using System.ServiceModel;
using Newtonsoft.Json;
using Npgsql;
using Prodma.DataAccessB2C;
namespace Prodma.DataAccessB2C
{
    public class B2cIslemlerService
    {
        public static void KargoNumarasiSet( List<SepetGosterimVm> listOrderProduct)
        {
            orderCntrl cntrl = new orderCntrl();
            List<orderVm> listOrder = new List<orderVm>();
            orderVm vm = new orderVm();
            vm.id = listOrderProduct[0].order_id;
            listOrder = cntrl.Liste_Al(vm);
            if (listOrder!=null && listOrder.Count==1)
	        {
		      listOrder[0].cargo_no = listOrderProduct[0].cargo_no;
              cntrl.Guncelle(listOrder[0],listOrder[0].id);
	        }
        }
        public static int? getB2CCari_Adres_ID(int p)
        {
            throw new NotImplementedException();
        }
        public static int getB2CCari_ID(int p)
        {
            return 0;
            //using (ProdmaEntities context = new ProdmaEntities())
            //{
            //    var list = (from skiy in context.CARI
            //                where skiy.customer_id == p
            //                select skiy.ID).FirstOrDefault();
            //    return list;
            //}
        }
        public static int getB2CCari_ID(int p,int cariTip)
        {
            return 0;
            //using (ProdmaEntities context = new ProdmaEntities())
            //{
            //    var list = (from skiy in context.CARI
            //                where skiy.customer_id == p && skiy.CARI_TIP_ID==cariTip
            //                select skiy.ID).FirstOrDefault();
            //    return list;
            //}
        }
        public static int getB2CToptanci_id(int p)
        {
            return 0;
            //using (ProdmaEntities context = new ProdmaEntities())
            //{
            //    var list = (from skiy in context.CARI
            //                where skiy.ID == p
            //                select skiy.customer_id).FirstOrDefault();
            //    return Convert.ToInt32(list)    ;
            //}
        }
        public static int getB2CStok_ID(int p)
        {
            return 0;
            //using (ProdmaEntities context = new ProdmaEntities())
            //{
            //    var list = (from skiy in context.STOK
            //                where skiy.product_id == p
            //                select skiy.ID).FirstOrDefault();
            //    return list;
            //}
        }
        public static object getOzceteFiyat(string stokKod, string tedarikci)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress remoteAddress = new EndpointAddress("http://oss.ozcete.com.tr/servis/OzceteParcasatis.asmx");
            binding.Name = "ParcaSatisSoap";
            binding.AllowCookies = false;
            List<SepetGosterimVm> fiyat = new List<SepetGosterimVm>();
            OzceteParcaSatisSoapClient client = new OzceteParcaSatisSoapClient(binding, remoteAddress);
            //string fiyatlar = client.fn_stok("P1", "E0011", "430.1786.00", "Zimmermann", "xx45fg");
            string fiyatlar = client.fn_stok_listesi(stokKod, tedarikci,Convert.ToDouble(1), "xx45fg");
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            var result = JsonConvert.DeserializeObject<List<fiyatlarList>>(fiyatlar);
            //var list = json_serializer.DeserializeObject(fiyatlar);
            //   var data = json_serializer.Deserialize<Dictionary<string, Dictionary<string, string>>[]>(fiyatlar);
            //  Test routes_list =
            //(Test)json_serializer.DeserializeObject(fiyatlar);
            //fiyat.Add(new SepetGosterimVm( { IDataAdapter }
            return result;
        }
        public static object getEgeYazilim()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress remoteAddress = new EndpointAddress("http://sorgu.egeyazilim.net/katalog/parcasatis.asmx");
            binding.Name = "ParcaSatisSoap1";
            binding.AllowCookies = false;
            List<SepetGosterimVm> fiyat = new List<SepetGosterimVm>();
            Prodma.DataAccessB2C.egeyazilim.ParcaSatisSoapClient client = new Prodma.DataAccessB2C.egeyazilim.ParcaSatisSoapClient(binding, remoteAddress);
            //string fiyatlar = client.fn_stok("P1", "E0011", "430.1786.00", "Zimmermann", "xx45fg");
            Prodma.DataAccessB2C.egeyazilim.ArrayOfStok_arac_parameter  list = new  Prodma.DataAccessB2C.egeyazilim.ArrayOfStok_arac_parameter ();
            Prodma.DataAccessB2C.egeyazilim.stok_arac_parameter vm = new egeyazilim.stok_arac_parameter();
            
            vm.tedarikci_id = "TRW";
            vm.tedarikci_kodu = "GDB106";
            list.Add(vm);
            string fiyatlar = client.fn_stok_arac(list,"xx45fg");
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            var result = JsonConvert.DeserializeObject<List<fiyatlarList>>(fiyatlar);
            //var list = json_serializer.DeserializeObject(fiyatlar);
            //   var data = json_serializer.Deserialize<Dictionary<string, Dictionary<string, string>>[]>(fiyatlar);
            //  Test routes_list =
            //(Test)json_serializer.DeserializeObject(fiyatlar);
            //fiyat.Add(new SepetGosterimVm( { IDataAdapter }
            return result;
        }
        public static string Alis_Servis_Siparis_Olustur(int toptanci_id, List<SepetGosterimVm> listOrderProduct)
        {
            if (toptanci_id==(int)ToptanciEn.Ozcete)
            {
                return setOzceteSiparis(listOrderProduct);
            }
            return "";
        }
        public static string setOzceteSiparisServices()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress remoteAddress = new EndpointAddress("http://oss.ozcete.com.tr/servis/OzceteParcasatis.asmx");
            binding.Name = "ParcaSatisSoap";
            binding.AllowCookies = false;
            List<SepetGosterimVm> fiyat = new List<SepetGosterimVm>();
            OzceteParcaSatisSoapClient client = new OzceteParcaSatisSoapClient(binding, remoteAddress);
            string fiyat_1 = client.fn_web_sifre_olustur("663868", "xx45fg");
            Prodma.DataAccessB2C.ozceteFiyatlar.ArrayOfErp_siparis list = new Prodma.DataAccessB2C.ozceteFiyatlar.ArrayOfErp_siparis();
            Prodma.DataAccessB2C.ozceteFiyatlar.erp_siparis vm = new Prodma.DataAccessB2C.ozceteFiyatlar.erp_siparis();
            string fiyat_4 = client.fn_cari_hareket_siparis_no("139092", "xx45fg");
            string fiyat_2 = client.fn_cari_hareket("xx45fg");
            //string fiyat_3 = client.fn_cari_hareket_detay("03.06.2014","0000033103", "xx45fg");
            vm.stok_kodu = "SO921";
            vm.tedarikci = "SARDES";
            vm.miktar = "1";
            list.Add(vm);
            vm = new Prodma.DataAccessB2C.ozceteFiyatlar.erp_siparis();
            vm.stok_kodu = "ADC42247";
            vm.tedarikci = "BLUEPRINT";
            vm.miktar = "1";
            list.Add(vm);
            string fiyatlar = client.fn_siparis_olustur(list, "xx45fg");
            return fiyatlar;
        }
        public static string setOzceteSiparis(List<SepetGosterimVm> listOrderProduct)
        {
            string erp_no = "";
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress remoteAddress = new EndpointAddress("http://oss.ozcete.com.tr/servis/OzceteParcasatis.asmx");
            binding.Name = "ParcaSatisSoap";
            binding.AllowCookies = false;
            List<SepetGosterimVm> fiyat = new List<SepetGosterimVm>();
            OzceteParcaSatisSoapClient client = new OzceteParcaSatisSoapClient(binding, remoteAddress);
            Prodma.DataAccessB2C.ozceteFiyatlar.ArrayOfErp_siparis list = new Prodma.DataAccessB2C.ozceteFiyatlar.ArrayOfErp_siparis();
            Prodma.DataAccessB2C.ozceteFiyatlar.erp_siparis vm = new Prodma.DataAccessB2C.ozceteFiyatlar.erp_siparis();
            foreach (var item in listOrderProduct)
            {
                vm = new Prodma.DataAccessB2C.ozceteFiyatlar.erp_siparis();
                vm.stok_kodu = item.product_code;
                vm.tedarikci = item.tedarikci;
                vm.miktar = Convert.ToString(item.siparis_miktar);
                list.Add(vm);
            }
            string artis = client.fn_siparis_olustur(list, "xx45fg");
            string urlSifre =  client.fn_web_sifre_olustur(artis, "xx45fg");
            string url = "oss.ozcete.com.tr/onay.aspx?kod=" + urlSifre;
            try
            {
                System.Diagnostics.Process.Start("IExplore", url);
                erp_no = client.fn_siparis_erp_no(Convert.ToInt32(artis), "xx45fg");
            }
            catch (Exception)
            {
                MessageBox.Show(
                   "The system could not open the specified Internet Explorer.",
                   "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            erp_no = client.fn_siparis_erp_no(Convert.ToInt32(artis), "xx45fg");

            return erp_no;
        }
        public static string setSenerOtotSiparis()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress remoteAddress = new EndpointAddress("http://oss.ozcete.com.tr/servis/OzceteParcasatis.asmx");
            binding.Name = "ParcaSatisSoap";
            binding.AllowCookies = false;
            List<SepetGosterimVm> fiyat = new List<SepetGosterimVm>();
            OzceteParcaSatisSoapClient client = new OzceteParcaSatisSoapClient(binding, remoteAddress);
            string fiyat_1 = client.fn_web_sifre_olustur("663868", "xx45fg");
            Prodma.DataAccessB2C.ozceteFiyatlar.ArrayOfErp_siparis list = new Prodma.DataAccessB2C.ozceteFiyatlar.ArrayOfErp_siparis();
            Prodma.DataAccessB2C.ozceteFiyatlar.erp_siparis vm = new Prodma.DataAccessB2C.ozceteFiyatlar.erp_siparis();
            string fiyat_4 = client.fn_cari_hareket_siparis_no("139092", "xx45fg");
            string fiyat_2 = client.fn_cari_hareket("xx45fg");
            //string fiyat_3 = client.fn_cari_hareket_detay("03.06.2014", "0000033103", "xx45fg");
            vm.stok_kodu = "SO921";
            vm.tedarikci = "SARDES";
            vm.miktar = "1";
            list.Add(vm);
            vm = new Prodma.DataAccessB2C.ozceteFiyatlar.erp_siparis();
            vm.stok_kodu = "ADC42247";
            vm.tedarikci = "BLUEPRINT";
            vm.miktar = "1";
            list.Add(vm);
            string fiyatlar = client.fn_siparis_olustur(list, "xx45fg");
            return fiyatlar;
        }
        public static void AlisFiyatGuncelle(GridCheckMarksSelection selection, BindingSource bn,int sepetSecim)
        {
            List<fiyatlarList> fiyat = new List<fiyatlarList>();
            List<SepetGosterimVm> listOrderProduct = new List<SepetGosterimVm>();
            List<SepetGosterimVm> listOrderEklenecek = new List<SepetGosterimVm>();
            for (int i = 0; i < selection.SelectedCount; i++)
            {
                listOrderProduct.Add((SepetGosterimVm)selection.GetSelectedRow(i));
            }

            foreach (var item in listOrderProduct)
            {
                fiyat = new List<fiyatlarList>();
                fiyat = ServistenFiyatAl(Convert.ToInt32 (item.vehicle_toptanci_id),item.product_code, item.tedarikci);
                item.ambar_miktar = Convert.ToDouble(fiyat[0].depoToplam);
                if ( Convert.ToInt32(fiyat[0].liste_fiyati_para_id)!=(int)DovizEn.TL)
                {
                    item.ALIS_FIYAT = Convert.ToDecimal(fiyat[0].isk_hesap7.Replace('.', ',')) * Convert.ToDecimal(fiyat[0].kur.Replace('.', ','));
                }
                else
                {
                    item.ALIS_FIYAT = Convert.ToDecimal(fiyat[0].isk_hesap7.Replace('.', ','));
                }
                item.KAR_ORAN = item.SATIS_FIYAT / item.ALIS_FIYAT;
                vehicle_toptanciCntrl cntrToptanci = new vehicle_toptanciCntrl();
                List<vehicle_toptanciVm> toptanciList = new List<vehicle_toptanciVm>();
                toptanciList = cntrToptanci.Liste_Al(null);
                if (sepetSecim == (int)SepetSecimiEn.OdemeIslemiTamamlandi)
                {
                    foreach (var item1 in toptanciList)
                    {
                        if (item1.id != item.vehicle_toptanci_id)
                        {
                            SepetGosterimVm vm = new SepetGosterimVm();
                            vm.ID = item.id;
                            vm.quantity = item.quantity;
                            vm.price = item.price;
                            vm.product_code = item.product_code;
                            vm.product_name = item.product_name;
                            vm.vehicle_toptanci_id = item.vehicle_toptanci_id;
                            vm.product_id = item.product_id;
                            vm.order_status_type_id = item.order_status_type_id;
                            vm.order_id = item.order_id;
                            vm.order = item.order;
                            vm.SATIS_FIYAT = item.price;
                            vm.tedarikci = item.tedarikci;
                            vm.order_product_id = item.order_product_id;
                            vm.delivery_address = item.delivery_address;
                            vm.billing_address = item.billing_address;
                            fiyat = new List<fiyatlarList>();
                            fiyat = ServistenFiyatAl(item1.id, item.product_code, item.tedarikci);
                            if (fiyat != null)
                            {
                                vm.ambar_miktar = Convert.ToDouble(fiyat[0].depoToplam);
                                if (Convert.ToInt32(fiyat[0].liste_fiyati_para_id) != (int)DovizEn.TL)
                                {
                                    vm.ALIS_FIYAT = Convert.ToDecimal(fiyat[0].isk_hesap7.Replace('.', ',')) * Convert.ToDecimal(fiyat[0].kur.Replace('.', ','));
                                }
                                else
                                {
                                    vm.ALIS_FIYAT = Convert.ToDecimal(fiyat[0].isk_hesap7.Replace('.', ','));
                                }
                                vm.ALIS_FIYAT = Convert.ToDecimal(fiyat[0].isk_hesap7.Replace('.', ','));
                                vm.KAR_ORAN = vm.SATIS_FIYAT / vm.ALIS_FIYAT;
                                listOrderEklenecek.Add(vm);
                            }
                        }
                     }
                 }
            }
            listOrderProduct.AddRange(listOrderEklenecek);
            bn.DataSource = listOrderProduct;
        }
        private static List<fiyatlarList> ServistenFiyatAl(int toptanciId,string product_code,string tedarikci)
        {
            if (toptanciId==(int)ToptanciEn.Ozcete || toptanciId ==0)
            {
                List<fiyatlarList> list = (List<fiyatlarList>)getOzceteFiyat(product_code, tedarikci);
                //list[0].birim_net_fiyat = Convert.ToString(Convert.ToDouble(list[0].birim_net_fiyat));
                list[0].depoToplam = Convert.ToDouble(list[0].adana) + Convert.ToDouble(list[0].istanbul);
                return list;
            }
            return null;
        }
        public static List<SepetGosterimVm> getB2COrderslinq(int p)
        {
            Prodma.DataAccessB2C.b2cEntities context = new Prodma.DataAccessB2C.b2cEntities();
            using (context)
            {
                //auth_user
                //var listStatus = from fis in co
                //var listStatus = (from fis in context.order_status
                //                  group fis by new { fis.order_product_id } into g
                //                  let value = g.OrderByDescending(r => r.id).FirstOrDefault()
                //                  select new
                //                  {
                //                      status_id = value.status_id,
                //                      order_id = value.order_id,
                //                      order_product_id = value.order_product_id,
                //                  }).ToList();

                var listSon = (from sepet in context.order_product
                               select new SepetGosterimVm()
                               {
                                   ID = sepet.id,
                                   quantity = sepet.quantity,
                                   price = sepet.price,
                                   product_code = sepet.product.partner_code,
                                   product_name = sepet.product.name,
                                   vehicle_toptanci_id = sepet.vehicle_toptanci_id,
                                   product_id = sepet.product_id,
                                   order_status_type_id = sepet.order_status.order_status_type_id,
                                   order_id = sepet.order_id,
                               }).ToList();


                //var alis = (from k in listSon
                //            join a in context.tb_kart_stok_fiyatlar on k.product_id equals a.ege_stok_id
                //            select new SepetGosterimVm()
                //            {
                //                ID = k.ID,
                //                quantity = k.quantity,
                //                price = k.price,
                //                product_code = k.product_code,
                //                product_name = k.product_name,
                //                vehicle_toptanci_id = k.vehicle_toptanci_id,
                //                product_id = k.product_id,
                //                order_status_type_id = k.order_status_type_id,
                //                order_id = k.order_id,
                //                ambar_miktar = a.depo1 + a.depo2,
                //                ALIS_FIYAT = (decimal?)((decimal)a.fiyat * (1 - ((decimal)a.isk1 / 100)) * (1 - ((decimal)a.isk2 / 100)))
                //            }).OrderBy(x => x.ID).ToList();

                List<SepetGosterimVm> listReturn = new List<SepetGosterimVm>();
                listReturn = listSon.Where(w => w.order_status_type_id == p).ToList();
                return listReturn;
            }
        }
        public static void npsqlCek(List<OrderStatusList> orderStatusList)
        {
            string connstring = String.Format("Server={0};Port={1};" +
                  "User Id={2};Password={3};Database={4};",
                  "185.22.184.145", "5432", "postgres",
                  "lok651*-", "orsan");

            NpgsqlConnection cn = new NpgsqlConnection(connstring);

            string sql = " select  \"order\".id,\"order_status\".order_status_type_id from \"order\"";
            sql = "select \"order\".id, \"order_status\".order_status_type_id from \"order\" join (select DISTINCT ON (order_id) * from \"order_status\" order by order_id,id desc) \"order_status\"";
            sql += " on (\"order_status\".order_id = \"order\".id)";
            //sql += " on (\"order_status\".order_id = \"order\".id) join order_status_type t on (\"t\".id = \"order_status\".order_status_type_id)";


//            select "order".id, "order_status".order_status_type_id 
//from "order" join (select DISTINCT ON (order_id) * from "order_status" order by order_id, id desc) 
//"order_status" on ("order_status".order_id = "order".id)


            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(sql, cn);
            DataSet ds = new DataSet();
            ds.Reset();
            da1.Fill(ds);
            DataRow dr;
            OrderStatusList orderStatusListVm = new OrderStatusList();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = ds.Tables[0].Rows[i];
                orderStatusListVm = new OrderStatusList();
                orderStatusListVm.order_id = Convert.ToInt32(dr[0].ToString());
                //orderStatusListVm.order_id = (int)dr[0].ToString();
                orderStatusListVm.order_status_type_id = Convert.ToInt32(dr[1].ToString());
                orderStatusList.Add(orderStatusListVm);
            }
        }
        public static List<SepetGosterimVm> getB2COrders(int p)
        {

            List<SepetGosterimVm> sepetList = new List<SepetGosterimVm>();
            List<OrderStatusList> orderStatusList = new List<OrderStatusList>();
            npsqlCek(orderStatusList);
            Prodma.DataAccessB2C.b2cEntities context = new Prodma.DataAccessB2C.b2cEntities();
            using (context)
            {
                //var listSon = (from sepet in context.order_product
                //               join orderstaus in orderStatusList on sepet.order_id equals orderstaus.order_id
                //               select new SepetGosterimVm()
                //               {
                //                   ID = sepet.id,
                //                   quantity = sepet.quantity,
                //                   price = sepet.price,
                //                   product_code = sepet.product.partner_code,
                //                   product_name = sepet.product.name,
                //                   vehicle_toptanci_id = sepet.vehicle_toptanci_id,
                //                   product_id = sepet.product_id,
                //                   order_status_type_id = orderstaus.order_status_type_id,
                //                   order_id = sepet.order_id,
                //               }).ToList();

                var listSon = (from sepet in context.order_product
                               //  join orderstaus in orderStatusList on sepet.order_id equals orderstaus.order_id
                               select new SepetGosterimVm()
                               {
                                   order = "Müşteri : " + sepet.order.auth_user.email + " No : " + sepet.order.receipt_id,
                                   quantity = sepet.quantity,
                                   price = sepet.price,
                                   product_code = sepet.product.partner_code,
                                   product_name = sepet.product.name,
                                   vehicle_toptanci_id = sepet.vehicle_toptanci_id,
                                   product_id = sepet.product_id,
                                   order_status_type_id = 1,
                                   order_id = sepet.order_id,
                                   tedarikci = sepet.product.manufacturer.name,
                                   order_product_id = sepet.id,
                                   delivery_address = sepet.order.delivery_address,
                                   billing_address = sepet.order.billing_address,
                                   siparis_miktar = 0,
                                   auth_user_id = sepet.order.auth_user.id,
                                   payment_type = sepet.order.payment_type
                               }).ToList();

                sepetList = (from t in listSon
                             join c in orderStatusList
                             on t.order_id equals c.order_id into q1
                             from sonuc in q1.DefaultIfEmpty()
                             select new SepetGosterimVm()
                             {
                                 ID = t.id,
                                 quantity = t.quantity,
                                 price = t.price,
                                 product_code = t.product_code,
                                 product_name = t.product_name,
                                 vehicle_toptanci_id = t.vehicle_toptanci_id,
                                 product_id = t.product_id,
                                 order_status_type_id = sonuc!=null? sonuc.order_status_type_id : 1,
                                 order_id = t.order_id,
                                 order = t.order,
                                 SATIS_FIYAT = t.price / Convert.ToDecimal(1.18),
                                 tedarikci = t.tedarikci,
                                 order_product_id = t.order_product_id,
                                 delivery_address = t.delivery_address,
                                 billing_address = t.billing_address,
                                 siparis_miktar = t.quantity,
                                 gonderilen_miktar = t.quantity,
                                 gonderilecek_miktar = t.quantity,
                                 auth_user_id = t.auth_user_id,
                                 payment_type = t.payment_type,
                             }).ToList();

                //var son =  ( from ss in context.
                //             where ss.k

                //var alis1 = (from a in context.tb_kart_stok_fiyatlar 
                //            select new  
                //            {
                //                product_id = a.ege_stok_id,
                //                ambar_miktar = a.depo1 + a.depo2,
                //                ALIS_FIYAT = a.fiyat
                //            }).ToList();

                //var alis = (from k in sepetList
                //          join a in context.tb_kart_stok_fiyatlar on k.product_id equals a.ege_stok_id
                //          select new SepetGosterimVm()
                //          {
                //              ID = k.ID,
                //              quantity = k.quantity,
                //              price = k.price,
                //              product_code = k.product_code,
                //              product_name = k.product_name,
                //              vehicle_toptanci_id = k.vehicle_toptanci_id,
                //              product_id = k.product_id,
                //              order_status_type_id = k.order_status_type_id,
                //              order_id = k.order_id,
                //              ambar_miktar = a.depo1 + a.depo2,
                //              ALIS_FIYAT = (decimal?)((decimal)a.fiyat * (1 - ((decimal)a.isk1 / 100)) * (1 - ((decimal)a.isk2 / 100)))
                //          }).OrderBy(x => x.ID).ToList();


            }

            List<SepetGosterimVm> listReturn = new List<SepetGosterimVm>();
            listReturn = sepetList.Where(w => w.order_status_type_id == p).ToList();
            if (p==(int)SepetSecimiEn.SiparisHazirlandi)
            {
                B2cIslemlerService.AlisIrsaliyeDurumunuUpdate(listReturn);
            }
            return listReturn;
        }
        public static List<order_productVm> SepetSiparisListele(int id)
        {
            Prodma.DataAccessB2C.b2cEntities context = new Prodma.DataAccessB2C.b2cEntities();
            using (context)
            {
                var list1 = (from p in context.order_status
                             where p.order_status_type_id != 1 && p.order_id == 1
                             select new { id = p.order_id }).ToList();
                if (list1 == null || list1.Count == 0)
                {
                    var list = (from order_satir in context.order_product
                                where order_satir.order_id == id
                                select new order_productVm()
                                {
                                    ID = order_satir.id,
                                    quantity = order_satir.quantity,
                                    price = order_satir.price,
                                    product_code = order_satir.product.partner_code,
                                    product_name = order_satir.product.name,
                                    vehicle_toptanci_id = order_satir.vehicle_toptanci_id,
                                    product_id = order_satir.product_id,
                                    //STOK = new StokVm { product_id = order_satir.product.id, KOD = order_satir.product.partner_code, AD = order_satir.product.name },
                                    SIFIRLI = new orderVm() { customer_id = order_satir.order.customer_id },
                                }).OrderBy(x => x.ID).ToList();
                    return list;
                    decimal miktar = 0;
                    decimal sipMiktar = 0;
                    int stokeskiId = 0;
                    int sayi = 0;
                }
                return null;
                //List<Object> t = new List<object>();
                //if (list.Count > 0)
                //{
                //    stokeskiId = list[0].STOK_ID;
                //    for (int i = 0; i < list.Count; i++)
                //    {
                //        if (stokeskiId == list[i].STOK_ID)
                //        {
                //            sipMiktar += list[i].SIPARIS_MIKTAR;
                //            miktar = list[i].MIKTAR;
                //            sayi = i;
                //        }
                //        else
                //        {
                //            list[sayi].MIKTAR = miktar - sipMiktar;
                //            if (list[sayi].MIKTAR > 0)
                //            {
                //                list[sayi].TUTAR = Convert.ToDecimal(String.Format("{0:0.00000}", (list[sayi].MIKTAR) * list[sayi].FIYAT));
                //                list[sayi].TUTAR_DOVIZ = Convert.ToDecimal(String.Format("{0:0.00000}", (list[sayi].MIKTAR) * list[sayi].FIYAT_DOVIZ));
                //                t.Add(list[sayi]);
                //            }
                //            if (stokeskiId == 0) break;// son kayit ise fordan ciksin diye
                //            stokeskiId = list[i].STOK_ID;
                //            miktar = 0;
                //            sipMiktar = 0;
                //            i--;// kayit bir oncekine kayitta devam ediyor.
                //        }
                //        if (i == list.Count - 1) { stokeskiId = 0; i--; }// son kayit ise else'kayita''e girebilmesi icin
                //    }

                //}
                //return t.Count > 0 ? t : null;
            }
        }
        public static int? GetVarsayilanCariAdresYeri(int cariID, SepetGosterimVm satirVm)
        {
            return null;
            //CariAdresVm vmCariAdres = new CariAdresVm();
            //List<CariAdresVm> vmCariAdresList = new List<CariAdresVm>();
            //CariAdresCntrl cntrlCariAdres = new CariAdresCntrl();
            //vmCariAdres.CARI_ID = cariID;
            //vmCariAdresList = cntrlCariAdres.Liste_Al(vmCariAdres);
            //if (vmCariAdresList.Count == 0)
            //{
            //    vmCariAdres.CARI_ID = cariID;
            //    vmCariAdres.KOD = "01";
            //    vmCariAdres.AD = "Siparişten Oluştu";

            //    string a1 = "";
            //    string a2 = "";
            //    string a3 = "";
            //    string adres = satirVm.billing_address.Replace("\r", " ").Replace("\n", " ");
            //    if (adres.Length < 60)
            //    {
            //        a1 = adres;
            //    }
            //    else if (adres.Length < 120)
            //    {
            //        a1 = adres.Substring(0, 60);
            //        a2 = adres.Substring(60, adres.Length - 60);
            //    }
            //    else
            //    {
            //        a1 = adres.Substring(0, 60);
            //        a2 = adres.Substring(60, 60);
            //        a3 = adres.Substring(120, adres.Length - 120);
            //    }

            //    vmCariAdres.FATURA_ADRES_1 = a1;
            //    vmCariAdres.FATURA_ADRES_2 = a2;
            //    vmCariAdres.FATURA_ADRES_3 = a3;


            //    adres = satirVm.delivery_address.Replace("\r", " ").Replace("\n", " ");

            //    if (adres.Length < 60)
            //    {
            //        a1 = adres;
            //    }
            //    else if (adres.Length < 120)
            //    {
            //        a1 = adres.Substring(0, 60);
            //        a2 = adres.Substring(60, adres.Length - 60);
            //    }
            //    else
            //    {
            //        a1 = adres.Substring(0, 60);
            //        a2 = adres.Substring(60, 60);
            //        a3 = adres.Substring(120, adres.Length - 120);
            //    }

            //    vmCariAdres.IRSALIYE_ADRES_1 = a1;
            //    vmCariAdres.IRSALIYE_ADRES_2 = a2;
            //    vmCariAdres.IRSALIYE_ADRES_3 = a3;
            //    cntrlCariAdres.Ekle(vmCariAdres);
            //    return cntrlCariAdres.insertId;
            //}
            //else
            //{
            //    cntrlCariAdres.Guncelle(vmCariAdresList[0], vmCariAdresList[0].ID);
            //    return vmCariAdresList[0].ID;
            //}
        }
        public static void SepetSiparisleriGuncelle(int orderId)
        {


        }
        public static KontrolVm Alis_Siparis_Fis_Olustur(List<SepetGosterimVm> listOrderProduct, Dictionary<string, string> parametreler, orderVm sifirVm)
        {
            //KontrolVm kontrolVm = new KontrolVm();
            //kontrolVm.DONUS_INT_DEGER = 1;
            //SiparisFisSifirCntrl siparisSifirCntrl = new SiparisFisSifirCntrl();
            //SiparisFisSifirliAciklamaCntrl siparisSifirAciklamCntrl = new SiparisFisSifirliAciklamaCntrl();
            //SiparisFisSifirliAciklamaVm vmAciklma = new SiparisFisSifirliAciklamaVm();
            //SiparisFisSifirVm siparisSifir = new SiparisFisSifirVm();
            //SiparisFisSatirCntrl siparisSatirCntrl = new SiparisFisSatirCntrl();
            //SiparisFisSatirVm siparisSatir = new SiparisFisSatirVm();
            //int insertID = 0;
            //bool kayitTamamlandı = true;
            //order_statusCntrl cntrlStatus = new order_statusCntrl();
            //order_statusVm vmStatus = new order_statusVm();
            //order_productCntrl Cntrl = new order_productCntrl();
            //SepetGosterimVm satirVm = listOrderProduct[0];
            //int toptanciId = Convert.ToInt32(satirVm.vehicle_toptanci_id);
            //order_productVm satirCekVm = new order_productVm();
            //for (int i = 0; i < listOrderProduct.Count; i++)
            //{
            //    satirVm = listOrderProduct[i];
            //    if (Convert.ToDecimal(satirVm.siparis_miktar) > 0 && Convert.ToDecimal(satirVm.ALIS_FIYAT)>0)
            //    {
            //            if (insertID == 0)
            //            {
            //                siparisSifirCntrl = new SiparisFisSifirCntrl();
            //                siparisSifir = new SiparisFisSifirVm();
            //                siparisSifir.LK_ALIS_SATIS_ID = (int)AlisSatisEn.ALIS;
            //                siparisSifir.TARIH = Convert.ToDateTime(parametreler["TARIH"]);
            //                siparisSifir.LK_ONAY_E_H = Convert.ToByte(parametreler["LK_ONAY_E_H"]);
            //                siparisSifir.NO = Siparis.Fis.Services.FisControlService.GetMax_Fis_No(Globals.gnKullaniciId, (int)AlisSatisEn.ALIS);
            //                siparisSifir.KULLANICI_ID = Globals.gnKullaniciId;
            //                siparisSifir.CARI_ID = B2cIslemlerService.getB2CCari_ID(Convert.ToInt32(satirVm.vehicle_toptanci_id));
            //                siparisSifir.CARI_ADRES_ID = GetVarsayilanCariAdresYeri(siparisSifir.CARI_ID, satirVm);
            //                siparisSifir.CARI_AYRIM_ID = (int)VarsayilanIdlerEn.CariAyrim;
            //                siparisSifir.DOVIZ_ID = (int)DovizEn.TL;
            //                siparisSifir.SEVKIYAT_TURU_ID = (int)SevkiyatTurunEn.OTOMATIK;
            //                siparisSifir.ACIKLAMA = Convert.ToString(ListService.GetKULLANICI_ID((int)ListServiceTipEn.LISTEBYIDAD, (int)AktifPasifTumuEn.TUMU, Globals.gnKullaniciId, 0, 0, "", "", 0));
            //                siparisSifir.SIPARIS_TUR_ID = (int)SiparisTurEn.Bos;
            //                siparisSifir.MUSTERI_SIPARIS_NO = parametreler["MUSTERI_SIPARIS_NO"];
            //                siparisSifirCntrl.Ekle(siparisSifir);
            //                insertID = siparisSifirCntrl.insertId;
            //            }
            //            siparisSatir = new SiparisFisSatirVm();
            //            satirVm = listOrderProduct[i];
            //            siparisSatir.SIPARIS_FIS_SIFIRLI_ID = siparisSifirCntrl.insertId;
            //            //siparisSatir.CARI_PLASIYER_ID = satirVm.SIFIRLI.CARI_PLASIYER_ID;
            //            //siparisSatir.CARI_SATIS_ELEMANI_ID = satirVm.SIFIRLI.CARI_SATIS_ELEMANI_ID;
            //            siparisSatir.STOK_ID = B2cIslemlerService.getB2CStok_ID(satirVm.product_id);
            //            siparisSatir.MIKTAR = Convert.ToDecimal(satirVm.siparis_miktar);
            //            siparisSatir.DOVIZ_ID = (int)DovizEn.TL;
            //            siparisSatir.FIYAT_DOVIZ = Convert.ToDecimal(satirVm.ALIS_FIYAT);
            //            siparisSatir.TUTAR_DOVIZ = Convert.ToDecimal(satirVm.ALIS_FIYAT) * Convert.ToDecimal(satirVm.siparis_miktar);
            //            if ((int)DovizEn.TL != (int)DovizEn.TL)
            //            {
            //                siparisSatir.KUR = Convert.ToDecimal(satirVm.kur);
            //                if (siparisSatir.KUR == 0)
            //                {
            //                    siparisSatir.KUR = FiyatBulService.GetDOVIZ_KUR(Globals.dovizKurTip, siparisSatir.DOVIZ_ID, siparisSifir.TARIH);
            //                    //  gunKuruBakilipbulunamadiMi = true;
            //                    // siparisSatir.KUR = satirVm.KUR;
            //                }
            //                siparisSatir.FIYAT = YardimciIslemler.DecimalFormatlaDec(siparisSatir.FIYAT_DOVIZ * siparisSatir.KUR, 5);
            //                siparisSatir.TUTAR = YardimciIslemler.DecimalFormatlaDec(siparisSatir.FIYAT * satirVm.quantity, 2);
            //            }
            //            else
            //            {
            //                siparisSatir.FIYAT = Convert.ToDecimal(satirVm.ALIS_FIYAT);
            //                siparisSatir.TUTAR = Convert.ToDecimal(satirVm.ALIS_FIYAT) * Convert.ToDecimal(satirVm.siparis_miktar);
            //            }
            //            siparisSatir.ISKONTO_YUZDE = satirVm.discount;
            //            siparisSatir.order_product_id = satirVm.order_product_id;
            //            siparisSatir.TESLIM_TARIH = siparisSifir.TARIH;
            //            siparisSatirCntrl.Ekle(siparisSatir);
            //            if (siparisSatirCntrl.hataKod!=100)
            //            {
            //                kayitTamamlandı = false; break;
            //            }
            //    }
            //}

            //string sonuc = "";
            //if (insertID==0)
            //{
            //    sonuc = "Sipariş Oluşturulamadı";
            //    kontrolVm.DONUS_INT_DEGER = 0;

            //}
            //else if (kayitTamamlandı == false)
            //{
            //    bool satirSil = true;
            //    siparisSatir = new SiparisFisSatirVm();
            //    List<SiparisFisSatirVm> satirListVm = new List<SiparisFisSatirVm>();
            //    siparisSatir.SIPARIS_FIS_SIFIRLI_ID = insertID;
            //    satirListVm = siparisSatirCntrl.Liste_Al(siparisSatir);
            //    int sayi = satirListVm.Count;
            //    for (int i = 0; i < sayi; i++)
            //    {
            //        //satirListVm[i].IslemNedeni = "Siparişte Hata Var";
            //        siparisSatirCntrl.Sil(satirListVm[i].ID, satirListVm[i]);
            //        if (siparisSatirCntrl.hataKod != 100)
            //        {
            //            satirSil = false;
            //        }
            //    }
            //    if (satirSil == true)
            //    {
            //        siparisSifir = new SiparisFisSifirVm();
            //        siparisSifir.ID = insertID;
            //        siparisSifirCntrl.LogDosyasinaYazma = false;
            //        siparisSifirCntrl.Sil(siparisSifir.ID, siparisSifir);
            //        //if (siparisSifirCntrl.hataKod == 100)
            //        //{
            //        //    islemTamamDegilSifirli = false;
            //        //}
            //        //else
            //        //{
            //        //    islemTamamDegilSifirli = true;
            //        //}
            //    }
            //    sonuc = "Sipariş Oluşumunda Hata Var!!!";
            //    kontrolVm.DONUS_INT_DEGER = 0;

            //}
            //else
            //{
            //    for (int i = 0; i < listOrderProduct.Count; i++)
            //    {
            //        satirVm = listOrderProduct[i];
            //        sonuc += SiparisDurumunuGoster(satirVm.order_product_id) + "\n";
            //    }
            //}
            //kontrolVm.DONUS_MESAJ = sonuc;

            return null;
        }
        public static string SiparisDurumunuGoster(int? order_product_id)
        {
            return "";
            //string sip = "";
            //ProdmaEntities context = new ProdmaEntities();
            //var teklif = (from c in context.SIPARIS_FIS_SATIR
            //              where c.order_product_id == order_product_id
            //              select new
            //              {
            //                  FIS_TARIH = c.SIPARIS_FIS_SIFIRLI.TARIH,
            //                  NO = c.SIPARIS_FIS_SIFIRLI.NO,
            //                  CARI = c.SIPARIS_FIS_SIFIRLI.CARI.AD,
            //                  KOD = c.STOK.KOD,
            //                  MIKTAR = c.MIKTAR,
            //              }).Distinct().ToList();
            //if (teklif.Count > 0)
            //{
            //    foreach (var item in teklif)
            //    {
            //        sip += item.FIS_TARIH.ToShortDateString() + "-" + item.NO + " / " + item.CARI + " / "  +  item.KOD +  " : " + Convert.ToString(item.MIKTAR);
            //    }
            //    return sip;
            //}
            //return "";
        }
        public static void SiparisDurumunuUpdate(List<SepetGosterimVm> listOrderProduct)
        {
            //string sip = "";
            //string musteriSiparisNo = "";
            //int cariId = 0;
            //ProdmaEntities context = new ProdmaEntities();
            //foreach (var item in listOrderProduct)
            //{
            //      cariId = getB2CCari_ID(Convert.ToInt32(item.vehicle_toptanci_id),(int)CariTipEn.SATICI);
            //      var teklif = (from c in context.SIPARIS_FIS_SATIR
            //                    where c.order_product_id == item.order_product_id && c.SIPARIS_FIS_SIFIRLI.CARI_ID == cariId
            //              select new
            //              {
            //                  FIS_TARIH = c.SIPARIS_FIS_SIFIRLI.TARIH,
            //                  NO = c.SIPARIS_FIS_SIFIRLI.NO,
            //                  MIKTAR = c.MIKTAR,
            //                  MUSTERI_SIPARIS_NO = c.SIPARIS_FIS_SIFIRLI.MUSTERI_SIPARIS_NO,
            //              }).Distinct().ToList();
            //    if (teklif.Count > 0)
            //    {
            //        sip = "";
            //        foreach (var item1 in teklif)
            //        {
            //            sip += item1.FIS_TARIH.ToShortDateString() + "-" + item1.NO + " : " + Convert.ToString(item1.MIKTAR);
            //            musteriSiparisNo = item1.MUSTERI_SIPARIS_NO;
            //        }
            //    }
            //    item.SIPARIS_NO = sip;
            //    item.MUSTERI_SIPARIS_NO = musteriSiparisNo;
            //}
           
        }
        public static List<SepetGosterimVm> getB2COrdersFromSiparis()
        {
            //List<SiparisFisSatirVm> listSiparis = new List<SiparisFisSatirVm>();
            //listSiparis = SiparisListeAl();
            //List<SepetGosterimVm> listReturn = new List<SepetGosterimVm>();
            //List<SepetGosterimVm> listTedarik = new List<SepetGosterimVm>();
            //List<SiparisFisSatirVm> listTemp = new List<SiparisFisSatirVm>();
            //SepetGosterimVm vm = new SepetGosterimVm();
            //listTedarik = getB2COrders((int)SepetSecimiEn.SiparisTedarikSurecinde);
            //foreach (var item in listTedarik)
            //{
            //    listTemp = listSiparis.FindAll(f => f.order_product_id == item.order_product_id);
            //    if (listTemp != null && listTemp.Count != 0)
            //    {
            //        foreach (var item1 in listTemp)
            //        {
            //            vm = new SepetGosterimVm();
            //            vm.ID = item.id;
            //            vm.quantity = item.quantity;
            //            vm.price = item.price;
            //            vm.product_code = item.product_code;
            //            vm.product_name = item.product_name;
            //            vm.vehicle_toptanci_id = getB2CToptanci_id(Convert.ToInt32(item1.cari_id));
            //            vm.product_id = item.product_id;
            //            vm.order_status_type_id = item.order_status_type_id;
            //            vm.order_id = item.order_id;
            //            vm.order = item.order;
            //            vm.SATIS_FIYAT = item.price / Convert.ToDecimal(1.18);
            //            vm.tedarikci = item.tedarikci;
            //            vm.order_product_id = item.order_product_id;
            //            vm.delivery_address = item.delivery_address;
            //            vm.billing_address = item.billing_address;
            //            vm.siparis_miktar = item1.MIKTAR;
            //            vm.gonderilen_miktar = item1.MIKTAR;
            //            vm.gonderilecek_miktar = item1.MIKTAR;
            //            vm.SIPARIS_NO = Convert.ToString(item1.SIPARIS_NO);
            //            vm.Siparis_fis_sifirli_id = item1.SIPARIS_FIS_SIFIRLI_ID;
            //            listReturn.Add(vm);
            //        }
            //    }
            //    else
            //    {
            //        vm = new SepetGosterimVm();
            //        vm.ID = item.id;
            //        vm.quantity = item.quantity;
            //        vm.price = item.price;
            //        vm.product_code = item.product_code;
            //        vm.product_name = item.product_name;
            //        vm.vehicle_toptanci_id = item.vehicle_toptanci_id;
            //        vm.product_id = item.product_id;
            //        vm.order_status_type_id = item.order_status_type_id;
            //        vm.order_id = item.order_id;
            //        vm.order = item.order;
            //        vm.SATIS_FIYAT = item.price / Convert.ToDecimal(1.18);
            //        vm.tedarikci = item.tedarikci;
            //        vm.order_product_id = item.order_product_id;
            //        vm.delivery_address = item.delivery_address;
            //        vm.billing_address = item.billing_address;
            //        vm.siparis_miktar = 0;
            //      //  vm.order = "";
            //        listReturn.Add(vm);
            //    }
            //}
            //B2cIslemlerService.SiparisDurumunuUpdate(listReturn);
            return null;
        }
        public static List<SepetGosterimVm> SiparisListeAl()
        {
            return null;
        //    ProdmaEntities context = new ProdmaEntities();
        //    using (context)
        //    {
        //        var list = (from fis in context.SIPARIS_FIS_SATIR
        //                    select new SiparisFisSatirVm()
        //                    {
        //                        ID = fis.ID,
        //                        SIPARIS_FIS_SIFIRLI_ID = fis.SIPARIS_FIS_SIFIRLI_ID,
        //                        SATIR_NO = fis.SATIR_NO,
        //                        BARKOD_ID = fis.BARKOD_ID,
        //                        DOVIZ_ID = fis.DOVIZ_ID,
        //                        STOK_ID = fis.STOK_ID,
        //                        CARI_PLASIYER_ID = fis.CARI_PLASIYER_ID,
        //                        CARI_SATIS_ELEMANI_ID = fis.CARI_SATIS_ELEMANI_ID,
        //                        MIKTAR = fis.MIKTAR,
        //                        FIYAT = fis.FIYAT,
        //                        FIYAT_DOVIZ = fis.FIYAT_DOVIZ,
        //                        TUTAR = fis.TUTAR,
        //                        TUTAR_DOVIZ = fis.TUTAR_DOVIZ,
        //                        ISKONTO_YUZDE = fis.ISKONTO_YUZDE,
        //                        ISKONTO_TUTAR = fis.ISKONTO_TUTAR,
        //                        ISKONTO_TUTAR_DOVIZ = fis.ISKONTO_TUTAR_DOVIZ,
        //                        KDV_YUZDE_ID = fis.KDV_YUZDE_ID,
        //                        KDV_TUTAR = fis.KDV_TUTAR,
        //                        KDV_TUTAR_DOVIZ = fis.KDV_TUTAR_DOVIZ,
        //                        KUR = fis.KUR,
        //                        ACIKLAMA = fis.ACIKLAMA,
        //                        URETIM_TARIH = fis.URETIM_TARIH,
        //                        TESLIM_TARIH = fis.TESLIM_TARIH,
        //                        TEKLIF_FIS_SATIR_ID = fis.TEKLIF_FIS_SATIR_ID,
        //                        BEDAVA_E_H = fis.BEDAVA_E_H,
        //                        LK_DURUM_ID = fis.LK_DURUM_ID,
        //                        EK_ISKONTO_UYGULANDI_E_H = fis.EK_ISKONTO_UYGULANDI_E_H,
        //                        //TEKLIF_NO = fis.TEKLIF_FIS_SATIR.TEKLIF_FIS_SIFIRLI.KULLANICI.AD + "-" + SqlFunctions.StringConvert((double)fis.TEKLIF_FIS_SATIR.TEKLIF_FIS_SIFIRLI.NO).Trim(),
        //                        //STOK = new StokVm() { ID = (int)fis.STOK_ID, AD = fis.STOK.AD, HACIM = fis.STOK.HACIM, NET_AGIRLIK = fis.STOK.NET_AGIRLIK, BRUT_AGIRLIK = fis.STOK.BRUT_AGIRLIK, STOK_GRUP1_ID = fis.STOK.STOK_GRUP1_ID, STOK_GRUP2_ID = fis.STOK.STOK_GRUP2_ID, STOK_GRUP3_ID = fis.STOK.STOK_GRUP3_ID, STOK_GRUP4_ID = fis.STOK.STOK_GRUP4_ID, STOK_GRUP5_ID = fis.STOK.STOK_GRUP5_ID, STOK_GRUP6_ID = fis.STOK.STOK_GRUP6_ID, STOK_GRUP7_ID = fis.STOK.STOK_GRUP7_ID, STOK_GRUP8_ID = fis.STOK.STOK_GRUP8_ID, STOK_GRUP9_ID = fis.STOK.STOK_GRUP9_ID, STOK_GRUP10_ID = fis.STOK.STOK_GRUP10_ID },
        //                        INSERT_KUL_ID = fis.INSERT_KUL_ID,
        //                        INSERT_TAR = fis.INSERT_TAR,
        //                        UPDATE_TAR = fis.UPDATE_TAR,
        //                        UPDATE_KUL_ID = fis.UPDATE_KUL_ID,
        //                        order_product_id = fis.order_product_id,
        //                        cari_id = fis.SIPARIS_FIS_SIFIRLI.CARI_ID,
        //                        SIPARIS_NO = SqlFunctions.StringConvert((double)fis.SIPARIS_FIS_SIFIRLI.NO).Trim()
        //                    }).OrderBy(o => o.SATIR_NO).ToList();
        //        return list;    
        //    }
        //}
        //public static void getAlisSiparisBilgilerCek(List<SepetGosterimVm> listOrderProduct)
        //{
        //    List<cari_hareket_detay> listHareket = new List<cari_hareket_detay>();
        //    string tedarikci = "" ;
        //    cari_hareket_detay vm = new cari_hareket_detay();
        //    var list = (from l in listOrderProduct select l.MUSTERI_SIPARIS_NO).Distinct().ToList();
        //    foreach (var item in list)
        //    {
        //        listHareket = getAlisSiparisBilgilerCek(item);
        //        foreach (var item1 in listOrderProduct)
        //        {
        //            tedarikci = item1.tedarikci.ToString().ToUpper();
        //            vm = listHareket.FindAll(f => f.yenikod == item1.product_code && f.tedarikci == tedarikci).FirstOrDefault();
        //            if (vm!=null)
        //            {
        //                item1.bakiye = item1.siparis_miktar - vm.miktar;
        //                item1.gonderilen_miktar = vm.miktar;
        //                item1.ALIS_FIYAT = vm.birim_fiyat;
        //            }
                    
        //        }
        //    }
           
        }
        public static List<cari_hareket_detay> getAlisSiparisBilgilerCek(string stokSiparisNo)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress remoteAddress = new EndpointAddress("http://oss.ozcete.com.tr/servis/OzceteParcasatis.asmx");
            binding.Name = "ParcaSatisSoap";
            binding.AllowCookies = false;
            List<SepetGosterimVm> fiyat = new List<SepetGosterimVm>();
            OzceteParcaSatisSoapClient client = new OzceteParcaSatisSoapClient(binding, remoteAddress);
            //string fiyatlar = client.fn_stok("P1", "E0011", "430.1786.00", "Zimmermann", "xx45fg");
            string siparis = client.fn_cari_hareket_detay(stokSiparisNo, "xx45fg");
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            var result = JsonConvert.DeserializeObject<List<cari_hareket_detay>>(siparis);
            return result;
        }
        public static void AlisIrsaliyeOlustur(List<SepetGosterimVm> listOrderProduct, Dictionary<string, string> parametreler)
        {
            //KontrolVm kontrolVm = new KontrolVm();
            //kontrolVm.DONUS_INT_DEGER = 1;
            //int CariId=0;
            //var list = (from l in listOrderProduct select l.Siparis_fis_sifirli_id).Distinct().ToList();
            //List<SiparisVm> listSiparis = new List<SiparisVm>();
            //List<Object> listobject = new List<object>();
            //foreach (var item in list)
            //{
            //    listSiparis = FisControlService.Siparis_Irsaliyelestirme_Listele(Convert.ToInt32(item));
            //    foreach (var item1 in listSiparis)
            //    {
            //        CariId = getB2CToptanci_id(item1.SIFIRLI.CARI_ID);
            //        var list1 = (from l in listOrderProduct select l).Where(w => w.order_product_id == item1.orde_product_id && w.vehicle_toptanci_id == CariId).ToList();
            //        if (list1!=null && list1.Count!=0)
            //        {
            //           item1.SIPARIS_MIKTAR = Convert.ToDecimal(list1[0].gonderilen_miktar);
            //        }
            //    }

            //    if (listSiparis!=null)
            //    {
            //       List<SiparisVm> sonuc = FisControlService.Stok_Fis_Olustur(listSiparis, parametreler);
            //       if (sonuc.Count > 0)
            //       {
            //           if (sonuc[0].ACIKLAMA != null && sonuc[0].ACIKLAMA != "")
            //           {
            //               MessageBox.Show(sonuc[0].ACIKLAMA);
            //           }
            //           if (sonuc[0].ID > 0)
            //           {


            //               usrGridIslem frm = new usrGridIslem(GridIslemEn.Bilgilendirme);
            //               List<Alanlar> vmList = new List<Alanlar>();
            //               Alanlar vm = new Alanlar(); vm.ALAN_AD = "ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TAMSAYI; vm.GORMESIN_E_H = true; vm.ALAN_SIRA = 1; vmList.Add(vm);
            //               vm = new Alanlar(); vm.ALAN_AD = "STOK_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 1; vmList.Add(vm);
            //               vm = new Alanlar(); vm.ALAN_AD = "TESLIM_TARIH"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 2; vmList.Add(vm);
            //               vm = new Alanlar(); vm.ALAN_AD = "SIPARIS_MIKTAR"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 3; vmList.Add(vm);
            //               ListHelper.Gridi_OlusturbyList(vmList, frm.gridView1, frm.gridControl1, 0, "", true, false);
            //               ListHelper.Gridi_Goster(frm, sonuc, "Ambarda Stok olmadığından İrsaliyeye aktarılamayanlar", 800);
            //           }
            //       }
            //    }
            //}
        }
        public static void AlisIrsaliyeDurumunuUpdate(List<SepetGosterimVm> listOrderProduct)
        {
            //string sip = "";
            //string musteriSiparisNo = "";
            //int cariId = 0;
            //ProdmaEntities context = new ProdmaEntities();
            //foreach (var item in listOrderProduct)
            //{
            //    cariId = getB2CCari_ID(Convert.ToInt32(item.vehicle_toptanci_id), (int)CariTipEn.SATICI);
            //    var teklif = (from c in context.STOK_FIS_SATIR
            //                  where c.order_product_id == item.order_product_id && c.STOK_FIS_SIFIRLI.CARI_ID == cariId
            //                  select new
            //                  {
            //                      FIS_TARIH = c.STOK_FIS_SIFIRLI.TARIH,
            //                      NO = c.STOK_FIS_SIFIRLI.IRSALIYE_NO,
            //                      MIKTAR = c.MIKTAR_IC,
            //                  }).Distinct().ToList();
            //    if (teklif.Count > 0)
            //    {
            //        sip = "";
            //        foreach (var item1 in teklif)
            //        {
            //            sip += item1.FIS_TARIH.ToShortDateString() + "-" + item1.NO + " : " + Convert.ToString(item1.MIKTAR);
            //        }
            //    }
            //    item.IRSALIYE_NO = sip;
            //}

        }
        public static void OrderStatusSet(GridCheckMarksSelection selection, int order_status_type)
        {
            List<fiyatlarList> fiyat = new List<fiyatlarList>();
            List<SepetGosterimVm> listOrderProduct = new List<SepetGosterimVm>();
            for (int i = 0; i < selection.SelectedCount; i++)
            {
                listOrderProduct.Add((SepetGosterimVm)selection.GetSelectedRow(i));
            }

            foreach (var item in listOrderProduct)
            {
                OrderStatusSet(item.order_id, order_status_type);
            }

        }
        public static void OrderStatusSet(int order_id, int order_status_type)
        {
            if (order_id==0) return;
            order_statusVm statusVm = new order_statusVm();
            List<order_statusVm> statuslist = new List<order_statusVm>();
            order_statusCntrl statusCntrl = new order_statusCntrl();
            statusVm.order_id = order_id;
            statusVm.order_status_type_id = order_status_type;
            statuslist = statusCntrl.Liste_Al(statusVm);
            if (statuslist == null)
            {
                statusVm = new order_statusVm();
                statusVm.order_id = order_id;
                statusVm.time = DateTime.Now;
                statusVm.order_status_type_id = (int)SepetSecimiEn.SiparisAlindiOdemeBekleniyor;
                statusCntrl.Ekle(statusVm);
            }
            else if (statuslist.Count == 0)
            {
                statusVm = new order_statusVm();
                statusVm.order_id = order_id;
                statusVm.time = DateTime.Now;
                statusVm.order_status_type_id = order_status_type;
                statusCntrl.Ekle(statusVm);
            }
        }
        public static void OrderStatusSet(int? id, int p)
        {
            OrderStatusSet(getOrderIdFromOrderProducut(id), p);
        }
        public static int getOrderIdFromOrderProducut(int? id)
        {
            List<order_productVm> vmList = new List<order_productVm>();
            order_productVm vm = new order_productVm();
            order_productCntrl cntrl= new order_productCntrl();
            vm.id = Convert.ToInt32(id);
            vmList = cntrl.Liste_Al(vm);
            if (vmList != null && vmList.Count != 0)
            {
                return Convert.ToInt32(vmList[0].order_id);
            }
            return 0;
        }
        public static void OrderStatusSil(int? order_product_id, int order_status_type)
        {
            int order_id = getOrderIdFromOrderProducut(order_product_id);
            order_statusVm statusVm = new order_statusVm();
            List<order_statusVm> statuslist = new List<order_statusVm>();
            order_statusCntrl statusCntrl = new order_statusCntrl();
            statusVm.order_id = order_id;
            statusVm.order_status_type_id = order_status_type + 1;
            statuslist = statusCntrl.Liste_Al(statusVm);
            if (statuslist != null)
            {
                statusCntrl.Sil(statuslist[0].id, statuslist[0]);
            }
        }
        public static void SatisIrsaliyeOlustur(List<SepetGosterimVm> listOrderProduct, Dictionary<string, string> parametreler)
        {
            //List<SiparisVm> siparisList = new List<SiparisVm>();
            //SiparisVm vmSiparis = new SiparisVm();
            //SiparisFisSifirVm sifirli = new SiparisFisSifirVm();
            //foreach (var item in listOrderProduct)
            //{
            //    vmSiparis = new SiparisVm();
            //    sifirli = new SiparisFisSifirVm();
            //    sifirli.CARI_ID = B2cIslemlerService.getB2CCari_ID(Convert.ToInt32(item.auth_user_id));
            //    sifirli.CARI_ADRES_ID = GetVarsayilanCariAdresYeri(sifirli.CARI_ID, item);
            //    sifirli.CARI_AYRIM_ID = (int)VarsayilanIdlerEn.CariAyrim;
             
            //    sifirli.DOVIZ_ID = (int)DovizEn.TL;
            //    sifirli.VALOR_GUN = 90;
            //    sifirli.LK_ALIS_SATIS_ID = (int)AlisSatisEn.SATIS;
            //    vmSiparis.SIFIRLI = sifirli;
            //    vmSiparis.SEVKIYAT_TURU_ID = (int)SevkiyatTurunEn.OTOMATIK;
            //    vmSiparis.STOK_ID = B2cIslemlerService.getB2CStok_ID(item.product_id);
            //    vmSiparis.ACIKLAMA = "";
            //    vmSiparis.SIPARIS_MIKTAR = Convert.ToDecimal(item.gonderilen_miktar);
            //    vmSiparis.FIYAT = YardimciIslemler.DecimalFormatlaDec(Convert.ToDecimal(item.SATIS_FIYAT),2);
            //    vmSiparis.DOVIZ_ID = (int)DovizEn.TL;
            //    vmSiparis.STOK = new StokVm();
            //    vmSiparis.STOK.AMBALAJ_MIKTARI = 1;
            //    vmSiparis.ISKONTO_YUZDE = 0;
            //    //vmSiparis.KDV_YUZDE_ID = (int)KdvEn.ONSEKIZ;
            //    siparisList.Add(vmSiparis);
            //}
            //if (siparisList != null)
            //{
            //    List<SiparisVm> sonuc = FisControlService.Stok_Fis_Olustur(siparisList, parametreler);
            //    if (sonuc.Count > 0)
            //    {
            //        if (sonuc[0].ACIKLAMA != null && sonuc[0].ACIKLAMA != "")
            //        {
            //            MessageBox.Show(sonuc[0].ACIKLAMA);
            //        }
            //        if (sonuc[0].ID > 0)
            //        {


            //            usrGridIslem frm = new usrGridIslem(GridIslemEn.Bilgilendirme);
            //            List<Alanlar> vmList = new List<Alanlar>();
            //            Alanlar vm = new Alanlar(); vm.ALAN_AD = "ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TAMSAYI; vm.GORMESIN_E_H = true; vm.ALAN_SIRA = 1; vmList.Add(vm);
            //            vm = new Alanlar(); vm.ALAN_AD = "STOK_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 1; vmList.Add(vm);
            //            vm = new Alanlar(); vm.ALAN_AD = "TESLIM_TARIH"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 2; vmList.Add(vm);
            //            vm = new Alanlar(); vm.ALAN_AD = "SIPARIS_MIKTAR"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 3; vmList.Add(vm);
            //            ListHelper.Gridi_OlusturbyList(vmList, frm.gridView1, frm.gridControl1, 0, "", true, false);
            //            ListHelper.Gridi_Goster(frm, sonuc, "Ambarda Stok olmadığından İrsaliyeye aktarılamayanlar", 800);
            //        }
            //    }
            //}
            //vmSiparis.STOK.am

        }
    }
    public class cari_hareket_detay
    {
        public DateTime tarih { get; set; }
        public string faturano { get; set; }
        public int sirano { get; set; }
        public string irsno { get; set; }
        public string firma { get; set; }
        public string stok_kod { get; set; }
        public string yenikod { get; set; }           
        public string urun_adi { get; set; }
        public decimal miktar { get; set; }
        public decimal liste_fiyati { get; set; }
        public decimal toplam { get; set; }
        public string tedarikci { get; set; }
        public decimal iskonto { get; set; }
        public decimal tutar { get; set; }
        public decimal kdv { get; set; }
        public decimal fatura_tutari { get; set; }
        public decimal birim_fiyat { get; set; }
    }
    class stokAracList
    {
        public string tedarikci_id { get; set; }
        public string tedarikci_kodu { get; set; }
    }
    class fiyatlarList
    {
        public string artis { get; set; }
        public string stok_kodu { get; set; }
        public string urun_adi { get; set; }
        public string paket_stok_id  { get; set; }
        public string minumum_siparis_adedi { get; set; }
        public string tedarikci { get; set; }
        public string birimi { get; set; }
        public string grup_id { get; set; }
        public double depoToplam { get; set; }
        public string adana { get; set; }
        public string istanbul { get; set; }
        public string yeni_urun { get; set; }
        public string isk1 { get; set; }
        public string isk2 { get; set; }
        public string isk3 { get; set; }
        public string isk4 { get; set; }
        public string kmp_isk { get; set; }
        public string birim_net_fiyat { get; set; }
        public string liste_fiyati_para_id { get; set; }
        public string kur { get; set; }
        public string kdv { get; set; }
        public string isk_hesap7 { get; set; }
    }
    public class SepetGosterimVm : IViewModel
    {
        public int id { get; set; }
        public int auth_user_id { get; set; }
        public int order_id { get; set; }
        public string order { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public decimal doviz_id { get; set; }
        public decimal kur { get; set; }
        public decimal discount { get; set; }
        public int? vehicle_toptanci_id { get; set; }
        public decimal? siparis_miktar { get; set; }
        public decimal? onaylanan_miktar { get; set; }
        public decimal? gonderilen_miktar { get; set; }
        public decimal? gonderilecek_miktar { get; set; }
        public decimal? bakiye { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string tedarikci { get; set; }
        public int? order_status_id { get; set; }
        public int? order_status_type_id { get; set; }
        public double? ambar_miktar { get; set; }
        public decimal? ALIS_FIYAT { get; set; }
        public decimal? SATIS_FIYAT { get; set; }
        public decimal? KAR_ORAN { get; set; }
        public int? order_product_id { get; set; }
        public string delivery_name { get; set; }
        public string delivery_address { get; set; }
        public int? delivery_city_id { get; set; }
        public string delivery_phone { get; set; }
        public string billing_name { get; set; }
        public string billing_address { get; set; }
        public int? billing_city_id { get; set; }
        public string billing_phone { get; set; }
        public string SIPARIS_NO { get; set; }
        public string MUSTERI_SIPARIS_NO { get; set; }
        public string IRSALIYE_NO { get; set; }
        public string cargo_no { get; set; }
        public int Siparis_fis_sifirli_id { get; set; }
        public int payment_type { get; set; }
     //   public List<SiparisVm> SIPARISLIST { get; set; }
        
    }
}
