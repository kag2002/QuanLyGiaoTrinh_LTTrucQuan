using Microsoft.Reporting.WinForms;
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
    public partial class FormRP2 : Form
    {
        ReportDataSource reportDataSource = new ReportDataSource();
        Connection connection = new Connection();
        public FormRP2()
        {
            InitializeComponent();
        }

        private void FormRP2_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "BTLLTTQ.Report.Report2.rdlc";
            reportDataSource.Name = "DataSet1";
            this.reportViewer1.RefreshReport();
            DataTable dt = connection.table("Select mathe from themuon ");
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "mathe";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = $"select * from HSMuon where MaThe = N'{comboBox1.Text.Trim()}'";
            reportDataSource.Value = connection.table(query);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
