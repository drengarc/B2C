using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Prodma.DataAccessB2C;
namespace Prodma.WinForms
{
    public partial class 
        usrControlSablon : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// Tum usercontroller bu sınıftan turetildi
        /// </summary>
        /// 
        string editingValueTemp = "";
        string editingValue = "";
        public string degisenGridlookupEditDegeri = "";
        public bool ilkKayit = false;
        public int listeBicimTip = 0;
        public List<Control> controlList = new List<Control>(); // numeric sinirlamalar
        public bool modelSetEdildiMi = false;
        public bool dinamikUpdate=false;
        public int varsayilanStokId = 0;//liste user controllerinde varsayilan degerleri set etmek icin konulduç
        public int varsayilanCariId = 0;
        public int varsayilanAlisSatisId = 0;
        public bool escapeKapatma = false;
        public List<Alanlar> alanlarVm = new List<Alanlar>();
        bool controlAyarlayaGirdi = false;
        public int girdi = 0;
        public Dictionary<string, string> filterParameters = new Dictionary<string, string>();
        public Dictionary<string, string> parametersUsr = new Dictionary<string, string>();
        public event EventHandler enter = delegate { };
        public static Control theActiveControl = null;
        public static Control thePreviousControl = null;
        public navBar navBar = new navBar();
        public bool kayitIcin=true;
        Control.ControlCollection Controller;
        public BindingSource bnSablon;
        public BindingSource bnSablon2;
        public usrControlSablon()
        {
            
            InitializeComponent();
            navBar.Dock = DockStyle.Bottom;
           // navBar.TabIndex = 26;
            this.navBar.controlNavigator1.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(navBar_Yonet);
            navBarDuzenle();
            //if (listeBicimTip == (int)UserControlTipEn.Liste)
            //{
            //    escapeKapatma = true;
            //}
            escapeKapatma = true;
             
        }
        public virtual void navBarDuzenle()
        {
            navBar.navBarCustomButTonSil();
        }
        //public void Control_Ayarla_Kayit(Control.ControlCollection Control, List<Alanlar> q,Control cntrl,bool kayit)
        //{
        //    girdi += 1;
        //    if (controlAyarlayaGirdi == true) return;
        //   // Control.SetEnterEvent(enter);
        //    if (kayit == true ) Control.Add(navBar);
        //    string name = "";
        //    foreach (Control fc in Control)
        //    {
        //        girdi += 1;
        //        if (fc.GetType() == typeof(System.Windows.Forms.TabControl))
        //        {
        //            Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
        //        }
        //        else if (fc.GetType() == typeof(System.Windows.Forms.TabPage))
        //        {
        //            Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
        //        }
        //        else if (fc.GetType() == typeof(DevExpress.XtraEditors.GroupControl))
        //        {
        //            Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
        //        }
        //        else if (fc.GetType() == typeof(System.Windows.Forms.GroupBox))
        //        {
        //            Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
        //        }
        //        else if (fc.GetType() == typeof(System.Windows.Forms.Panel))
        //        {
        //            Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
        //        }
        //        else if (fc.GetType() == typeof(DevExpress.XtraEditors.PanelControl))
        //        {
        //            Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
        //        }
        //        else if (fc.GetType() == typeof(System.Windows.Forms.UserControl))
        //        {
        //            Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
        //        }
        //        else if (fc.GetType() == typeof(DevExpress.XtraEditors.XtraUserControl))
        //        {
        //            Control_Ayarla_Kayit(fc.Controls,q,cntrl,kayit);
        //        }
        //        else if (fc.GetType() == typeof(DevExpress.XtraEditors.LabelControl))
        //        {

        //            DevExpress.XtraEditors.LabelControl label = fc as DevExpress.XtraEditors.LabelControl;
        //            if (label.Tag!=null && label.Tag.ToString() == "B") label.Text = "";
        //            if (label.Name.Length > 3)
        //            {
        //                string labelName = label.Name.Substring(0, label.Name.Length - 3);
        //                string s;
        //                s = Globals.rman.GetString(labelName);
        //            }
        //        }
        //        else if (fc.GetType() == typeof(System.Windows.Forms.Label))
        //        {
        //            Label label = fc as Label;
        //            if (label.Tag != null && label.Tag.ToString() == "B") label.Text = "";
        //            if (label.Name.Length > 3)
        //            {
        //                string labelName = label.Name.Substring(0, label.Name.Length - 3);
        //                string s;
        //                s = Globals.rman.GetString(labelName);
        //            }

        //        }
        //        else if (fc.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
        //        {
        //            DevExpress.XtraEditors.LookUpEdit cbo = fc as DevExpress.XtraEditors.LookUpEdit;
        //            if (cbo.Tag == null)
        //            {
        //                cbo.Properties.ValueMember = "ID";
        //                cbo.Properties.DisplayMember = "AD";
        //                cbo.Properties.NullText = "Seçiniz";
        //                cbo.Properties.PopulateColumns();
        //                cbo.EnterMoveNextControl = true;
        //                cbo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
        //                if (cbo.Properties.Columns.Count > 0)
        //                {
        //                    cbo.Properties.Columns["ID"].Visible = false;
        //                }
        //            }
        //            cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
        //            cbo.Leave += new System.EventHandler(Control_Cikis);
        //            cbo.EditValue = null;
        //            if (cntrl != null)
        //            {
        //                if (cntrl.Name == cbo.Name)
        //                {
        //                    cntrl.Focus();
        //                }
                       
        //            }
        //            if (cbo.Tag != null && cbo.Tag.ToString().Substring(0, cbo.Tag.ToString().Length) == "S")
        //            {
        //                cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kaydet);
        //            }
        //        }
        //        else if (fc.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
        //        {
        //            DevExpress.XtraEditors.GridLookUpEdit cbo = fc as DevExpress.XtraEditors.GridLookUpEdit;
        //            if (cbo.Tag == null ||  cbo.Tag.ToString() != "X")
        //            {
        //                cbo.Properties.ValueMember = "ID";
        //                cbo.Properties.DisplayMember = "AD";
        //                cbo.Properties.NullText = "Seçiniz";
        //                cbo.Properties.View.PopulateColumns();
        //                cbo.EnterMoveNextControl = true;
        //                if (cbo.Properties.View.RowCount > 0)
        //                {
        //                    cbo.Properties.View.Columns["AD"].Caption = "AD";
        //                    cbo.Properties.View.Columns["ID"].Visible = false;
        //                }
        //            }
        //            cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
        //            cbo.Leave += new System.EventHandler(Control_Cikis);
        //            cbo.Enter += new EventHandler(control_enter);
        //            cbo.EditValue = null;
        //            if (cntrl != null)
        //            {
        //                if (cntrl.Name == cbo.Name)
        //                {
        //                    cntrl.Focus();
        //                }
                     
        //            }
        //            if (cbo.Tag != null && cbo.Tag.ToString().Substring(0, cbo.Tag.ToString().Length - 1) == "S")
        //            {
        //                cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kaydet);
        //            }
        //        }
        //        else if (fc.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
        //        {
        //            //DevExpress.XtraEditors.TextEdit txt = fc as DevExpress.XtraEditors.TextEdit;
        //            //if (q != null)
        //            //{
        //            //    foreach (var item in q)
        //            //    {
        //            //        name = item.ALAN_AD + "txt";
        //            //        if (txt.Name == name)
        //            //        {
        //            //            switch (item.M_ALAN_TIP_ID)
        //            //            {
        //            //                case 1://textboxlar için 
        //            //                    txt.Properties.MaxLength = Convert.ToInt32(item.ALAN_UZUNLUK);
        //            //                    break;
        //            //                case 5://tamsayılar için
        //            //                    txt.Properties.Mask.EditMask = "\\d{0," + item.ALAN_UZUNLUK + "}";
        //            //                    txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
        //            //                    break;
        //            //                case 3://tarih için
        //            //                    break;
        //            //                case 4://decimal için
        //            //                    String a = new String('#', Convert.ToInt32(item.ALAN_DECIMAL));
        //            //                    String b = new String('#', Convert.ToInt32(item.ALAN_UZUNLUK));
        //            //                    txt.Properties.Mask.EditMask = b + "0." + a;
        //            //                    txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
        //            //                    break;
        //            //                default:
        //            //                    break;
        //            //            }
        //            //            txt.EnterMoveNextControl = true;
        //            //            break;
        //            //        }
        //            //        txt.EnterMoveNextControl = true;
        //            //    }
        //            //}
        //            //txt.EnterMoveNextControl = true;
        //            //txt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
        //            //txt.Text = "";
        //            //if (cntrl != null)
        //            //{
        //            //    if (cntrl.Name == txt.Name)
        //            //    {
        //            //        cntrl.Focus();
        //            //    }
                     
        //            //}
        //            //if (txt.Tag != null && txt.Tag.ToString().Substring(0, txt.Tag.ToString().Length - 1) == "S")
        //            //{
        //            //    txt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kaydet);
        //            //}
        //        }
        //        else if (fc.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
        //        {
        //            DevExpress.XtraEditors.DateEdit dt = fc as DevExpress.XtraEditors.DateEdit;
        //            dt.EnterMoveNextControl = true;
        //            dt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
        //            dt.Leave += new System.EventHandler(Control_Cikis);
        //            dt.EditValue = null;
        //            if (dt != null)
        //            {
        //                if (dt.Name == dt.Name)
        //                {
        //                    dt.Focus();
        //                }
        //            }
        //            if (dt.Tag!=null && dt.Tag.ToString().Substring(0, dt.Tag.ToString().Length) == "S")
        //            {
        //                dt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kaydet);
        //            }
        //        }
        //        else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckEdit))
        //        {
        //            DevExpress.XtraEditors.CheckEdit chk = fc as DevExpress.XtraEditors.CheckEdit;
        //            if (chk.Tag == "F" && kayit == true)
        //                chk.Visible = false;
        //        }
        //        else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckedComboBoxEdit))
        //        {
        //            DevExpress.XtraEditors.CheckedComboBoxEdit cbo = fc as DevExpress.XtraEditors.CheckedComboBoxEdit;
        //            cbo.EnterMoveNextControl = true;
        //        }
        //    }
        //    //controlAyarlayaGirdi = true;
        //}
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
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LabelControl))
                {
                    DevExpress.XtraEditors.LabelControl dt = fc as DevExpress.XtraEditors.LabelControl;
                    if (dt.Tag !=null && dt.Tag.ToString() == "B")
                       dt.Text = "";
                }
            }
        }
        public virtual void Kaydet() { }
        public virtual void Doldur() { }
        public virtual void Doldur(bool kayitIcin) { }
        public virtual void ControlleriDuzenle() { } // Doldur fonksiyonu calismayan userkontrollerin controllerini duzenliyor
        public virtual void Yazdir() { }
        public virtual void KontrolleriDoldur()
        {
        }
        public virtual void VarSayilanKontrolDegerleriniAyarla()
        {
        }
        public virtual bool IslemKontrol() { return true; }
        public virtual void KontrolUstDegerKopyala() 
        {
            if (theActiveControl == null) return;
          if (theActiveControl.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
          {
             DevExpress.XtraEditors.TextEdit txt = theActiveControl as DevExpress.XtraEditors.TextEdit;
             foreach (Control cntrl in Controller)
             {
                if (cntrl.TabIndex==theActiveControl.TabIndex-1)
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
              foreach (Control cntrl in Controller)
              {
                  if (cntrl.TabIndex == theActiveControl.TabIndex - 1)
                  {
                      if (theActiveControl.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                      {
                          DevExpress.XtraEditors.LookUpEdit txt1 = cntrl as DevExpress.XtraEditors.LookUpEdit;
                          if (txt1 != null) txt.EditValue = txt1.EditValue;
                      }

                  }
              }
          }
          else if (theActiveControl.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
          {
              DevExpress.XtraEditors.GridLookUpEdit txt = theActiveControl as DevExpress.XtraEditors.GridLookUpEdit;
              foreach (Control cntrl in Controller)
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
              foreach (Control cntrl in Controller)
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
            thePreviousControl = theActiveControl;
            theActiveControl = sender as Control;
            //MessageBox.Show("Active Control is now : " + theActiveControl.Name);
        }
        public virtual void Kayit_KeyDown(object sender, KeyEventArgs e)
        {
            theActiveControl = sender as Control;
            if (e.KeyCode == Keys.F10)
            {
                if (kayitIcin == true && IslemKontrol() == true) Kaydet();
            }
            else if (e.KeyCode == Keys.F9)
            {
                KontrolUstDegerKopyala();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (escapeKapatma == false)
                {
                    this.Parent.Dispose();
                }
                editingValue = editingValueTemp;
                editingValueTemp = "";
            }
            if (e.KeyCode == Keys.F6)
            {
                DevExpress.XtraEditors.GridLookUpEdit cbo = sender as DevExpress.XtraEditors.GridLookUpEdit;
                if (cbo!=null)
                {
                    if (cbo.Properties.TextEditStyle == TextEditStyles.Standard)
                    {
                        cbo.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
                        //cbo.Properties.PopupFilterMode = PopupFilterMode.Contains;
                    }
                    else
                    {
                        cbo.Properties.TextEditStyle = TextEditStyles.Standard;
                        cbo.Properties.PopupFilterMode = PopupFilterMode.Contains;
                    }
                    cbo.Focus();
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                UserKontrolIslemYap();
            }
        }
        public virtual void UserKontrolIslemYap()
        {

        }
        public virtual void Control_Cikis(object sender, EventArgs e)
        {
            thePreviousControl = theActiveControl;
            theActiveControl = sender as Control;
            if (theActiveControl!=null && theActiveControl.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
            {
                GridLookUpEdit gle = (GridLookUpEdit)sender;
                if (gle != null)
                    editingValue = gle.Text;
            }
            //editingValueTemp = "";
        }
        public void Kaydet(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (kayitIcin == true && IslemKontrol()==true) Kaydet();
            }
        }
        public  void navBar_Yonet(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ImageIndex == 9)
            {
                EventArgs e1 = new EventArgs();
                Control_Cikis(theActiveControl, e1);
                if (kayitIcin == true && IslemKontrol() == true) Kaydet();
            }
            else if (e.Button.ImageIndex == 10)
            {
                Doldur();
            }
            else if (e.Button.ImageIndex == 11)
            {
                Yazdir();
            }
        }
        private void usrControlSablon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                ParentForm.Dispose();
        }
        public void Control_Ayarla_Kayit(Control.ControlCollection Control, List<Alanlar> q, Control cntrl, Control cntrlKayit, bool kayit)
        {
            Controller = Control;
            //if (controlAyarlayaGirdi == true) return;
            
            kayitIcin = kayit;
            if (Control.Owner.Text=="")
            {
                if (kayit == true)
                {
                    Control.Add(navBar);
                }
                else
                {
                    Control.Remove(navBar);
                }
            }

          

            string name = "";
            foreach (Control fc in Control)
            {
                if (listeBicimTip==(int)UserControlTipEn.Kayit)
                {
                  //  if (kayit == false) fc.Enabled = false;
                }

                if (fc.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                {
                  

                }
                if (fc.GetType() == typeof(System.Windows.Forms.TabControl))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl,cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.TabPage))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl,cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GroupControl))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl,cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                     controlAyarlayaGirdi = false;
                     Control_Ayarla_Kayit(fc.Controls, q, cntrl,cntrlKayit, kayit);
                     controlAyarlayaGirdi = false;
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl,cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.PanelControl))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl,cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.UserControl))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl,cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.XtraUserControl))
                {
                    Control_Ayarla_Kayit(fc.Controls, q, cntrl,cntrlKayit, kayit);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LabelControl))
                {

                    DevExpress.XtraEditors.LabelControl label = fc as DevExpress.XtraEditors.LabelControl;
                    if (label.Tag != null && label.Tag.ToString() == "B")
                    {
                        label.Text = ""; return;
                    }
                    else if (label.Name.Length > 3)
                    {
                        string labelName = label.Name.Substring(0, label.Name.Length - 3);
                        string s;
                        s = Globals.rman.GetString(labelName);
                        if (s == null)
                        {
                            label.Text = label.Text.Trim()!=":" ? label.Text + "":label.Text.Trim();
                        }
                        else
                        {
                            if (Convert.ToString(s)!="") label.Text = Convert.ToString(s);
                        }
                    }
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Label))
                {
                    Label label = fc as Label;
                    if (label.Tag != null && label.Tag.ToString() == "B")
                    {
                        label.Text = "";
                    }
                    else if (label.Name.Length > 3)
                    {
                        string labelName = label.Name.Substring(0, label.Name.Length - 3);
                        string s;
                        s = Globals.rman.GetString(labelName);
                        if (s == null)
                        {
                            label.Text = label.Text.Trim() != ":" ? label.Text + "" : label.Text.Trim();
                        }
                        else
                        {
                            label.Text = Convert.ToString(s);
                        }
                    }

                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                {
                    DevExpress.XtraEditors.LookUpEdit cbo = fc as DevExpress.XtraEditors.LookUpEdit;
                    if (controlAyarlayaGirdi == false)
                    {
                        Alanlar item = new Alanlar();
                        string name1 = fc.Name.Substring(0, fc.Name.Length - 3);
                        if (q != null)
                        {
                            item = q.Find(f => f.ALAN_AD == name1);
                        }
                        if (item != null)
                        {
                            if (item.GORMESIN_E_H != null && Convert.ToInt32(item.GORMESIN_E_H) == (int)EvetHayirEn.Evet)
                            {
                                cbo.Visible = false;
                            }
                            if (item.YAZMASIN_E_H != null && Convert.ToInt32(item.YAZMASIN_E_H) == (int)EvetHayirEn.Evet)
                            {
                                cbo.Enabled = false;
                            }
                        }
                        if (cbo.Tag == null || cbo.Tag.ToString() != "X")
                        {
                            cbo.Properties.ValueMember = "ID";
                            cbo.Properties.DisplayMember = "AD";
                            cbo.Properties.NullText = "";
                            cbo.Properties.ForceInitialize();
                            cbo.Properties.PopulateColumns();
                            cbo.EnterMoveNextControl = true;
                            cbo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                            //cbo.Properties.View.PopulateColumns(cbo.Properties.DataSource);
                            if (cbo.Properties.Columns.Count > 0)
                            {
                                for (int i = 0; i < cbo.Properties.Columns.Count; i++)
                                {
                                    if (cbo.Properties.Columns[i].FieldName != "AD")
                                        cbo.Properties.Columns[i].Visible = false;
                                }
                            }
                        }
                        cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                        cbo.MouseWheel += new MouseEventHandler(lookUpEdit1_MouseWheel);
                        cbo.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                        cbo.Leave += new System.EventHandler(Control_Cikis);
                        if (cntrlKayit != null)
                        {
                            if (cntrlKayit.Name == cbo.Name && kayit == true)
                            {
                                cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kaydet);
                            }
                        }
                    }
                    cbo.EditValue = null;
                    if (cntrl != null)
                    {
                        if (cntrl.Name == cbo.Name && listeBicimTip!=(int)UserControlTipEn.Liste)
                        { cntrl.Focus(); }
                    }
                
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
                {
                    DevExpress.XtraEditors.GridLookUpEdit cbo = fc as DevExpress.XtraEditors.GridLookUpEdit;
                    if (controlAyarlayaGirdi == false)
                    {
                        Alanlar item = new Alanlar();
                        string name1 = fc.Name.Substring(0, fc.Name.Length - 3);
                        if (q != null)
                        {
                            item = q.Find(f => f.ALAN_AD == name1);
                        }
                        if (item != null)
                        {
                            if (item.GORMESIN_E_H != null && Convert.ToInt32(item.GORMESIN_E_H) == (int)EvetHayirEn.Evet)
                            {
                                cbo.Visible = false;
                            }
                            if (item.YAZMASIN_E_H != null && Convert.ToInt32(item.YAZMASIN_E_H) == (int)EvetHayirEn.Evet)
                            {
                                cbo.Enabled = false;
                            }
                        }
                        if (cbo.Tag == null || cbo.Tag.ToString() != "X")
                        {
                            cbo.Properties.ValueMember = "ID";
                            cbo.Properties.DisplayMember = "AD";
                            cbo.Properties.NullText = "";
                            //cbo.Properties.View.PopulateColumns();
                            cbo.Properties.ImmediatePopup = true;
                            //cbo.Properties.TextEditStyle = TextEditStyles.Standard;
                            cbo.Properties.PopupFormSize = new Size(300, 500); cbo.EnterMoveNextControl = true;
                            cbo.Properties.PopupFilterMode = PopupFilterMode.Contains;
                            cbo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                            cbo.Properties.View.PopulateColumns(cbo.Properties.DataSource);
                            //if (cbo.Properties.View.RowCount > 0)
                            //{
                                //cbo.Properties.View.Columns["AD"].Caption = "AD";
                                cbo.Properties.View.Columns["ID"].Visible = false;
                                if (cbo.Properties.View.Columns.Count>2)
                                {
                                    cbo.Properties.View.Columns["KOD"].Visible = false;                                    
                                }
                            //}
                        }
                        cbo.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                        cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                        cbo.Leave += new System.EventHandler(Control_Cikis);
                        cbo.Enter += new EventHandler(control_enter);
                        cbo.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.Gle_ProcessNewValue);
                        cbo.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.Gle_CustomDisplayText);
                        cbo.Validating += new System.ComponentModel.CancelEventHandler(this.Gle_Validating);

                        if (cntrlKayit != null)
                        {
                            if (cntrlKayit.Name == cbo.Name && kayit == true) 
                            {
                                cbo.KeyDown += new System.Windows.Forms.KeyEventHandler(Kaydet);
                            }
                        }
                    }
                    cbo.EditValue = null;
                    if (cntrl != null)
                    {
                        if (cntrl.Name == cbo.Name && listeBicimTip != (int)UserControlTipEn.Liste)
                        { cntrl.Focus(); }
                    }
                   
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                {
                    DevExpress.XtraEditors.TextEdit txt = fc as DevExpress.XtraEditors.TextEdit;
                    if (controlAyarlayaGirdi == false)
                    {
                       Alanlar item = new Alanlar();
                       string name1 = fc.Name.Substring(0, fc.Name.Length - 3);
                       if (q != null)
                       {
                            item = q.Find(f => f.ALAN_AD == name1);
                       }
                       if (item != null)
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
                                            txt.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                                            break;
                                        default:
                                            break;
                                    }
                                    if (item.GORMESIN_E_H!=null && Convert.ToInt32(item.GORMESIN_E_H) == (int)EvetHayirEn.Evet)
                                    {
                                        txt.Visible = false;
                                    }
                                    if (item.YAZMASIN_E_H != null && Convert.ToInt32(item.YAZMASIN_E_H) == (int)EvetHayirEn.Evet)
                                    {
                                        txt.Enabled = false;
                                    }
                                    txt.EnterMoveNextControl = true;
                                    //break;
                                }
                                txt.EnterMoveNextControl = true;
                        }
                        txt.EnterMoveNextControl = true;
                        txt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                        txt.Leave += new System.EventHandler(Control_Cikis);
                        txt.Enter += new EventHandler(control_enter);
                        if (cntrlKayit != null)
                        {
                            if (cntrlKayit.Name == txt.Name && kayit == true)
                            {
                                txt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kaydet);
                            }
                        }
                    }
                    txt.Text = "";
                    if (cntrl != null)
                    {
                        if (cntrl.Name == txt.Name && listeBicimTip != (int)UserControlTipEn.Liste)
                        { cntrl.Focus(); }
                    }
                  
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
                {
                    DevExpress.XtraEditors.DateEdit dt = fc as DevExpress.XtraEditors.DateEdit;
                    if (controlAyarlayaGirdi == false)
                    {
                        Alanlar item = new Alanlar();
                        string name1 = fc.Name.Substring(0, fc.Name.Length - 3);
                        if (q != null)
                        {
                            item = q.Find(f => f.ALAN_AD == name1);
                        }
                        if (item != null)
                        {
                            if (item.GORMESIN_E_H != null && Convert.ToInt32(item.GORMESIN_E_H) == (int)EvetHayirEn.Evet)
                            {
                                dt.Visible = false;
                            }
                            if (item.YAZMASIN_E_H != null && Convert.ToInt32(item.YAZMASIN_E_H) == (int)EvetHayirEn.Evet)
                            {
                                dt.Enabled = false;
                            }
                        }
                        dt.EnterMoveNextControl = true;
                        dt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                        dt.Leave += new System.EventHandler(Control_Cikis);
                        dt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
                        if (cntrlKayit != null)
                        {
                            if (cntrlKayit.Name == dt.Name && kayit == true)
                            {
                                dt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kaydet);
                            }
                        }
                    }
                    dt.EditValue = null;
                    if (cntrl != null)
                    {
                        if (cntrl.Name == dt.Name && listeBicimTip != (int)UserControlTipEn.Liste)
                        { cntrl.Focus(); }
                    }
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.TimeEdit))
                {
                    DevExpress.XtraEditors.TimeEdit dt = fc as DevExpress.XtraEditors.TimeEdit;
                    if (controlAyarlayaGirdi == false)
                    {
                        Alanlar item = new Alanlar();
                        string name1 = fc.Name.Substring(0, fc.Name.Length - 3);
                        if (q != null)
                        {
                            item = q.Find(f => f.ALAN_AD == name1);
                        }
                        if (item != null)
                        {
                            if (item.GORMESIN_E_H != null && Convert.ToInt32(item.GORMESIN_E_H) == (int)EvetHayirEn.Evet)
                            {
                                dt.Visible = false;
                            }
                            if (item.YAZMASIN_E_H != null && Convert.ToInt32(item.YAZMASIN_E_H) == (int)EvetHayirEn.Evet)
                            {
                                dt.Enabled = false;
                            }
                        }
                        dt.EnterMoveNextControl = true;
                        dt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kayit_KeyDown);
                        dt.Leave += new System.EventHandler(Control_Cikis);
                        if (cntrlKayit != null)
                        {
                            if (cntrlKayit.Name == dt.Name && kayit == true)
                            {
                                dt.KeyDown += new System.Windows.Forms.KeyEventHandler(Kaydet);
                            }
                        }
                    }
                    dt.EditValue = null;
                    if (cntrl != null)
                    {
                        if (cntrl.Name == dt.Name && listeBicimTip != (int)UserControlTipEn.Liste)
                        { cntrl.Focus(); }
                    }
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckEdit))
                {
                    DevExpress.XtraEditors.CheckEdit chk = fc as DevExpress.XtraEditors.CheckEdit;
                    if (Convert.ToString(chk.Tag) == "F" && dinamikUpdate == false)
                        chk.Visible = false;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckedComboBoxEdit))
                {
                    DevExpress.XtraEditors.CheckedComboBoxEdit cbo = fc as DevExpress.XtraEditors.CheckedComboBoxEdit;
                    cbo.Properties.IncrementalSearch = true;
                    cbo.EnterMoveNextControl = true;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.ComboBoxEdit))
                {
                    DevExpress.XtraEditors.ComboBoxEdit cbo = fc as DevExpress.XtraEditors.ComboBoxEdit;
                    cbo.EnterMoveNextControl = true;
                }
            }
            controlAyarlayaGirdi = true;
        }
        public void SetControl(Control.ControlCollection Control, Dictionary<string, string> values)
        {
            foreach (Control fc in Control)
            {
                if (fc.GetType() == typeof(System.Windows.Forms.TabControl))
                {
                    SetControl(fc.Controls, values);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.TabPage))
                {
                    SetControl(fc.Controls, values);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GroupControl))
                {
                    SetControl(fc.Controls, values);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    SetControl(fc.Controls, values);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    SetControl(fc.Controls, values);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.PanelControl))
                {
                    SetControl(fc.Controls, values);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.UserControl))
                {
                    SetControl(fc.Controls, values);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.XtraUserControl))
                {
                    SetControl(fc.Controls, values);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckedComboBoxEdit))
                {
                    DevExpress.XtraEditors.CheckedComboBoxEdit chl = fc as DevExpress.XtraEditors.CheckedComboBoxEdit;
                    if (values.ContainsKey(chl.Name) && (chl.Tag == null || chl.Tag.ToString() != "N"))
                    { chl.SetEditValue(values[chl.Name]); }
                    else if (chl.Tag != null && chl.Tag != "N")
                    { 
                        chl.EditValue = null;
                        chl.RefreshEditValue();
                    }
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                {
                    DevExpress.XtraEditors.LookUpEdit cbo = fc as DevExpress.XtraEditors.LookUpEdit;
                    if (values.ContainsKey(cbo.Name) && (cbo.Tag == null || cbo.Tag.ToString() != "N"))
                        cbo.EditValue = Convert.ToInt32(values[cbo.Name]);
                    else if (cbo.Tag != null && cbo.Tag.ToString() != "N")
                        cbo.EditValue = null;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
                {
                    DevExpress.XtraEditors.GridLookUpEdit cbo = fc as DevExpress.XtraEditors.GridLookUpEdit;
                    if (values.ContainsKey(cbo.Name) && (cbo.Tag  == null || cbo.Tag.ToString() != "N"))
                        cbo.EditValue = values[cbo.Name];
                    else if (cbo.Tag != null && cbo.Tag.ToString() != "N")
                        cbo.EditValue = null;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                {
                    DevExpress.XtraEditors.TextEdit txt = fc as DevExpress.XtraEditors.TextEdit;
                    if (values.ContainsKey(txt.Name) && (txt.Tag == null || txt.Tag.ToString() != "N"))
                        txt.Text = values[txt.Name];
                    else if (txt.Tag != null && txt.Tag != "N")
                        txt.Text = null;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
                {
                    DevExpress.XtraEditors.DateEdit dt = fc as DevExpress.XtraEditors.DateEdit;
                    if (values.ContainsKey(dt.Name) && (dt.Tag == null || dt.Tag.ToString() != "N"))
                        dt.EditValue = Convert.ToDateTime(values[dt.Name]);
                    else if ((dt.Tag != null && dt.Tag != "N"))
                        dt.EditValue = null;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.ComboBoxEdit))
                {
                    DevExpress.XtraEditors.ComboBoxEdit dt = fc as DevExpress.XtraEditors.ComboBoxEdit;
                    if (values.ContainsKey(dt.Name) && (dt.Tag == null || dt.Tag != "N"))
                        dt.SelectedIndex = Convert.ToInt32(values[dt.Name]);
                    else if ((dt.Tag != null && dt.Tag != "N"))
                        dt.SelectedIndex = -1;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckEdit))
                {
                    DevExpress.XtraEditors.CheckEdit chk = fc as DevExpress.XtraEditors.CheckEdit;
                }

            }
        }
        private void MouseSpin(object sender, SpinEventArgs e)
        {
            //e.IsSpinUp = false;
            e.Handled = true;
        }
        void lookUpEdit1_MouseWheel(object sender, MouseEventArgs e)
        {
           DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
            //e.Handled = true;
        }
        public void Control_Ayarla_Deger_Kopyala(Control.ControlCollection Control)
        {
            filterParameters.Clear();
            foreach (Control fc in Control)
            {
                if (fc.GetType() == typeof(System.Windows.Forms.TabControl))
                {
                    Control_Ayarla_Deger_Kopyala(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.TabPage))
                {
                    Control_Ayarla_Deger_Kopyala(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GroupControl))
                {
                    Control_Ayarla_Deger_Kopyala(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    Control_Ayarla_Deger_Kopyala(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    Control_Ayarla_Deger_Kopyala(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.PanelControl))
                {
                    Control_Ayarla_Deger_Kopyala(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.UserControl))
                {
                    Control_Ayarla_Deger_Kopyala(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.XtraUserControl))
                {
                    Control_Ayarla_Deger_Kopyala(fc.Controls);
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
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckedComboBoxEdit))
                {
                    DevExpress.XtraEditors.CheckedComboBoxEdit cbo = fc as DevExpress.XtraEditors.CheckedComboBoxEdit;
                    if (cbo.EditValue != null && cbo.EditValue.ToString() != "") filterParameters.Add(cbo.Name, cbo.EditValue.ToString());
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                {
                    DevExpress.XtraEditors.LookUpEdit cbo = fc as DevExpress.XtraEditors.LookUpEdit;
                    if (cbo.EditValue != null && cbo.EditValue.ToString() != "") filterParameters.Add(cbo.Name, cbo.EditValue.ToString());
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
                {
                    DevExpress.XtraEditors.GridLookUpEdit cbo = fc as DevExpress.XtraEditors.GridLookUpEdit;
                    if (cbo.EditValue != null && cbo.EditValue.ToString() != "") filterParameters.Add(cbo.Name, cbo.EditValue.ToString());

                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                {
                    DevExpress.XtraEditors.TextEdit txt = fc as DevExpress.XtraEditors.TextEdit;
                    if (txt.Text != "") filterParameters.Add(txt.Name, txt.Text);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
                {
                    DevExpress.XtraEditors.DateEdit dt = fc as DevExpress.XtraEditors.DateEdit;
                    if (dt.EditValue != null && dt.EditValue.ToString() != "") filterParameters.Add(dt.Name, dt.EditValue.ToString());
                }

                else if (fc.GetType() == typeof(DevExpress.XtraEditors.ComboBoxEdit))
                {
                    DevExpress.XtraEditors.ComboBoxEdit dt = fc as DevExpress.XtraEditors.ComboBoxEdit;
                    if (dt.SelectedIndex != -1 && dt.EditValue.ToString() != "") filterParameters.Add(dt.Name, Convert.ToString(dt.SelectedIndex));

                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckEdit))
                {
                    DevExpress.XtraEditors.CheckEdit chk = fc as DevExpress.XtraEditors.CheckEdit;
                    if (chk.EditValue != null && chk.EditValue.ToString() != "") filterParameters.Add(chk.Name, chk.EditValue.ToString());
                }
            }
        }
        public void Secili_Kontrolleri_Temizle(Control.ControlCollection Control)
        {
            foreach (Control fc in Control)
            {
                if (fc.GetType() == typeof(System.Windows.Forms.TabControl))
                {
                    Secili_Kontrolleri_Temizle(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.TabPage))
                {
                    Secili_Kontrolleri_Temizle(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GroupControl))
                {
                    Secili_Kontrolleri_Temizle(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    Secili_Kontrolleri_Temizle(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    Secili_Kontrolleri_Temizle(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.PanelControl))
                {
                    Secili_Kontrolleri_Temizle(fc.Controls);
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.UserControl))
                {
                    Secili_Kontrolleri_Temizle(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.XtraUserControl))
                {
                    Secili_Kontrolleri_Temizle(fc.Controls);
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LabelControl))
                {
                    DevExpress.XtraEditors.LabelControl label = fc as DevExpress.XtraEditors.LabelControl;
                    if (label.Tag != null && label.Tag.ToString() == "T") label.Text = "";
                    
                }
                else if (fc.GetType() == typeof(System.Windows.Forms.Label))
                {
                    Label label = fc as Label;
                    if (label.Tag != null && label.Tag.ToString() == "T") label.Text = "";
                   
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                {
                    DevExpress.XtraEditors.LookUpEdit cbo = fc as DevExpress.XtraEditors.LookUpEdit;
                    if (cbo.Tag != null && cbo.Tag.ToString() == "T") cbo.EditValue = null;
                    
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
                {
                    DevExpress.XtraEditors.GridLookUpEdit cbo = fc as DevExpress.XtraEditors.GridLookUpEdit;
                    if (cbo.Tag != null && cbo.Tag.ToString() == "T") cbo.EditValue = null;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                {
                    DevExpress.XtraEditors.TextEdit txt = fc as DevExpress.XtraEditors.TextEdit;
                    if (txt.Tag != null && txt.Tag.ToString() == "T") txt.Text = "";
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
                {
                    DevExpress.XtraEditors.DateEdit dt = fc as DevExpress.XtraEditors.DateEdit;
                    if (dt.Tag != null && dt.Tag.ToString() == "T") dt.EditValue = null;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.TimeEdit))
                {
                    DevExpress.XtraEditors.TimeEdit dt = fc as DevExpress.XtraEditors.TimeEdit;
                    if (dt.Tag != null && dt.Tag.ToString() == "T") dt.EditValue = null;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckEdit))
                {
                    DevExpress.XtraEditors.CheckEdit chk = fc as DevExpress.XtraEditors.CheckEdit;
                    if (chk.Tag != null && chk.Tag.ToString() == "T") chk.EditValue = null;
                }
                else if (fc.GetType() == typeof(DevExpress.XtraEditors.CheckedComboBoxEdit))
                {
                    DevExpress.XtraEditors.CheckedComboBoxEdit cbo = fc as DevExpress.XtraEditors.CheckedComboBoxEdit;
                    if (cbo.Tag != null && cbo.Tag.ToString() == "T") cbo.EditValue = null;
                }
            }
        }
        private void Gle_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            //GridLookUpEdit gle = (GridLookUpEdit)sender;
            ///editingValueTemp = e.DisplayValue.ToString();
        }
        private void Gle_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (editingValue != "")
            {
                e.DisplayText = editingValue;
                editingValue = "";
            }
        }

        private void Gle_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }
    }
    public enum UserControlTipEn : int
    {
        Liste = 1,
        Kayit = 2,
    }
}
