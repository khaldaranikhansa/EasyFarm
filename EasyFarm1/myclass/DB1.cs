using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace EasyFarm1
{
    internal class DB1
    {
        public MySqlConnection Con;

        public DB1()
        {
            string host = "localhost";
            string db = "easyfarm";
            string port = "3306";
            string user = "root";
            string pass = "";
            string constring = "datasource =" + host + ";database =" + db + "; port =" + port + "; username =" + user + "; password =" + pass + "; SslMode=none";
            Con = new MySqlConnection(constring);

        }
    }
    class CRUD1 : DB1
    {
        public string tgl { set; get; }
        public string ket { set; get; }
        public string msk { set; get; }
        public string klr { set; get; }
        public string id_transaksi { set; get; }


        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();




        //CREATE

        public void Create_data1()
        {
            Con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO `transaksi`(`tanggal_transaksi`, `keterangan`, `nominal_masuk`, `nominal_keluar`) VALUES(@tgl,@ket,@msk,@klr)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Con;

                cmd.Parameters.Add("@tgl", MySqlDbType.VarChar).Value = tgl;
                cmd.Parameters.Add("@ket", MySqlDbType.VarChar).Value = ket;
                cmd.Parameters.Add("@msk", MySqlDbType.VarChar).Value = msk;
                cmd.Parameters.Add("@klr", MySqlDbType.VarChar).Value = klr;

                cmd.ExecuteNonQuery();
                Con.Close();
            }
        }

        //UPDATE

        public void Update_data1()
        {
            Con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE transaksi SET tanggal_transaksi=@tgl, keterangan=@ket, nominal_masuk=@msk, nominal_keluar=@klr WHERE id_transaksi=@id_transaksi";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Con;

                cmd.Parameters.Add("@tgl", MySqlDbType.VarChar).Value = tgl;
                cmd.Parameters.Add("@ket", MySqlDbType.VarChar).Value = ket;
                cmd.Parameters.Add("@msk", MySqlDbType.VarChar).Value = msk;
                cmd.Parameters.Add("@klr", MySqlDbType.VarChar).Value = klr;

                cmd.ExecuteNonQuery();
                Con.Close();
            }
        }

        //DELETE
        public void Delete_data1()
        {
            Con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE from transaksi WHERE id_transaksi=@id_transaksi";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Con;

                cmd.Parameters.Add("@id_transaksi", MySqlDbType.VarChar).Value = id_transaksi;

                cmd.ExecuteNonQuery();
                Con.Close();
            }
        }

        //READ
        public void Read_data1()
        {
            dt.Clear();
            string query = "SELECT * FROM `transaksi`";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, Con);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
