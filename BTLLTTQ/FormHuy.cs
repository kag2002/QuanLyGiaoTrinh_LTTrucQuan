using BTLLTTQ;
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
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTLLTTQ
{
    public partial class FormHuy : Form
    {
        Connection DBconnection = new Connection();
        public FormHuy()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = DBconnection.table("Select * from DMGiaoTrinh");
            dataGridView1.DataSource = dt;
            DataTable dt2 = DBconnection.table("Select MaTacGia from TacGia");
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "MaTacGia";
            DataTable dt3 = DBconnection.table("Select MaChuyenNganh from ChuyenNganh");
            comboBox2.DataSource = dt3;
            comboBox2.DisplayMember = "MaChuyenNganh";
        }
        private bool check0()
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show(" Vui lòng nhập tên cùa giáo trình", "Thông báo");
                return false;
            }
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên của tác giả giáo trình", "Thông báo");
                return false;
            }
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập chuyên ngành cùa giáo trình", "Thông báo");
                return false;
            }
            return true;
        }

        private bool check1()
        {
            if (textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng không để trống", "Thông báo");
                return false;
            }
            if (textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng không để trống", "Thông báo");
                return false;
            }
            if (comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng không để trống", "Thông báo");
                return false;
            }
            if (textBox7.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng không để trống", "Thông báo");
                return false;
            }
            if (textBox8.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng không để trống", "Thông báo");
                return false;
            }
            if (comboBox2.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng không để trống", "Thông báo");
                return false;
            }
            if (textBox10.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng không để trống", "Thông báo");
                return false;
            }
            if (textBox11.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng không để trống", "Thông báo");
                return false;
            }
            if (textBox12.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng không để trống", "Thông báo");
                return false;
            }
            return true;
        }
        private void resetForm0()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void resetForm1()
        {
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox2.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Enabled = false;
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (check0())
            {

                string query = $"Select TenTacGia,TenChuyenNganh,DMGiaoTrinh.* from DMGiaoTrinh join TacGia on DMGiaoTrinh.MaTacGia=TacGia.MaTacGia join ChuyenNganh on DMGiaoTrinh.MaChuyenNganh=ChuyenNganh.MaChuyenNganh where TenGT = N'{textBox1.Text.Trim()}' and TenTacGia = N'{textBox2.Text.Trim()}' and TenChuyenNganh = N'{textBox3.Text.Trim()}'";
                try
                {
                    dataGridView1.DataSource = DBconnection.table(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (check1())
            {
                string query = $"Insert into DMGiaoTrinh values(N'{textBox4.Text}',N'{textBox5.Text}',N'{comboBox1.Text}',{int.Parse(textBox7.Text)},{int.Parse(textBox8.Text)},N'{comboBox2.Text}',{int.Parse(textBox10.Text)},N'{textBox11.Text}',{int.Parse(textBox12.Text)})";
                if (MessageBox.Show("Bạn có muốn thêm môn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        DBconnection.Excute(query);
                        MessageBox.Show("Thêm thành công!", "Thông báo");
                        Form1_Load(sender, e);
                        resetForm1();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + "Mã GT đã tồn tại vui lòng nhập mã khác!", "Thông báo");
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (check1())
            {
              
                string query = $"Update DMGiaoTrinh set TenGT = N'{textBox5.Text}',MaTacGia = N'{comboBox1.Text}',NamXB = {int.Parse(textBox7.Text)},LanTB = {int.Parse(textBox8.Text)},MaChuyenNganh = N'{comboBox2.Text}',SoTrang = {int.Parse(textBox10.Text)},TomTatND = N'{textBox11.Text}',SoLuongGT = {int.Parse(textBox12.Text)} where MaGT = N'{textBox4.Text.Trim()}'";
                if (MessageBox.Show("Bạn có muốn sửa khách hàng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        DBconnection.Excute(query);
                        MessageBox.Show("Sửa thành công!", "Thông báo");
                        Form1_Load(sender, e);
                        resetForm1();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Thông báo");
                    }
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string query = "delete from DMGiaoTrinh where MaGT = '" + s + "'";
                DBconnection.Excute(query);
                Form1_Load(sender, e);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(96, 155, 173), 1);
            Rectangle rectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            graphics.FillRectangle(linearGradientBrush, rectangle);
            graphics.DrawRectangle(pen, rectangle);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(textBox2.Text.Trim()=="" && textBox3.Text.Trim() == "" && textBox1.Text.Trim() != "")
            {
                string query = String.Format("Select DMGiaoTrinh.* from\r\nDMGiaoTrinh join TacGia on DMGiaoTrinh.MaTacGia=TacGia.MaTacGia\r\njoin ChuyenNganh on " +
                    "ChuyenNganh.MaChuyenNganh=DMGiaoTrinh.MaChuyenNganh where TenGT like N'%{0}%'",textBox1.Text);
                dataGridView1.DataSource = DBconnection.table(query);
            }
            if (textBox1.Text.Trim() == "" && textBox3.Text.Trim() == "" && textBox2.Text.Trim() != "")
            {
                string query = String.Format("Select DMGiaoTrinh.* from\r\nDMGiaoTrinh join TacGia on DMGiaoTrinh.MaTacGia=TacGia.MaTacGia\r\njoin ChuyenNganh on " +
                    "ChuyenNganh.MaChuyenNganh=DMGiaoTrinh.MaChuyenNganh where TenTacGia like N'%{0}%'", textBox2.Text);
                dataGridView1.DataSource = DBconnection.table(query);
            }
            if (textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "" && textBox3.Text.Trim() != "")
            {
                string query = String.Format("Select DMGiaoTrinh.* from\r\nDMGiaoTrinh join TacGia on DMGiaoTrinh.MaTacGia=TacGia.MaTacGia\r\njoin ChuyenNganh on " +
                    "ChuyenNganh.MaChuyenNganh=DMGiaoTrinh.MaChuyenNganh where TenChuyenNganh like N'%{0}%'", textBox3.Text);
                dataGridView1.DataSource = DBconnection.table(query);
            }
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() == "")
            {
                string query = String.Format("Select DMGiaoTrinh.* from\r\nDMGiaoTrinh join TacGia on DMGiaoTrinh.MaTacGia=TacGia.MaTacGia\r\njoin ChuyenNganh on " +
                    "ChuyenNganh.MaChuyenNganh=DMGiaoTrinh.MaChuyenNganh where TenGT like N'%{0}%' and TenTacGia like N'%{1}%'", textBox1.Text,textBox2.Text);
                dataGridView1.DataSource = DBconnection.table(query);
            }
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() == "" && textBox3.Text.Trim() != "")
            {
                string query = String.Format("Select DMGiaoTrinh.* from\r\nDMGiaoTrinh join TacGia on DMGiaoTrinh.MaTacGia=TacGia.MaTacGia\r\njoin ChuyenNganh on " +
                    "ChuyenNganh.MaChuyenNganh=DMGiaoTrinh.MaChuyenNganh where TenGT like N'%{0}%' and TenChuyenNganh like N'%{1}%'", textBox1.Text, textBox3.Text);
                dataGridView1.DataSource = DBconnection.table(query);
            }
            if (textBox1.Text.Trim() == "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "")
            {
                string query = String.Format("Select DMGiaoTrinh.* from\r\nDMGiaoTrinh join TacGia on DMGiaoTrinh.MaTacGia=TacGia.MaTacGia\r\njoin ChuyenNganh on " +
                    "ChuyenNganh.MaChuyenNganh=DMGiaoTrinh.MaChuyenNganh where TenTacGia like N'%{0}%' and TenChuyenNganh like N'%{1}%'", textBox2.Text, textBox3.Text);
                dataGridView1.DataSource = DBconnection.table(query);
            }
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "")
            {
                string query = String.Format("Select DMGiaoTrinh.* from\r\nDMGiaoTrinh join TacGia on DMGiaoTrinh.MaTacGia=TacGia.MaTacGia\r\njoin ChuyenNganh on " +
                    "ChuyenNganh.MaChuyenNganh=DMGiaoTrinh.MaChuyenNganh where TenGT like N'%{0}%' and TenTacGia like N'%{1}%' and TenChuyenNganh like N'%{2}%'", textBox1.Text, textBox2.Text, textBox3.Text);
                dataGridView1.DataSource = DBconnection.table(query);
            }
            if (textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "" && textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin");
            }
        }
    }
}
