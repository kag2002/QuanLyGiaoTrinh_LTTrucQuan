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
    public partial class Form2 : Form
    {
        ConectData conectData = new ConectData();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = $"select * from Cau2(N'{textBox1.Text.Trim()}')";
            conectData.Connect();
            DataTable dt = conectData.table(query);
            dataGridView1.DataSource = dt;
            conectData.closeConnect();
        }
    }
}
