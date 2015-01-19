using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Prodma.DataAccess;
using Satis.Cari.Models;
using Satis.Cari.Controllers;
using Prodma.Sistem.Models;
using Prodma.Sistem.Controllers;

namespace Prodma.Sistem.Forms
{
    public partial class usrBarkodDokumKoordinat : usrControlSablon
    {
        public BarkodDokumKoordinatVm barkodDokumKoordinatVm = new BarkodDokumKoordinatVm();
        BarkodDokumKoordinatCntrl barkodDokumKoordinatCntrl = new BarkodDokumKoordinatCntrl();
        private bool eskiKayit;
        public usrBarkodDokumKoordinat()
        {
            InitializeComponent();
            Ilk_Deger_Ver();
        }
        void Ilk_Deger_Ver()
        {
            BindingSource evetHayir = new BindingSource();
            evetHayir.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
            BARKOD_FONT_BOLDlke.Properties.DataSource = evetHayir;
            STOK_KOD_FONT_BOLDlke.Properties.DataSource = evetHayir;
            STOK_AD_FONT_BOLDlke.Properties.DataSource = evetHayir;
            STOK_AMBALAJ_MIKTAR_FONT_BOLDlke.Properties.DataSource = evetHayir;
            ACIKLAMA_1_FONT_BOLDlke.Properties.DataSource = evetHayir;
            ACIKLAMA_2_FONT_BOLDlke.Properties.DataSource = evetHayir;
            ACIKLAMA_3_FONT_BOLDlke.Properties.DataSource = evetHayir;
            ACIKLAMA_4_FONT_BOLDlke.Properties.DataSource = evetHayir;
            ACIKLAMA_5_FONT_BOLDlke.Properties.DataSource = evetHayir;
        }
        public override void Doldur()
        {
            Control_Ayarla_Kayit(this.Controls, null, null, null, true);
            List<BarkodDokumKoordinatVm> list = barkodDokumKoordinatCntrl.Liste_Al(barkodDokumKoordinatVm);
            if (list != null && list.Count!=0)
            {
                eskiKayit = true;

                barkodDokumKoordinatVm = list[0];
                BARKOD_CHKche.Checked = barkodDokumKoordinatVm.BARKOD_CHK;
                BARKOD_Xtxt.Text = barkodDokumKoordinatVm.BARKOD_X.ToString();
                BARKOD_Ytxt.Text = barkodDokumKoordinatVm.BARKOD_Y.ToString();
                BARKOD_FONT_SIZEtxt.Text = barkodDokumKoordinatVm.BARKOD_FONT_SIZE.ToString();
                BARKOD_FONT_BOLDlke.EditValue = barkodDokumKoordinatVm.BARKOD_FONT_BOLD == true ? 1 : 0;

                STOK_KOD_CHKche.Checked = barkodDokumKoordinatVm.STOK_AD_CHK;
                STOK_KOD_Xtxt.Text = barkodDokumKoordinatVm.STOK_KOD_X.ToString();
                STOK_KOD_Ytxt.Text = barkodDokumKoordinatVm.STOK_KOD_Y.ToString();
                STOK_KOD_FONT_SIZEtxt.Text = barkodDokumKoordinatVm.STOK_KOD_FONT_SIZE.ToString();
                STOK_KOD_FONT_BOLDlke.EditValue = barkodDokumKoordinatVm.STOK_KOD_FONT_BOLD == true ? 1 : 0;

                STOK_AD_CHKche.Checked = barkodDokumKoordinatVm.STOK_AD_CHK;
                STOK_AD_Xtxt.Text = barkodDokumKoordinatVm.STOK_AD_X.ToString();
                STOK_AD_Ytxt.Text = barkodDokumKoordinatVm.STOK_AD_Y.ToString();
                STOK_AD_FONT_SIZEtxt.Text = barkodDokumKoordinatVm.STOK_AD_FONT_SIZE.ToString();
                STOK_AD_FONT_BOLDlke.EditValue = barkodDokumKoordinatVm.STOK_AD_FONT_BOLD == true ? 1 : 0;

                STOK_AMBALAJ_MIKTAR_CHKche.Checked = barkodDokumKoordinatVm.STOK_AMBALAJ_MIKTAR_CHK;
                STOK_AMBALAJ_MIKTAR_Xtxt.Text = barkodDokumKoordinatVm.STOK_AMBALAJ_MIKTAR_X.ToString();
                STOK_AMBALAJ_MIKTAR_Ytxt.Text = barkodDokumKoordinatVm.STOK_AMBALAJ_MIKTAR_Y.ToString();
                STOK_AMBALAJ_MIKTAR_FONT_SIZEtxt.Text = barkodDokumKoordinatVm.STOK_AMBALAJ_MIKTAR_FONT_SIZE.ToString();
                STOK_AMBALAJ_MIKTAR_FONT_BOLDlke.EditValue = barkodDokumKoordinatVm.STOK_AMBALAJ_MIKTAR_FONT_BOLD == true ? 1 : 0;

                ACIKLAMA_1_CHKche.Checked = barkodDokumKoordinatVm.ACIKLAMA_1_CHK;
                ACIKLAMA_1_Xtxt.Text = barkodDokumKoordinatVm.ACIKLAMA_1_X.ToString();
                ACIKLAMA_1_Ytxt.Text = barkodDokumKoordinatVm.ACIKLAMA_1_Y.ToString();
                ACIKLAMA_1_FONT_SIZEtxt.Text = barkodDokumKoordinatVm.ACIKLAMA_1_FONT_SIZE.ToString();
                ACIKLAMA_1_FONT_BOLDlke.EditValue = barkodDokumKoordinatVm.ACIKLAMA_1_FONT_BOLD == true ? 1 : 0;
                ACIKLAMA_1txt.Text = barkodDokumKoordinatVm.ACIKLAMA_1;

                ACIKLAMA_2_CHKche.Checked = barkodDokumKoordinatVm.ACIKLAMA_2_CHK;
                ACIKLAMA_2_Xtxt.Text = barkodDokumKoordinatVm.ACIKLAMA_2_X.ToString();
                ACIKLAMA_2_Ytxt.Text = barkodDokumKoordinatVm.ACIKLAMA_2_Y.ToString();
                ACIKLAMA_2_FONT_SIZEtxt.Text = barkodDokumKoordinatVm.ACIKLAMA_2_FONT_SIZE.ToString();
                ACIKLAMA_2_FONT_BOLDlke.EditValue = barkodDokumKoordinatVm.ACIKLAMA_2_FONT_BOLD == true ? 1 : 0;
                ACIKLAMA_2txt.Text = barkodDokumKoordinatVm.ACIKLAMA_2;

                ACIKLAMA_3_CHKche.Checked = barkodDokumKoordinatVm.ACIKLAMA_3_CHK;
                ACIKLAMA_3_Xtxt.Text = barkodDokumKoordinatVm.ACIKLAMA_3_X.ToString();
                ACIKLAMA_3_Ytxt.Text = barkodDokumKoordinatVm.ACIKLAMA_3_Y.ToString();
                ACIKLAMA_3_FONT_SIZEtxt.Text = barkodDokumKoordinatVm.ACIKLAMA_3_FONT_SIZE.ToString();
                ACIKLAMA_3_FONT_BOLDlke.EditValue = barkodDokumKoordinatVm.ACIKLAMA_3_FONT_BOLD == true ? 1 : 0;
                ACIKLAMA_3txt.Text = barkodDokumKoordinatVm.ACIKLAMA_3;

                ACIKLAMA_4_CHKche.Checked = barkodDokumKoordinatVm.ACIKLAMA_4_CHK;
                ACIKLAMA_4_Xtxt.Text = barkodDokumKoordinatVm.ACIKLAMA_4_X.ToString();
                ACIKLAMA_4_Ytxt.Text = barkodDokumKoordinatVm.ACIKLAMA_4_Y.ToString();
                ACIKLAMA_4_FONT_SIZEtxt.Text = barkodDokumKoordinatVm.ACIKLAMA_4_FONT_SIZE.ToString();
                ACIKLAMA_4_FONT_BOLDlke.EditValue = barkodDokumKoordinatVm.ACIKLAMA_4_FONT_BOLD == true ? 1 : 0;
                ACIKLAMA_4txt.Text = barkodDokumKoordinatVm.ACIKLAMA_4;

                ACIKLAMA_5_CHKche.Checked = barkodDokumKoordinatVm.ACIKLAMA_5_CHK;
                ACIKLAMA_5_Xtxt.Text = barkodDokumKoordinatVm.ACIKLAMA_5_X.ToString();
                ACIKLAMA_5_Ytxt.Text = barkodDokumKoordinatVm.ACIKLAMA_5_Y.ToString();
                ACIKLAMA_5_FONT_SIZEtxt.Text = barkodDokumKoordinatVm.ACIKLAMA_5_FONT_SIZE.ToString();
                ACIKLAMA_5_FONT_BOLDlke.EditValue = barkodDokumKoordinatVm.ACIKLAMA_5_FONT_BOLD == true ? 1 : 0;
                ACIKLAMA_5txt.Text = barkodDokumKoordinatVm.ACIKLAMA_5;
            }
            else 
            {
                this.Clear(this.Controls);
                eskiKayit = false;
            }

        }
        public void cbodoldur()
        {

            Type irs = typeof(BarkodDokumKoordinatVm);
            System.Reflection.PropertyInfo[] fi = irs.GetProperties();

            foreach (System.Reflection.PropertyInfo fia in fi)
            {
                foreach (Control control in this.Controls)
                {
                    if (control.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                    {
                        DevExpress.XtraEditors.TextEdit ctrl = control as DevExpress.XtraEditors.TextEdit;

                        if (fia.Name + "txt" == ctrl.Name)
                        {
                            object propertyValue = fia.GetValue(barkodDokumKoordinatVm, null);
                            if (propertyValue != null && propertyValue.ToString()!="0,00")
                            {
                                ctrl.Enabled = true;
                                ctrl.Text = propertyValue.ToString();
                            }
                        }
                    }
                    else if (control.GetType() == typeof(DevExpress.XtraEditors.CheckEdit))
                    {
                        DevExpress.XtraEditors.CheckEdit ctrl = control as DevExpress.XtraEditors.CheckEdit;
                        if (fia.Name + "che" == ctrl.Name)
                        {
                            object propertyValue = fia.GetValue(barkodDokumKoordinatVm, null);
                            if (Convert.ToBoolean(propertyValue) == true)
                            {
                                ctrl.Checked = true;
                            }
                            else
                            {
                                ctrl.Checked = false;
                            }
                        }
                    }
                }

            }
        }
        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit checkEdit = sender as DevExpress.XtraEditors.CheckEdit;
            string nameX, nameY,nameFontSize,nameFontBold;
            nameX = nameY = nameFontSize = nameFontBold = checkEdit.Name.Remove(checkEdit.Name.Length - 6);
            Control[] cntrlX = this.Controls.Find(nameX + "Xtxt", true);
            Control[] cntrlY = this.Controls.Find(nameY + "Ytxt", true);
            Control[] cntrlFontSize = this.Controls.Find(nameY + "FONT_SIZEtxt", true);
            Control[] cntrlFontBold = this.Controls.Find(nameY + "FONT_BOLDtxt", true);
            DevExpress.XtraEditors.TextEdit textEditX = (DevExpress.XtraEditors.TextEdit)cntrlX[0];
            DevExpress.XtraEditors.TextEdit textEditY = (DevExpress.XtraEditors.TextEdit)cntrlY[0];
            DevExpress.XtraEditors.TextEdit textEditFontSize = (DevExpress.XtraEditors.TextEdit)cntrlFontSize[0];
            //DevExpress.XtraEditors.LookUpEdit lookUpEditFontBold = (DevExpress.XtraEditors.LookUpEdit)cntrlFontBold[0];

            if (!checkEdit.Checked)
            {
                textEditX.Enabled = false;
                textEditY.Enabled = false;
                textEditFontSize.Enabled = false;
                //lookUpEditFontBold.Enabled = false;
            }
            else
            {
                textEditX.Enabled = true;
                textEditY.Enabled = true;
                textEditFontSize.Enabled = true;
                //lookUpEditFontBold.Enabled = true;
            }
            
        }
        public override void Kaydet()
        {
            Type irs = typeof(BarkodDokumKoordinatVm);
            System.Reflection.PropertyInfo[] fi = irs.GetProperties();
            foreach (System.Reflection.PropertyInfo fia in fi)
            {
                foreach (Control control in this.Controls)
                {
                    if (control.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                    {
                        DevExpress.XtraEditors.TextEdit ctrl = control as DevExpress.XtraEditors.TextEdit;
                        if (fia.Name + "txt" == ctrl.Name)
                        {
                            if (fia.Name + "txt" == ctrl.Name && ctrl.Tag != null && ctrl.Tag.ToString() == "S")
                            {
                                fia.SetValue(barkodDokumKoordinatVm, ctrl.Text, null);
                            }
                            else if (fia.Name + "txt" == ctrl.Name && ctrl.Text != "" && ctrl.Text != null && ctrl.Enabled == true)
                            {
                                if (YardimciIslemler.Strip(ctrl.Text) > 0)
                                {
                                    fia.SetValue(barkodDokumKoordinatVm, Convert.ToInt32(ctrl.Text), null);
                                }
                            }
                           
                        }
                        //else if (fia.Name + "txt" == ctrl.Name)
                        //{
                        //    fia.SetValue(barkodDokumKoordinatVm, Convert.ToDecimal(ctrl.Text), null);
                        //}
                    }
                    else if (control.GetType() == typeof(DevExpress.XtraEditors.CheckEdit))
                    {
                        DevExpress.XtraEditors.CheckEdit ctrl = control as DevExpress.XtraEditors.CheckEdit;
                        if (fia.Name + "che" == ctrl.Name)
                        {
                            try
                            {
                                fia.SetValue(barkodDokumKoordinatVm, ctrl.Checked, null);
                            }
                            catch (Exception)
                            {


                            }
                        }
                    }
                    else if (control.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                    {
                        DevExpress.XtraEditors.LookUpEdit ctrl = control as DevExpress.XtraEditors.LookUpEdit;
                        if (fia.Name + "lke" == ctrl.Name)
                        {
                            try
                            {
                                fia.SetValue(barkodDokumKoordinatVm, Convert.ToInt32(ctrl.EditValue) == 0 ? false : true, null);
                            }
                            catch (Exception)
                            {


                            }
                        }
                    }
                }
            }

            if (eskiKayit)
            {
                barkodDokumKoordinatCntrl.doGuncelle(barkodDokumKoordinatVm, barkodDokumKoordinatVm.BARKOD_YAZICI_TANITIM_ID);
                MessageBox.Show("Kaydetme İşlemi Tamamlandı");
            }
            else
            {
                barkodDokumKoordinatCntrl.doEkle(barkodDokumKoordinatVm);
                MessageBox.Show("Yeni Kayıt İşlemi Tamamlandı");
            }
        }
    }
}
