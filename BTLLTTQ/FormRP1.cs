using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLLTTQ
{
    public partial class FormRP1 : Form
    {
        public FormRP1()
        {
            InitializeComponent();
        }
        ReportDataSource reportDataSource = new ReportDataSource();
        Connection connection = new Connection();
        private void add()
        {
            comboBox1.Items.Add("Quý 1");
            comboBox1.Items.Add("Quý 2");
            comboBox1.Items.Add("Quý 3");
            comboBox1.Items.Add("Quý 4");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Quý 1")
            {

                string query = String.Format("select top(5) DMGiaoTrinh.MaGT, TenGT, MaTacGia, NamXB, TomTatND, TheMuon.SLMuon, Month(HSMuon.NgayMuon)\r\nfrom HSMuon join TheMuon on HSMuon.MaThe = TheMuon.MaThe\r\njoin ChiTietHSMuon on HSMuon.MaHSM = ChiTietHSMuon.MaHSM\r\njoin DMGiaoTrinh on ChiTietHSMuon.MaGT = DMGiaoTrinh.MaGT\r\nwhere Month(HSMuon.NgayMuon) = 1 or  Month(HSMuon.NgayMuon) = 2 or Month(HSMuon.NgayMuon) = 3\r\norder by TheMuon.SLMuon desc\r\n");
                reportDataSource.Value = connection.table(query);
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }
            if (comboBox1.Text == "Quý 2")
            {
                string query = String.Format("select top(5) DMGiaoTrinh.MaGT, TenGT, MaTacGia, NamXB, TomTatND, TheMuon.SLMuon, Month(HSMuon.NgayMuon)\r\nfrom HSMuon join TheMuon on HSMuon.MaThe = TheMuon.MaThe\r\njoin ChiTietHSMuon on HSMuon.MaHSM = ChiTietHSMuon.MaHSM\r\njoin DMGiaoTrinh on ChiTietHSMuon.MaGT = DMGiaoTrinh.MaGT\r\nwhere Month(HSMuon.NgayMuon) = 4 or  Month(HSMuon.NgayMuon) = 5 or Month(HSMuon.NgayMuon) = 6\r\norder by TheMuon.SLMuon desc\r\n");
                reportDataSource.Value = connection.table(query);
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }
            if (comboBox1.Text == "Quý 3")
            {
                string query = String.Format("select top(5) DMGiaoTrinh.MaGT, TenGT, MaTacGia, NamXB, TomTatND, TheMuon.SLMuon, Month(HSMuon.NgayMuon)\r\nfrom HSMuon join TheMuon on HSMuon.MaThe = TheMuon.MaThe\r\njoin ChiTietHSMuon on HSMuon.MaHSM = ChiTietHSMuon.MaHSM\r\njoin DMGiaoTrinh on ChiTietHSMuon.MaGT = DMGiaoTrinh.MaGT\r\nwhere Month(HSMuon.NgayMuon) = 7 or  Month(HSMuon.NgayMuon) = 8 or Month(HSMuon.NgayMuon) = 9\r\norder by TheMuon.SLMuon desc\r\n");
                reportDataSource.Value = connection.table(query);
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }
            if (comboBox1.Text == "Quý 4")
            {
                string query = String.Format("select top(5) DMGiaoTrinh.MaGT, TenGT, MaTacGia, NamXB, TomTatND, TheMuon.SLMuon, Month(HSMuon.NgayMuon)\r\nfrom HSMuon join TheMuon on HSMuon.MaThe = TheMuon.MaThe\r\njoin ChiTietHSMuon on HSMuon.MaHSM = ChiTietHSMuon.MaHSM\r\njoin DMGiaoTrinh on ChiTietHSMuon.MaGT = DMGiaoTrinh.MaGT\r\nwhere Month(HSMuon.NgayMuon) = 10 or  Month(HSMuon.NgayMuon) = 11 or Month(HSMuon.NgayMuon) = 12\r\norder by TheMuon.SLMuon desc\r\n");
                reportDataSource.Value = connection.table(query);
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }
        }

        private void FormRP1_Load(object sender, EventArgs e)
        {
            add();
            reportViewer1.LocalReport.ReportEmbeddedResource = "BTLLTTQ.Report.Report1.rdlc";
            reportDataSource.Name = "DataSet1";
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
