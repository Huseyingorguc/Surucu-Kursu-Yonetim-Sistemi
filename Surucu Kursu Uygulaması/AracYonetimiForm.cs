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
    public partial class AracYonetimiForm : Form
    {
        public AracYonetimiForm()
        {
            InitializeComponent();
        }

        private void AracYonetimiForm_Load(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DersID, DersAdi FROM Ders", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbDers.DisplayMember = "DersAdi";
                cmbDers.ValueMember = "DersID";
                cmbDers.DataSource = dt;

                SqlDataAdapter da2 = new SqlDataAdapter("SELECT AracID, Plaka FROM Arac", conn);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                cmbAraclar.DisplayMember = "Plaka";
                cmbAraclar.ValueMember = "AracID";
                cmbAraclar.DataSource = dt2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlCommand cmd = new SqlCommand("sp_AracEkleGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Plaka", txtPlaka.Text);
                cmd.Parameters.AddWithValue("@Marka", txtMarka.Text);
                cmd.Parameters.AddWithValue("@Model", txtModel.Text);
                cmd.Parameters.AddWithValue("@KullanilanDersID", cmbDers.SelectedValue);

                cmd.ExecuteNonQuery();
            } MessageBox.Show("Araç eklendi/güncellendi.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT a.AracID, a.Plaka, a.Marka, a.Model, d.DersAdi FROM Arac a LEFT JOIN Ders d ON a.KullanilanDersID = d.DersID", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbAraclar.SelectedValue == null)
            {
                MessageBox.Show("Lütfen silinecek aracı seçin.");
                return;
            }

            int aracID = Convert.ToInt32(cmbAraclar.SelectedValue);

            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlCommand cmd = new SqlCommand("sp_AracSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AracID", aracID);
                cmd.Parameters.Add("@Mesaj", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Kod", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                string mesaj = cmd.Parameters["@Mesaj"].Value.ToString();
                MessageBox.Show(mesaj);


            }

}

              private void button4_Click(object sender, EventArgs e)
              {
                frmSqlBaglanti bgl = new frmSqlBaglanti();
                using (SqlConnection conn = bgl.baglan())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM AracLog ORDER BY IslemTarihi  DESC", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

              }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM v_AracDersEgitmen", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }
    }   }           

