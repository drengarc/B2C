using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using Prodma.DataAccessB2C.Ortak_Classlar;
using Microsoft.Reporting.WinForms;
using System.Diagnostics;

namespace Prodma.DataAccessB2C
{
    public class Export
    {
        public static void ExportToGridControl(DevExpress.XtraGrid.GridControl grid, string title, string filter, string exportFormat)
        {
            if (grid == null) return; //parametre olarak gönderilen vgrid geçersizse işlem yapma
            string fileName =  ShowSaveFileDialog(title, filter);//SaveFileDialog ile kayıt yeri ve ismi belirt
            fileName = title;
            if (fileName != "")
            {//geriye dönen kayıt yeri değişkeni geçersiz değilse
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                switch (exportFormat)
                {//parametre olarak gönderilen dosya biçimine göre döngüye girip gridi export et
                    case "HTML": grid.ExportToHtml(fileName);
                        break;
                    case "MHT": grid.ExportToMht(fileName);
                        break;
                    case "PDF": grid.ExportToPdf(fileName);
                        break;
                    case "XLS": grid.ExportToXls(fileName);
                        break;
                    case "XLSX": grid.ExportToXlsx(fileName);
                        break;
                    case "RTF": grid.ExportToRtf(fileName);
                        break;
                    case "TXT": grid.ExportToText(fileName);
                        break;
                } Cursor.Current = currentCursor;
                OpenFile(fileName);//dosya açma yöntemini kullan
            }
        }
        public static void ExportToGridControl(DevExpress.XtraPivotGrid.PivotGridControl grid, string title, string filter, string exportFormat)
        {
            if (grid == null) return; //parametre olarak gönderilen vgrid geçersizse işlem yapma
            string fileName = ShowSaveFileDialog(title, filter);//SaveFileDialog ile kayıt yeri ve ismi belirt
            if (fileName != "")
            {//geriye dönen kayıt yeri değişkeni geçersiz değilse
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                switch (exportFormat)
                {//parametre olarak gönderilen dosya biçimine göre döngüye girip gridi export et
                    case "HTML": grid.ExportToHtml(fileName);
                        break;
                    case "MHT": grid.ExportToMht(fileName);
                        break;
                    case "PDF": grid.ExportToPdf(fileName);
                        break;
                    case "XLS": grid.ExportToXls(fileName);
                        break;
                    case "XLSX": grid.ExportToXlsx(fileName);
                        break;
                    case "RTF": grid.ExportToRtf(fileName);
                        break;
                    case "TXT": grid.ExportToText(fileName);
                        break;
                } Cursor.Current = currentCursor;
                OpenFile(fileName);//dosya açma yöntemini kullan
            }
        }
        static string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            //string name = "Belge1" + filter;
            string name = "Belge1";
            dlg.Title =
            "Gönder " + title;
            dlg.FileName = name;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                name = dlg.FileName;
                int n = name.LastIndexOf(".") + 1;//dosya ismi sonunda uzantı belirtmek için nokta kullanıldıysa
                if (n > 0)
                {
                    name = name.Substring(0,n-1);//noktadan öncesini dosya ismi olarak ata
                }
                name = name + filter; 
                return name;//kayıt bilgilerini dialog penceresinden aldıktan sonra kayıt yerini geri döndür
            }
            else
            {
                return ""; //kayıttan vazgeçildiyse geriye boş değer döndür
            }
        }

        static void OpenFile(string fileName)
        {//export işlemi tamamlandıktan sonra kullanıcıya dosyayı açmak isteyip istemediğini sor istiyorsa dosyayı aç
            if (XtraMessageBox.Show("Dosyayı açmak istiyor musunuz?", "Gönder...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle =
                    ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch //bilgisayarda dosyayı açmak için geçerli bir program yoksa hata ver
                {
                    XtraMessageBox.Show("Dosyayı açmak için sisteminizde gerekli uygulama     bulunamadı !...", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
