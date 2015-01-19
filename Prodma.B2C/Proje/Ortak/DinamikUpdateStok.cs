using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccessB2C; 
using Prodma.WinForms;
using Prodma.Raporlar;
using Microsoft.Reporting.WinForms;
using Listeler.UserControlStok;
using System.Threading;
using Ortak.Forms;
using System.Reflection;
using B2C.Models;
using B2C.Controllers;
namespace Ortak.Forms
{
    public partial class DinamikUpdateStok : ListSablonStok
    {
        usrStokGenel stokGenelList = new usrStokGenel();
        usrStokEkBilgi usrStokEkBilgi;
        List<productVm> listStok = new List<productVm>();
        public DinamikUpdateStok()
        {
           
            ListeOzellikleri.listSablonTip = (int)ListSablonEn.DinamikUpdate;
            ListeOzellikleri.mt = new string[1];
            ListeOzellikleri.mt[0] = "STOK_UPDATE"; // filtre kayıdı icin  gerekiyor normal listelerde metod adı icin kullanılır.
            bn = new BindingSource[1];
            ListeOzellikleri.dinamikUpdateTabloTip = "STOK";
            InitializeComponent();
            this.Text = Globals.rman.GetString("StokTopluBilgiIslemlerifrm");
        }
        public override void TabPage_Index_Changed(int index)
        {
            if (index == 0)
            {

            }
            else if (index == 1)
            {
                if (usrStokEkBilgi == null)
                {
                    usrStokEkBilgi = new usrStokEkBilgi(false);
                    usrStokEkBilgi.dinamikUpdate = true;
                    usrStokEkBilgi.Dock = DockStyle.Top;
                    xtraTabPage4.Controls.Add(usrStokEkBilgi);
                    usrStokEkBilgi.ControlleriDuzenle();
                }
            }
            else if (index == 2)
            {
                //if (stokKodlar == null)
                //{
                //        stokKodlar = new usrStokKodlar();
                ////        stokMarkaModelYil = new usrStokMarkaModelYil();
                //        stokKodlar.Dock = DockStyle.Top;
                //        tbKodlar.Controls.Add(stokKodlar);
                //        //stokMarkaModelYil.Dock = DockStyle.Top;
                //        //tbKodlar.Controls.Add(stokMarkaModelYil);
                //        stokKodlar.Doldur();
                //      //  stokMarkaModelYil.Doldur();
                   
                //}
            }
            else if (index == 3)
            {
                //if (stokMiktarlar == null)
                //{
                    
                //     stokMiktarlar = new usrStokMiktarlar();
                //     stokMiktarlar.dinamikUpdate = true; 
                //     stokMiktarlar.Dock = DockStyle.Top;
                //     tbDetay.Controls.Add(stokMiktarlar);
                //      stokMiktarlar.Doldur();
                //}
            }
            else if (index == 4)
            {
                //if (usrStokEkBilgi_3 == null)
                //{
                //    usrStokEkBilgi_3 = new usrStokEkBilgi_3(false);
                //    usrStokEkBilgi_3.dinamikUpdate = true;
                //    usrStokEkBilgi_3.Dock = DockStyle.Top;
                //    xtraTabPage3.Controls.Add(usrStokEkBilgi_3);
                //    usrStokEkBilgi_3.ControlleriDuzenle();
                //}
            }
            else if (index == 5)
            {
                if (usrStokEkBilgi == null)
                {
                    usrStokEkBilgi = new usrStokEkBilgi(false);
                    usrStokEkBilgi.dinamikUpdate = true;
                    usrStokEkBilgi.Dock = DockStyle.Top;
                    xtraTabPage4.Controls.Add(usrStokEkBilgi);
                    usrStokEkBilgi.ControlleriDuzenle();
                }
            }
            else if (index == 6)
            {
                //if (usrStokEkBilgi_1 == null)
                //{
                //    usrStokEkBilgi_1 = new usrStokEkBilgi_1(false);
                //    usrStokEkBilgi_1.dinamikUpdate = true;
                //    usrStokEkBilgi_1.Dock = DockStyle.Top;
                //    xtraTabPage5.Controls.Add(usrStokEkBilgi_1);
                //    usrStokEkBilgi_1.ControlleriDuzenle();
                //}
            }
            else if (index == 7)
            {
                //if (usrStokEkBilgi_2 == null)
                //{
                //    usrStokEkBilgi_2 = new usrStokEkBilgi_2(false);
                //    usrStokEkBilgi_2.dinamikUpdate = true;
                //    usrStokEkBilgi_2.Dock = DockStyle.Top;
                //    xtraTabPage6.Controls.Add(usrStokEkBilgi_2);
                //    usrStokEkBilgi_2.ControlleriDuzenle();
                //}
            }
            
            else if (index == 8)
            {
                //if (stokKodlar_1 == null)
                //{
                //    stokKodlar_1 = new usrStokGruplar(false);
                //    stokKodlar_1.dinamikUpdate = true;
                //    stokKodlar_1.Dock = DockStyle.Top;
                //    xtraTabPage7.Controls.Add(stokKodlar_1);
                //    stokKodlar_1.ControlleriDuzenle();
                //}
            }
        }
        public override void IlkDegerleriVer()
        {
            stokGenelList.Doldur();
            stokGenelList.Dock = DockStyle.Fill;
            panelGenelList.Controls.Add(stokGenelList);
            
            xtraTabPage3.Text = "Taşıma Bilgileri (Ön Yüz)";
            xtraTabPage4.Text = "Taşıma Bilgileri (Ek Bilgiler)";
            xtraTabPage5.Text = "Taşıma Bilgileri (Ek Bilgiler 2)";
            xtraTabPage6.Text = "Taşıma Bilgileri (Ek Bilgiler Mesajlar)";
            xtraTabPage7.Text = "Taşıma Bilgileri (Gruplar)";
            this.tbControl.TabPages.Remove(tbBalantili);
            this.tbControl.TabPages.Remove(tbKodlar);
            this.tbControl.TabPages.Remove(tbDetay);
            this.tbControl.TabPages.Remove(xtraTabPage3);
            this.tbControl.TabPages.Remove(xtraTabPage5);
            this.tbControl.TabPages.Remove(xtraTabPage6);
            this.tbControl.TabPages.Remove(xtraTabPage7);
            this.tbControl.TabPages.Remove(xtraTabPage8);
            this.tbControl.TabPages.Remove(xtraTabPage9);
            this.tbControl.TabPages.Remove(xtraTabPage10);
            ListeOzellikleri.modelPath = "B2C.Models"; // gridi olustururken ihtiyac var.
            ListeOzellikleri.modelName = "productVm";
        }
        public override void Tamam()
        {
            if (sorguBitti == false)
            {
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                listStok = B2cSistemService.ProductList(parametersForm);
                bn[0] = new BindingSource();
                bn[0].DataSource = listStok;
            }
            sorguBitti = true;
        }
        public override void ParametreSet()
        {
            sorguBitti = false;
            ListeOzellikleri.dinamikUpdateTabloTip = "STOK";
            stokGenelList.ParametreUsrSet();
            //if (stokIliskili!=null) stokIliskili.ParametreUsrSet();
            //if (stokKodlar != null) stokKodlar.ParametreKodlarSet();
            //if (stokMiktarlar != null) stokMiktarlar.ParametreUsrSet();
            parametersForm.Clear();
            //parametersForm.Add("GRUP_SECIM",Convert.ToString(Gruplke.EditValue));
            parametersForm = parametersForm.Concat(stokGenelList.parametersUsr).ToDictionary(e => e.Key, e => e.Value);
            //if (stokIliskili != null)  parametersForm = parametersForm.Concat(stokIliskili.parametersUsr).ToDictionary(e => e.Key, e => e.Value);
            //if (stokKodlar != null) parametersForm = parametersForm.Concat(stokKodlar.parametersUsr).ToDictionary(e => e.Key, e => e.Value);
            //if (stokMiktarlar != null) parametersForm = parametersForm.Concat(stokMiktarlar.parametersMiktarlar).ToDictionary(e => e.Key, e => e.Value);
        }
        public override void SeriKayit()
        {
            bool degisiklikOldu = false;
            productCntrl cntrl = new productCntrl();
            productVm productVm = new productVm();
            Dictionary<string, bool> checkControl = new Dictionary<string, bool>();
            if (usrStokEkBilgi != null) usrStokEkBilgi.SetproductVm(productVm, checkControl);
           
            Type irs = typeof(productVm);
            PropertyInfo[] fi = irs.GetProperties();
            List<productVm> productList = new List<productVm>();
            for (int i = 0; i < gridControl.gridView1.DataRowCount; i++)
            {
                object row = gridControl.gridView1.GetRow(i);
                productList.Add((productVm)row);
            }
            foreach (productVm item in productList)
            {
                item.IslemNedeni = (int)IslemNedeniEn.TopluIslemlerGuncelleme;
                degisiklikOldu = false;
                foreach (PropertyInfo prop in fi)
                {
                    PropertyInfo pi = productVm.GetType().GetProperty(prop.Name);
                    PropertyInfo pi_1 = item.GetType().GetProperty(prop.Name);
                    if (checkControl.ContainsKey(prop.Name))
                    { pi_1.SetValue(item, pi.GetValue(productVm, null), null); degisiklikOldu = true; }
                }
                if (degisiklikOldu == true) cntrl.Guncelle(item, item.id);
            }
            MessageBox.Show("İşlem Tamamlandı"); 
        }
    }
}