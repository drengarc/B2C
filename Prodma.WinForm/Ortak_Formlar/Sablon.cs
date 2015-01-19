using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.SistemB2C.Controllers;
using Prodma.SistemB2C.Models;
using System.Diagnostics;
using Prodma.DataAccessB2C;
namespace Prodma.WinForms
{
    public partial class Sablon : DevExpress.XtraEditors.XtraForm
    {
        public YetkiMenulerVm yetki = new YetkiMenulerVm();
        public bool silme = true;
        public bool kayitEtme = true;
        public bool guncelleme = true;
        public bool okuma = true;
        public bool gorme = true;
        public bool tamYetki = false;
        public bool acilis = true;
        private TabControl tabCtrl;
        private TabPage tabPag;
        public int sablonSecilenMenuId=0;
        public Sablon()
        {
            InitializeComponent();
            //FileVersionInfo myFI = FileVersionInfo.GetVersionInfo(Application.StartupPath.ToString() + "/Prodma.Satis.exe");
            //if (this.MdiParent != null)
            //{
            //    this.MdiParent.Text = "PRODMA ERP -" + myFI.FileVersion;
            //}
            //byte? a = GenelParametreSng.Nesne().firmaBilgileri.MUHASEBE_KAPALI_AY;
            //ListDenemeService.FirmaBilgileriGuncelle();
            //a = GenelParametreSng.Nesne().firmaBilgileri.MUHASEBE_KAPALI_AY;
        }
        public void Sablon_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Globals.sablonKapatildi = true;
            //Globals.tabliCalis = true;
            //Destroy the corresponding Tabpage when closing MDI child form
            if (KapatKontrol()==true)
	        {
                e.Cancel = true;
                return;
	        }
            try
            {
                //if (Globals.tabliCalis == true)
                //{
                    if (this.tabPag != null)
                    {
                        this.tabPag.Dispose();

                        //If no Tabpage left
                        if (!tabCtrl.HasChildren)
                        {
                            tabCtrl.Visible = false;
                        }
                    }
                //}
            }
            catch (Exception)
            {
                
                
            }
          
        }
        public virtual bool KapatKontrol()
        {
            return false;
        }
        public void Sablon_Activated(object sender, System.EventArgs e)
        {
            try
            {
                //Ekran_Yenile();
               // Month11(); 
                //Type hai = this.GetType();
                //string name = hai.ToString();
                //MenulerVm fVm = new MenulerVm();
                //fVm.URL = name;
                //MenulerCntrl cntrl = new MenulerCntrl();
                //yetki = ListDenemeService.GetYETKI_MENULER(name);
                //if (this.DesignMode == false)
                //{
                //    var list = (from n in GenelParametreSng.Nesne().kullaniciMenuYetkiBilgileri
                //                where n.M_MENU_ID == sablonSecilenMenuId
                //                select new YetkiMenulerVm
                //                {
                //                    ID = n.ID,
                //                    KULLANICI_ID = n.KULLANICI_ID,
                //                    M_MENU_ID = n.M_MENU_ID,
                //                    OKU_E_H = n.OKU_E_H,
                //                    YAZ_E_H = n.YAZ_E_H,
                //                    GUNCELLE_E_H = n.GUNCELLE_E_H,
                //                    SIL_E_H = n.SIL_E_H,
                //                }).ToList();
                //    if (list.Count > 0)
                //    {
                //        yetki = (YetkiMenulerVm)list[0];
                //    }
                //} 
                //Activate the corresponding Tabpage
                //if (Globals.tabliCalis == true)
                //{
                    if (tabPag != null)
                    {
                        tabCtrl.SelectedTab = tabPag;
                        if (!tabCtrl.Visible)
                        {
                            tabCtrl.Visible = true;
                        }
                    }
                //}
            }
            catch (Exception)
            {
            }
            if (acilis==true)
            {
                Form_Acilis(sender, e);
                acilis = false;
            }
        }
        public virtual void Ekran_Yenile() { }
        public void Isimlendir(Control.ControlCollection Control)
        {
            foreach (Control fc in Control)
            {
                if (fc.GetType() == typeof(System.Windows.Forms.TabControl))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.TabPage))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GroupControl))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.PanelControl))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.UserControl))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.XtraUserControl))
                {
                    Isimlendir(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LabelControl))
                {
                    DevExpress.XtraEditors.LabelControl label = fc as DevExpress.XtraEditors.LabelControl;
                    if (label.Name.Length > 3)
                    {
                        string labelName = label.Name.Substring(0, label.Name.Length - 3);
                        string s;
                        s = Globals.rman.GetString(labelName);
                        label.Text = s ?? label.Text;
                    }
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Label))
                {
                    Label label = fc as Label;
                    if (label.Name.Length > 3)
                    {
                        string labelName = label.Name.Substring(0, label.Name.Length - 3);
                        string s;
                        s = Globals.rman.GetString(labelName);
                        label.Text = s ?? label.Text;
                    }
                    
                }
            }
        }
        public TabPage TabPag
        {
            get
            {
                return tabPag;
            }
            set
            {
                tabPag = value;
            }
        }
        public TabControl TabCtrl
        {
            set
            {
                tabCtrl = value;
            }
        }
        public virtual void Form_Acilis(object sender, EventArgs e){
        
        }
        private void Sablon_Shown(object sender, EventArgs e)
        {
           // Form_Acilis(sender, e);
        }
    }
}
