using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelefonRehberi
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btn_New_Registry_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            int ReturnValue = BLL.KayitEkle(
                                            txt_Name_New.Text,
                                            txt_Surname_New.Text,
                                            txt_Email_New.Text,
                                            txt_Phone1_New.Text,
                                            txt_Phone2_New.Text,
                                            txt_Phone3_New.Text,
                                            txt_WebAddress_New.Text,
                                            txt_Address_New.Text,
                                            txt_Description_New.Text
                                            );
            if (ReturnValue > 0)
            {
                ListeDoldur(); // Yeni Kayıt sonrası listeyi yeniden doldursun :D
                MessageBox.Show("Yeni Kayıt Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt eklenemedi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            ListeDoldur();
        }

        private void ListeDoldur()
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            List<Rehber> listeRehber = bll.KayitListele();
            if (listeRehber != null && listeRehber.Count > 0)
            {
                lst_liste.DataSource = listeRehber;
            }

        }

        private void lst_liste_DoubleClick(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;
            Rehber secilenKayit = (Rehber)lst.SelectedItem;
            if (secilenKayit != null)
            {
                txt_Name_Update.Text        = secilenKayit.Isim;
                txt_Surname_Update.Text     = secilenKayit.Soyisim;
                txt_Phone1_Update.Text      = secilenKayit.TelefonNumarasiI;
                txt_Phone2_Update.Text      = secilenKayit.TelefonNumarasiII;
                txt_Phone3_Update.Text      = secilenKayit.TelefonNumarasiIII;
                txt_Email_Update.Text       = secilenKayit.EmailAdres;
                txt_WebAddress_Update.Text  = secilenKayit.WebAdres;
                txt_Address_Update.Text     = secilenKayit.Adres;
                txt_Description_Update.Text = secilenKayit.Aciklama;
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            Guid id = ((Rehber)lst_liste.SelectedItem).ID;

            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            int ReturnValues =  bll.KayitDuzenle(id,
                                txt_Name_Update.Text,
                                txt_Surname_Update.Text,
                                txt_Phone1_Update.Text,
                                txt_Phone2_Update.Text,
                                txt_Phone3_Update.Text,
                                txt_Email_Update.Text,
                                txt_WebAddress_Update.Text,
                                txt_Address_Update.Text,
                                txt_Description_Update.Text
                            );
            if(ReturnValues > 0)
            {
                ListeDoldur();
                MessageBox.Show("Kayıt Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else
            {
                MessageBox.Show("Kayıt Güncellenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Guid id = ((Rehber)lst_liste.SelectedItem).ID;
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            int ReturnValues = bll.KayitSil(id);
            if (ReturnValues > 0 )
            {
                ListeDoldur();
                MessageBox.Show("Kayıt Silindi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt Güncellenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    } 
}