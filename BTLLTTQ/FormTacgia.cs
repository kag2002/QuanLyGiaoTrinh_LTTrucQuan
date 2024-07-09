using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTLLTTQ
{
    public partial class FormTacgia : Form
    {
        Connection con =new Connection();
        public FormTacgia()
        {
            InitializeComponent();
            for(int i = 0; i<con.MaHTap("Select MaKhoa from Khoa").Count; i++)
            {
                comboBox1.Items.Add(con.MaHTap("Select MaKhoa from Khoa")[i]);
            }
            for (int i = 0; i < con.MaHTap("Select MaTrinhDo from TrinhDo").Count; i++)
            {
                comboBox2.Items.Add(con.MaHTap("Select MaTrinhDo from TrinhDo")[i]);
            }
        }

        private void FormTacgia_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource=con.table("Select * from TacGia");
        }
        private bool ischeck()
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Mã tác giả trống");
                return false;
            }
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Tên tác giả trống");
                return false;
            }
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Năm sinh tác giả trống");
                return false;
            }
            if (comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Mã khoa trống");
                return false;
            }
            if (comboBox2.Text.Trim() == "")
            {
                MessageBox.Show("Mã trình độ trống");
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled=true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (ischeck())
            {

                string query = String.Format("insert into TacGia values(N'{0}',N'{1}',N'{2}',{3},N'{4}')",
                   textBox1.Text, textBox2.Text, comboBox1.Text, int.Parse(textBox3.Text.Trim()),comboBox2.Text);
                if (MessageBox.Show("Bạn có muốn thêm tác giả không", "Thông báo", MessageBoxButtons.YesNo
                              , MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        con.Excute(query);
                        MessageBox.Show("Thêm tác giả thành công");
                        dataGridView1.DataSource = con.table("Select * from TacGia");
                    }
                    catch
                    {
                        MessageBox.Show("Mã trùng");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0 && ischeck())
            {
                string query = String.Format("update TacGia set TenTacGia=N'{0}',MaKhoa=N'{1}',NamSinh={2},MaTrinhDo=N'{3}'" +
                    "where MaTacGia=N'{4}'",
                   textBox2.Text, comboBox1.Text, int.Parse(textBox3.Text.Trim()), comboBox2.Text, textBox1.Text);
                if (MessageBox.Show("Bạn có sửa thông tin tác giả không", "Thông báo", MessageBoxButtons.YesNo
                              , MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    con.Excute(query);
                    MessageBox.Show("sửa  thông tin tác giả thành công");
                    dataGridView1.DataSource = con.table("Select * from TacGia");

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0 && textBox1.Text.Trim()!="")
            {
                string query = String.Format("delete from TacGia where MaTacGia='{0}'",
                    textBox1.Text);
                if (MessageBox.Show("Bạn có xóa tác giả không", "Thông báo", MessageBoxButtons.YesNo
                              , MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        con.Excute(query);
                        MessageBox.Show("Xóa tác giả thành công");
                        dataGridView1.DataSource = con.table("Select * from TacGia");
                    }
                    catch
                    {
                        MessageBox.Show("Còn dữ liệu không xóa được");
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text  = "";
            textBox2.Text  = "";
            comboBox1.Text = "";
            textBox3.Text  = "";
            comboBox2.Text = "";
            dataGridView1.DataSource = con.table("Select * from TacGia");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sql = textBox2.Text.Trim();
            if (sql == "")
            {
                MessageBox.Show("Bạn cần nhập tên tác giả tìm kiếm");
            }
            else
            {
                string query = "Select * from TacGia where TenTacGia like N'%" + sql + "%'";
                dataGridView1.DataSource = con.table(query);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(96, 155, 173), 1);
            Rectangle rectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            graphics.FillRectangle(linearGradientBrush, rectangle);
            graphics.DrawRectangle(pen, rectangle);
        }
    }
}
