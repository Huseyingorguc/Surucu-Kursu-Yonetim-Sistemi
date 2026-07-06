using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Surucu_Kursu_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciYonetimiForm ogrenciForm = new OgrenciYonetimiForm();
            ogrenciForm.Show();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EgitmenYonetimiForm egitmenForm = new EgitmenYonetimiForm();
            egitmenForm.Show();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DersYonetimiForm dersForm = new DersYonetimiForm();
            dersForm.Show();  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OgrenciDersYonetimiForm ogrenciDersForm = new OgrenciDersYonetimiForm();
            ogrenciDersForm.Show();  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OdemeYonetimiForm odemeForm = new OdemeYonetimiForm();
            odemeForm.Show();  
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AracYonetimiForm aracForm = new AracYonetimiForm();
            aracForm.Show();  
        }
        private void button7_Click(object sender, EventArgs e)
        {
            SinavYonetimiForm sinavForm = new SinavYonetimiForm();
            sinavForm.Show();  
        }
    }
}
