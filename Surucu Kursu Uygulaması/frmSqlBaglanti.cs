using System.Data.SqlClient;
using System.Data;
namespace Surucu_Kursu_Uygulaması
{
    internal class frmSqlBaglanti
    {
        private string baglantiYolu = "Data Source=HUSEYIN\\SQLEXPRESS;Initial Catalog=SurucuKursuDB;Integrated Security=True;Encrypt=False";

        public SqlConnection baglan()
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();
            return baglanti;

        }
    }
}
