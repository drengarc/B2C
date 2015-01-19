using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Prodma.DataAccessB2C; using Prodma.WinForms;
using Satis.Cari.Models;
using Satis.Cari.Controllers;
using Prodma.Sistem.Models;
using Prodma.Sistem.Controllers;

namespace Prodma.Sistem.Forms
{
    public partial class usrIrsaliyeYaziciAyar : usrControlSablon
    {
        public FaturaIrsaliyeAyarVm FtuIrsAyarVm = new FaturaIrsaliyeAyarVm();
        FaturaIrsaliyeAyarCntrl FtuIrsCntrl = new FaturaIrsaliyeAyarCntrl();
        //public FaturaIrsaliyeAyarVm irsaliyeVm = new FaturaIrsaliyeAyarVm();
        public int faturaIrsaliyeAyarID;
        bool control;
        public usrIrsaliyeYaziciAyar()
        {
            InitializeComponent();
            this.control = true;
        }
        public void Doldur()
        {
            //Control_Ayarla_Kayit(this.Controls, ListDenemeService.GetALANLAR("FATURA_IRSALIYE_AYAR", 1), null, null, true);
            List<FaturaIrsaliyeAyarVm> listAyar = new List<FaturaIrsaliyeAyarVm>();
            FaturaIrsaliyeAyarVm ayarVm = new FaturaIrsaliyeAyarVm();
            ayarVm.FATURA_IRSALIYE_AYAR_TIP_ID = faturaIrsaliyeAyarID;
            listAyar = FtuIrsCntrl.Liste_Al(ayarVm);
            if (listAyar != null && listAyar.Count > 0)
            {
                FtuIrsAyarVm = listAyar[0];
                faturaIrsaliyeAyarID = FtuIrsAyarVm.ID;
                cbodoldur();
            }
            else
            {
                FtuIrsCntrl.Ekle(FtuIrsAyarVm);
            }
        }
        public void cbodoldur()
        {


            Type irs = typeof(FaturaIrsaliyeAyarVm);
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
                            object propertyValue = fia.GetValue(FtuIrsAyarVm, null);
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
                            object propertyValue = fia.GetValue(FtuIrsAyarVm, null);
                            if (Convert.ToBoolean(propertyValue) == true)
                            {
                                ctrl.Checked = true;
                                this.control = false;
                            }
                        }
                    }
                }

            }
        }
        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.control == false)
            {
                this.control = true;
                return;
            }
            else
            {
                DevExpress.XtraEditors.CheckEdit checkEdit = sender as DevExpress.XtraEditors.CheckEdit;
                string nameSA, nameUA;
                nameSA = nameUA = checkEdit.Name.Remove(checkEdit.Name.Length - 6);
                Control[] cntrlSA = this.Controls.Find(nameUA + "SAtxt", true);
                Control[] cntrlUA = this.Controls.Find(nameUA + "UAtxt", true);
                DevExpress.XtraEditors.TextEdit textEditSA = (DevExpress.XtraEditors.TextEdit)cntrlSA[0];
                DevExpress.XtraEditors.TextEdit textEditUA = (DevExpress.XtraEditors.TextEdit)cntrlUA[0];

                if (!checkEdit.Checked)
                {
                    textEditSA.Enabled = false;
                    textEditUA.Enabled = false;
                }
                else
                {
                    textEditSA.Enabled = true;
                    textEditUA.Enabled = true;
                }
            }
        }
        public override void Kaydet()
        {
            Type irs = typeof(FaturaIrsaliyeAyarVm);
            System.Reflection.PropertyInfo[] fi = irs.GetProperties();
            foreach (System.Reflection.PropertyInfo fia in fi)
            {
                foreach (Control control in this.Controls)
                {
                    if (control.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                    {
                        DevExpress.XtraEditors.TextEdit ctrl = control as DevExpress.XtraEditors.TextEdit;
                        if (fia.Name + "txt" == ctrl.Name && ctrl.Tag != null && ctrl.Tag.ToString() == "S")
                        {
                            fia.SetValue(FtuIrsAyarVm, ctrl.Text, null);
                        }
                        else if (fia.Name + "txt" == ctrl.Name && ctrl.Text != "" && ctrl.Text != null && ctrl.Enabled == true)
                        {
                            fia.SetValue(FtuIrsAyarVm, Convert.ToDecimal(ctrl.Text), null);
                        }
                    }
                    else if (control.GetType() == typeof(DevExpress.XtraEditors.CheckEdit))
                    {
                        DevExpress.XtraEditors.CheckEdit ctrl = control as DevExpress.XtraEditors.CheckEdit;
                        if (fia.Name + "che" == ctrl.Name)
                        {
                            fia.SetValue(FtuIrsAyarVm, ctrl.Checked, null);
                        }
                    }
                }
            }

            if (faturaIrsaliyeAyarID != 0)
            {
                FtuIrsAyarVm.ID = faturaIrsaliyeAyarID;
                FtuIrsCntrl.doGuncelle(FtuIrsAyarVm, faturaIrsaliyeAyarID);
                MessageBox.Show("Kaydetme İşlemi Tamamlandı");
            }
            if (faturaIrsaliyeAyarID == 0)
            {
                FtuIrsCntrl.doEkle(FtuIrsAyarVm);
                MessageBox.Show("Kaydetme İşlemi Tamamlandı");
            }
        }
    }
}
