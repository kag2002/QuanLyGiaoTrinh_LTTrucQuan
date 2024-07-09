using BTLLTTQ;
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

namespace BTLLTTQ
{
    public partial class FormK : Form
    {
         Connection connection = new Connection();
        public FormK()
        {
            InitializeComponent();
        }
        private void FormK_Load(object sender, EventArgs e)
        {
           
            DataTable dt = connection.table("Select thuthu.* from thuthu ");
            dataGridView1.DataSource = dt;
        }
        private bool check()
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Mã hstra không được để trống", "Thông báo");
                return false;
            }
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Ma thuthu không được để trống", "Thông báo");
                return false;
            }
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Ma hsm không được để trống", "Thông báo");
                return false;
            }
            if (textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại khách hàng không được để trống", "Thông báo");
                return false;
            }
           
            return true;
        }
        private bool check2()
        {
            
           
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Ma mtt không được để trống", "Thông báo");
                return false;
            }
            if (textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Ma mtt không được để trống", "Thông báo");
                return false;
            }
            if (textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại khách hàng không được để trống", "Thông báo");
                return false;
            }
            if (textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại khách hàng không được để trống", "Thông báo");
                return false;
            }
            if (textBox7.Text.Trim() == "")
            {
                MessageBox.Show("Ma que không được để trống", "Thông báo");
                return false;
            }

            return true;
        }
        private void resetForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";  
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm !", "Thông báo");
                FormK_Load(sender, e);
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã hồ sơ trả ! !", "Thông báo");
                FormK_Load(sender, e);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã thủ thư muốn tìm", "Thông báo");
                FormK_Load(sender, e);
            }
            
            else
            {
                string query = $"select thuthu.* from thuthu join HoSoTra \r\non ThuThu.MaThuThu = HoSoTra.MaThuThu where ThuThu.MaThuThu = N'{textBox1.Text.Trim()}' and MaHSTra = N'{textBox2.Text.Trim()}'";
                try
                {
                    dataGridView1.DataSource = connection.table(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            if (check2())
            {
                string query = $"Insert into ThuThu values(N'{textBox8.Text}',N'{textBox3.Text}',N'{textBox4.Text}',N'{textBox5.Text}',N'{textBox6.Text}',N'{textBox7.Text}')";
                if (MessageBox.Show("Bạn có muốn thêm khách hàng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    connection.Excute(query);
                    MessageBox.Show("Thêm thu thu thành công!", "Thông báo");
                    FormK_Load(sender, e);
                    resetForm();


                }
            }
        }


        

        

        private void button5_Click_1(object sender, EventArgs e)
        {
            resetForm();
            FormK_Load(sender, e);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string query = $"Update thuthu set TenThuThu = N'{textBox3.Text}',DiaChi = N'{textBox4.Text}',DienThoaicd = N'{textBox5.Text}',DienThoaidd = N'{textBox6.Text}',MaQue = N'{textBox7.Text}' where MaThuThu = N'{textBox8.Text.Trim()}'";
            if (MessageBox.Show("Bạn có muốn sửa thủ thư không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    connection.Excute(query);
                    MessageBox.Show("Sửa thành công!", "Thông báo");
                    FormK_Load(sender, e);
                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Thông báo");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {
                string query = "delete from ThuThu where MaThuThu = '" + s + "'";
                connection.Excute(query);
                FormK_Load(sender, e);
                
            }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Thông báo");
            }
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
