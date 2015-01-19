using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prodma.DataAccessB2C;
namespace Prodma.WinForms
{
    public class MySplash  
    {
        static private SplashScreenForm form;
        private static bool isStarted = false;
        public void Start()
        {
            isStarted = true;
            form = new SplashScreenForm();
            form.Show();
            System.Windows.Forms.Application.DoEvents();
        }
        public void Stop()
        {
            if (form != null)
            {
                form.Hide();
                form.Close();
                form = null;
            }
            isStarted = false;
        }
        public void SetDisplayText(string displayText)
        {
        }
        public bool IsStarted
        {
            get { return isStarted; }
        }
    }
}
