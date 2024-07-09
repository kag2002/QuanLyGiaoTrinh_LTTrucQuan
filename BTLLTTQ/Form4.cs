using Excel=Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Drawing2D;

namespace BTLLTTQ
{
    
    public partial class Form4 : Form
    {
        Connection connection = new Connection();
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = connection.table("Select * from HSMuon");
            dataGridView2.DataSource = connection.table("Select * from HoSoTra");
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            btxacnhan.Enabled = false;
            groupBox6.Enabled = false;
            button6.Visible = false;
            groupBox4.Enabled = false;
            DataTable dt = connection.table("Select MaGT from ChiTietHSMuon Where ChuaTra = N'True'");
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "MaGT";
            DataTable dt1 = connection.table("Select MaViPham from ViPham");
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "MaViPham";
            DataTable dt2 = connection.table("Select MaPhat from Phat");
            comboBox3.DataSource = dt2;
            comboBox3.DisplayMember = "MaPhat";
        }
        private void loadform()
        {
            string bang = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string query = String.Format("Select * from ChiTietHSMuon where MaHSM=N'{0}' and ChuaTra = N'True'", bang);
            dataGridView1.DataSource = connection.table(query);

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(groupBox5.Text == "Danh sách hồ sơ trả")
            {
                
                button7.Enabled = true;
                button6.Visible = false;
                button3.Enabled = true;
                groupBox6.Enabled = false;
                button4.Enabled = true;
                textBox15.Enabled = true;
                textBox14.Enabled = true;
                resetdata2();
                dateTimePicker3.Value = DateTime.Now;
                dateTimePicker4.Value = DateTime.Now;
                dataGridView2.DataSource = connection.table("Select * from HoSoTra");
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                btxacnhan.Enabled = false;
                groupBox6.Enabled = false;
                button6.Visible = false;
                textBox9.Text = "";
               
            }
            if (groupBox5.Text == "Chi tiết hồ sơ trả")
            {
                comboBox1.Enabled = true;
                button7.Enabled = true;
                button3.Enabled = true;
                button6.Visible = false;
                groupBox6.Enabled = false;
                button4.Enabled = true;
                textBox15.Enabled = true;
                textBox14.Enabled = true;
                loadform1();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button4.Enabled = false;
            if (groupBox5.Text == "Danh sách hồ sơ trả")
            {
                groupBox4.Enabled = true;
                textBox15.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                textBox14.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                if(dataGridView2.CurrentRow.Cells[2].Value.ToString() == "")
                {
                    dateTimePicker4.Value = DateTime.Now;
                }
                else
                {
                    dateTimePicker4.Value = DateTime.Parse(dataGridView2.CurrentRow.Cells[2].Value.ToString());

                }
                textBox9.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                textBox13.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                textBox11.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                textBox15.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                textBox14.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                textBox13.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                textBox11.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                comboBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                comboBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                comboBox3.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void btnlammoi_Click_1(object sender, EventArgs e)
        {
            Form4_Load(sender, e);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (groupBox1.Text == "Danh sách mượn")
            {
                textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                dateTimePicker2.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                textBox8.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                string ma = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string magt = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox5.Text = connection.Ngaynopphat(ma);
                textBox7.Text = connection.vipham(ma, magt);
                
            }
        }

        private void btntra_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "Chi tiết mượn";
            btxacnhan.Enabled = true;
            btnlammoi.Enabled = false;
            btntra.Enabled = false;
            loadform();
        }

        private void btxacnhan_Click_1(object sender, EventArgs e)
        {
            if (textBox7.Text.Length > 0 && textBox5.Text.Length == 0)
            {
                try
                {
                    string magt = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    string query = String.Format("Update TheMuon set KhoaThe=N'true' where MaThe=N'{0}'",
                              textBox3.Text);
                    string query3 = String.Format("Update TheMuon set SLMuon= SLMuon - 1 where MaThe=N'{0}' and SLMuon > 0",
                              textBox3.Text);
                    string query1 = String.Format("Update ChiTietHSMuon set ChuaTra=N'false' where MaHSM=N'{0}' and MaGT = N'{1}'",
                             textBox2.Text, magt);
                    string query2 = String.Format("Update DMGiaoTrinh set SoLuongGT = SoLuongGT + 1 where MaGT=N'{0}' and SoLuongGT > 0 ",
                              magt);
                    connection.Excute(query);
                    connection.Excute(query1);
                    connection.Excute(query2);
                    connection.Excute(query3);
                    loadform();
                    MessageBox.Show("Thẻ đã bị khóa!", "Thông báo");

                }
                catch (Exception x)
                {
                    MessageBox.Show("Không tìm thấy giáo trình để trả! " + x.Message);
                }
            }
            else
            {
                try
                {
                    string magt = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    string query4 = "";
                    string query3 = String.Format("Update TheMuon set SLMuon= SLMuon - 1 where MaThe=N'{0}' and SLMuon > 0",
                              textBox3.Text);
                    string query = String.Format("Update DMGiaoTrinh set SoLuongGT = SoLuongGT + 1 where MaGT=N'{0}' and SoLuongGT > 0",
                              magt);
                    string query1 = String.Format("Update ChiTietHSMuon set ChuaTra=N'false' where MaHSM=N'{0}' and MaGT = N'{1}'",
                             textBox2.Text, magt);
                    connection.Excute(query);
                    connection.Excute(query1);
                    connection.Excute(query3);
                    if(checkThe() > 0)
                    {
                        query4 = String.Format("Update TheMuon set KhoaThe=N'true' where MaThe=N'{0}'",
                             textBox3.Text);
                    }
                    else
                    {
                        query4 = String.Format("Update TheMuon set KhoaThe=N'false' where MaThe=N'{0}'",
                             textBox3.Text);
                    }
                    connection.Excute(query4);
                    loadform();
                    MessageBox.Show("Cập nhật thành công số lượng giáo trình và số lượng thẻ mượn!", "Thông báo");
                }
                catch (Exception x)
                {
                    MessageBox.Show("Không tìm thấy giáo trình để trả! " + x.Message);
                }
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "Danh sách mượn";
            dataGridView1.DataSource = connection.table("Select * from HSMuon");
            btnlammoi.Enabled = true;
            btntra.Enabled = true;
            btxacnhan.Enabled = false;
        }
        private void resetdata2()
        {
            textBox11.Text = "";
            textBox14.Text = "";
            textBox13.Text = "";
        }
        private void loadform1()
        {
            try
            {
                string bang = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                string query = String.Format("Select * from ChiTietHSTra where MaHSTra=N'{0}'", bang);
                dataGridView2.DataSource = connection.table(query);
            }
            catch
            {

            }
           
        }
        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(groupBox5.Text == "Danh sách hồ sơ trả")
            {
                groupBox5.Text = "Chi tiết hồ sơ trả";
                loadform1();
                label12.Text = "Mã hồ sơ trả";
                label16.Text = "Mã giáo trình";
                label15.Text = "Mã vi phạm";
                label13.Text = "Mã phạt";
                label14.Visible = false;
                label10.Visible = false;
                dateTimePicker3.Visible = false;
                dateTimePicker4.Visible = false;
                button6.Visible = false;
                resetdata2();
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                textBox14.Text = "a";
                textBox11.Text = "a";
                textBox14.Visible = false;
                textBox13.Visible = false;
                textBox11.Visible = false;
                textBox9.Visible = false;
               
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            groupBox5.Text = "Danh sách hồ sơ trả";
            dataGridView2.DataSource = connection.table("Select * from HoSoTra");
            label14.Visible = true;
            label10.Visible = true;
            button6.Visible = false;
            dateTimePicker3.Visible = true;
            dateTimePicker4.Visible = true;
            resetdata2();
            label12.Text = "Mã hồ sơ trả";
            label16.Text = "Mã hồ sơ mượn";
            label15.Text = "Tổng tiền phạt";
            label13.Text = "Mã thủ thư";
            textBox14.Visible = true;
            textBox13.Visible = true;
            textBox11.Visible = true;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            textBox9.Visible = true;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
        private bool check()
        {
            if (textBox15.Text.Trim() == "")
            {
                MessageBox.Show("Mã HSTra không được trống");
                return false;
            }
            if (textBox14.Text.Trim() == "")
            {
                MessageBox.Show("Mã HSMuon không được trống");
                return false;
            }
            if (textBox11.Text.Trim() == "")
            {
                MessageBox.Show("Mã Thu thu không được trống");
                return false;
            }
            return true;
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            if(groupBox5.Text == "Danh sách hồ sơ trả" )
            {
                
                groupBox6.Enabled = true;
                button3.Enabled = false;
                button6.Visible = true;
                button7.Enabled = false;
            }
            if(groupBox5.Text == "Chi tiết hồ sơ trả")
            {
                if(textBox15.Text == "")
                {
                    textBox15.Enabled = true;
                }
                else
                {
                    textBox15.Enabled = false;
                }
                groupBox6.Enabled = true;
                button3.Enabled = false;
                button6.Visible = true;
                button7.Enabled = false;
                
            }
        }
        private bool check1()
        {
            if (comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Mã Giáo Trình không được trống");
                return false;
            }
            if (comboBox2.Text.Trim() == "")
            {
                MessageBox.Show("Mã vi phạm không được trống");
                return false;
            }
            if (comboBox3.Text.Trim() == "")
            {
                MessageBox.Show("Mã phạt không được trống");
                return false;
            }
           
            return true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (check1() && groupBox5.Text == "Chi tiết hồ sơ trả" && button3.Enabled)
            {

                string query = String.Format("update ChiTietHSTra set MaViPham =N'{0}',MaPhat=N'{1}' where MaHSTra =N'{2}' and MaGT =N'{3}'"
                    , comboBox2.Text, comboBox3.Text, textBox15.Text, comboBox1.Text);

                if (MessageBox.Show("Bạn có muốn sửa ChiTietHSTra không", "Thông báo", MessageBoxButtons.YesNo
                          , MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        connection.Excute(query);
                        MessageBox.Show("Sửa ChiTietHSTra thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            if (check()  &&  groupBox5.Text == "Danh sách hồ sơ trả" && button4.Enabled )
            {
                string query = "";
                if (textBox9.Text == "")
                {
                     query = String.Format("insert into HoSoTra values(N'{0}',N'{1}','{2}','{3}',NULL,N'{5}')"
                    , textBox15.Text, textBox14.Text, dateTimePicker4.Value.ToString("yyyy-MM-dd"), textBox13.Text, textBox9.Text, textBox11.Text);
                }
                else
                {
                    query = String.Format("insert into HoSoTra values(N'{0}',N'{1}','{2}','{3}','{4}',N'{5}')"
                    , textBox15.Text, textBox14.Text, dateTimePicker4.Value.ToString("yyyy-MM-dd"), textBox13.Text, textBox9.Text, textBox11.Text);
                }
                 

                if (MessageBox.Show("Bạn có muốn thêm HSTra không", "Thông báo", MessageBoxButtons.YesNo
                          , MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        connection.Excute(query);
                        MessageBox.Show("Thêm HSTra thành công");
                    }
                    catch
                    {
                        MessageBox.Show("Ma HSTra hoac Ma Thu Thu ko hop le");
                    }
                }
            }
            if (check1() && groupBox5.Text == "Chi tiết hồ sơ trả" && button4.Enabled)
            {
                string query = String.Format("insert into ChiTietHSTra values(N'{0}',N'{1}',N'{2}',N'{3}')"
                    , textBox15.Text, comboBox1.Text, comboBox2.Text, comboBox3.Text);

                if (MessageBox.Show("Bạn có muốn thêm ChiTietHSTra không", "Thông báo", MessageBoxButtons.YesNo
                          , MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        connection.Excute(query);
                        MessageBox.Show("Thêm ChiTietHSTra thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            if (check() && groupBox5.Text == "Danh sách hồ sơ trả" && button3.Enabled)
            {
                string query = "";
                if (textBox9.Text == "")
                {
                     query = String.Format("update HoSoTra set NgayTra='{0}',TongTienPhat ='{1}',NgayNopPhat= NULL,MaThuThu=N'{3}' where MaHSTra =N'{4}' and MaHSM=N'{5}'"
                    , dateTimePicker4.Value.ToString("yyyy-MM-dd"), textBox13.Text, textBox9.Text, textBox11.Text, textBox15.Text, textBox14.Text);
                }
                else
                {
                    query = String.Format("update HoSoTra set NgayTra='{0}',TongTienPhat ='{1}',NgayNopPhat='{2}',MaThuThu=N'{3}' where MaHSTra =N'{4}' and MaHSM=N'{5}'"
                   , dateTimePicker4.Value.ToString("yyyy-MM-dd"), textBox13.Text, textBox9.Text, textBox11.Text, textBox15.Text, textBox14.Text);
                }
                    

                if (MessageBox.Show("Bạn có muốn sửa HSTra không", "Thông báo", MessageBoxButtons.YesNo
                          , MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        connection.Excute(query);
                        MessageBox.Show("Sửa HSTra thành công");
                    }
                    catch
                    {
                        MessageBox.Show("Ma HSTra hoac Ma Thu Thu ko hop le");
                    }
                }
            }
            
            if (groupBox5.Text == "Danh sách hồ sơ trả" && button7.Enabled)
            {
                string query = String.Format("Delete from HoSoTra Where MaHSTra=N'{0}'",
                   textBox15.Text);

                if (MessageBox.Show("Bạn có muốn xóa HSTra không", "Thông báo", MessageBoxButtons.YesNo
                          , MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        connection.Excute(query);
                        MessageBox.Show("Xóa HSTra thành công");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error: "+ ex.Message);
                    }
                }
            }

            if (groupBox5.Text == "Chi tiết hồ sơ trả" && button7.Enabled)
            {
                string query = String.Format("Delete from ChiTietHSTra Where MaHSTra=N'{0}' and MaGT = N'{1}'",
                   textBox15.Text, comboBox1.Text);

                if (MessageBox.Show("Bạn có muốn xóa ChiTietHSTra không", "Thông báo", MessageBoxButtons.YesNo
                          , MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        connection.Excute(query);
                        MessageBox.Show("Xóa ChiTietHSTra thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (groupBox5.Text == "Danh sách hồ sơ trả")
            {
                groupBox6.Enabled = true;
                textBox15.Enabled = false; 
                textBox14.Enabled = false;
                button6.Visible = true;
                button7.Enabled = false;
                button4.Enabled = false;
            }
            if(groupBox5.Text == "Chi tiết hồ sơ trả")
            {
                groupBox6.Enabled = true;
                textBox15.Enabled = false;
                comboBox1.Enabled = false;
                button6.Visible = true;
                button7.Enabled = false;
                button4.Enabled = false;
            }

        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (groupBox5.Text == "Danh sách hồ sơ trả")
            {
                groupBox6.Enabled = true;
                textBox15.Enabled = false;
                textBox14.Enabled = false;
                button6.Visible = true;
                button4.Enabled = false;
                button3.Enabled = false;
            }
            if (groupBox5.Text == "Chi tiết hồ sơ trả")
            {
                groupBox6.Enabled = true;
                textBox15.Enabled = false;
                button6.Visible = true;
                button4.Enabled = false;
                button3.Enabled = false;
            }
        }
        private int checkThe()
        {
            int dem = 0;
            List<KhoaThe> lst = connection.Thongtin(textBox3.Text);
            if (lst.Count > 0)
            {
                foreach (KhoaThe item in lst)
                {
                    if (item.Ngaynophat == "" && item.Mavipham.Length > 0)
                    {
                        dem++;
                    }
                }
            }
            return dem;
        }
        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(96, 155, 173), 1);
            Rectangle rectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            graphics.FillRectangle(linearGradientBrush, rectangle);
            graphics.DrawRectangle(pen, rectangle);
        }

        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(96, 155, 173), 1);
            Rectangle rectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            graphics.FillRectangle(linearGradientBrush, rectangle);
            graphics.DrawRectangle(pen, rectangle);
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
