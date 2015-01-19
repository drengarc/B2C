using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccess;
using System.Globalization;
using Prodma.WinForms;
namespace Ortak.Formlar
{
    public partial class FisKurGiris : Islemler
    {
        public int cariId = 0;
        public bool dovizKurBul=true;
        public bool degisiklikYapma = false;
        public FisKurGiris()
        {
            CultureInfo ci = new CultureInfo("tr-Tr");
            InitializeComponent();
            String a = new String('#', Convert.ToInt32(5));
            String b = new String('#', Convert.ToInt32(5));
            KURtxt.Properties.Mask.UseMaskAsDisplayFormat = true;
            KURtxt.Properties.Mask.EditMask = "f5";
            KURtxt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            FIYATtxt.Properties.Mask.UseMaskAsDisplayFormat = true;
            FIYATtxt.Properties.Mask.EditMask = "f5";
            FIYATtxt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            DOVIZ_FIYATtxt.Properties.Mask.UseMaskAsDisplayFormat = true;
            DOVIZ_FIYATtxt.Properties.Mask.EditMask = "f5";
            DOVIZ_FIYATtxt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Text = "Döviz Kur Bilgileri";
            //panelTamam.Visible = false;
            YardimciIslemlerKontrols.InvokeEnumSet(YardimciIslemlerKontrols.EnumToList<DovizKurTipEn>(), SATIS_DOVIZ_KUR_TIPlke);
            DOVIZ_IDLke.Properties.DataSource = ListService.GetDOVIZ_ID((int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
            DOVIZ_IDLke.Properties.DisplayMember = "AD";
            DOVIZ_IDLke.Properties.ValueMember = "ID";
            this.TAMAM_1cmd.Click += new System.EventHandler(this.button1_Click);
            this.TAMAM_1cmd.Enter += new System.EventHandler(this.TAMAMcmd_Enter);
            this.TAMAM_1cmd.Focus();
            this.IPTAL_1btn.Visible = false;

        }
        public event EventHandler ButtonClick;
        private void OnButtonClicked(EventArgs e)
        {
                if (ButtonClick != null)
                {
                    ButtonClick(this, e);
                }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_dovizKur == 0 && _dovizTutar != 0 && _dovizTlTutar != 0)
            {
                _dovizKur =  _dovizTlTutar / _dovizTutar;
            }
            else if (_dovizKur != 0 && _dovizTutar == 0 && _dovizTlTutar != 0)
            {
                _dovizTlTutar = _dovizKur * _dovizTlTutar;
            }
            else if (_dovizKur != 0 && _dovizTutar != 0 && _dovizTlTutar == 0)
            {
                _dovizTutar = _dovizTlTutar / _dovizKur;
            }
             OnButtonClicked(e);
             this.Close();  
        }

        public DateTime? _fisTarih;
        int _dovizId;
        public int dovizId
        {
            get { return _dovizId; }
            set { _dovizId = value; }
        }
        decimal _dovizKur;
        public decimal dovizKur
        {
            get { return _dovizKur; }
            set { _dovizKur =  value; }
        }
        decimal _dovizTutar = 0;
        public decimal dovizTutar
        {
            get { return _dovizTutar; }
            set { _dovizTutar  = value; }
        }
        decimal _dovizTlTutar = 0;
        public decimal dovizTlTutar
        {
            get { return _dovizTlTutar; }
            set { _dovizTlTutar = value; }
        }
        private void FisKurGiris_Load(object sender, EventArgs e)
        {
            Control_Ayarla_Kayit(this.Controls, null, TAMAM_1cmd, false);
            DOVIZ_IDLke.EditValue = dovizId != 0 ? dovizId : (int)DovizEn.TL;
            SATIS_DOVIZ_KUR_TIPlke.EditValue = GenelParametreSng.Nesne().firmaBilgileri.SATIS_DOVIZ_KUR_TIP != null ?  (int)GenelParametreSng.Nesne().firmaBilgileri.SATIS_DOVIZ_KUR_TIP : (int)DovizKurTipEn.DOVIZ_SATIS;
            UYGULAcmd.Enabled = false;
            KURtxt.Text = _dovizKur.ToString();
            DOVIZ_FIYATtxt.Text = _dovizTutar.ToString();
            FIYATtxt.Text = _dovizTlTutar.ToString();   
            if  (_dovizKur==0 && dovizKurBul ==true) Doviz_Kur_Bul();
            if (degisiklikYapma == true)
            {
                KURtxt.Enabled = false;
                DOVIZ_FIYATtxt.Enabled = false;
                FIYATtxt.Enabled = false;
            }
            else
            {
                KURtxt.Enabled = true;
                DOVIZ_FIYATtxt.Enabled = true;
                FIYATtxt.Enabled = true;
            }
            this.panelTamam.Focus();
            this.TAMAM_1cmd.Focus();
           
        }
        private void DOVIZ_UYGULAcmd_Click(object sender, EventArgs e)
        {
            Doviz_Kur_Bul();
            Doviz_Kur_Form_Ayarla();
        }  
        private void Doviz_Kur_Bul()
        {
            decimal kur = FiyatBulService.GetCARI_DOVIZ_KUR(cariId, _fisTarih, (int)DOVIZ_IDLke.EditValue)[0];
            if (kur != 0)
            {
                KURtxt.Text = YardimciIslemler.DecimalFormatla(kur, 5);
            }
            else
            {
                KURtxt.Text = Convert.ToString(FiyatBulService.GetDOVIZ_KUR((int)SATIS_DOVIZ_KUR_TIPlke.EditValue, (int)DOVIZ_IDLke.EditValue, _fisTarih));  
            }
        }
        private void Doviz_Kur_Form_Ayarla()
        {
            decimal result;
            _dovizKur =decimal.TryParse(KURtxt.Text, out result)== true ? Convert.ToDecimal(KURtxt.Text) :0;
            _dovizTutar = decimal.TryParse(DOVIZ_FIYATtxt.Text, out result) == true ? Convert.ToDecimal(DOVIZ_FIYATtxt.Text) : 0;
            _dovizTlTutar = decimal.TryParse(FIYATtxt.Text, out result) == true ? Convert.ToDecimal(FIYATtxt.Text) : 0;
            if (_dovizKur == 0 && _dovizTutar != 0 && _dovizTlTutar != 0)
            {
                _dovizKur = _dovizTlTutar / _dovizTutar;
            }
            else if (_dovizKur != 0 && _dovizTutar == 0 && _dovizTlTutar != 0)
            {
                _dovizTutar = _dovizTlTutar / _dovizKur;
            }
            else if (_dovizKur != 0 && _dovizTutar != 0 && _dovizTlTutar == 0)
            {
                _dovizTlTutar = _dovizTutar * _dovizKur;
            }
            else if (_dovizKur != 0 && _dovizTutar != 0 && _dovizTlTutar != 0)
            {
                _dovizTlTutar = _dovizTutar * _dovizKur;
            }
            KURtxt.Text = String.Format("{0:0.00000}", Convert.ToString(_dovizKur));
            DOVIZ_FIYATtxt.Text = String.Format("{0:0.00000}", Convert.ToString(_dovizTutar));
            FIYATtxt.Text =   String.Format("{0:0.00000}",Convert.ToString(_dovizTlTutar));
        }
        private void TAMAMcmd_Enter(object sender, EventArgs e)
        {
            Doviz_Kur_Form_Ayarla(); 
        }

        private void SATIS_DOVIZ_KUR_TIPlke_EditValueChanged(object sender, EventArgs e)
        {
            UYGULAcmd.Enabled = true;
        }
    }
}
