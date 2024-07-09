using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLLTTQ
{
    internal class Connection
    {
        private SqlConnection sqlConnection;
        private string string_connect = @"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QuanLyGiaoTrinh;Integrated Security=True";

        private SqlDataAdapter sqldataAdapter;//chen du lieu vao bang datatable va dataset
        private SqlCommand sqlCommand;//thuc thi cau lenh truy van
        private SqlDataReader sqlDataReader;
        public DataTable table(string query)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(string_connect))
            {
                sqlConnection.Open();
                sqldataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqldataAdapter.Fill(datatable);
                sqlConnection.Close();
            }
            return datatable;
        }
        public void Excute(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(string_connect))
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public Themuon ThongtinTM(string mathe)
        {
            Themuon tm=new Themuon("Không tồn tại",0);
            string query = String.Format("Select KhoaThe,SLMuon from TheMuon where MaThe=N'{0}'",
                mathe);
            using (SqlConnection sqlConnection = new SqlConnection(string_connect))
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Themuon a = new Themuon(sqlDataReader.GetString(0),sqlDataReader.GetInt32(1));
                    tm = a;
                }

                sqlConnection.Close();
            }
            return tm;
        }
        
        public List<KhoaThe> Thongtin(string mathe)
        {
            List<KhoaThe> tm = new List<KhoaThe>();
            string query = String.Format("select mathe, ngaynopphat,mavipham \r\nfrom HSMuon join HoSoTra on HSMuon.MaHSM = HoSoTra.MaHSM\r\njoin ChiTietHSTra on ChiTietHSTra.MaHSTra = HoSoTra.MaHSTra\r\nwhere HSMuon.MaThe = N'{0}'",
                mathe);
            using (SqlConnection sqlConnection = new SqlConnection(string_connect))
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    if (sqlDataReader.IsDBNull(1))
                    {
                        tm.Add(new KhoaThe(sqlDataReader.GetString(0), "", sqlDataReader.GetString(2)));

                    }
                    else
                    {
                        tm.Add(new KhoaThe(sqlDataReader.GetString(0), sqlDataReader.GetDateTime(1).ToString("yyyy-MM-dd"), sqlDataReader.GetString(2)));
                    }
                }

                sqlConnection.Close();
            }
            return tm;
        }
        public string Ngaynopphat(string mahosom)
        {
            string ngaynop = "";
            string query = String.Format("Select NgayNopPhat from HoSoTra where MaHSM=N'{0}'",
                mahosom);
            using (SqlConnection sqlConnection = new SqlConnection(string_connect))
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    if (sqlDataReader.IsDBNull(0))
                    {
                        ngaynop = "";
                    }
                    else
                    {
                        ngaynop = sqlDataReader.GetDateTime(0).ToString("dd/mm/yyyy");
                    }

                }
                sqlConnection.Close();
            }
            return ngaynop;
        }
        public string vipham(string mahosom, string magt)
        {
            string vipham = "";
            string query = String.Format("Select TenViPham from ViPham\r\njoin ChiTietHSTra on ViPham.MaViPham = ChiTietHSTra.MaViPham\r\njoin ChiTietHSMuon on ChiTietHSTra.MaGT = ChiTietHSMuon.MaGT\r\njoin HoSoTra on ChiTietHSTra.MaHSTra = HoSoTra.MaHSTra\r\nwhere ChiTietHSMuon.MaHSM = N'{0}' and ChiTietHSMuon.MaGT = N'{1}'",
                mahosom, magt);
            using (SqlConnection sqlConnection = new SqlConnection(string_connect))
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    if (sqlDataReader.IsDBNull(0))
                    {
                        vipham = "";
                    }
                    else
                    {
                        vipham = sqlDataReader.GetString(0);
                    }

                }
                sqlConnection.Close();
            }
            return vipham;
        }
        public string magt(string ma)
        {
            string magt = "";
            string query = String.Format("Select MaGT from ChiTietHSMuon where MaHSM = N'{0}'",
                ma);
            using (SqlConnection sqlConnection = new SqlConnection(string_connect))
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    magt = sqlDataReader.GetString(0);

                }
                sqlConnection.Close();
            }
            return magt;
        }
        public List<string> MaHTap(string query)
        {
            List<string> list = new List<string>();
            using (SqlConnection sqlConnection = new SqlConnection(string_connect))
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    list.Add(sqlDataReader.GetString(0).Trim());

                }

                sqlConnection.Close();
            }
            return list;
        }
        public int SLGT(string query)
        {
            int sl = -1;
            using (SqlConnection sqlConnection = new SqlConnection(string_connect))
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    sl = sqlDataReader.GetInt32(0);

                }

                sqlConnection.Close();
            }
            return sl;
        }
}
}
