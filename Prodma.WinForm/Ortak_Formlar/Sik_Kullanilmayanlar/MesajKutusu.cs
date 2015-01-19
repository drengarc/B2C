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

namespace Prodma.WinForms
{
    public partial class MesajKutusu : DevExpress.XtraEditors.XtraForm
    {
      
        public MesajKutusu()
        {
            InitializeComponent();
            lblNot.Focus();
            
            //byte? a = GenelParametreSng.Nesne().firmaBilgileri.MUHASEBE_KAPALI_AY;
            //ListDenemeService.FirmaBilgileriGuncelle();
            //a = GenelParametreSng.Nesne().firmaBilgileri.MUHASEBE_KAPALI_AY;
        }
        public void Sablon_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
         
          
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
             
                //}
            }
            catch (Exception)
            {
            }
           
        }
        private void Sablon_Shown(object sender, EventArgs e)
        {
           // Form_Acilis(sender, e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
