using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace EasyFarm1
{
    internal class DB2
    {
        public MySqlConnection con;

        public DB2()
        {
            string host = "localhost";
            string db = "easyfarm";
            string port = "3306";
            string user = "root";
            string pass = "";
            string constring = "datasource =" + host + ";database =" + db + "; port =" + port + "; username =" + user + "; password =" + pass + "; SslMode=none";
            con = new MySqlConnection(constring);

        }
    }
    class CRUD2 : DB2
    {
        public string name1 { set; get; }
        public string weight1 { set; get; }
        public string id_pangan { set; get; }


        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();




        //CREATE

        public void Create_data2()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO `pangan`(`nama_pangan`, `berat_pangan`) VALUES (@name1,@weight1)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@name1", MySqlDbType.VarChar).Value = name1;
                cmd.Parameters.Add("@weight1", MySqlDbType.VarChar).Value = weight1;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //UPDATE

        public void Update_data2()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE pangan SET nama_pangan=@name1, berat_pangan=@weight1 WHERE id_pangan=@id_pangan";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@name1", MySqlDbType.VarChar).Value = name1;
                cmd.Parameters.Add("@weight1", MySqlDbType.VarChar).Value = weight1;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //DELETE
        public void Delete_data2()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE from pangan WHERE id_pangan=@id_pangan";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_pangan", MySqlDbType.VarChar).Value = id_pangan;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //READ
        public void Read_data2()
        {
            dt.Clear();
            string query = "SELECT * FROM `pangan`";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
