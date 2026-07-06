using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surucu_Kursu_Uygulaması
{
    public partial class DersYonetimiForm : Form
    {
        public DersYonetimiForm()
        {
            InitializeComponent();
        }
       
        private void btnDersEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDersAdi.Text))
            {
                MessageBox.Show("Lütfen ders adını giriniz.");
                return;
            }

            if (cmbDersTuru.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen ders türünü seçiniz.");
                return;
            }

            if (cmbEgitmen.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen eğitmen seçiniz.");
                return;
            }

            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlCommand cmd = new SqlCommand("sp_DersEkleGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DersAdi", txtDersAdi.Text);
                cmd.Parameters.AddWithValue("@DersTuru", cmbDersTuru.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@EgitmenID", cmbEgitmen.SelectedValue);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Ders başarıyla eklendi.");
            }
        }

        private void DersYonetimiForm_Load_1(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT EgitmenID, Ad + ' ' + Soyad AS EgitmenAdi FROM Egitmen", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbEgitmen.DisplayMember = "EgitmenAdi";  
                cmbEgitmen.ValueMember = "EgitmenID";     
                cmbEgitmen.DataSource = dt;              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtDersAdi.Text) || string.IsNullOrWhiteSpace(cmbDersTuru.SelectedItem?.ToString()))
            {
                MessageBox.Show("Lütfen silinecek dersin adını ve türünü giriniz.");
                return;
            }

            using (var conn = new frmSqlBaglanti().baglan())
            {
                using (var cmd = new SqlCommand("sp_DersSil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DersAdi", txtDersAdi.Text);
                    cmd.Parameters.AddWithValue("@DersTuru", cmbDersTuru.SelectedItem.ToString()); 

                    cmd.Parameters.Add("@Mesaj", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Kod", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(cmd.Parameters["@Mesaj"].Value.ToString());
                }
        }   }

        private void label2_Click(object sender, EventArgs e)
        {
            using (var conn = new frmSqlBaglanti().baglan())
            {
                using (var cmd = new SqlCommand("sp_DersListele", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
}
