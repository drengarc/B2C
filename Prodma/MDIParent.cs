using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Policy;
using Prodma.DataAccessB2C;
using Prodma.WinForms;
using Prodma.WinForm;
using Prodma.SistemB2C.Models;
using Prodma.SistemB2C.Services;
using DevExpress.XtraEditors;
//using Satis.StokAmbar.Forms;
//using Satis.Cari.Forms;
//using AlisSatis.Fis.Forms;
//using Siparis.Fis.Forms;
//using Teklif.Fis.Forms;
//using Cek.Fis.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using Prodma.Sistem.Forms;

namespace Prodma.Parent
{
    public partial class MDIParent : DevExpress.XtraEditors.XtraForm
    {
        bool erpproject = false;
        bool zamanliProgramCalisti = false;
        DateTime uyariBakIlkTarih = DateTime.Now;
        bool mesajAcildi = false;
        public Prodma.WinForms.MesajForm mfrm;
        public bool blnBaglantiyiKes = false;
        public int formSecimTip=0;
        string treeViewNodeName = "";
        string treeViewNodeTag = "";
        RegistryKey register;
        public int childCount = 1;
        bool panelgoster = true;
        bool sikkullanilanlargoster = true;
        private int childFormNumber = 0;
        //public FisSablonSon frmFis;
        //public TanitimSablon frmTanitim;
        internal System.Windows.Forms.MenuStrip mnuMain;
        internal System.Windows.Forms.ToolStripMenuItem mnuParent;
        internal System.Windows.Forms.ToolStripMenuItem mnuSubParent;
        internal System.Windows.Forms.ToolStripMenuItem mnuMenu;
        internal System.Windows.Forms.TreeNode treeNodeFile;
        internal System.Windows.Forms.TreeNode treeNodeNew;
        internal System.Windows.Forms.TreeNode treeNodeNew2;
        Point sagAltKose;
        public MDIParent()
        {
            //MessageBox.Show("parent aciliyor");
            InitializeComponent();
            //MessageBox.Show("parent acildi");
            Globals.tabliCalis = YardimciIslemler.SetTabliCalis();
            //mfrm = new MesajForm();
            timer1.Enabled = false;
           // YardimciIslemler.ButonDurumu(button1);
           // MenuleriDoldur();         

            //string menuAd = "";

            //menuAd = Prodma.DataAccess.Globals.rman.GetString("Genel");
            //if (menuAd == null) { menuAd = ""; }
            //if (menuAd != "" && menuAd != null) { this.fileMenu.Text = menuAd; }

            //menuAd = Prodma.DataAccess.Globals.rman.GetString("Bağlantıyı Kes");
            //if (menuAd == null) { menuAd = ""; }
            //if (menuAd != "" && menuAd != null) { this.baglantiyiKes.Text = menuAd; }

            //menuAd = Prodma.DataAccess.Globals.rman.GetString("Çıkış");
            //if (menuAd == null) { menuAd = ""; }
            //if (menuAd != "" && menuAd != null) { this.exitToolStripMenuItem.Text = menuAd; }

        }

        public void MenuleriDoldur()
        {

            int[] ustIdler = new int[11];
            int k = 0;
            string menuAd = "";
            List<MenulerVm> AllMenus = new List<MenulerVm>();
            List<MenulerVm> parentMenus = new List<MenulerVm>();
            List<MenulerVm> subParentMenus = new List<MenulerVm>();
            List<MenulerVm> menus = new List<MenulerVm>();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuMain.BackColor = System.Drawing.Color.GhostWhite;
            this.mnuMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mnuMain.ImageList = imageList1;
            this.mnuParent = new System.Windows.Forms.ToolStripMenuItem();
            this.treeNodeFile = new System.Windows.Forms.TreeNode();
            MenulerService mn = new MenulerService();
            MenulerVm k1 = new MenulerVm();
            AllMenus = mn.Liste_Al(new MenulerVm { LK_DURUM_ID = (int)DurumEn.Aktif }, Globals.gnKullaniciId);
            this.treeView1.ImageList = this.imageList1;
            bool subParent = false;
            foreach (MenulerVm menu in AllMenus)
            {
                subParent = false;
                if (menu.M_MENU_ID == 0 && (menu.KULLANICI_GORMESIN == null || menu.KULLANICI_GORMESIN == (int)EvetHayirEn.Hayir))
                {
                    menuAd = Globals.rman.GetString(menu.AD);
                    if (menuAd == null) { menuAd = ""; }
                    if (menuAd != "" && menuAd != null) { menu.AD = menuAd; }

                    parentMenus.Add(menu);
                    ustIdler[k] = menu.ID;
                    k += 1;
                }
                else
                {
                    for (int j = 0; j < k; j++)
                    {
                        if (menu.M_MENU_ID == ustIdler[j] && (menu.KULLANICI_GORMESIN == null || menu.KULLANICI_GORMESIN == (int)EvetHayirEn.Hayir))
                        {
                            menuAd = Globals.rman.GetString(menu.AD);
                            if (menuAd == null) { menuAd = ""; }
                            if (menuAd != "" && menuAd != null) { menu.AD = menuAd; }

                            subParentMenus.Add(menu);
                            subParent = true;
                        }
                    }
                    if (subParent == false && (menu.KULLANICI_GORMESIN == null || menu.KULLANICI_GORMESIN ==  (int)EvetHayirEn.Hayir))
                    {
                        menuAd = Globals.rman.GetString(menu.AD);
                        if (menuAd == null) { menuAd = ""; }
                        if (menuAd != "" && menuAd != null) { menu.AD = menuAd; }

                        menus.Add(menu);
                    }
                }
            }
            for (int i = 0; i < parentMenus.Count; i++)
            {
                this.mnuParent = new System.Windows.Forms.ToolStripMenuItem();
                this.mnuMain.Items.Add(this.mnuParent);
                this.mnuParent.Text = parentMenus[i].AD;
                this.mnuParent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                this.treeNodeFile = new System.Windows.Forms.TreeNode();
                this.treeView1.Nodes.Add(this.treeNodeFile);
                this.treeView1.ShowPlusMinus = true;
                this.treeView1.ShowRootLines = true;
                this.treeNodeFile.Text = parentMenus[i].AD;
                //this.treeNodeFile.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                for (int j = 0; j < subParentMenus.Count; j++)
                {
                    if (parentMenus[i].ID == subParentMenus[j].M_MENU_ID)
                    {
                        this.mnuSubParent = new System.Windows.Forms.ToolStripMenuItem();
                        this.mnuSubParent.TextImageRelation = TextImageRelation.ImageBeforeText;
                        this.mnuParent.DropDownItems.Add(this.mnuSubParent);
                        this.mnuSubParent.Click += new EventHandler(DropDownItems_Click);
                        this.mnuSubParent.Text = subParentMenus[j].AD;
                        this.mnuSubParent.Name = subParentMenus[j].URL;
                        this.mnuSubParent.Font = new Font("Microsoft Sans Serif", 9.75F);
                        this.mnuSubParent.Tag = subParentMenus[j].ASSEMBLY_NAME + "/" + Convert.ToString(subParentMenus[j].ID) + "/" + Convert.ToString(subParentMenus[j].HEDEF);
                        treeNodeNew = new TreeNode();
                        treeNodeNew.Name = this.mnuSubParent.Name;
                        treeNodeFile.Nodes.Add(treeNodeNew);
                        treeNodeNew.Text = this.mnuSubParent.Text;
                        //treeNodeNew.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162))); //new Font("Microsoft Sans Serif", 9.75F);
                        treeNodeNew.Tag = this.mnuSubParent.Tag;
                        treeNodeNew.Name = this.mnuSubParent.Name;
                        foreach (MenulerVm menu in menus)
                        {
                            if (menu.M_MENU_ID == subParentMenus[j].ID)
                            {
                                this.mnuMenu = new System.Windows.Forms.ToolStripMenuItem();
                                this.mnuSubParent.DropDownItems.Add(this.mnuMenu);
                                this.mnuMenu.Click += new EventHandler(DropDownItems_Click);

                                menuAd = Globals.rman.GetString(menu.AD);
                                if (menuAd == null) { menuAd = ""; }
                                if (menuAd.Trim() == "" || menuAd == null)
                                {
                                    this.mnuMenu.Text = menu.AD;
                                }
                                else
                                {
                                    this.mnuMenu.Text = menuAd;
                                }

                                this.mnuMenu.Name = menu.URL;
                                this.mnuMenu.Tag = menu.ASSEMBLY_NAME + "/" + Convert.ToString(menu.ID) + "/" + Convert.ToString(menu.HEDEF);
                                treeNodeNew2 = new TreeNode();
                                treeNodeNew.Nodes.Add(treeNodeNew2);
                                treeNodeNew2.Text = this.mnuMenu.Text;
                                //treeNodeNew2.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162))); //new Font("Microsoft Sans Serif", 9.75F);
                                treeNodeNew2.Tag = this.mnuMenu.Tag;
                                treeNodeNew2.Name = this.mnuMenu.Name;
                            }

                        }
                    }
                }
            }
            mnuMain.Items.Add(this.fileMenu);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    //mnuMain.Items.Add(this.fileMenu);
            //    //this.Controls.Add(this.mnuMain);
            //    //this.MainMenuStrip = this.mnuMain;
            //}
        }   
        private void DropDownItems_Click(object sender, EventArgs e)
        {
            try
            {
               // YardimciIslemlerKontrols.ProgramBeklemeGoster();
                if (Globals.SifirliKayitKontrol == false)
                {
                    //MessageBox.Show("Fiş Kaydını Tamamlamalısınız");
                    //return;
                }
                ToolStripMenuItem button = (ToolStripMenuItem)sender;
                string st = button.Name;
                if (st == "Baglantiyi_Kes")
                {
                    if (Globals.programKapatma == true) { return; }                   
                    Application.Restart();
                }
                else
                {
                    erpproject = false;
                    string[] asssembly_name = Convert.ToString(button.Tag).Split('/');
                    if (asssembly_name[0]=="Prodma.Satis")
                    {
                        erpproject = true;
                    }
                    if (asssembly_name.Length == 3 && asssembly_name[2]=="3")
                    {
                        FormGonderProdma Frm = new FormGonderProdma();
                        Frm.st = st;
                        Frm.assembly_name = asssembly_name[0].Trim();
                        Frm.FormAc().ShowDialog();
                        //Prodma_Form_Ac(Frm.FormAc(), Convert.ToInt32(asssembly_name[1]));
                    }
                    else
                    {
                        if (TabPageBak(st) == false)
                        {

                            FormGonderProdma Frm = new FormGonderProdma();
                            Frm.st = st;
                            Frm.assembly_name = asssembly_name[0].Trim();
                            //(Frm.FormAc, Convert.ToInt32(asssembly_name[1])); 
                            Prodma_Form_Ac(Frm.FormAc(), Convert.ToInt32(asssembly_name[1]));

                        }
                    }
                }
            }
            catch (Exception)
            {
                //YardimciIslemlerKontrols.ProgramBeklemeDurdur();
            }
            //YardimciIslemlerKontrols.ProgramBeklemeDurdur();
        }
        public void  Prodma_Form_Ac(Form frm,int menuId)
        {
            if (erpproject==true)
            {
                Prodma.WinForms.Sablon objfrmSChild = (Prodma.WinForms.Sablon)frm;
                objfrmSChild.sablonSecilenMenuId = menuId;
                objfrmSChild.MdiParent = this;
                if (Globals.tabliCalis == true)
                {
                    objfrmSChild.TabCtrl = this.tabControlMenuItem;
                    TabPage tp = new TabPage();
                    tp.Parent = tabControlMenuItem;
                    tp.Text = objfrmSChild.Text;
                    //  tp.SuspendLayout();
                    tp.Show();
                    // tp.ResumeLayout();
                    objfrmSChild.TabPag = tp;
                    childCount++;
                    tabControlMenuItem.SelectedTab = tp;
                }
                try
                {
                    objfrmSChild.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Açmak İstediğiniz Ekrana Ulaşımazsınız. Yetkiliye Müracaat Ediniz");
                }
            }
            else
            {
                Prodma.WinForms.Sablon objfrmSChild = (Prodma.WinForms.Sablon)frm;
                objfrmSChild.sablonSecilenMenuId = menuId;
                objfrmSChild.MdiParent = this;
                if (Globals.tabliCalis == true)
                {
                    objfrmSChild.TabCtrl = this.tabControlMenuItem;
                    TabPage tp = new TabPage();
                    tp.Parent = tabControlMenuItem;
                    tp.Text = objfrmSChild.Text;
                    //  tp.SuspendLayout();
                    tp.Show();
                    // tp.ResumeLayout();
                    objfrmSChild.TabPag = tp;
                    childCount++;
                    tabControlMenuItem.SelectedTab = tp;
                }
                try
                {
                    objfrmSChild.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Açmak İstediğiniz Ekrana Ulaşımazsınız. Yetkiliye Müracaat Ediniz");
                }
            }
            
       
            //objfrmSChild.ShowDialog();
          
        }
        private bool TabPageBak(string name)
        {
            if (Globals.tabliCalis == false) return false;
            string[] st1 = Convert.ToString(name).Split('.');
            if (st1.Length > 0)
            {
                name = st1[st1.Length-1];
            }
            foreach (Form fr in this.MdiChildren)
            {
                if (fr.Name == name)
                {
                    if (erpproject==true)
                    {
                        Prodma.WinForms.Sablon frT;
                        frT = (Prodma.WinForms.Sablon)fr;

                        //Activate the MDI child form
                        frT.Select();
                    }
                    else
                    {
                        Prodma.WinForms.Sablon frT;
                        frT = (Prodma.WinForms.Sablon)fr;

                        //Activate the MDI child form
                        frT.Select();
                    }
                    return true;   
                  
                }
                
            }
            return false;  
        }
        private void TabPageBul()
        {
            try
            {

                foreach (Form fr in this.MdiChildren)
                {
                    if (Convert.ToString(fr.Tag)  != "login")
                    {
                        if (erpproject==true)
                        {
                            Prodma.WinForms.Sablon frT;
                            frT = (Prodma.WinForms.Sablon)fr;
                            if (formSecimTip == 1)// tabcontrolden gelen
                            {
                                if ((frT.TabPag != null && frT.TabPag.Equals(tabControlMenuItem.SelectedTab)))
                                {
                                    //Activate the MDI child form
                                    frT.Select();
                                }
                            }
                            else if (formSecimTip == 0 && frT.TabPag != null)// form kapatmaktan gelen
                            {
                                if (Globals.sablonKapatildi == true)
                                {
                                    if ((tabControlMenuItem.TabPages.Count > 0 && frT.TabPag.Equals(tabControlMenuItem.TabPages[tabControlMenuItem.TabPages.Count - 1])))
                                    {
                                        //    //Activate the MDI child form
                                        frT.Select();
                                    }
                                }
                                else
                                {
                                    if ((frT.TabPag != null && frT.TabPag.Equals(tabControlMenuItem.SelectedTab)))
                                    {
                                        //Activate the MDI child form
                                        frT.Select();
                                    }
                                }
                                //&& frT.TabPag.Equals(tabControlMenuItem.TabPages[tabControlMenuItem.TabPages.Count - 1]) EKRAN geri DONUSLERI ICIN KONULDU
                            }
                        }
                        else
                        {
                            Prodma.WinForms.Sablon frT;
                            frT = (Prodma.WinForms.Sablon)fr;
                            if (formSecimTip == 1)// tabcontrolden gelen
                            {
                                if ((frT.TabPag != null && frT.TabPag.Equals(tabControlMenuItem.SelectedTab)))
                                {
                                    //Activate the MDI child form
                                    frT.Select();
                                }
                            }
                            else if (formSecimTip == 0 && frT.TabPag != null)// form kapatmaktan gelen
                            {
                                if (Globals.sablonKapatildi == true)
                                {
                                    if ((tabControlMenuItem.TabPages.Count > 0 && frT.TabPag.Equals(tabControlMenuItem.TabPages[tabControlMenuItem.TabPages.Count - 1])))
                                    {
                                        //    //Activate the MDI child form
                                        frT.Select();
                                    }
                                }
                                else
                                {
                                    if ((frT.TabPag != null && frT.TabPag.Equals(tabControlMenuItem.SelectedTab)))
                                    {
                                        //Activate the MDI child form
                                        frT.Select();
                                    }
                                }
                                //&& frT.TabPag.Equals(tabControlMenuItem.TabPages[tabControlMenuItem.TabPages.Count - 1]) EKRAN geri DONUSLERI ICIN KONULDU
                            }
                        }
                    }
                }
                //formSecimTip = 0;
                Globals.SifirliKayitKontrol = true;
                ////foreach (Form fr in this.MdiChildren )
                //{
                //    if (fr.Text != "PRODMA ERP GİRİŞ")
                //    { 
                //      foreach (Prodma.TanitimSablon childForm in this.MdiChildren)
                //        {
                //             //Check for its corresponding MDI child form
                //            if (childForm.TabPag.Equals(tabControl1.SelectedTab))
                //            {
                //                //Activate the MDI child form
                //                childForm.Select();
                //            }
                //        }
                //    }    
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       

        }
        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
           // formSecimTip = 1;
            if (tabControlMenuItem.SelectedIndex == 0)
            {
                formSecimTip = 0;
                TabPageBul();
            }
            else
            {
                formSecimTip = 1;
                TabPageBul();
            }
            Globals.sablonKapatildi = false;
        }
        void toolStripDropDownItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string msg = String.Format("Item clicked: {0}", e.ClickedItem.Text);
            MessageBox.Show (msg);
        }
#region "MDIPARENT ISLEMLERI"

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }
        private void BaglantiyiKes_Click(object sender, EventArgs e)
        {
            if (Globals.programKapatma == true) { return; }
            DialogResult diaResult;
            blnBaglantiyiKes = true;
            // Show Message to the User
            diaResult = MessageBox.Show("Program Kapatılacaktır Emin Misiniz?",
                                        "",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button2);
            // Checking which button as been pressed
            if (diaResult == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
        private void Mesaj_Click(object sender, EventArgs e)
        {
            Mesaj frm = new Mesaj();
            MDIParent fr = this;
            fr.Prodma_Form_Ac(frm, 5);
        }
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void mnMenuItemClick_Click(object sender, EventArgs e){       
        }

#endregion




        private void MDIParent1_Load(object sender, EventArgs e)
        {
            try
            {
                this.panel1.Size = new System.Drawing.Size(20, 453);
                this.panel2.Size = new System.Drawing.Size(20, 453);
                //this.mnuMain.Enabled = false;  
                Login objfrmSChild = new Login();
                objfrmSChild.MdiParent = this;
                objfrmSChild.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                
            }
            
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.Exe", "Hesap Makinesi");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore.exe", "http://www.prodma.com/?sayfa=Iletisim");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore.exe", "www.google.com"); 
        }

        private void MDIParent_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && Globals.menuKisayolCalissin)
            {
                //if (e.KeyCode == Keys.M)
                //{
                //    Stok frm = new Stok();
                //    MDIParent fr = this;
                //    fr.Prodma_Form_Ac(frm, 5);
                //    timer1.Enabled = true;
                //}
                //else if (e.KeyCode == Keys.Z)
                //{
                //    CariKart frm = new CariKart();
                //    MDIParent fr = this;
                //    fr.Prodma_Form_Ac(frm, 5);
                //    timer1.Enabled = false;
                //}
                //else if (e.KeyCode == Keys.T)
                //{
                //    TeklifFis frm = new TeklifFis();
                //    MDIParent fr = this;
                //    fr.Prodma_Form_Ac(frm, 5);
                //}
                //else if (e.KeyCode == Keys.S)
                //{
                //    SiparisFis frm = new SiparisFis();
                //    MDIParent fr = this;
                //    timer1.Enabled = true;
                //    fr.Prodma_Form_Ac(frm, 5);
                //}
                //else if (e.KeyCode == Keys.I)
                //{
                //    StokFis frm = new StokFis();
                //    MDIParent fr = this;
                //    fr.Prodma_Form_Ac(frm, 5);
                //}
                //else if (e.KeyCode == Keys.K)
                //{
                //    CekFis frm = new CekFis();
                //    MDIParent fr = this;
                //    fr.Prodma_Form_Ac(frm, 5);
                //}
                //else if (e.KeyCode == Keys.L)
                //{
                //    CekTanitim frm = new CekTanitim();
                //    MDIParent fr = this;
                //    fr.Prodma_Form_Ac(frm, 5);
                //}
                //else if (e.KeyCode == Keys.I)
                //{
                //    //StokIcFis frm = new StokIcFis();
                //    //MDIParent fr = this;
                //    //fr.Prodma_Form_Ac(frm, 5);
                //}
            }
            Globals.menuKisayolCalissin = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region call cente
            
            //string cariKod = "";
            //////////////////////////register = Registry.LocalMachine.OpenSubKey(@"Software\prodmaerp\carikod", true);
            //////////////////////////if (register != null)
            //////////////////////////{
            //////////////////////////    register = Registry.LocalMachine.OpenSubKey(@"Software\prodmaerp", true);
            //////////////////////////    if (register.GetValue("cariKod") != null && register.GetValue("cariKod").ToString() != "")
            //////////////////////////    {
            //////////////////////////        cariKod = register.GetValue("cariKod").ToString();
            //////////////////////////        register.SetValue("cariKod", "");
            //////////////////////////        CariBilgilendirme frm = new CariBilgilendirme();
            //////////////////////////        frm.cariVm = new global::Satis.Cari.Models.CariVm();
            //////////////////////////        frm.cariKod = cariKod;
                   
            //////////////////////////        MDIParent fr = this;
            //////////////////////////        fr.Prodma_Form_Ac(frm, 5);
            //////////////////////////        frm.DisaridanAc();
            //////////////////////////    }
            //////////////////////////}
            //string[] lines = File.ReadAllLines(Application.StartupPath.ToString() + "/file.txt");
            //foreach (string line in lines)
            //{
            //    cariKod = line != "" ?line.Substring(1,line.Length-2) :"";
            //}
            //string[] a = new string[1];
            //a[0]="";
            //if (cariKod!="")
            //{
            //  //////////////////File.WriteAllLines(Application.StartupPath.ToString() + "/file.txt",a);
            //  //////////////////CariBilgilendirme frm = new CariBilgilendirme();
            //  //////////////////frm.cariKod = cariKod;
            //  //////////////////MDIParent fr = this;
            //  //////////////////fr.Prodma_Form_Ac(frm, 5);
            //  //////////////////frm.DisaridanAc();
            //}
            #endregion
            try
            {
                if (GenelParametreSng.Nesne().kullaniciBilgileri != null && GenelParametreSng.Nesne().kullaniciBilgileri.ROL_ID == (int)VarsayilanIdlerEn.SuperVisorRol)
                {
                    TimeSpan span = DateTime.Now.Subtract(uyariBakIlkTarih);
                    if (span.Seconds > 30 || mesajAcildi == true)
                    {
                        string[] mesaj = YardimciIslemler.KullaniciMesajYaz();
                        if (mesaj[0] != "")
                        {
                            if (mfrm.gosterildi == false)
                            {
                                //mfrm = new SplashScreenForm();
                                mfrm.Show();
                                sagAltKose = new Point(this.Width - (mfrm.Width + 10), this.Height - (mfrm.Height + 10));
                                //mfrm.MdiParent = this;
                                mfrm.mesajSet(mesaj);
                                mfrm.StartPosition = FormStartPosition.Manual;
                                mfrm.Location = sagAltKose;
                                mfrm.gosterilmeZamani = DateTime.Now;
                                mfrm.gosterildi = true;
                            }
                            TimeSpan span1 = DateTime.Now.Subtract(mfrm.gosterilmeZamani);
                            if (span1.Seconds == 5)
                            {
                                mfrm.Hide();
                                mfrm.gosterildi = false;
                            }
                            mesajAcildi = true;
                        }
                        else
                        {
                            mesajAcildi = false;
                        }
                        uyariBakIlkTarih = DateTime.Now;
                    }

                    //if (DateTime.Now.Hour == 20 && DateTime.Now.Minute == 45 && DateTime.Now.Second == 0 && zamanliProgramCalisti == false && GenelParametreSng.Nesne().kullaniciBilgileri.ROL_ID == (int)VarsayilanIdlerEn.SuperVisorRol)
                    //{
                    //    OrtakIslemlerService.DovizKurKopyala(DateTime.Today);
                    //    Dictionary<string, string> parameterIslemler = new Dictionary<string, string>();
                    //    parameterIslemler.Add("SATIS_FIYAT_CARI_AYRIM_ID", Convert.ToString((int)VarsayilanIdlerEn.CariAyrim));
                    //    parameterIslemler.Add("ALIS_FIYAT_CARI_AYRIM_ID", Convert.ToString((int)VarsayilanIdlerEn.CariAyrim));
                    //    parameterIslemler.Add("TARIHbas", Convert.ToString(DateTime.Today.ToShortDateString()));
                    //    OrtakIslemlerService.FiyatAtamaYap(parameterIslemler);
                    //}
                }
            }
            catch (Exception)
            {
              //
            }
         
            
        }

        private void tabControlMenuItem_Selecting(object sender, TabControlCancelEventArgs e)
        {
           // formSecimTip = e.TabPageIndex;
        }

        private void tabControlMenuItem_Selected(object sender, TabControlEventArgs e)
        {
          //  formSecimTip = e.TabPageIndex;
        }

        private void tabControlMenuItem_Click(object sender, EventArgs e)
        {
         //   formSecimTip = 1;
        }

        private void tabControlMenuItem_MouseClick(object sender, MouseEventArgs e)
        {
         //   formSecimTip = 1;
        }

        public void BilgilerYaz(string bilgi)
        {
            FileVersionInfo myFI = FileVersionInfo.GetVersionInfo(Application.StartupPath.ToString() + "/Prodma.B2C.exe");
            lblStatus.Text = "PRODMA ERP -" + myFI.FileVersion +  " " + bilgi;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (panelgoster == true)
            {
                this.panel1.Size = new System.Drawing.Size(225, 453);
                panelgoster = false;
            }
            else
            {
                this.panel1.Size = new System.Drawing.Size(20, 453);
                panelgoster = true;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           treeViewNodeName=e.Node.Name;
           treeViewNodeTag = e.Node.Tag!=null? e.Node.Tag.ToString():"";
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Name = treeViewNodeName;
                    item.Tag = treeViewNodeTag;
                    EventArgs args = new EventArgs();
                    DropDownItems_Click(item, args);
                }
            }
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Name = treeViewNodeName;
            item.Tag = treeViewNodeTag;
            EventArgs args = new EventArgs();
            DropDownItems_Click(item, args);
        }

        private void MDIParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Globals.programKapatma == true) { e.Cancel = true; return; }
            if (blnBaglantiyiKes == true)
            {
              //  this.Dispose();
                //Application.Restart();
            }
            else
            {
                DialogResult diaResult;
                // Show Message to the User
                diaResult = MessageBox.Show("Program Kapatılacaktır Emin Misiniz?",
                                            "",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning,
                                            MessageBoxDefaultButton.Button2);
                // Checking which button as been pressed
                if (diaResult == DialogResult.No)
                {
                    // CANCEL pressed, set focus to the program
                    e.Cancel = true;
                }
                else
                {
                    // YES pressed, exit the program
                    this.Dispose();
                    Application.Exit();
                }
            }
        }
    }
}
