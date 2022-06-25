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
    public partial class Form2 : Form
    {
        CRUD1 crud1 = new CRUD1();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 hewan = new Form1();
           hewan.Show();
            this.Hide();
        }

        private void add1_b_Click(object sender, EventArgs e)
        {
            CREATE1();
            READ1();
            MessageBox.Show("Berhasil Tambah Data");
        }

        private void update1_b_Click(object sender, EventArgs e)
        {
            UPDATE1();
            READ1();
            MessageBox.Show("Berhasil Update Data");
        }

        private void delete1_b_Click(object sender, EventArgs e)
        {
            DELETE1();
            READ1();
            MessageBox.Show("Berhasil Hapus Data");
        }
        public void READ1()
        {
            dataGridView2.DataSource = null;
            crud1.Read_data1();
            dataGridView2.DataSource = crud1.dt;
        }
        public void CREATE1()
        {
            crud1.tgl = tgl_t1.Text;
            crud1.ket = keluar_t.Text;
            crud1.msk = masuk_t.Text;
            crud1.klr = keluar_t.Text;
            crud1.Create_data1();
        }
        public void UPDATE1()
        {
            crud1.tgl = u_tgl.Text;
            crud1.ket = u_ket.Text;
            crud1.msk = u_masuk.Text;
            crud1.klr = u_keluar.Text;
            crud1.id_transaksi = id1_t.Text;
            crud1.Update_data1();
        }
        public void DELETE1()
        {
            crud1.id_transaksi = id1_t.Text;
            crud1.Delete_data1();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    id1_t.Text = (dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                    u_tgl.Text = (dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString());
                    u_masuk.Text = (dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString());
                    u_keluar.Text = (dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString());
                    u_ket.Text = (dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Don't Click The Header!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            READ1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 pangan = new Form3();
            pangan.Show();
            this.Hide();
        }
    }
 }

