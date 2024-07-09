using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BTLSQL
{
    internal class ConectData
    {
        SqlConnection sqlConnection;
        public void Connect()
        {
            sqlConnection = new SqlConnection("Data Source=LAPTOP-K9PN94BS\\SQLEXPRESS;Initial Catalog=QLBanLapTop;Integrated Security=True");

            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

        }
        public void closeConnect()
        {

            if (sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }
        public DataTable table(string query)
        {
            DataTable table = new DataTable();
            Connect();
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            adapter.Fill(table);
            closeConnect();
            table.Dispose();
            return table;
        }
        public void excute(string query)
        {
            Connect();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            closeConnect();
        }
        public void insert(string ma, string macty, string mabh, string loaihang, string tenhang, int sl, string donvitinh, int dongianhap, int dongiaxuat)
        {
            try
            {

                Connect();
                SqlCommand cmd = new SqlCommand("spInsertSp",sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@masp", SqlDbType.NVarChar).Value = ma;
                cmd.Parameters.AddWithValue("@macty", SqlDbType.NVarChar).Value = macty;
                cmd.Parameters.AddWithValue("@mabh", SqlDbType.NVarChar).Value = mabh;
                cmd.Parameters.AddWithValue("@maloaihang", SqlDbType.NVarChar).Value = loaihang;
                cmd.Parameters.AddWithValue("@tenhang", SqlDbType.NVarChar).Value = tenhang;
                cmd.Parameters.AddWithValue("@soluong", SqlDbType.Int).Value = sl;
                cmd.Parameters.AddWithValue("@donvitinh", SqlDbType.NVarChar).Value = donvitinh;
                cmd.Parameters.AddWithValue("@dongianhap", SqlDbType.Int).Value = dongianhap;
                cmd.Parameters.AddWithValue("@dongiaxuat", SqlDbType.Int).Value = dongiaxuat;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công","Thông báo");
                closeConnect();
            }catch(Exception e)
            {
                MessageBox.Show("ERROR:" + e );
            }
           }
        public void update(string ma, string macty, string mabh, string loaihang, string tenhang, int sl, string donvitinh, int dongianhap, int dongiaxuat)
        {
            try
            {

            Connect();
            SqlCommand cmd = new SqlCommand("spUpdateSp", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@masp", SqlDbType.NVarChar).Value = ma;
            cmd.Parameters.AddWithValue("@macty", SqlDbType.NVarChar).Value = macty;
            cmd.Parameters.AddWithValue("@mabh", SqlDbType.NVarChar).Value = mabh;
            cmd.Parameters.AddWithValue("@maloaihang", SqlDbType.NVarChar).Value = loaihang;
            cmd.Parameters.AddWithValue("@tenhang", SqlDbType.NVarChar).Value = tenhang;
            cmd.Parameters.AddWithValue("@soluong", SqlDbType.Int).Value = sl;
            cmd.Parameters.AddWithValue("@donvitinh", SqlDbType.NVarChar).Value = donvitinh;
            cmd.Parameters.AddWithValue("@dongianhap", SqlDbType.Int).Value = dongianhap;
            cmd.Parameters.AddWithValue("@dongiaxuat", SqlDbType.Int).Value = dongiaxuat;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Update thành công", "Thông báo");
            closeConnect();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR" + e);
            }
        }
    }
}
