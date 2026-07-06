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
    public partial class OgrenciDersYonetimiForm : Form
    {
        public OgrenciDersYonetimiForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbOgrenci.SelectedItem == null || cmbDers.SelectedItem == null)
            {
                MessageBox.Show("Lütfen öğrenci ve ders seçiniz.");
                return;
            }

            int ogrenciID = (int)cmbOgrenci.SelectedValue; 
            int dersID = (int)cmbDers.SelectedValue;       
            DateTime katilimTarihi = dateTimePicker1.Value;

            using (var conn = new frmSqlBaglanti().baglan())
            {
                using (var cmd = new SqlCommand("sp_OgrenciDersEkleGuncelle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@OgrenciID", ogrenciID);
                    cmd.Parameters.AddWithValue("@DersID", dersID);
                    cmd.Parameters.AddWithValue("@KatilimTarihi", katilimTarihi);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Öğrenci dersi başarıyla eklendi veya güncellendi.");
                }
            }
        }

        private void OgrenciDersYonetimiForm_Load(object sender, EventArgs e)
        {
            LoadOgrenciComboBox();
            LoadDersComboBox();
        }
        private void LoadOgrenciComboBox()
        {
            using (var conn = new frmSqlBaglanti().baglan())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT OgrenciID, CONCAT(Ad, ' ', Soyad) AS AdSoyad FROM Ogrenci", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbOgrenci.DisplayMember = "AdSoyad";  
                cmbOgrenci.ValueMember = "OgrenciID";  
                cmbOgrenci.DataSource = dt;
            }
        }

        private void LoadDersComboBox()
        {
            using (var conn = new frmSqlBaglanti().baglan())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DersID, DersAdi FROM Ders", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbDers.DisplayMember = "DersAdi"; 
                cmbDers.ValueMember = "DersID";    
                cmbDers.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbOgrenci.SelectedValue == null || cmbDers.SelectedValue == null)
            {
                MessageBox.Show("Lütfen öğrenci ve ders seçiniz.");
                return;
            }

            using (var conn = new frmSqlBaglanti().baglan())
            {
                var cmd = new SqlCommand("sp_OgrenciDersSil", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@OgrenciID", cmbOgrenci.SelectedValue);
                cmd.Parameters.AddWithValue("@DersID", cmbDers.SelectedValue);
                cmd.Parameters.Add("@Mesaj", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Kod", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                MessageBox.Show(cmd.Parameters["@Mesaj"].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var conn = new frmSqlBaglanti().baglan())
            {
                var cmd = new SqlCommand("sp_OgrenciDersListele", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();

            using (SqlConnection conn = bgl.baglan())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM v_EgitmenDersleri", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }
    }
}
