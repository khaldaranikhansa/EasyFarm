using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EasyFarm1
{
    public partial class Form1 : Form
    {
        CRUD crud = new CRUD();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create
            CREATE();
            READ();
            MessageBox.Show("Berhasil Tambah Data");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update
            UPDATE();
            READ();
            MessageBox.Show("Berhasil Update Data");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delete
            DELETE();
            READ();
            MessageBox.Show("Berhasil Hapus Data");
        }
        public void READ()
        {
            dataGridView1.DataSource = null;
            crud.Read_data();
            dataGridView1.DataSource = crud.dt;
        }
        public void CREATE()
        {
            crud.name = name.Text;
            crud.weight = weight.Text;
            crud.age = age.Text;
            crud.Create_data();
        }
        public void UPDATE()
        {
            crud.name = u_name.Text;
            crud.weight = u_weight.Text;
            crud.age = u_age.Text;
            crud.id_Hewan = id.Text;
            crud.Update_data();
        }
        public void DELETE()
        {
            crud.id_Hewan = id.Text;
            crud.Delete_data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Get Data
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    id.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    u_name.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    u_weight.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    u_age.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Don't Click The Header!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           //
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 transaksi = new Form2();
            transaksi.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Hasil
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            READ();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 pangan = new Form3();
            pangan.Show();
            this.Hide();

        }
    }
}
