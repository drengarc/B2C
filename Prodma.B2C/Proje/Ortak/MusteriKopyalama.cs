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
namespace B2C.Forms
{
    public partial class MusteriKopyalama : Islemler
    {
        public MusteriKopyalama()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.MusteriKopyalama_Load);
            this.Text = "Müşteri Kopyalama"; //Globals.rman.GetString("IthalatFisiOlusturfrm"); //"İthalat Fişi Oluştur";
            YardimciIslemlerKontrols.InvokeChlSet(Prodma.DataAccessB2C.ListService.Getauth_user_id((int)ListServiceTipEn.LISTE, 0, 0, 0, 0, "", "", 1), auth_userchl);
        }
        private void MusteriKopyalama_Load(object sender, EventArgs e)
        {
            Control_Ayarla_Kayit(this.Controls, null, auth_userchl, false);
        }
        public override void Tamam()
        {
            if (sorguBitti == false)
            {
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                IslemYap();
            }
            sorguBitti = true;
        }
        void IslemYap()
        {
            B2cSistemService.CariUpdate(parameterIslemler);
            //if (faturalilar != null && faturalilar.Count > 0)
            //{
            //    sorguBitti = true;
            //    usrGridBilgilendirme frm = new usrGridBilgilendirme();
            //    List<Alanlar> vmList = new List<Alanlar>();
            //    Alanlar vm = new Alanlar(); vm.ALAN_AD = "ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TAMSAYI; vm.GORMESIN_E_H = true; vm.ALAN_SIRA = 1; vmList.Add(vm);
            //    vm = new Alanlar(); vm.ALAN_AD = "TARIH"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TARIH; vm.ALAN_SIRA = 1; vmList.Add(vm);
            //    vm = new Alanlar(); vm.ALAN_AD = "KULLANICI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 2; vmList.Add(vm);
            //    vm = new Alanlar(); vm.ALAN_AD = "FIS_NO"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TAMSAYI; vm.ALAN_SIRA = 3; vmList.Add(vm);
            //    vm = new Alanlar(); vm.ALAN_AD = "IRSALIYE_NO"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 4; vmList.Add(vm);
            //    ListHelper.Gridi_OlusturbyList(vmList, frm.gridView1, frm.gridControl1, 0, "", true);
            //    frm.listObject = faturalilar;
            //    frm.Text = "61 Fişi Oluşturulmayanlar";
            //    frm.panelControl1.Size = new System.Drawing.Size(0, 0);
            //    frm.ShowDialog();
            //}
            //else
            //{
            //    sorguBitti = true;
            //    MessageBox.Show("İşlem Tamamlandı");
            //}
        }
        public override bool IslemKontrol(Control cntrl)
        {
            
            string param1 = "";
            param1 = auth_userchl.EditValue.ToString();
            if (param1 != "") parameterIslemler.Add("auth_user_id", param1);            
            DialogResult res = MessageBox.Show("", "Müşteri Kopyalama İşlemi Gerçekleştirilsin Mi?", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return false;
            }
           
            return true;

        }
         
    }
}
