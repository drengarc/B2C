using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Prodma.DataAccessB2C;
using System.ComponentModel;
using System.Drawing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections;
using System.Text;
using System.Linq.DynamicB2C;
using Prodma.SistemB2C.Models;
using DevExpress.XtraEditors;
namespace Prodma.DataAccessB2C
{
    public class HelperBase
    {
        public bool fiyatEnabled=true;
        public bool tutarEnabled=true;
        public bool fiyatDegistir = false;
        public KontrolVm kontrolVm = new KontrolVm();
        public string _donusHataMesaj = "";
        public string _donusMesajBoxMesaj = "";
        public string _donusMesajBoxTip = "";
        public int _donusNDeger = 0;
        public bool _donusBDeger = true;
        public bool _donusBDegerFalse = false;
        public string _donusMethodDeger = "";
        public string _donusColumnDeger = "";
        public HelperBase()
        {
            _donusHataMesaj = "";
            _donusMesajBoxMesaj = "";
            _donusNDeger = 0;
            _donusBDeger = true;
            _donusBDegerFalse = false;
            _donusMethodDeger = "";
            _donusMesajBoxTip = "";
        }
    }
}
