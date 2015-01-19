using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Prodma.DataAccessB2C; using Prodma.WinForms; 
namespace Prodma
{
   
    public class FormGonderProdma
    {
        public FormGonderProdma()
        {
    
        }
        private string _st;
        public string st
        {
            set
            {
                _st = value;
            }
        }
        private string _assembly_name;
        public string assembly_name
        {
            set
            {
                _assembly_name = value;
            }
        }
        public Form FormAc(){
            try
            {
                if (_assembly_name.Equals("") == false)
                {
                    Assembly assembly = Assembly.LoadFrom(_assembly_name + ".exe");
                    //Assembly assembly = Assembly.LoadFile("Prodma.Satis.exe");
                    _st = _st + "," + _assembly_name;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException + " " + ex.Message + "assambly");
                return null;
                //loglama meselesi
            }
            try
            {
                // _st = "Stok";
                Type hai = Type.GetType(_st, true);
                Form o = (Form)(Activator.CreateInstance(hai));
                return o;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException + " " + ex.Message);
                return null;
                //loglama meselesi
            }

        } 
    }
}
