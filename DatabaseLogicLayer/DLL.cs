using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogicLayer
{
    public class DLL
    {
        SqlConnection _conn;
        SqlCommand _command;
        SqlDataReader _reader;

        int ReturnValues;

        public DLL()
        {
            _conn = new SqlConnection("Data Source=.; initial catalog = TelefonRehberi;  Integrated Security=True;");
        }
        public void BaglantiAyarla()
        {
            if(_conn.State == System.Data.ConnectionState.Closed)
            {
                _conn.Open();
            }
            else
            {
                _conn.Close();
            }
        }
        public int SistemKontrol(Kullanici kullanici)
        {
            try
            {
                _command = new SqlCommand("SELECT Count(*) FROM Kullanici WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre", _conn);
                BaglantiAyarla();
                ReturnValues = (int)_command.ExecuteScalar();

            }
            catch(Exception ex) 
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }
        public int KayitEkle(Rehber rehber)
        {
            try
            {
                _command = new SqlCommand("INSERT INTO Rehber (ID, Isim, Soyisim, TelefonNumarasiI, TelefonNumarasiII, TelefonNumarasiIII, EmailAdres, WebAdres, Adres, Aciklama)" +
                                          "VALUES(@ID, @Isim, @Soyisim, @TelefonNumarasiI, @TelefonNumarasiII, @TelefonNumarasiIII, @EmailAdres, @WebAdres, @Adres, @Aciklama)", _conn);
                _command.Parameters.Add("@ID",                  SqlDbType.UniqueIdentifier).Value = rehber.ID;
                _command.Parameters.Add("@Isım",                SqlDbType.NVarChar).Value = rehber.Isim;
                _command.Parameters.Add("@Soyisim",             SqlDbType.NVarChar).Value = rehber.Soyisim;
                _command.Parameters.Add("@TelefonNumarasiI",    SqlDbType.NVarChar).Value = rehber.TelefonNumarasiI;
                _command.Parameters.Add("@TelefonNumarasiII",   SqlDbType.NVarChar).Value = rehber.TelefonNumarasiII;
                _command.Parameters.Add("@TelefonNumarasiIII",  SqlDbType.NVarChar).Value = rehber.TelefonNumarasiIII;
                _command.Parameters.Add("@EmailAdres",          SqlDbType.NVarChar).Value = rehber.EmailAdres;
                _command.Parameters.Add("@WebAdres",            SqlDbType.NVarChar).Value = rehber.WebAdres;
                _command.Parameters.Add("@Adres",               SqlDbType.NVarChar).Value = rehber.Adres;
                _command.Parameters.Add("@Aciklama",            SqlDbType.NVarChar).Value = rehber.Aciklama;
                
                BaglantiAyarla();               // Insert cümlemizi ayarladıktan sonra bu şekilde database ile olan bağlantıyı açacağız...

                ReturnValues = _command.ExecuteNonQuery();     // Hazırladığımız SQL Sorgusunu SQL SERVER'a göndereceğiz...
                                                               // Burada yazdığımız komut kaç tane row etkilendiyse
                                                               // bunu bize interger olarak geri dönüyor.        
            }catch (Exception ex)
            {

            }
            finally { BaglantiAyarla(); }
            return ReturnValues;
        }
        public int KayitDuzenle(Rehber rehber)
        {
            try
            {
                _command = new SqlCommand(@"UPDATE Rehber 
                                            Isim = @Isim,
                                            Soyisim = @Soyisim,
                                            TelefonNumarasiI = @TelefonNumarasiI,
                                            TelefonNumarasiI = @TelefonNumarasiII,
                                            TelefonNumarasiI = @TelefonNumarasiIII,
                                            EmailAdres = @EmailAdres,
                                            Adres = @Adres,
                                            Aciklama = @Aciklama
                                            WHERE ID = @ID
                                        ",_conn);
                _command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = rehber.ID;
                _command.Parameters.Add("@Isım", SqlDbType.NVarChar).Value = rehber.Isim;
                _command.Parameters.Add("@Soyisim", SqlDbType.NVarChar).Value = rehber.Soyisim;
                _command.Parameters.Add("@TelefonNumarasiI", SqlDbType.NVarChar).Value = rehber.TelefonNumarasiI;
                _command.Parameters.Add("@TelefonNumarasiII", SqlDbType.NVarChar).Value = rehber.TelefonNumarasiII;
                _command.Parameters.Add("@TelefonNumarasiIII", SqlDbType.NVarChar).Value = rehber.TelefonNumarasiIII;
                _command.Parameters.Add("@EmailAdres", SqlDbType.NVarChar).Value = rehber.EmailAdres;
                _command.Parameters.Add("@WebAdres", SqlDbType.NVarChar).Value = rehber.WebAdres;
                _command.Parameters.Add("@Adres", SqlDbType.NVarChar).Value = rehber.Adres;
                _command.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = rehber.Aciklama;

                BaglantiAyarla();               // Insert cümlemizi ayarladıktan sonra bu şekilde database ile olan bağlantıyı açacağız...

                ReturnValues = _command.ExecuteNonQuery();     // Hazırladığımız SQL Sorgusunu SQL SERVER'a göndereceğiz...
                                                               // Burada yazdığımız komut kaç tane row etkilendiyse
                                                               // bunu bize interger olarak geri dönüyor.        
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }
        public int KayitSil(Guid Id)
        {
            try
            {
                _command = new SqlCommand(@"DELETE Rehber WHERE ID = @ID", _conn);
                _command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Id;
                
                BaglantiAyarla();               // Insert cümlemizi ayarladıktan sonra bu şekilde database ile olan bağlantıyı açacağız...

                ReturnValues = _command.ExecuteNonQuery();     // Hazırladığımız SQL Sorgusunu SQL SERVER'a göndereceğiz...
                                                               // Burada yazdığımız komut kaç tane row etkilendiyse
                                                               // bunu bize interger olarak geri dönüyor.        
            }
            catch (Exception ex)
            {

            }
            finally { BaglantiAyarla(); }
            return ReturnValues;
        }
        public SqlDataReader KayitListele()
        {
            _command = new SqlCommand("SELECT * FROM Rehber", _conn);
            BaglantiAyarla();
            return _command.ExecuteReader();
        }
        public SqlDataReader KayitListeleID(Guid id)
        {
            _command = new SqlCommand("SELECT * Rehber WHERE ID = @id", _conn);
            BaglantiAyarla();
            return _command.ExecuteReader();
        }

    }
}
