/*
 Tiny MCE integration into IE ActiveX used in .NET
 (c) [OSP] 2008

 Use under GPL
*/


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using System.IO;
using mshtml;
using ICSharpCode.SharpZipLib.Zip;

namespace WF_tinyMCE
{
	/// <summary>
	/// Summary description for FrmHTMLBrowser.
	/// </summary>
	public class FrmHTMLBrowser : System.Windows.Forms.Form
	{
        private AxSHDocVw.AxWebBrowser axBrowser;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private mshtml.IHTMLDocument2 hc;
        //subdir in ApplicationData Folder, change whatever you think
        private const string M_WORKPATH = "someMCEenabledFolder";
        //easilly navigate into resources
        private const string M_RESOURCE = "WF_tinyMCE";

		public FrmHTMLBrowser()
		{
            InitializeComponent();
            doInit();
		}

        public override string Text
        {
            get
            {
                return m_text;
            }
            set
            {
                m_text = value;
            }
        }

        public void CopyFile(Stream source, Stream target)
        {
            byte[] buffer = new byte[0x10000];
            int bytes;
            try
            {
                while ((bytes = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    target.Write(buffer, 0, bytes);
                }
            }
            finally
            {
                target.Close(); 
            }
        }

        /// <summary>
        /// Get the correct internal path where tinyMCE and work file will be stored
        /// </summary>
        /// <param name="subPath"></param>
        /// <returns></returns>
        private string getWorkPath(string subPath)
        {
            string AppFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return System.IO.Path.Combine(AppFolder, M_WORKPATH + "\\"+ subPath);
        }

        private string m_strMCEDir = "";
        private string m_strMCESettings = "";
        /// <summary>
        /// Prepare tinyMCE package
        /// </summary>
        public void PrepareTinyMCE()
        {
            string sCpy = getWorkPath("tinyMCE.zip");
            m_strMCEDir = getWorkPath("tinyMCE");
            m_strMCESettings = getWorkPath("tinyMCE.txt");
            if (!Directory.Exists(getWorkPath("")))
            {
                Directory.CreateDirectory(getWorkPath(""));
            }

            string sMCE = "tinyMCE\\tinyMCE\\jscripts\\tiny_mce";
            if (!Directory.Exists(m_strMCEDir) || !File.Exists(getWorkPath(sMCE) + "\\tiny_mce.js"))
            {
                string sMce = M_RESOURCE + ".resources.tinyMCE.zip";
                Stream strFile = GetResourceFile(sMce);
                FileStream fs = new FileStream(sCpy, FileMode.OpenOrCreate);
                CopyFile(strFile, fs);
                strFile.Close();

                Directory.CreateDirectory(m_strMCEDir);
                FastZip fz = new FastZip();
                fz.ExtractZip(sCpy, m_strMCEDir, FastZip.Overwrite.Never, null, null, null);
                File.Delete(sCpy);
            }
            //settings 
            {
                string sMce = M_RESOURCE + ".resources.tinyMCE.txt";
                Stream strFile = GetResourceFile(sMce);
                StreamReader sr = new StreamReader(strFile);
                m_strMCESettings = sr.ReadToEnd();
                sr.Close();
            }
            m_strMCEDir = sMCE;
        }

        public Stream GetResourceFile(string File)
        {
            if (File == null || File == "")
                return null;
            try
            {
                return this.GetType().Assembly.GetManifestResourceStream(File);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void doInit()
        {
            object empty = System.Reflection.Missing.Value;
            axBrowser.Navigate("about:blank", ref empty, ref empty, ref empty, ref empty);
            hc = (mshtml.IHTMLDocument2)axBrowser.Document;
        }

        private string m_text = "", m_type = "", m_css = "";
		public void ShowText(string Text)
		{
			m_text = Text;
			showText(false);
            this.Show();
			//this.Dispose();
		}

        public string EditText(string Text, string Type, string CSSFile)
        {
            m_text = Text;
            m_type = Type;
            m_css = CSSFile;
            PrepareTinyMCE();
            showText(true);
            this.ShowDialog();
            m_text = ((mshtml.IHTMLDocument3)axBrowser.Document).getElementById("elm1").innerText;
            return m_text;
            //this.Dispose();
        }


		private void showText(bool edit)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<HTML><HEAD><meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1250\" content=\"no-cache\">");
            if (edit && !string.IsNullOrEmpty(m_strMCESettings))
            {
                sb.Append("<script type=\"text/javascript\" src=\"");
                sb.Append(this.m_strMCEDir.Replace('\\', '/')); //IE compatible
                sb.AppendLine("/tiny_mce.js\">");
                sb.AppendLine("</script>");
                sb.AppendLine(this.m_strMCESettings);
                sb.AppendLine("</HEAD><BODY><FONT FACE=\"Arial\" SIZE=\"-1\">");
                sb.AppendLine("<form method=\"\" action=\"\" onsubmit=\"return false;\">");
                sb.AppendLine("<textarea id=\"elm1\" name=\"elm1\" style=\"width: 100%;height:100%\">");
            }
            else
            {
                sb.AppendLine("</HEAD><BODY><FONT FACE=\"Arial\" SIZE=\"-1\">");
            }
            sb.AppendLine(m_text);
            if (edit && !string.IsNullOrEmpty(m_strMCESettings))
            {
                sb.AppendLine("</textarea>");
            }
            sb.AppendLine("</FONT></BODY></HTML>");

            //get CSS to local folder
            if (File.Exists(m_css))
            {
                File.Copy(m_css, getWorkPath(m_type + ".css"), true);
                m_css = m_type + ".css";
            }
            string t = sb.Replace("[CSS]", m_css).ToString();
            string sDoc = getWorkPath(m_type + ".html");
            StreamWriter sw = new StreamWriter(sDoc, false, System.Text.Encoding.GetEncoding(1250));
            sw.Write(t);
            sw.Close();
			try
			{
                axBrowser.Navigate(sDoc);
			}
			catch(Exception e)
			{
				string s= e.Message;
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHTMLBrowser));
            this.axBrowser = new AxSHDocVw.AxWebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.axBrowser)).BeginInit();
            this.SuspendLayout();
            // 
            // axBrowser
            // 
            this.axBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axBrowser.Enabled = true;
            this.axBrowser.Location = new System.Drawing.Point(0, 0);
            this.axBrowser.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axBrowser.OcxState")));
            this.axBrowser.Size = new System.Drawing.Size(803, 574);
            this.axBrowser.TabIndex = 0;
            // 
            // FrmHTMLBrowser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(803, 574);
            this.Controls.Add(this.axBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmHTMLBrowser";
            this.Text = "FrmHTMLBrowser";
            ((System.ComponentModel.ISupportInitialize)(this.axBrowser)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private void ctlExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

	}
}
