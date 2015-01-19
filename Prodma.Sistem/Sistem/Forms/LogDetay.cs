using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccess;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Prodma.Sistem.Models;
using Prodma.Sistem.Controllers;
using DevExpress.XtraEditors.Repository;
namespace Prodma.Sistem.Forms
{
    public partial class LogDetay : Islemler
    {
        #region degiskenler
        int menuId = 0;
        byte tiklananButon = 0;
        private System.Windows.Forms.BindingSource testInfoBindingSource = new System.Windows.Forms.BindingSource();
        public usrGridIslem usr = new usrGridIslem(GridIslemEn.Giris);
        private YetkiMenulerCntrl kulcntrl = new YetkiMenulerCntrl();
        public YetkiMenulerVm yetkiMenulerVm = new YetkiMenulerVm();
        #endregion
        #region Constructors
        public LogDetay()
        {
            InitializeComponent();
            usr.escapeKapatma = true;
            this.panel1.Controls.Add(usr);
            usr.Dock = DockStyle.Fill; 
            usr.tabloAdi = "YETKI";
            usr.Gridi_Olustur(); 
            EventArgs eArgs = new EventArgs();
            usrDoldur(usr.gridView1, eArgs);
            usr.Doldur += usrDoldur;
            Control_Ayarla_Kayit(this.Controls, null, menuLke1, false);
            this.Text = "Menu Yetkileri";
            UYGULAcmd.Visible = true;
            panelTamam.Visible = false;
        }
        public void usrDoldur(object sender, EventArgs e)
        {
            EventArgs a = new EventArgs();
           
        }
        #endregion
        #region İşlemler  (override edenler)
        public void usrTabPage_Index_Changed(int index)
        {
            if (index != 0)
            {
                YardimciIslemler.InvokeLkeSet("KULLANICI_ID", kullaniciLe);
                YardimciIslemler.InvokeLkeSet("M_MENU_UST_ID", menuLke1);
                menuLke2.Properties.DataSource = ListDenemeService.GetM_MENU_ID_BY_PARAM(0, 0);
            }
        }
        #endregion
        private void UYGULAcmd_Click(object sender, EventArgs e)
        {
            YetkiMenulerVm k = (YetkiMenulerVm)usr.ModelVm;
            OrtakIslemlerService.MenuYetkileriniKopyala(k);
            MessageBox.Show("İşlem Tamamlandı");
        }

        
    }
}