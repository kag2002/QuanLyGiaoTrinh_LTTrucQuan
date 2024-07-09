using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Diagnostics.Internal;
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
using Excel = Microsoft.Office.Interop.Excel;
namespace BTLLTTQ
{
    public partial class FormBC : Form
    {
        ReportDataSource reportDataSource = new ReportDataSource();
        Connection connection = new Connection();
        Connection con =new Connection();
        public FormBC()
        {
            InitializeComponent();
        }

        private void FormBC_Load(object sender, EventArgs e)
        {
            add();
            reportDataSource.Name = "DataSet1";
            dataGridView1.DataSource = con.table("Select * from baocao3");
            tabControl1.TabPages[2].Text = "Báo cáo số 3";
            tabControl1.TabPages[1].Text = "Báo cáo hồ sơ mượn";
            DataTable dt = connection.table("Select mathe from themuon ");
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "mathe";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            exSheet.get_Range("B3").Value = "CHI TIẾT DANH SÁCH CÁC HỒ SƠ MƯỢN CÓ GIÁO TRÌNH ĐANG ĐƯỢC MƯỢN CHƯA TRẢ";
            exSheet.get_Range("A4").Value = "STT";
            exSheet.get_Range("B4").Value = "Mã HSM";
            exSheet.get_Range("C4").Value = "Mã thẻ mượn";
            exSheet.get_Range("D4").Value = "Mã Thủ thư";
            exSheet.get_Range("E4").Value = "Ngày mượn";
            exSheet.get_Range("F4").Value = "Ngày trả";
            exSheet.get_Range("G4").Value = "Tình trạng mượn";
            exSheet.get_Range("H4").Value = "Mã Giáo Trình";
            exSheet.get_Range("I4").Value = "Chưa trả";
            int n = dataGridView1.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                exSheet.get_Range("A" + (i + 5).ToString()).Value = (i + 1);
                exSheet.get_Range("B" + (i + 5).ToString()).Value =
                    dataGridView1.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 5).ToString()).Value =
                   dataGridView1.Rows[i].Cells[1].Value;
                exSheet.get_Range("D" + (i + 5).ToString()).Value =
                  dataGridView1.Rows[i].Cells[2].Value;
                exSheet.get_Range("E" + (i + 5).ToString()).Value =
                  dataGridView1.Rows[i].Cells[3].Value;
                exSheet.get_Range("F" + (i + 5).ToString()).Value =
                  dataGridView1.Rows[i].Cells[4].Value;
                exSheet.get_Range("G" + (i + 5).ToString()).Value =
                  dataGridView1.Rows[i].Cells[5].Value;
                exSheet.get_Range("H" + (i + 5).ToString()).Value =
                  dataGridView1.Rows[i].Cells[6].Value;
                exSheet.get_Range("I" + (i + 5).ToString()).Value =
                  dataGridView1.Rows[i].Cells[7].Value;
            }


            exBook.Activate();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003(*.xls)|*.xls";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = ".xls";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                exBook.SaveAs(saveFileDialog.FileName.ToString());
                MessageBox.Show("Xuất Excel thành công");
                exApp.Quit();
            }
            else
            {
                exApp.Quit();
                MessageBox.Show("Không có danh sách hàng để in");
            }
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            FormReport3 formReport3 = new FormReport3();
            formReport3.ShowDialog();
        }
        private void add()
        {
            comboBox1.Items.Add("Quý 1");
            comboBox1.Items.Add("Quý 2");
            comboBox1.Items.Add("Quý 3");
            comboBox1.Items.Add("Quý 4");
        }
  


        private void button3_Click(object sender, EventArgs e)
        {
            FormRP1 formReport1 = new FormRP1();
            formReport1.ShowDialog();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            exSheet.get_Range("B3").Value = "Danh sách ";
            exSheet.get_Range("A4").Value = "STT";
            exSheet.get_Range("B4").Value = "MaHSM";
            exSheet.get_Range("C4").Value = "MaThe";
            exSheet.get_Range("D4").Value = "MaThuThu";
            exSheet.get_Range("E4").Value = "NgayMuon";
            exSheet.get_Range("F4").Value = "NgayTra";
            exSheet.get_Range("G4").Value = "TinhTrangMuon";

            int n = dataGridView3.Rows.Count;
            for (int i = 0; i < n - 1; i++)
            {
                exSheet.get_Range("A" + (i + 5).ToString()).Value = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 5).ToString()).Value = dataGridView3.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 5).ToString()).Value = dataGridView3.Rows[i].Cells[1].Value;
                exSheet.get_Range("D" + (i + 5).ToString()).Value = dataGridView3.Rows[i].Cells[2].Value;
                exSheet.get_Range("E" + (i + 5).ToString()).Value = dataGridView3.Rows[i].Cells[3].Value;
                exSheet.get_Range("F" + (i + 5).ToString()).Value = dataGridView3.Rows[i].Cells[4].Value;
                exSheet.get_Range("G" + (i + 5).ToString()).Value = dataGridView3.Rows[i].Cells[5].Value;


            }
            exBook.Activate();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003(*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    exBook.SaveAs(saveFileDialog.FileName.ToString());
                    MessageBox.Show("Xuất file thành công!", "Thông báo");
                    exApp.Quit();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            exSheet.get_Range("B3").Value = "DANH SÁCH 5 GIÁO TRÌNH ĐƯỢC MƯỢN NHIỀU NHẤT";
            exSheet.get_Range("A4").Value = "STT";
            exSheet.get_Range("B4").Value = "Mã giáo trình";
            exSheet.get_Range("C4").Value = "Tên giáo trình";
            exSheet.get_Range("D4").Value = "Mã tác giả";
            exSheet.get_Range("E4").Value = "Năm xuất bản";
            exSheet.get_Range("F4").Value = "Tóm tắt nội dung";

            int n = dataGridView2.Rows.Count;
            for (int i = 0; i < n - 1; i++)
            {
                exSheet.get_Range("A" + (i + 5).ToString()).Value = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 5).ToString()).Value = dataGridView2.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 5).ToString()).Value = dataGridView2.Rows[i].Cells[1].Value;
                exSheet.get_Range("D" + (i + 5).ToString()).Value = dataGridView2.Rows[i].Cells[2].Value;
                exSheet.get_Range("E" + (i + 5).ToString()).Value = dataGridView2.Rows[i].Cells[3].Value;
                exSheet.get_Range("F" + (i + 5).ToString()).Value = dataGridView2.Rows[i].Cells[4].Value;
            }
            exBook.Activate();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003(*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    exBook.SaveAs(saveFileDialog.FileName.ToString());
                    MessageBox.Show("Xuất file thành công!", "Thông báo");
                    exApp.Quit();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string query = $"select * from HSMuon where MaThe = N'{comboBox2.Text.Trim()}'";
            try
            {
                dataGridView3.DataSource = connection.table(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormRP2 formReport = new FormRP2();
            formReport.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Quý 1")
            {

                string query = String.Format("select top(5) DMGiaoTrinh.MaGT, TenGT, MaTacGia, NamXB, TomTatND, TheMuon.SLMuon, Month(HSMuon.NgayMuon)\r\nfrom HSMuon join TheMuon on HSMuon.MaThe = TheMuon.MaThe\r\njoin ChiTietHSMuon on HSMuon.MaHSM = ChiTietHSMuon.MaHSM\r\njoin DMGiaoTrinh on ChiTietHSMuon.MaGT = DMGiaoTrinh.MaGT\r\nwhere Month(HSMuon.NgayMuon) = 1 or  Month(HSMuon.NgayMuon) = 2 or Month(HSMuon.NgayMuon) = 3\r\norder by TheMuon.SLMuon desc\r\n");
                dataGridView2.DataSource = connection.table(query);
                
            }
            if (comboBox1.Text == "Quý 2")
            {
                string query = String.Format("select top(5) DMGiaoTrinh.MaGT, TenGT, MaTacGia, NamXB, TomTatND, TheMuon.SLMuon, Month(HSMuon.NgayMuon)\r\nfrom HSMuon join TheMuon on HSMuon.MaThe = TheMuon.MaThe\r\njoin ChiTietHSMuon on HSMuon.MaHSM = ChiTietHSMuon.MaHSM\r\njoin DMGiaoTrinh on ChiTietHSMuon.MaGT = DMGiaoTrinh.MaGT\r\nwhere Month(HSMuon.NgayMuon) = 4 or  Month(HSMuon.NgayMuon) = 5 or Month(HSMuon.NgayMuon) = 6\r\norder by TheMuon.SLMuon desc\r\n");
                dataGridView2.DataSource = connection.table(query);
            }
            if (comboBox1.Text == "Quý 3")
            {
                string query = String.Format("select top(5) DMGiaoTrinh.MaGT, TenGT, MaTacGia, NamXB, TomTatND, TheMuon.SLMuon, Month(HSMuon.NgayMuon)\r\nfrom HSMuon join TheMuon on HSMuon.MaThe = TheMuon.MaThe\r\njoin ChiTietHSMuon on HSMuon.MaHSM = ChiTietHSMuon.MaHSM\r\njoin DMGiaoTrinh on ChiTietHSMuon.MaGT = DMGiaoTrinh.MaGT\r\nwhere Month(HSMuon.NgayMuon) = 7 or  Month(HSMuon.NgayMuon) = 8 or Month(HSMuon.NgayMuon) = 9\r\norder by TheMuon.SLMuon desc\r\n");
                dataGridView2.DataSource = connection.table(query);
            }
            if (comboBox1.Text == "Quý 4")
            {
                string query = String.Format("select top(5) DMGiaoTrinh.MaGT, TenGT, MaTacGia, NamXB, TomTatND, TheMuon.SLMuon, Month(HSMuon.NgayMuon)\r\nfrom HSMuon join TheMuon on HSMuon.MaThe = TheMuon.MaThe\r\njoin ChiTietHSMuon on HSMuon.MaHSM = ChiTietHSMuon.MaHSM\r\njoin DMGiaoTrinh on ChiTietHSMuon.MaGT = DMGiaoTrinh.MaGT\r\nwhere Month(HSMuon.NgayMuon) = 10 or  Month(HSMuon.NgayMuon) = 11 or Month(HSMuon.NgayMuon) = 12\r\norder by TheMuon.SLMuon desc\r\n");
                dataGridView2.DataSource = connection.table(query);
            }
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
    
}
