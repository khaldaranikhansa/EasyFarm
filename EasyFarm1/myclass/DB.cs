using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace EasyFarm1
{
    internal class DB
    {
        public MySqlConnection Conn;

        public DB()
        {
            string host = "localhost";
            string db = "easyfarm";
            string port = "3306";
            string user = "root";
            string pass = "";
            string constring = "datasource =" +host +";database =" + db+"; port =" + port +"; username =" + user + "; password =" + pass +"; SslMode=none";
            Conn = new MySqlConnection(constring);

        }
    }
    class CRUD:DB
    {
        public string name { set; get; }
        public string weight { set; get; }
        public string age { set; get; }
        public string id_Hewan { set; get; }


        public DataTable dt= new DataTable();
        private DataSet ds= new DataSet();




        //CREATE

        public void Create_data()
        {
            Conn.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO `hewan`(`nama_Hewan`, `Berat_Hewan`, `Umur_Hewan`) VALUES (@name,@weight,@age)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Conn;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@weight", MySqlDbType.VarChar).Value = weight;
                cmd.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;

                cmd.ExecuteNonQuery();
                Conn.Close();
            }
        }

        //UPDATE

        public void Update_data()
        {
            Conn.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE hewan SET nama_Hewan=@name, Berat_Hewan=@weight, Umur_Hewan=@age WHERE id_Hewan=@id_Hewan";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Conn;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@weight", MySqlDbType.VarChar).Value = weight;
                cmd.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;
                cmd.Parameters.Add("@id_Hewan", MySqlDbType.VarChar).Value = id_Hewan;

                cmd.ExecuteNonQuery();
                Conn.Close();
            }
        }

        //DELETE
        public void Delete_data()
        {
            Conn.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE from hewan WHERE id_Hewan=@id_Hewan";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Conn;

                cmd.Parameters.Add("@id_Hewan", MySqlDbType.VarChar).Value = id_Hewan;

                cmd.ExecuteNonQuery();
                Conn.Close();
            }
        }

        //READ
        public void Read_data()
        {
            dt.Clear();
            string query = "SELECT * FROM `hewan`";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, Conn);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
