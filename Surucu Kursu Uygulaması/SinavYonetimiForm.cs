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
    public partial class SinavYonetimiForm : Form
    {
        public SinavYonetimiForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ogrenciID = Convert.ToInt32(cmbOgrenci.SelectedValue); 
            string sinavTuru = cmbSinavTuru.SelectedItem.ToString(); 
            string sonuc = cmbSonuc.SelectedItem.ToString(); 

            
            if (string.IsNullOrWhiteSpace(sinavTuru) || string.IsNullOrWhiteSpace(sonuc))
            {
                MessageBox.Show("Lütfen sınav türü ve sonucu seçiniz.");
                return;
            }

            
            frmSqlBaglanti bgl = new frmSqlBaglanti();         
            using (SqlConnection conn = bgl.baglan())
            {
           
                SqlCommand cmd = new SqlCommand("sp_SinavEkleGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

              
                cmd.Parameters.AddWithValue("@OgrenciID", ogrenciID);
                cmd.Parameters.AddWithValue("@SinavTuru", sinavTuru);
                cmd.Parameters.AddWithValue("@Sonuc", sonuc);

                
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sınav kaydı başarıyla eklendi.");
            }

        }

        private void SinavYonetimiForm_Load(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
               
                SqlDataAdapter da = new SqlDataAdapter("SELECT OgrenciID, Ad + ' ' + Soyad AS OgrenciAdi FROM Ogrenci", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                
                cmbOgrenci.DisplayMember = "OgrenciAdi"; 
                cmbOgrenci.ValueMember = "OgrenciID"; 
                cmbOgrenci.DataSource = dt; 
            }
            
            
        }

            private void button2_Click(object sender, EventArgs e)
            {
                if (dataGridView1.SelectedRows.Count == 0) 
                {
                    MessageBox.Show("Lütfen silinecek bir sınav seçin.");
                    return;
                }              
                int sinavID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SinavID"].Value);

                frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlCommand cmd = new SqlCommand("sp_SinavSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;         
                cmd.Parameters.AddWithValue("@SinavID", sinavID);
                cmd.Parameters.Add("@Mesaj", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Kod", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery(); 

               
                string mesaj = cmd.Parameters["@Mesaj"].Value.ToString();
                MessageBox.Show(mesaj); 

               
                if (Convert.ToInt32(cmd.Parameters["@Kod"].Value) == 0)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index); 
                }
            }


            }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSqlBaglanti bgl = new frmSqlBaglanti();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlCommand cmd = new SqlCommand("sp_SinavListele", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                dataGridView1.DataSource = dt;
            }
        }
    }
}
