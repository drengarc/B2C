using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccessB2C; using Prodma.WinForms;
using System.Threading;
namespace Prodma.DataAccessB2C
{
    public partial class KullaniciIslemKopyalama : Islemler
    {
        public int yetkiIslemTanitimId = 0;
        public int yetkiIslemTipId=0;
        public KullaniciIslemKopyalama()
        {
            InitializeComponent();
            this.Text = "Kullanici İşlem Kopyalama";
            YardimciIslemlerKontrols.InvokeLueContainSet("YETKI_ISLEM_TANTIM_ID", ESKI_KULLANICI_IDlke);
            YardimciIslemlerKontrols.InvokeChlSet("AKTIF_KULLANICI_ID", KULLANICI_IDchl);
            //YardimciIslemlerKontrols.InvokeEnumSet(YardimciIslemlerKontrols.EnumToList<KullaniciRolEn>(), KULLANICI_ROL_IDlke);
            YardimciIslemlerKontrols.InvokeLueContainSet("LK_HAYIR_EVET_ID", YETKILI_E_Hlke);
            YardimciIslemlerKontrols.InvokeChlSet("KULLANICI_ID", KULLANICI_IDchl);


        }
        private void KullaniciKopyalama_Load(object sender, EventArgs e)
        {
            Control_Ayarla_Kayit(this.Controls, alanlarVm, KULLANICI_IDchl, true);
            ESKI_KULLANICI_IDlke.EditValue = yetkiIslemTanitimId;
            //KULLANICI_ROL_IDlke.EditValue = (int)KullaniciRolEn.Kullanici;
            KULLANICI_IDchl.CheckAll();
        }
        public override void Tamam()
        {
            if (sorguBitti == false)
            {
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                Kullanici_Kopyala();
            }
            sorguBitti = true;
            MessageBox.Show("İşlem Tamamlandı");
        }
        void Kullanici_Kopyala()
        {
            string sonuc = OrtakIslemlerService.IslemiKullanicilaraKopyala(parameterIslemler);
            if (sonuc != "")
            {
                MessageBox.Show(sonuc);
            }
        }
        public override bool IslemKontrol(Control cntrl)
        {
                parameterIslemler.Clear();
                parameterIslemler.Add("KULLANICI_ID", Convert.ToString(KULLANICI_IDchl.EditValue.ToString()));
                parameterIslemler.Add("YETKI_ISLEM_TANITIM_ID", Convert.ToString(ESKI_KULLANICI_IDlke.EditValue));
                parameterIslemler.Add("YETKILI_E_H", Convert.ToString(YETKILI_E_Hlke.EditValue));
            return true;
        }

        private void KULLANICI_ROL_IDlke_EditValueChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(KULLANICI_ROL_IDlke.EditValue) == (int)KullaniciRolEn.Kullanici)
            //{
            //    YardimciIslemlerKontrols.InvokeChlSet("KULLANICI_ID", KULLANICI_IDchl);
            //}
            //else
            //{
            //    YardimciIslemlerKontrols.InvokeChlSet("ROL_ID", KULLANICI_IDchl);
            //}
        }
    }
}
