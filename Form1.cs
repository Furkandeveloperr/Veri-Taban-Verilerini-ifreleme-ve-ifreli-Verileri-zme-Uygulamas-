using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ŞİFRELİ_VERİLRRR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@ "Data source = DESTKOP - B1PO0435 / SQLEXPRESS; Initial
        Catalog = Test;ıntegrated security = true");
       void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select* From TBLVERILER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
       private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = TxtAd.Text;
            byte[] addizi = ASCIIEncoding.ASCII.GetBytes(ad);
            string adsifre = Convert.ToBase64String(addizi);
            label6.Text = adsifre;

            string soyad = TxtSoyad.Text;
            byte[] soyaddizi = ASCIIEncoding.ASCII.GetBytes(soyad);
            string soyadsifre = Convert.ToBase64String(soyaddizi);

            string mail = TxtMail.Text;
            byte[] maildizi = ASCIIEncoding.ASCII.GetBytes(mail);
            string mailsifre = Convert.ToBase64String(maildizi);

            string sifre = TxtSifre.Text;
            byte[] sifredizi = ASCIIEncoding.ASCII.GetBytes(sifre);
            string sifresifre = Convert.ToBase64String(sifredizi);

            string hesapno = TxtHesapNo.Text;
            byte[] hesapnodizi = ASCIIEncoding.ASCII.GetBytes(hesapno);
            string hesapnosifre = Convert.ToBase64String(hesapnodizi);

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLVERILERRR 
                (AD, SOYAD, MAIL, SIFRE, HESAPNO) values(@p1, @p2, @p3, @p4, @p5)",baglanti);
                komut.Parameters.AddWithValue("@p1", adsifre);
            komut.Parameters.AddWithValue("@p1", soyadsifre);
            komut.Parameters.AddWithValue("@p1", mailsifre);
            komut.Parameters.AddWithValue("@p1", sifresifre);
            komut.Parameters.AddWithValue("@p1", hesapnosifre);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("veriler Eklendi");
        }

        private void form1_load(object sender,EventArgs e)
        {
            listele()
        }

        private void şifreçöz_Click(object sender, EventArgs e)
        {
            string adcozum = TxtAd.Text;
            byte[] adcozumdizi = Convert.FromBase64String(adcozum);
            string adverisi = ASCIIEncoding.ASCII.GetString(adcozumdizi);
            label6.Text= adverisi 
        }
    }

    }
}
