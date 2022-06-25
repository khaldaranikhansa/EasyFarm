using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyFarm1
{
    public partial class Form3 : Form
    {
        CRUD2 crud2 = new CRUD2();
        public Form3()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //READ
            READ2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CREATE
            CREATE2();
            READ2();
            MessageBox.Show("Berhasil Tambah Data");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //UPADATE
            UPDATE2();
            READ2();
            MessageBox.Show("Berhasil Hapus Data");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DELETE
            DELETE2();
            READ2();
            MessageBox.Show("Berhasil Hapus Data");
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //GRID
        }
        public void READ2()
        {
            dataGridView3.DataSource = null;
            crud2.Read_data2();
            dataGridView3.DataSource = crud2.dt;
        }
        public void CREATE2()
        {
            crud2.name1 = name_p.Text;
            crud2.weight1 = weight_p.Text;
            crud2.Create_data2();
        }
        public void UPDATE2()
        {
            crud2.name1 = name_p.Text;
            crud2.weight1 = weight_p.Text;
            crud2.id_pangan = id_p.Text;
            crud2.Update_data2();
        }
        public void DELETE2()
        {
            crud2.id_pangan = id_p.Text;
            crud2.Delete_data2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 transaksi = new Form2();
            transaksi.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 hewan = new Form1();
            hewan.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
