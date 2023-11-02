using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLL
    {
        DatabaseLogicLayer.DLL dll;
        public BLL()
        {
            dll = new DatabaseLogicLayer.DLL();
        }
        public int KayitEkle(string isim, string soyisim, string TelefonNumarasiI, string TelefonNumarasiII, string TelefonNumarasiIII,
                             string EmailAdres, string WebAdres, string Adres, string Aciklama)
        {
            if (!string.IsNullOrEmpty(isim) && !string.IsNullOrEmpty(soyisim) && !string.IsNullOrEmpty(TelefonNumarasiI))
            {
                return dll.KayitEkle(new Entities.Rehber()
                {
                    ID = Guid.NewGuid(),
                    Isim = isim,
                    Soyisim = soyisim,
                    TelefonNumarasiI = TelefonNumarasiI,
                    TelefonNumarasiII = TelefonNumarasiII,
                    TelefonNumarasiIII = TelefonNumarasiIII,
                    EmailAdres = EmailAdres,
                    WebAdres = WebAdres,
                    Adres = Adres,
                    Aciklama = Aciklama
                });
            }
            else 
            { 
            return -1; // Eksik parametre hatası
            }    
        }
    }
}
