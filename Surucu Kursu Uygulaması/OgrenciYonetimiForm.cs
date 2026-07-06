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
    public partial class OgrenciYonetimiForm : Form
    {
        public OgrenciYonetimiForm()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_OgrenciEkleGuncelle", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCNo", txtTC.Text);
                    cmd.Parameters.AddWithValue("@Ad", txtAd.Text);
                    cmd.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                    cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                    cmd.Parameters.AddWithValue("@kayittarihi", dateTimePicker1.Value);


                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Öğrenci başarıyla eklendi veya güncellendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
       
        private void btnSil_Click_1(object sender, EventArgs e)
        {    if (string.IsNullOrWhiteSpace(txtTC.Text))
            {
                MessageBox.Show("Lütfen silinecek öğrencinin TC numarasını giriniz.");
                return;
            }

            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlCommand cmd = new SqlCommand("sp_OgrenciSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TCNo", txtTC.Text);

                cmd.Parameters.Add("@Mesaj", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Kod", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                string mesaj = cmd.Parameters["@Mesaj"].Value.ToString();
                MessageBox.Show(mesaj);
            }

        }

        private void btnListele_Click_Click(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_OgrenciListele", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();

            using (SqlConnection conn = bgl.baglan())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM OgrenciLog ORDER BY IslemTarihi DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
