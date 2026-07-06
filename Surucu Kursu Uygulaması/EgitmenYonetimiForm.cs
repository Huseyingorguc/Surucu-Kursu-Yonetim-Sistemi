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
    public partial class EgitmenYonetimiForm : Form
    {
        public EgitmenYonetimiForm()
        {
            InitializeComponent();
        }

        private void EgitmenYonetimiForm_Load(object sender, EventArgs e)
        {
            
            this.egitmenTableAdapter.Fill(this.surucuKursuDBDataSet.Egitmen);

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_EgitmenEkleGuncelle", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Ad", txtAd.Text);
                    cmd.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                    cmd.Parameters.AddWithValue("@Brans", cmbBrans.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Eğitmen başarıyla eklendi veya güncellendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }

            }   }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Lütfen silinecek eğitmenin adını ve soyadını giriniz.");
                return;
            }

            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlCommand cmd = new SqlCommand("sp_EgitmenSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Ad", txtAd.Text);
                cmd.Parameters.AddWithValue("@Soyad", txtSoyad.Text);

                cmd.Parameters.Add("@Mesaj", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Kod", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                string mesaj = cmd.Parameters["@Mesaj"].Value.ToString();
                MessageBox.Show(mesaj);
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlCommand cmd = new SqlCommand("sp_EgitmenListele", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();

            using (SqlConnection conn = bgl.baglan())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM EgitmenLog ORDER BY IslemTarihi DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
