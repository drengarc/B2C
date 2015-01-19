using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Prodma.DataAccessB2C;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
namespace Prodma.WinForms
{
    public partial class LogDetayGozlem : Islemler
    {
        usrGridIslem usr = new usrGridIslem(GridIslemEn.Bilgilendirme);
        BindingSource bn = new BindingSource();
        public string tabloAdi = "";
        public int ID = 0;
        public LogDetayGozlem()
        {
            InitializeComponent();
            panelControl1.Size = new Size(0, 0);
            this.Text = "Log Gözlem"; //  Globals.rman.GetString("StokIslemBilgilerifrm"); //"Stok İşlem Bilgileri";
            panelControlGrid.Controls.Add(usr);
            usr.controlNavigatorButtonClick += controlNavigator1_ButtonClick;
            usr.gridView1.OptionsView.ShowGroupPanel = true;
            //YardimciIslemlerKontrols.InvokeEnumSet(YardimciIslemlerKontrols.EnumToList<CariTakipIstatistikEn>(), LISTE_TIPlke);
            //YardimciIslemlerKontrols.InvokeEnumSet(YardimciIslemlerKontrols.EnumToList<FaturaIrsaliyeEn>(), KAYNAK_TIPlke);
            panelTamam.Visible = false;
            usr.Dock = System.Windows.Forms.DockStyle.Fill;
        }
        void Gridi_Olustur(usrGridIslem usr)
        {
            List<Alanlar> vmList = new List<Alanlar>();
            Alanlar vm = new Alanlar();
            vm.ALAN_AD = "TARIH"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TARIHTAM; vm.ALAN_SIRA = 1; vmList.Add(vm);
            vm = new Prodma.DataAccessB2C.Alanlar(); vm.ALAN_AD = "KULLANICI"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 1; vmList.Add(vm);
            //vm = new Prodma.DataAccessB2C.Alanlar(); vm.ALAN_AD = "TABLO"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA =2; vmList.Add(vm);
           // vm = new Prodma.DataAccessB2C.Alanlar(); vm.ALAN_AD = "ALAN"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 3; vmList.Add(vm);
            vm = new Prodma.DataAccessB2C.Alanlar(); vm.ALAN_AD = "ISLEM_TIP"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 4; vmList.Add(vm);
            WinFormsHelper.Gridi_OlusturbyList(vmList, usr.gridView1, usr.gridControl1, 0, "",true);
        }
        public void Gridi_Doldur()
        {
             bn.DataSource = OrtakIslemlerService.GetLogDetay(tabloAdi,ID);
             usr.gridControl1.DataSource = bn;
        }
        private void CariTakipStokIstatistikleri_Load(object sender, EventArgs e)
        {
            Control_Ayarla_Kayit(this.Controls, null, LISTE_TIPlke, false);
            Gridi_Olustur(usr);
            Gridi_Doldur();
         }
        public void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
        }
        private void CariTakipStokIstatistikleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void CariTakipStokIstatistikleri_Shown(object sender, EventArgs e)
        {
            usr.gridControl1.Focus();
        }
        public void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
        }
        private void LISTE_TIPlke_EditValueChanged(object sender, EventArgs e)
        {
            usr.gridView1.Columns.Clear();
            if (LISTE_TIPlke.EditValue !=null )
            {
                Gridi_Olustur(usr);
                Gridi_Doldur();
            }
            
        }
        private void KAYNAK_TIPlke_EditValueChanged(object sender, EventArgs e)
        {
            usr.gridView1.Columns.Clear();
            if (KAYNAK_TIPlke.EditValue != null)
            {
                Gridi_Olustur(usr);
                Gridi_Doldur();
            }

        }

        private void panelControlGrid_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}