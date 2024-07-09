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
    public partial class Form3 : Form
    {
        Connection con = new Connection();
        string caulenh = "";
        bool thaydoi = true;
        int dem = 0;
        List<GiaoTrinh> lst = new List<GiaoTrinh>();
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("true");
            comboBox1.Items.Add("false");
            dataGridView1.DataSource = con.table("Select * from HSMuon");
            caulenh = "HSMuon";
            label12.Text = "Danh sách Hồ Sơ Mượn";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (thaydoi)
            {
                label12.Text = "Danh sách Hồ Sơ Mượn";
                dataGridView1.DataSource = con.table("Select * from HSMuon");
                caulenh = "HSMuon";
                groupBox1.Visible = true;
                button1.Visible = false;
                groupBox2.Visible = false;
                resetgb2();
            }
            else
            {
                label12.Text = "Danh sách Hồ Sơ Mượn của Mã thẻ " + textBox8.Text;
                string query = String.Format("Select * from HSMuon where MaThe=N'{0}'",
              textBox8.Text.Trim());
                dataGridView1.DataSource = con.table(query);
                caulenh = "HSMuon";
                groupBox1.Visible = true;
                button1.Visible = false;
                groupBox2.Visible = false;
                resetgb2();
            }
        }
        private void resetgb1()
        {
            if (thaydoi)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                textBox4.Text = "";
            }
            else
            {
                textBox1.Text = "";
                textBox3.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                textBox4.Text = "";
            }
        }
        private void resetgb2()
        {
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (caulenh == "HSMuon")
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                dateTimePicker2.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            if (caulenh == "ChiTietHSMuon")
            {
                textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            label12.Text = "Chi tiết Hồ Sơ Mượn";
            groupBox2.Visible = true;
            button1.Visible = true;
            groupBox1.Visible = false;
            string bang = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string query = String.Format("Select * from ChiTietHSMuon where MaHSM=N'{0}'", bang);
            caulenh = "ChiTietHSMuon";
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            resetgb1();

            dataGridView1.DataSource = con.table(query);
            caulenh = "ChiTietHSMuon";

        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool ktr()
        {
            if (con.ThongtinTM(textBox8.Text).Mathe == "Không tồn tại")
            {
                MessageBox.Show("Mã thẻ không tồn tại");
                return false;
            }
                 if (con.ThongtinTM(textBox8.Text).Slmuon1 >= 3)
              {
                   MessageBox.Show("Số lượng mượn trong thẻ mượn vượt quá 3");
                    return false;
               }
            if (con.ThongtinTM(textBox8.Text).Mathe.Trim() == "true")
            {
                MessageBox.Show("Thẻ bị khóa");
                return false;
            }
            if (textBox9.Text.Trim() == "")
            {
                MessageBox.Show("Số lượng sách mượn không được để trống");
                return false;
            }
            else if (int.Parse(textBox9.Text.Trim()) == 0)
            {

                MessageBox.Show("Số lượng sách mượn phải lớn hơn 0");
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //  textBox10.Text = con.ThongtinTM(textBox8.Text.Trim()).Mathe;
            //   textBox11.Text = con.ThongtinTM(textBox8.Text.Trim()).Slmuon1.ToString();
            if (ktr())
            {
                label12.Text = "Danh sách Hồ Sơ Mượn của Mã thẻ " + textBox8.Text;
                groupBox3.Enabled = true;
                panel1.Enabled = false;
                textBox2.Text = textBox8.Text.Trim();
                textBox2.Enabled = false;
                textBox5.Enabled = false;
                thaydoi = false;
                string query = String.Format("Select * from HSMuon where MaThe=N'{0}'",
               textBox8.Text.Trim());
                caulenh = "HSMuon";
                dataGridView1.DataSource = con.table(query);
            }
        }
        private void StartGroupboxChitiet(bool type)
        {
            groupBox1.Enabled = type;
            groupBox2.Enabled = type;
        }
        private void StartButtonThemSuaXoa(bool type)
        {
            btnThem.Enabled = type;
            btnSua.Enabled = type;
            btnXoa.Enabled = type;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            StartGroupboxChitiet(true);
            StartButtonThemSuaXoa(false);
            textBox1.Enabled = true;
            btnThem.Enabled = true;
            textBox6.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            StartGroupboxChitiet(true);
            StartButtonThemSuaXoa(false);
            btnSua.Enabled = true;
            textBox1.Enabled = false;
            textBox6.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            StartGroupboxChitiet(true);
            StartButtonThemSuaXoa(false);
            btnXoa.Enabled = true;
            textBox6.Enabled = false;
            textBox1.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            comboBox1.Text = "";
            StartGroupboxChitiet(false);
            StartButtonThemSuaXoa(true);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBox4.Text = "";
            StartGroupboxChitiet(false);
            StartButtonThemSuaXoa(true);
        }
        private bool ischeck()
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Mã HSM không được trống");
                return false;
            }
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Mã Thủ thư không được trống");
                return false;
            }
            if (dateTimePicker1.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày mượn không được lớn hơn ngày hiện tại");
                return false;
            }
            TimeSpan diff = dateTimePicker2.Value.Subtract(dateTimePicker1.Value);
            if (diff.TotalDays < 7)
            {
                MessageBox.Show("Ngày phải trar  phải lớn hơn 7 ngày");
                return false;
            }
            return true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled && ischeck())
            {
                string query = String.Format("insert into HSMuon values(N'{0}',N'{1}',N'{2}','{3}','{4}',N'{5}')"
                    , textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), textBox4.Text);

                if (MessageBox.Show("Bạn có muốn thêm HSM không", "Thông báo", MessageBoxButtons.YesNo
                          , MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        con.Excute(query);
                        MessageBox.Show("Thêm HSM thành công");
                    }
                    catch
                    {
                        MessageBox.Show("Ma HSM hoac Ma Thu Thu ko hop le");
                    }

                    string query2 = String.Format("Select * from HSMuon where MaThe=N'{0}'",
            textBox8.Text.Trim());
                    caulenh = "HSMuon";
                    dataGridView1.DataSource = con.table(query2);
                }

            }
            if (btnSua.Enabled && ischeck())
            {


                string query = String.Format("Update HSMuon set MaThuThu=N'{0}',NgayMuon='{1}',NgayTra='{2}',TinhTrangMuon=N'{3}' where MaHSM=N'{4}'",
                      textBox3.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), textBox4.Text, textBox1.Text);
                if (MessageBox.Show("Bạn có muốn sửa Hồ sơ mượn không", "Thông báo", MessageBoxButtons.YesNo
                                   , MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    con.Excute(query);
                    MessageBox.Show("Sửa Hồ sơ mượn thành công");
                    string query2 = String.Format("Select * from HSMuon where MaThe=N'{0}'",
        textBox8.Text.Trim());
                    caulenh = "HSMuon";
                    dataGridView1.DataSource = con.table(query2);
                }
            }
            if (btnXoa.Enabled)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn mã HSM muốn xóa");
                }
                else
                {
                    string query1 = "Delete from HSMuon Where MaHSM=N'" + textBox1.Text + "'";
                    if (con.table("Select * from ChiTietHSMuon Where MaHSM=N'" + textBox1.Text + "'").Rows.Count == 0)
                    {

                        if (MessageBox.Show("Bạn có muốn xóa Hồ sơ mượn không", "Thông báo", MessageBoxButtons.YesNo
                         , MessageBoxIcon.Information) == DialogResult.Yes)
                        {

                            con.Excute(query1);
                            MessageBox.Show("Xóa Hồ sơ mượn thành công");
                            string query2 = String.Format("Select * from HSMuon where MaThe=N'{0}'",
                           textBox8.Text.Trim());
                            caulenh = "HSMuon";
                            dataGridView1.DataSource = con.table(query2);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Còn dữ liệu không xóa được");
                    }

                }
            }
        }
        private bool ischeck2()
        {
            if (textBox6.Text.Trim() == "")
            {

                MessageBox.Show("Mã GT không được trống");
                return false;
            }
            if (comboBox1.Text.Trim() == "")
            {

                MessageBox.Show(" không được trống phần chưa trả");
                return false;
            }
            return true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled && ischeck2())
            {
                if (dem < int.Parse(textBox9.Text.Trim()))
                {
                    string query = String.Format("insert into ChiTietHSMuon values(N'{0}',N'{1}','{2}')"
                        , textBox5.Text, textBox6.Text, comboBox1.Text);
                    string query1 = String.Format("Update DMGiaoTrinh set SoLuongGT=SoLuongGT-1 where MaGT=N'{0}'"
                        , textBox6.Text);
                    string query2 = String.Format("Update TheMuon set SLMuon=SLMuon+1 where MaThe=N'{0}'"
                        , textBox8.Text);
                    if (MessageBox.Show("Bạn có muốn thêm HSM không", "Thông báo", MessageBoxButtons.YesNo
                              , MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            if (con.SLGT("Select SoLuongGT from DMGiaoTrinh where MaGT=N'" + textBox6.Text + "'") > 0)
                            {
                                con.Excute(query);
                                con.Excute(query1);
                                con.Excute(query2);

                                lst.Add(new GiaoTrinh(textBox5.Text, textBox6.Text));
                                ++dem;
                                MessageBox.Show("Thêm HSM thành công");
                            }
                            else if (con.SLGT("Select SoLuongGT from DMGiaoTrinh where MaGT=N'" + textBox6.Text + "'") == 0)
                            {
                                MessageBox.Show("Số lượng giáo trình đã hết");
                            }
                            else
                            {
                                MessageBox.Show("Mã GT không tồn tại");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Mã GT không hợp lệ");
                        }
                        string query3 = String.Format("Select * from ChiTietHSMuon where MaHSM=N'{0}'",
                textBox5.Text.Trim());
                        caulenh = "ChiTietHSMuon";
                        dataGridView1.DataSource = con.table(query3);
                    }
                }
                else
                {
                    MessageBox.Show("Vuot qua Sl muon");
                }

            }
            if (btnSua.Enabled && ischeck2())
            {


                string query = String.Format("Update ChiTietHSMuon set ChuaTra='{0}' where MaHSM=N'{1}' and MaGT=N'{2}'",
                      comboBox1.Text, textBox5.Text, textBox6.Text);
                if (MessageBox.Show("Bạn có muốn sửa  không", "Thông báo", MessageBoxButtons.YesNo
                                   , MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    con.Excute(query);
                    MessageBox.Show("Sửa  thành công");
                    string query3 = String.Format("Select * from ChiTietHSMuon where MaHSM=N'{0}'",
           textBox5.Text.Trim());
                    caulenh = "ChiTietHSMuon";
                    dataGridView1.DataSource = con.table(query3);
                }
            }
            if (btnXoa.Enabled && ischeck2())
            {


                string query = String.Format("Delete from ChiTietHSMuon where MaHSM=N'{0}' and MaGT=N'{1}'",
                  textBox5.Text, textBox6.Text);
                string query1 = String.Format("Update DMGiaoTrinh set SoLuongGT=SoLuongGT+1 where MaGT=N'{0}'"
                    , textBox6.Text);
                string query2 = String.Format("Update TheMuon set SLMuon=SLMuon-1 where MaThe=N'{0}'"
                    , textBox8.Text);
                //   string query3 = String.Format("Select * from ChiTietHSMuon  where MaHSM=N'{0}",
                //                 textBox5.Text);

                if (MessageBox.Show("Bạn có muốn xóa  không", "Thông báo", MessageBoxButtons.YesNo
                         , MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    bool dc = true;
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (lst[i].Mahsm == textBox5.Text && lst[i].Magt == textBox6.Text)
                        {
                            dem--;
                            con.Excute(query);
                            con.Excute(query1);
                            con.Excute(query2);
                            lst.RemoveAt(i);
                            dc = false;
                            break;
                        }

                    }
                    if (!dc)
                    {
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                    {
                        if (dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim() == "true")
                        {
                            con.Excute(query);
                            con.Excute(query1);
                            con.Excute(query2);
                        }
                        else if (dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim() == "false")
                        {
                            con.Excute(query);
                        }
                        MessageBox.Show("Xóa được dữ liệu thành công");
                    }
                    string query3 = String.Format("Select * from ChiTietHSMuon where MaHSM=N'{0}'",
           textBox5.Text.Trim());
                    caulenh = "ChiTietHSMuon";
                    dataGridView1.DataSource = con.table(query3);

                }

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            label12.Text = "Danh sách Hồ Sơ Mượn";
            StartGroupboxChitiet(false);
            StartButtonThemSuaXoa(true);
            dem = 0;
            lst.Clear();
            button1.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Enabled = false;
            panel1.Enabled = true;
            textBox2.Text = "";
            textBox5.Text = "";
            textBox2.Enabled = false;
            textBox5.Enabled = false;
            thaydoi = true;
            string query = "Select * from HSMuon";
            caulenh = "HSMuon";
            dataGridView1.DataSource = con.table(query);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

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

        private void groupBox3_Paint(object sender, PaintEventArgs e)
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
