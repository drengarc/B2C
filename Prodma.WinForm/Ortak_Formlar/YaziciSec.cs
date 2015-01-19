using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlisSatis.Fis.Services;
using Prodma.DataAccess;
using Prodma.WinForms;
using System.Globalization;
using Prodma.Sistem.Controllers;
using Prodma.Sistem.Models;
namespace Prodma.WinForms
{
    public partial class YaziciSec : Islemler
    {
        public YaziciSec()
        {
            InitializeComponent();
            this.Text = Globals.rman.GetString("IslemNedenfrm");
            IslemNedenleriCntrl cntrl = new IslemNedenleriCntrl();
            YardimciIslemlerKontrols.InvokeEnumSet(YardimciIslemlerKontrols.EnumToList<YatayDikeyEn>(), DIKEY_YATAYlke);
            this.TAMAM_1cmd.Click += new System.EventHandler(this.button1_Click);
            this.TAMAM_1cmd.Focus();
            this.IPTAL_1btn.Visible = false;

        }
        public event EventHandler ButtonClick;
        private void OnButtonClicked(EventArgs e)
        {
            _printerName = YAZICI_ADItxt.Text;
            _YatayDikey = (int)DIKEY_YATAYlke.EditValue;
            _KagitSecimi =  KAGIT_SECIMItxt.Text;
            if (ButtonClick != null)
            {
                ButtonClick(this, e);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

             OnButtonClicked(e);
             this.Close();  
        }

         
        public string _printerName;
        //public string printerName
        //{
        //    get { return _printerName; }
        //    set { _printerName = value; }
        //}
        public int _YatayDikey;
        //public int YatayDikey
        //{
        //    get { return _YatayDikey; }
        //    set { _YatayDikey = value; }
        //}
        public string _KagitSecimi;
        //public string KagitSecimi
        //{
        //    get { return _KagitSecimi; }
        //    set { _KagitSecimi = value; }
        //}
        private void FisKurGiris_Load(object sender, EventArgs e)
        {
            Control_Ayarla_Kayit(this.Controls, null, YAZICI_ADItxt, false);
            DIKEY_YATAYlke.EditValue = (int)YatayDikeyEn.Dikey;
            this.panelTamam.Focus();
            this.YAZICI_ADItxt.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PrintDialog pdiag = new PrintDialog();
            pdiag.ShowDialog();
            YAZICI_ADItxt.Text = pdiag.PrinterSettings.PrinterName;
            _printerName = pdiag.PrinterSettings.PrinterName;
        }
    }
}
