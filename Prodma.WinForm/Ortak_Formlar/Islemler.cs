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
using System.Threading;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using Prodma.DataAccessB2C;
namespace Prodma.WinForms
{
    public partial class Islemler : Sablon
    {
        public int islemYapilanKayiSayisi = 0;
        public bool kontrollerDisaridenSetEdildi = false;
        public bool formTipIslemMi=true;
        public bool islemdenSonraKapat=false;
        public bool threadSizMi = false;
        public Dictionary<string, string> parameterDisaridanGelenler = new Dictionary<string, string>();
        public Dictionary<string, string> parameterIslemler = new Dictionary<string, string>();
        public int maximum = 100;
        public bool sorguBitti =false;
        public bool escapeKapatma = false;
        public List<Alanlar> alanlarVm = new List<Alanlar>();
        bool controlAyarlayaGirdi = false;
        public event EventHandler enter = delegate { };
        public static Control theActiveControl = null;
        public static Control thePreviousControl = null;
        public navBar navBar = new navBar();
        public Control.ControlCollection Controller;
        public Control.ControlCollection DegerController;
        public Islemler()
        {
            InitializeComponent();
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            panelTamam.Dock = DockStyle.Bottom;
            this.TAMAM_1cmd.Click += new System.EventHandler(this.TAMAMcmd_Click);
            this.IPTAL_1btn.Click += new System.EventHandler(this.IPTALbtn_Click);
            this.Load += new System.EventHandler(this.Form_Load);
        }
        private void Form_Load(object sender, EventArgs e)
        {
            //if (threadSizMi==true)
            //   timer1.Enabled = false;
        }
        private void IPTALbtn_Click(object sender, EventArgs e)
        {
            if (this.ControlBox == true)
            {
                this.Dispose();
                this.Close();
            }
            
        }
        private void TAMAMcmd_Click(object sender, EventArgs e)
        {
            parameterIslemler.Clear();
            sorguBitti = false;
            butonlariIsle(false);
            if (IslemKontrol(TAMAM_1cmd) == true)
            {
                Goster();
            }
            else
            {
                butonlariIsle(true);
            }
           // butonlariIsle(true);
            //this.Dispose();
            //this.Close();

        }
        public void Control_Ayarla_Kayit(Control.ControlCollection Control, List<Alanlar> q,Control cntrl,bool kayit)
        {
            Controller = Control;
            if (DegerController==null) DegerController = Controller;
            string name = "";
            foreach (Control fc in Control)
            {
                if (fc.GetType() == typeof(DevExpress.XtraTab.XtraTabControl))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl, kayit);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraTab.XtraTabPage))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl, kayit);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.TabControl))
                {
                    Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.TabPage))
                {
                    Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GroupControl))
                {
                    Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.PanelControl))
                {
                    Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.UserControl))
                {
                    Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.XtraUserControl))
                {
                    Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LabelControl))
                {

                    DevExpress.XtraEditors.LabelControl label = fc as DevExpress.XtraEditors.LabelControl;
                    if (label.Tag!=null && label.Tag.ToString() == "B") label.Text = "";
                    if (label.Name.Length > 3)
                    {
                        string labelName = label.Name.Substring(0, label.Name.Length - 3);
                        string s;
                        s = Globals.rman.GetString(labelName);
                        if (s!=null) label.Text = s;
                    }
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.SimpleButton))
                {
                    DevExpress.XtraEditors.SimpleButton cmd = fc as DevExpress.XtraEditors.SimpleButton;
                    if (cmd.Tag != null && cmd.Tag.ToString() == "B") cmd.Text = "";
                    if (cmd.Name.Length > 3)
                    {
                        string cmdName = cmd.Name.Substring(0, cmd.Name.Length - 3);
                        string s;
                        s = Globals.rman.GetString(cmdName);
                        if (s != null) cmd.Text = s;
                    }
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Label))
                {
                    Label label = fc as Label;
                    if (label.Tag != null && label.Tag.ToString() == "B") label.Text = "";
                    if (label.Name.Length > 3)
                    {
                        string labelName = label.Name.Substring(0, label.Name.Length - 3);
                        string s = Globals.rman.GetString(labelName);
                        if (s != null) label.Text = s;
                    }

                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                {
                    DevExpress.XtraEditors.LookUpEdit cbo = fc as DevExpress.XtraEditors.LookUpEdit;
                    cbo.Properties.ValueMember = "ID";
                    cbo.Properties.DisplayMember = "AD";
                    cbo.Properties.ForceInitialize();
                    cbo.Properties.PopulateColumns();
                    for (int i = 0; i < cbo.Properties.Columns.Count; i++)
                    {
                        if (cbo.Properties.Columns[i].FieldName != "AD")
                            cbo.Properties.Columns[i].Visible = false;
                    }
                    //cbo.Properties.PopulateColumns();
                    cbo.EnterMoveNextControl = true;
                    cbo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                    //if (cbo.Properties.Columns.Count > 0)
                    //{
                    //    cbo.Properties.Columns["ID"].Visible = false;
                    //}
                    //if (cbo.Properties.Columns.Count ==3)
                    //{
                    //    cbo.Properties.Columns[2].Visible = false;
                    //}
                    cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                    cbo.Leave += new System.EventHandler(Control_Cikis); 
                    cbo.EditValue = null;
                    if (cntrl != null)
                    {
                        if (cntrl.Name == cbo.Name)
                        { cntrl.Focus(); }
                    }
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
                {
                    DevExpress.XtraEditors.GridLookUpEdit cbo = fc as DevExpress.XtraEditors.GridLookUpEdit;
                    cbo.Properties.ValueMember = "ID";
                    cbo.Properties.DisplayMember = "AD";
                    cbo.Properties.NullText = "";
                    //cbo.Properties.View.PopulateColumns();
                    cbo.Properties.ImmediatePopup = true;
                    cbo.Properties.TextEditStyle = TextEditStyles.Standard;
                    cbo.Properties.PopupFormSize = new Size(300, 500); cbo.EnterMoveNextControl = true;
                    cbo.Properties.PopupFilterMode = PopupFilterMode.Contains;
                    cbo.EnterMoveNextControl = true;

                    if (cbo.Properties.DataSource != null)
                    {
                        cbo.Properties.View.PopulateColumns(cbo.Properties.DataSource);
                        cbo.Properties.View.Columns[0].Visible = false;
                        if (cbo.Properties.View.Columns.Count > 2)
                        {
                            cbo.Properties.View.Columns[2].Visible = false;
                        }
                    }
                   
                    cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                    cbo.Leave += new System.EventHandler(Control_Cikis);
                    //cbo.Enter += new System.EventHandler(control_enter); 
                    cbo.EditValue = null;
                    if (cntrl != null)
                    {
                        if (cntrl.Name == cbo.Name)
                        { cntrl.Focus(); }
                    }
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                {
                    DevExpress.XtraEditors.TextEdit txt = fc as DevExpress.XtraEditors.TextEdit;
                    //if (txt.Tag.ToString().Substring(0,7)=="DECIMAL")
                    //{
                    //    int dec=Convert.ToInt32(txt.Tag.ToString().Substring(7,1));
                    //    int uzunluk=Convert.ToInt32(txt.Tag.ToString().Substring(8,1)=;
                    //}
                    //else
                    if (q != null)
                    {
                        foreach (var item in q)
                        {
                            name = item.ALAN_AD + "txt";
                            if (txt.Name == name)
                            {
                                switch (item.M_ALAN_TIP_ID)
                                {
                                    case 1://textboxlar için 
                                        txt.Properties.MaxLength = Convert.ToInt32(item.ALAN_UZUNLUK);
                                        break;
                                    case 5://tamsayılar için
                                        txt.Properties.Mask.EditMask = "\\d{0," + item.ALAN_UZUNLUK + "}";
                                        txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                                        break;
                                    case 3://tarih için
                                        break;
                                    case 4://decimal için
                                          String a = new String('#', Convert.ToInt32(item.ALAN_DECIMAL));
                                            String b = new String('#', Convert.ToInt32(item.ALAN_UZUNLUK));
                                            txt.Properties.Mask.EditMask = "F" + item.ALAN_DECIMAL;
                                            txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                                            txt.Properties.Mask.UseMaskAsDisplayFormat = true;
                                        break;
                                    default:
                                        break;
                                }
                                txt.EnterMoveNextControl = true;
                                break;
                            }
                            txt.EnterMoveNextControl = true;
                        }
                    }
                    txt.EnterMoveNextControl = true;
                    txt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                    txt.Leave += new System.EventHandler(Control_Cikis); 
                    txt.Text = "";
                    if (cntrl != null)
                    {
                        if (cntrl.Name == txt.Name)
                        { cntrl.Focus(); }
                    }
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
                {
                    DevExpress.XtraEditors.DateEdit dt = fc as DevExpress.XtraEditors.DateEdit;
                    dt.EnterMoveNextControl = true;
                    dt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                    dt.Leave += new System.EventHandler(Control_Cikis);
                    dt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
                    dt.EditValue = null;
                    if (cntrl != null)
                    {
                        if (cntrl.Name == dt.Name)
                        { cntrl.Focus(); }
                    }
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.TimeEdit))
                {
                    DevExpress.XtraEditors.TimeEdit dt = fc as DevExpress.XtraEditors.TimeEdit;
                    if (controlAyarlayaGirdi == false)
                    {
                        dt.EnterMoveNextControl = true;
                        dt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                        dt.Leave += new System.EventHandler(Control_Cikis);
                        dt.Leave += new System.EventHandler(Control_Cikis);

                    }
                    dt.EditValue = null;
                    if (cntrl != null)
                    {
                        if (cntrl.Name == dt.Name)
                        { cntrl.Focus(); }
                    }
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckEdit))
                {
                    DevExpress.XtraEditors.CheckEdit chk = fc as DevExpress.XtraEditors.CheckEdit;
                    if (Convert.ToString(chk.Tag) == "F" && kayit == true)
                    {  chk.Visible = false;}
                    chk.Leave += new System.EventHandler(Control_Cikis);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckedComboBoxEdit))
                {
                    DevExpress.XtraEditors.CheckedComboBoxEdit cbo = fc as DevExpress.XtraEditors.CheckedComboBoxEdit;
                    cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                    cbo.Properties.IncrementalSearch = true;
                    cbo.Properties.TextEditStyle = TextEditStyles.Standard;
                    //cbo.Properties.Po = PopupFilterMode.Contains;
                    //cbo.Properties
                    cbo.EnterMoveNextControl = true;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.ComboBoxEdit))
                {
                    DevExpress.XtraEditors.ComboBoxEdit cbo = fc as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.EnterMoveNextControl = true;
                }
            }
        }
        public void Control_Ayarla_Kayit(Control.ControlCollection Control, List<Alanlar> q, Control cntrl, Control cntrlKayit, bool kayit)
        {
            //if (controlAyarlayaGirdi == true) return;
           // if (kayit == true) Control.Add(navBar);
            string name = "";
            Controller = Control;
            if (DegerController == null) DegerController = Controller;
            foreach (Control fc in Control)
            {
                if (fc.GetType() == typeof(System.Windows.Forms.TabControl))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl, cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.TabPage))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl, cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GroupControl))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl, cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl, cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl, cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.PanelControl))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl, cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.UserControl))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl, cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.XtraUserControl))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl, cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LabelControl))
                {

                    DevExpress.XtraEditors.LabelControl label = fc as DevExpress.XtraEditors.LabelControl;
                    if (label.Tag != null && label.Tag.ToString() == "B") label.Text = "";
                    if (label.Name.Length > 3)
                    {
                        string labelName = label.Name.Substring(0, label.Name.Length - 3);
                        string s;
                        s = Globals.rman.GetString(labelName);
                    }
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Label))
                {
                    Label label = fc as Label;
                    if (label.Tag != null && label.Tag.ToString() == "B") label.Text = "";
                    if (label.Name.Length > 3)
                    {
                        string labelName = label.Name.Substring(0, label.Name.Length - 3);
                        string s;
                        s = Globals.rman.GetString(labelName);
                    }

                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                {
                    DevExpress.XtraEditors.LookUpEdit cbo = fc as DevExpress.XtraEditors.LookUpEdit;
                    if (controlAyarlayaGirdi == false)
                    {
                        cbo.Properties.ValueMember = "ID";
                        cbo.Properties.DisplayMember = "AD";
                        cbo.Properties.NullText = "Seçiniz";
                        cbo.Properties.PopulateColumns();
                        cbo.EnterMoveNextControl = true;
                        cbo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                        if (cbo.Properties.Columns.Count > 0)
                        {
                            cbo.Properties.Columns["ID"].Visible = false;
                        }
                        cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                        cbo.Leave += new System.EventHandler(Control_Cikis);
                        if (cntrlKayit != null)
                        {
                            if (cntrlKayit.Name == cbo.Name)
                            {
                                cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kaydet);
                            }
                        }
                    }
                    cbo.EditValue = null;
                    if (cntrl != null)
                    {
                        if (cntrl.Name == cbo.Name)
                        { cntrl.Focus(); }
                    }

                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
                {
                    DevExpress.XtraEditors.GridLookUpEdit cbo = fc as DevExpress.XtraEditors.GridLookUpEdit;
                    if (controlAyarlayaGirdi == false)
                    {
                        if (cbo.Tag == null || cbo.Tag.ToString() != "X")
                        {
                            cbo.Properties.ValueMember = "ID";
                            cbo.Properties.DisplayMember = "AD";
                            cbo.Properties.NullText = "Seçiniz";
                           // cbo.Properties.View.PopulateColumns();
                            cbo.Properties.ImmediatePopup = true;
                            cbo.Properties.TextEditStyle = TextEditStyles.Standard;
                            cbo.Properties.PopupFormSize = new Size(300, 500); cbo.EnterMoveNextControl = true;
                            cbo.Properties.PopupFilterMode = PopupFilterMode.Contains;
                            cbo.EnterMoveNextControl = true;
                            if (cbo.Properties.View.RowCount > 0)
                            {
                                cbo.Properties.View.Columns["AD"].Caption = "AD";
                                cbo.Properties.View.Columns["ID"].Visible = false;
                            }
                        }
                        cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                        cbo.Leave += new System.EventHandler(Control_Cikis);
                        cbo.Enter += new EventHandler(control_enter);
                        if (cntrlKayit != null)
                        {
                            if (cntrlKayit.Name == cbo.Name)
                            {
                                cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kaydet);
                            }
                        }
                    }
                    cbo.EditValue = null;
                    if (cntrl != null)
                    {
                        if (cntrl.Name == cbo.Name)
                        { cntrl.Focus(); }
                    }

                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                {
                    DevExpress.XtraEditors.TextEdit txt = fc as DevExpress.XtraEditors.TextEdit;
                    if (controlAyarlayaGirdi == false)
                    {
                        if (q != null)
                        {
                            foreach (var item in q)
                            {
                                name = item.ALAN_AD + "txt";
                                if (txt.Name == name)
                                {
                                    switch (item.M_ALAN_TIP_ID)
                                    {
                                        case 1://textboxlar için 
                                            txt.Properties.MaxLength = Convert.ToInt32(item.ALAN_UZUNLUK);
                                            break;
                                        case 5://tamsayılar için
                                            txt.Properties.Mask.EditMask = "\\d{0," + item.ALAN_UZUNLUK + "}";
                                            txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                                            break;
                                        case 3://tarih için
                                            break;
                                        case 4://decimal için
                                            String a = new String('#', Convert.ToInt32(item.ALAN_DECIMAL));
                                            String b = new String('#', Convert.ToInt32(item.ALAN_UZUNLUK));
                                            txt.Properties.Mask.EditMask = "F" + item.ALAN_DECIMAL;
                                            txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                                            txt.Properties.Mask.UseMaskAsDisplayFormat = true;
                                            break;
                                        default:
                                            break;
                                    }
                                    txt.EnterMoveNextControl = true;
                                    break;
                                }
                                txt.EnterMoveNextControl = true;
                            }
                        }
                        txt.EnterMoveNextControl = true;
                        txt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                        txt.Leave += new System.EventHandler(Control_Cikis);
                        txt.Enter += new EventHandler(control_enter);
                        if (cntrlKayit != null)
                        {
                            if (cntrlKayit.Name == txt.Name)
                            {
                                txt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kaydet);
                            }
                        }
                    }
                    txt.Text = "";
                    if (cntrl != null)
                    {
                        if (cntrl.Name == txt.Name)
                        { cntrl.Focus(); }
                    }

                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
                {
                    DevExpress.XtraEditors.DateEdit dt = fc as DevExpress.XtraEditors.DateEdit;
                    if (controlAyarlayaGirdi == false)
                    {
                        dt.EnterMoveNextControl = true;
                        dt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                        dt.Leave += new System.EventHandler(Control_Cikis);
                        dt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
                        if (cntrlKayit != null)
                        {
                            if (cntrlKayit.Name == dt.Name)
                            {
                                dt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kaydet);
                            }
                        }
                    }
                    dt.EditValue = null;
                    if (cntrl != null)
                    {
                        if (cntrl.Name == dt.Name)
                        { cntrl.Focus(); }
                    }
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.TimeEdit))
                {
                    DevExpress.XtraEditors.TimeEdit dt = fc as DevExpress.XtraEditors.TimeEdit;
                    if (controlAyarlayaGirdi == false)
                    {
                        dt.EnterMoveNextControl = true;
                        dt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                        dt.Leave += new System.EventHandler(Control_Cikis);
                        if (cntrlKayit != null)
                        {
                            if (cntrlKayit.Name == dt.Name)
                            {
                                dt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kaydet);
                            }
                        }
                    }
                    dt.EditValue = null;
                    if (cntrl != null)
                    {
                        if (cntrl.Name == dt.Name)
                        { cntrl.Focus(); }
                    }
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckEdit))
                {
                    DevExpress.XtraEditors.CheckEdit chk = fc as DevExpress.XtraEditors.CheckEdit;
                    if (Convert.ToString(chk.Tag) == "F" && kayit == true)
                        chk.Visible = false;
                }
               
            }
            controlAyarlayaGirdi = true;
        }
        public void Clear(Control.ControlCollection Control)
        {
            foreach (Control fc in Control)
            {
                if (fc.GetType() == typeof(System.Windows.Forms.TabControl))
                {
                    Clear(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.TabPage))
                {
                    Clear(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GroupControl))
                {
                    Clear(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    Clear(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    Clear(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.PanelControl))
                {
                    Clear(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.UserControl))
                {
                    Clear(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.XtraUserControl))
                {
                    Clear(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                {
                    DevExpress.XtraEditors.LookUpEdit cbo = fc as DevExpress.XtraEditors.LookUpEdit;
                    cbo.EditValue = null;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
                {
                    DevExpress.XtraEditors.GridLookUpEdit cbo = fc as DevExpress.XtraEditors.GridLookUpEdit;
                    cbo.EditValue = null;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                {
                    DevExpress.XtraEditors.TextEdit txt = fc as DevExpress.XtraEditors.TextEdit;
                    txt.Text = null;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
                {
                    DevExpress.XtraEditors.DateEdit dt = fc as DevExpress.XtraEditors.DateEdit;
                    dt.EditValue = null;
                }
            }
        }
        public void Goster()
        {
            if (threadSizMi == true)
            {
                Tamam();
            }
            else
            {
                maximum = 300;
                timer1.Enabled = true;
                progressBar1.Value = 0;
                progressBar1.Maximum = maximum;
                progressBar1.Step = 1;
                timer1.Enabled = true;
                Thread t = new Thread(Tamam);
                t.Start();
                Thread.Sleep(1);
            }
        }
        public virtual void Tamam() { }
        public virtual void Kaydet() { }
        public virtual void Doldur() { }
        public virtual bool IslemKontrol(Control cntrl) { return true; }
        public virtual void KontrolUstDegerKopyala()
        {
            if (theActiveControl == null) return;
            if (theActiveControl.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
            {
                DevExpress.XtraEditors.TextEdit txt = theActiveControl as DevExpress.XtraEditors.TextEdit;
                foreach (Control cntrl in DegerController)
                {
                    if (cntrl.TabIndex == theActiveControl.TabIndex - 1)
                    {
                        if (theActiveControl.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                        {
                            DevExpress.XtraEditors.TextEdit txt1 = cntrl as DevExpress.XtraEditors.TextEdit;
                            if (txt1 != null) txt.Text = txt1.Text;
                        }

                    }
                }
            }
            else if (theActiveControl.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
            {
                DevExpress.XtraEditors.LookUpEdit txt = theActiveControl as DevExpress.XtraEditors.LookUpEdit;
                foreach (Control cntrl in DegerController)
                {
                    if (cntrl.TabIndex == theActiveControl.TabIndex - 1)
                    {
                        if (theActiveControl.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                        {
                            DevExpress.XtraEditors.LookUpEdit txt1 = cntrl as DevExpress.XtraEditors.LookUpEdit;
                            if(txt1!=null) txt.EditValue = txt1.EditValue;
                        }

                    }
                }
            }
            else if (theActiveControl.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
            {
                DevExpress.XtraEditors.GridLookUpEdit txt = theActiveControl as DevExpress.XtraEditors.GridLookUpEdit;
                foreach (Control cntrl in DegerController)
                {
                    if (cntrl.TabIndex == theActiveControl.TabIndex - 1)
                    {
                        if (theActiveControl.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
                        {
                            DevExpress.XtraEditors.GridLookUpEdit txt1 = cntrl as DevExpress.XtraEditors.GridLookUpEdit;
                            if (txt1 != null) txt.EditValue = txt1.EditValue;
                        }

                    }
                }
            }
            else if (theActiveControl.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
            {
                DevExpress.XtraEditors.DateEdit txt = theActiveControl as DevExpress.XtraEditors.DateEdit;
                foreach (Control cntrl in DegerController)
                {
                    if (cntrl.TabIndex == theActiveControl.TabIndex - 1)
                    {
                        if (theActiveControl.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
                        {
                            DevExpress.XtraEditors.DateEdit txt1 = cntrl as DevExpress.XtraEditors.DateEdit;
                            if (txt1 != null) txt.EditValue = txt1.EditValue;
                        }

                    }
                }
            }
        }
        public void control_enter(object sender, EventArgs e)
        {
            //thePreviousControl = theActiveControl;
            //theActiveControl = sender as Control;
            //MessageBox.Show("Active Control is now : " + theActiveControl.Name);
        }
        public virtual void Kayit_KeyDown(object sender, KeyEventArgs e)
        {
            theActiveControl = sender as Control;
            //MessageBox.Show(theActiveControl.Name);
            if (e.KeyCode == Keys.F10)
            {
                Kaydet();
            }
            else if (e.KeyCode == Keys.F9)
            {
                KontrolUstDegerKopyala();
            }
            else if (e.KeyCode == Keys.Escape && escapeKapatma==false)
            {
                if (this.Parent != null && this.Parent.TopLevelControl.Name != "MDIParent")
                {
                    this.Parent.Dispose();
                }
                else
                {
                    if (this.ControlBox == true)
                    {
                        this.Dispose();
                        this.Close();
                    }
                }
            }
        }
        public virtual void KontrolleriTemizle()
        {
        
        }
        public virtual void Control_Cikis(object sender, EventArgs e)
        {
            //thePreviousControl = theActiveControl;
            //theActiveControl = sender as Control;
            //MessageBox.Show(theActiveControl.Name);
        }
        public void Kaydet(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode== Keys.Tab)
            {
                if (formTipIslemMi == true)
                {
                    TAMAM_1cmd.Focus();
                }
                Kaydet();
            }
        }
        public void navBar_Yonet(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ImageIndex == 9)
            {
                EventArgs e1 = new EventArgs();
                Control_Cikis(theActiveControl, e1);
                Kaydet();
            }
            else if (e.Button.ImageIndex == 10)
            {
                Doldur();
            }
        }
        public void IslemiBitir()
        {
            sorguBitti = true;
            butonlariIsle(true);
            timer1.Enabled = false;
            if (islemdenSonraKapat == true)
            {
                if (this.ControlBox == true)
                {
                    this.Dispose();
                    this.Close();
                }
                
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            if (sorguBitti == true)
            {
                progressBar1.Value = 0;
                butonlariIsle(true);
                timer1.Enabled = false;
                KontrolleriTemizle();
                if (islemdenSonraKapat == true && this.ControlBox==true)
                {
                    this.Dispose();
                    this.Close();
                }
                return;
            }
            else if (progressBar1.Value == maximum)
            {
                progressBar1.Value = 0;
            }
           
        }
        public virtual void butonlariIsle(bool deger)
        {
            TAMAM_1cmd.Enabled = deger;
            IPTAL_1btn.Enabled = deger;
            this.ControlBox = deger;
        }
    }
}
