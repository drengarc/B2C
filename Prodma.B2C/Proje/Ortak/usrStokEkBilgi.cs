using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccessB2C;
using Prodma.WinForms;
using System.Threading;
using B2C.Models;
using B2C.Controllers;
namespace Ortak.Forms
{
    public partial class usrStokEkBilgi : usrControlSablon
    {
        public string kayitEdilemez = "";
        public productVm sifirliVm;
        bool _kayitIcin = false;
        Dictionary<string, bool> checkControl = new Dictionary<string, bool>();
        BindingSource[] bnSablonDizi = new BindingSource[10];
        public usrStokEkBilgi()
        {
            InitializeComponent();
            listeBicimTip = (int)UserControlTipEn.Kayit;
            escapeKapatma = true;
        }
        public usrStokEkBilgi(bool kayitIcin)
        {
            //Thread t = new Thread(hesapPlaniDoldur);
            //t.Start();
            InitializeComponent();
            listeBicimTip = (int)UserControlTipEn.Kayit;
            _kayitIcin = kayitIcin;
            Ilk_Deger_Ver();
            escapeKapatma = true;
            //this.TEKNIK_KODtxt.Properties.Mask.EditMask = "\\w\\w\\w-\\w\\w-\\w\\w\\w\\w";
            //this.TEKNIK_KODtxt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
        }
        public void Ilk_Deger_Ver()
        {
         //   hesapPlaniDoldur();
            alanlarVm = ListDenemeService.GetALANLAR("product", 2);
        }
        public override void ControlleriDuzenle()
        {
            Control_Ayarla_Kayit(this.Controls, alanlarVm, cargo_pricetxt, cargo_pricetxt, _kayitIcin);
        }
        public override void Doldur(bool ilkKayit)
        {
            Control_Ayarla_Kayit(this.Controls, alanlarVm, cargo_pricetxt, cargo_pricetxt, _kayitIcin);
            cargo_pricetxt.Text = Convert.ToString(sifirliVm.cargo_price) ?? "";
        }
        public override void Kaydet()
        {
            if (cargo_pricetxt.Text != "") sifirliVm.cargo_price = Convert.ToDecimal(cargo_pricetxt.Text); else sifirliVm.cargo_price = null;
            productCntrl ekBilgiCntrl1 = new productCntrl();
            ekBilgiCntrl1.KayitMesajiGoster = true;
            ekBilgiCntrl1.Guncelle(sifirliVm, sifirliVm.ID);
            if (ekBilgiCntrl1.hataKod  !=  100)
            {
                
                productVm Vm = ekBilgiCntrl1.Liste_Al(sifirliVm)[0];
                sifirliVm = Vm;
                Doldur();
            }
        }
        public override bool IslemKontrol()
        {
          
         
            return true;
        }
        public void SetproductVm(productVm productVm, Dictionary<string, bool> checkControl)
        {
            if (cargo_pricetxt.Text != "") productVm.cargo_price = Convert.ToDecimal(cargo_pricetxt.Text); else productVm.cargo_price = null;
            foreach (Control fc in this.Controls)
            {
                if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckEdit))
                {
                    DevExpress.XtraEditors.CheckEdit chk = fc as DevExpress.XtraEditors.CheckEdit;
                    if (chk.Checked == true)
                    {
                        string textName;
                        textName = chk.Name.Remove(chk.Name.Length - 3);
                        checkControl.Add(textName, chk.Checked);
                    }
                }
            }

        }
        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit checkEdit = sender as DevExpress.XtraEditors.CheckEdit;
            string textName;
            textName = checkEdit.Name.Remove(checkEdit.Name.Length - 3);
            if (!checkControl.ContainsKey(textName) && checkEdit.Checked)
            {
                checkControl.Add(textName, checkEdit.Checked);
            }
            else if (checkControl.ContainsKey(textName) && !checkEdit.Checked)
                checkControl.Remove(textName);

        }
      
    }
}