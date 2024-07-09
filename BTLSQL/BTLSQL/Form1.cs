using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTLSQL
{
    public partial class Form1 : Form
    {
        ConectData conectData = new ConectData();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            conectData.Connect();
            DataTable dt = conectData.table("select * from MatHang");
            dataGridView1.DataSource = dt;
            conectData.closeConnect();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox20.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox21.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox22.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox23.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox24.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox25.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox26.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox27.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox28.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form p = new Form2();
            p.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conectData.Connect();
            conectData.insert(textBox20.Text, textBox21.Text, textBox22.Text, textBox23.Text, textBox24.Text, Convert.ToInt32(textBox25.Text), textBox26.Text, Convert.ToInt32(textBox27.Text), Convert.ToInt32(textBox28.Text));
            DataTable dt = conectData.table("select * from MatHang");
            dataGridView1.DataSource = dt;
            conectData.closeConnect();
            reset();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conectData.Connect();
            conectData.update(textBox20.Text, textBox21.Text, textBox22.Text, textBox23.Text, textBox24.Text, Convert.ToInt32(textBox25.Text), textBox26.Text, Convert.ToInt32(textBox27.Text), Convert.ToInt32(textBox28.Text));
            DataTable dt = conectData.table("select * from MatHang");
            dataGridView1.DataSource = dt;
            conectData.closeConnect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conectData.Connect();
            DataTable dt = conectData.table("select * from inkhach");
            dataGridView1.DataSource = dt;
            conectData.closeConnect();
        }
        void reset()
        {
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            reset();
            conectData.Connect();
            DataTable dt = conectData.table("select * from MatHang");
            dataGridView1.DataSource = dt;
            conectData.closeConnect();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
