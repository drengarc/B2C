using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Prodma.WinForms
{
    public partial class DynamicUpdateWarning : DevExpress.XtraEditors.XtraForm
    {
        private bool nextFlag;
        public bool saveFlag;
        public DynamicUpdateWarning()
        {
            InitializeComponent();
            nextFlag = true;
            saveFlag = false;
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (nextFlag == true)
            {
                this.nextBtn.Text = "Kaydet";
                this.warningLbl.Text = "Seçili tüm kayıtları güncellemek istediğinizden emin misiniz?";
                this.warningLbl2.Text = "";
                this.nextFlag = false;
            }
            else
            {
                saveFlag = true;
                this.Dispose();
                this.Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            saveFlag = false;
            this.Dispose();
            this.Close();
        }
    }
}