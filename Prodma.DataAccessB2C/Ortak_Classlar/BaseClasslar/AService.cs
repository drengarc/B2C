using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Data;
using System.Data.SqlClient;
namespace Prodma.DataAccessB2C
{
    public abstract class AService<TCtrlEntity, TCtrlKey,TViewModel> where TCtrlEntity : EntityObject where TViewModel : IViewModel
    {
        public DateTime FisBaslangicTarih = YardimciIslemler.TarihSet1900();
        public DateTime FisBitisTarih = YardimciIslemler.TarihSet2049();
        public string ServiceSql = "";
        public int insertId;
        public int skipValue = 0;
        public int takeValue = 100;
        public int dtSongun = 30;
        public bool mesajGosterme = false;
        public int yil = 0;
        public List<TViewModel> Service_Liste_Al(TViewModel t)
        {
            try
            {
                return doService_Liste_Al(t);
            }
            catch (UpdateException ex)
            {
                throw new ServiceIstisna(ex.Message, ex.InnerException);
            }
            catch (Exception ex)
            {
                throw new ServiceIstisna(ex.Message, ex.InnerException);
            }  
        }
        public void Service_Ekle(TCtrlEntity t)
        {
            try
            {
               doService_Ekle(t);
               Globals.islemYapilanTabloAdiServiceten = t.EntityKey.EntitySetName.ToString() + "," + t.EntityKey.EntityKeyValues[0].Value; 
               //insertId = Convert.ToInt32(t.EntityKey.EntityKeyValues.ToList()[0].Value);
            }
            catch (UpdateException ex)
            {
                throw new ServiceIstisna(ex.Message, ex.InnerException);
            }
            catch (Exception ex)
            {
                throw new ServiceIstisna(ex.Message,ex.InnerException );
            }  
        }
        public void Service_Guncelle(TCtrlEntity t, TCtrlKey id)
        {

            try
            {
                doService_Guncelle(t,id);
                Globals.islemYapilanTabloAdiServiceten = t.EntityKey.EntitySetName.ToString() + "," + t.EntityKey.EntityKeyValues[0].Value; 
            }
            catch (UpdateException ex)
            {
                throw new ServiceIstisna(ex.Message, ex.InnerException);
            }
            catch (Exception ex)
            {
                throw new ServiceIstisna(ex.Message, ex.InnerException);
            }  
             
        }
        public void Service_Sil(TCtrlEntity t,TCtrlKey id)
        {
            try
            {
                Globals.islemYapilanTabloAdiServiceten = t.EntityKey.EntitySetName.ToString() + "," + t.EntityKey.EntityKeyValues[0].Value; 
                doService_Sil(t, id);
            }
            catch (Exception ex)
            {

                throw new ServiceIstisna(ex, mesajGosterme);
            }
           
             
        }
        public string MesajYaz()
        {

             return "";
        }
        public abstract void doService_Ekle(TCtrlEntity t);
        public abstract void doService_Sil(TCtrlEntity t,TCtrlKey id);
        public abstract void doService_Guncelle(TCtrlEntity t, TCtrlKey id);
        public abstract List<TViewModel> doService_Liste_Al(TViewModel t);
    }

}
