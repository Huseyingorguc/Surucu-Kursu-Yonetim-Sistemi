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
    public partial class OdemeYonetimiForm : Form
    {
        public OdemeYonetimiForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbOgrenci.SelectedValue == null || string.IsNullOrWhiteSpace(txtTutar.Text) || string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                MessageBox.Show("Lütfen gerekli tüm alanları doldurunuz.");
                return;
            }


            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlCommand cmd = new SqlCommand("sp_OdemeEkleGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OgrenciID", Convert.ToInt32(cmbOgrenci.SelectedValue));
                cmd.Parameters.AddWithValue("@Tutar", Convert.ToDecimal(txtTutar.Text));
                cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Ödeme kaydı başarıyla eklendi/güncellendi.");
            }
        }

        private void OdemeYonetimiForm_Load(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT OgrenciID, Ad + ' ' + Soyad AS AdSoyad FROM Ogrenci", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbOgrenci.DataSource = dt;
                cmbOgrenci.DisplayMember = "AdSoyad"; 
                cmbOgrenci.ValueMember = "OgrenciID"; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek bir kayıt seçin.");
                return;
            }

            int odemeID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["OdemeID"].Value);

            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlCommand cmd = new SqlCommand("sp_OdemeSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OdemeID", odemeID);
                cmd.Parameters.Add("@Mesaj", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Kod", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                string mesaj = cmd.Parameters["@Mesaj"].Value.ToString();
                MessageBox.Show(mesaj);
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlCommand cmd = new SqlCommand("sp_OdemeListele", conn);
                cmd.CommandType = CommandType.StoredProcedure;

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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM OdemeLog ORDER BY IslemTarihi DESC", conn);
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
               
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM v_OgrenciSonOdeme", conn);

               
                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
    }
}
