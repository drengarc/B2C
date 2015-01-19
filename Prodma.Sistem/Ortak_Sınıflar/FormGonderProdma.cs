using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Prodma.DataAccess; 
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

            if (_assembly_name.Equals("") == false)
            {
                Assembly assembly = Assembly.LoadFrom(_assembly_name + ".exe");
                //Assembly assembly = Assembly.LoadFile("Prodma.Satis.exe");
                _st = _st + "," + _assembly_name;
            }
            try
            {
                // _st = "Stok";
                Type hai = Type.GetType(_st, true);
                Form o = (Form)(Activator.CreateInstance(hai));
                return o;
            }
            catch (Exception )
            {
                return null;
                //loglama meselesi
            }

        } 
    }
}
