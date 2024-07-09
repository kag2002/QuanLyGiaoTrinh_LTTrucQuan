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

namespace BTLLTTQ
{
    public partial class FormThemuon : Form
    {
        Connection con =new Connection();
        public FormThemuon()
        {
            InitializeComponent();
        }
        private void StartGroupboxChitiet(bool type)
        {
            groupBox1.Enabled = type;
        }
        private void StartButtonThemSuaXoa(bool type)
        {
            btnThem.Enabled = type;
            btnSua.Enabled = type;
            btnXoa.Enabled = type;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            hienkq(radioButton1, radioButton2, dataGridView1.CurrentRow.Cells[2].Value.ToString());
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            hienkq(radioButton4, radioButton3, dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim());
            textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void FormThemuon_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = con.table("Select * from TheMuon");
            for(int i=0;i<con.MaHTap("Select MaKhoa from Khoa").Count; i++)
            {
                comboBox1.Items.Add(con.MaHTap("Select MaKhoa from Khoa")[i]);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            StartGroupboxChitiet(true);
            StartButtonThemSuaXoa(false);
            btnThem.Enabled = true;
            textBox1.Enabled=true;
            radioButton3.Checked = true;
            textBox3.Text = "0";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            StartGroupboxChitiet(true);
            StartButtonThemSuaXoa(false);
            btnSua.Enabled = true;
            textBox1.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            StartGroupboxChitiet(true);
            StartButtonThemSuaXoa(false);
            btnXoa.Enabled = true;
            textBox1.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            StartGroupboxChitiet(false);
            StartButtonThemSuaXoa(true);
            textBox1.Text = "";
            textBox2.Text = "";
            radioButton1.Checked=false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox3.Text = "";
        }
        private bool ischeck()
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống mã thẻ");
                return false;
            }
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống họ tên");
                return false;
            }
            if(radioButton1.Checked==false && radioButton2.Checked == false)
            {
                MessageBox.Show("Chưa chọn giới tính");
                return false;
            }
            if (comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Chưa chọn mã khoa");
                return false;
            }
            if (comboBox2.Text.Trim() == "")
            {
                MessageBox.Show("Chưa chọn mã lớp");
                return false;
            }
            if (radioButton3.Checked == false && radioButton4.Checked == false)
            {
                MessageBox.Show("Chưa chọn khóa thẻ");
                return false;
            }
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống số lượng mượn");
                return false;
            }
            return true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled=true;
            }
        }
        private string ketquachon(RadioButton a,RadioButton b)
        {
            string kq="";
            if (a.Checked)
            {
                 kq=a.Text;
            }
            if (b.Checked)
            {
                kq= b.Text;
            }
            return kq;
        }
        private void hienkq(RadioButton a,RadioButton b, string str)
        {
            if (a.Text == str)
            {
                a.Checked=true;
            }
            if(b.Text == str)
            {
                b.Checked=true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled && ischeck())
            {
                    string query = $"Insert into TheMuon " +
              $"values(N'{textBox1.Text}',N'{textBox2.Text}',N'{ketquachon(radioButton1,radioButton2)}',N'{comboBox2.Text}',N'{comboBox1.Text}','{ketquachon(radioButton3,radioButton4)}',{int.Parse(textBox3.Text)})";

                    if (MessageBox.Show("Bạn có muốn thêm thẻ mượn không", "Thông báo", MessageBoxButtons.YesNo
                              , MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                    try
                    {
                        con.Excute(query);
                        MessageBox.Show("Thêm thẻ mượn thành công");
                        dataGridView1.DataSource = con.table("Select * from TheMuon");
                    }
                    catch
                    {
                        MessageBox.Show("mã thẻ bị trùng");
                    }
                }  
            }
            if (btnSua.Enabled && ischeck())
            {

                
                string query = String.Format("Update TheMuon set HoTen=N'{0}',GioiTinh=N'{1}',MaLop=N'{2}',MaKhoa=N'{3}',KhoaThe='{4}'," +
                                         "SLMuon={5} Where MaThe=N'{6}'",
                             textBox2.Text, ketquachon(radioButton1, radioButton2), comboBox2.Text, comboBox1.Text, ketquachon(radioButton3, radioButton4), int.Parse(textBox3.Text), textBox1.Text);
                if (MessageBox.Show("Bạn có muốn sửa thẻ mượn không?", "Thông báo", MessageBoxButtons.YesNo
                                   , MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    con.Excute(query);
                    MessageBox.Show("Sửa thẻ mượn thành công");
                    dataGridView1.DataSource = con.table("Select * from TheMuon");
                }
            }
            if (btnXoa.Enabled)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn mã sản phẩm muốn xóa");
                }
                else
                {
                    
                    string query = "Delete from TheMuon Where MaThe=N'" + textBox1.Text+"'";
                    if (MessageBox.Show("Bạn có muốn xóa thẻ mượn không", "Thông báo", MessageBoxButtons.YesNo
                         , MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            con.Excute(query);
                            MessageBox.Show("Xóa thẻ mượn thành công");
                            dataGridView1.DataSource = con.table("Select * from TheMuon");
                        }
                        catch
                        {
                            MessageBox.Show("Còn dữ liệu không xóa được");
                        }
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            comboBox2.Items.Clear();
            string query = "Select MaLop from Lop where MaKhoa=N'" + comboBox1.Text+"'";
            for(int i = 0; i < con.MaHTap(query).Count; i++)
            {
                comboBox2.Items.Add(con.MaHTap(query)[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = textBox4.Text.Trim();
            if (sql == "")
            {
                MessageBox.Show("Bạn cần nhập họ tên cần tìm kiếm");
            }
            else
            {
                string query = "Select * from TheMuon where HoTen like N'%" + sql + "%'";
                dataGridView1.DataSource = con.table(query);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            radioButton1.Checked = false; 
            radioButton2.Checked=false;
            comboBox2.Text = "";
            comboBox1.Text = "";
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            textBox3.Text = "";
            textBox4.Text = "";
            dataGridView1.DataSource = con.table("Select * from TheMuon");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
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
