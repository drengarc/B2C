using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prodma.DataAccessB2C.Ortak_Classlar
{
         
    public abstract class BaseValidation
    {
        //public int hataKod = 100;
        //public string Mesaj;
        //#region SATIR
        //public void FocusedRowChanged_Satir(DevExpress.XtraGrid.Views.Grid.GridView view)
        //{
        //    try
        //    {
        //        doFocusedRowChanged_Satir(view);
        //    }
        //    catch (ServiceIstisna ex)
        //    {
        //        hataKod = 101;
        //        Mesaj = "Servise İstisna Hatası - detayli Aciklama: " + ex.InnerException;
        //    }
        //    catch (Exception ex)
        //    {
        //        hataKod = 102;
        //        Mesaj = "Controller Hatası - detayli Aciklama: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (hataKod != 100)
        //        {
        //            LogHelperB2C.Logger.LogError(Mesaj);
        //        }

        //    }
             
        //}
        //public void ValidatingEditor_Satir(object value, int FocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn, bool tamYetki)
        //{
        //    try
        //    {
        //        doFocusedRowChanged_Satir(view);
        //    }
        //    catch (ServiceIstisna ex)
        //    {
        //        hataKod = 101;
        //        Mesaj = "Servise İstisna Hatası - detayli Aciklama: " + ex.InnerException;
        //    }
        //    catch (Exception ex)
        //    {
        //        hataKod = 102;
        //        Mesaj = "Controller Hatası - detayli Aciklama: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (hataKod != 100)
        //        {
        //            LogHelperB2C.Logger.LogError(Mesaj);
        //        }

        //    }
        //}
        //public void ValidateRow_Satir(int FocusedRowHandle)
        //{
        //    try
        //    {
        //        doFocusedRowChanged_Satir(view);
        //    }
        //    catch (ServiceIstisna ex)
        //    {
        //        hataKod = 101;
        //        Mesaj = "Servise İstisna Hatası - detayli Aciklama: " + ex.InnerException;
        //    }
        //    catch (Exception ex)
        //    {
        //        hataKod = 102;
        //        Mesaj = "Controller Hatası - detayli Aciklama: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (hataKod != 100)
        //        {
        //            LogHelperB2C.Logger.LogError(Mesaj);
        //        }

        //    }
        //}
        //public void ShowingEditor_Satir(int FocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn, bool yeniKayit)
        //{
        //}
        //public void FocusedColumnChanged_Satir(DevExpress.XtraGrid.Views.Grid.GridView view, int FocusedRowHandle, int PrevFocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn, DevExpress.XtraGrid.Columns.GridColumn PrevFocusedColumn, TeklifFisSatirVm satirEskiVm)
        //{
        //    try
        //    {
        //        doFocusedRowChanged_Satir(view);
        //    }
        //    catch (ServiceIstisna ex)
        //    {
        //        hataKod = 101;
        //        Mesaj = "Servise İstisna Hatası - detayli Aciklama: " + ex.InnerException;
        //    }
        //    catch (Exception ex)
        //    {
        //        hataKod = 102;
        //        Mesaj = "Controller Hatası - detayli Aciklama: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (hataKod != 100)
        //        {
        //            LogHelperB2C.Logger.LogError(Mesaj);
        //        }

        //    }
        //}
        //public void ProcessGridKey_Satir(DevExpress.XtraGrid.GridControl gridControl, DevExpress.XtraGrid.Views.Grid.GridView view, KeyEventArgs args, int FocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn)
        //{
        //    try
        //    {
        //        doFocusedRowChanged_Satir(view);
        //    }
        //    catch (ServiceIstisna ex)
        //    {
        //        hataKod = 101;
        //        Mesaj = "Servise İstisna Hatası - detayli Aciklama: " + ex.InnerException;
        //    }
        //    catch (Exception ex)
        //    {
        //        hataKod = 102;
        //        Mesaj = "Controller Hatası - detayli Aciklama: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (hataKod != 100)
        //        {
        //            LogHelperB2C.Logger.LogError(Mesaj);
        //        }

        //    }
        //}
        //#endregion
        //#region SIFIR
        //public void FocusedRowChanged(DevExpress.XtraGrid.Views.Grid.GridView view)
        //{
        //    try
        //    {
        //        doFocusedRowChanged_Satir(view);
        //    }
        //    catch (ServiceIstisna ex)
        //    {
        //        hataKod = 101;
        //        Mesaj = "Servise İstisna Hatası - detayli Aciklama: " + ex.InnerException;
        //    }
        //    catch (Exception ex)
        //    {
        //        hataKod = 102;
        //        Mesaj = "Controller Hatası - detayli Aciklama: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (hataKod != 100)
        //        {
        //            LogHelperB2C.Logger.LogError(Mesaj);
        //        }

        //    }
        //}
        //public void ValidateRow(int FocusedRowHandle)
        //{
        //    try
        //    {
        //        doFocusedRowChanged_Satir(view);
        //    }
        //    catch (ServiceIstisna ex)
        //    {
        //        hataKod = 101;
        //        Mesaj = "Servise İstisna Hatası - detayli Aciklama: " + ex.InnerException;
        //    }
        //    catch (Exception ex)
        //    {
        //        hataKod = 102;
        //        Mesaj = "Controller Hatası - detayli Aciklama: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (hataKod != 100)
        //        {
        //            LogHelperB2C.Logger.LogError(Mesaj);
        //        }

        //    }
        //}
        //public void ShowingEditor(int FocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn)
        //{
        //    try
        //    {
        //        doFocusedRowChanged_Satir(view);
        //    }
        //    catch (ServiceIstisna ex)
        //    {
        //        hataKod = 101;
        //        Mesaj = "Servise İstisna Hatası - detayli Aciklama: " + ex.InnerException;
        //    }
        //    catch (Exception ex)
        //    {
        //        hataKod = 102;
        //        Mesaj = "Controller Hatası - detayli Aciklama: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (hataKod != 100)
        //        {
        //            LogHelperB2C.Logger.LogError(Mesaj);
        //        }

        //    }
            
        //}
        //public void FocusedColumnChanged(DevExpress.XtraGrid.Views.Grid.GridView view, int FocusedRowHandle, int PrevFocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn, DevExpress.XtraGrid.Columns.GridColumn PrevFocusedColumn)
        //{
        //    try
        //    {
        //        doFocusedRowChanged_Satir(view);
        //    }
        //    catch (ServiceIstisna ex)
        //    {
        //        hataKod = 101;
        //        Mesaj = "Servise İstisna Hatası - detayli Aciklama: " + ex.InnerException;
        //    }
        //    catch (Exception ex)
        //    {
        //        hataKod = 102;
        //        Mesaj = "Controller Hatası - detayli Aciklama: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (hataKod != 100)
        //        {
        //            LogHelperB2C.Logger.LogError(Mesaj);
        //        }

        //    }
        //}
        //public void ProcessGridKey(DevExpress.XtraGrid.Views.Grid.GridView view, KeyEventArgs args, int FocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn)
        //{
        //    try
        //    {
        //        doFocusedRowChanged_Satir(view);
        //    }
        //    catch (ServiceIstisna ex)
        //    {
        //        hataKod = 101;
        //        Mesaj = "Servise İstisna Hatası - detayli Aciklama: " + ex.InnerException;
        //    }
        //    catch (Exception ex)
        //    {
        //        hataKod = 102;
        //        Mesaj = "Controller Hatası - detayli Aciklama: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (hataKod != 100)
        //        {
        //            LogHelperB2C.Logger.LogError(Mesaj);
        //        }

        //    }
        //}
        //#endregion
    }
}