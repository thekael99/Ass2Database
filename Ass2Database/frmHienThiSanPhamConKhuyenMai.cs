using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ass2Database
{
    public partial class frmHienThiSanPhamConKhuyenMai : Form
    {
        public frmHienThiSanPhamConKhuyenMai()
        {
            InitializeComponent();
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            string strConn = "Data Source=PCKael;Initial Catalog=Store;Integrated Security=True";
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(strConn);
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "p_hien_thi_san_pham_con_khuyen_mai";
                sqlCommand.Connection = conn;

                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                lvSanpham.Items.Clear();
                while (sqlReader.Read())
                {
                    string masanpham = sqlReader.GetString(0);
                    string tensanpham = sqlReader.GetString(1);
                    string makhuyenmai = sqlReader.GetString(2);
                    string madoitac = sqlReader.GetString(3);
                    string thoigianketthuc = sqlReader.GetDateTime(4).ToString("yyyy-MM-dd HH:mm:ss.fff");
                    ListViewItem lvi = new ListViewItem(masanpham);
                    lvi.SubItems.Add(tensanpham);
                    lvi.SubItems.Add(makhuyenmai);
                    lvi.SubItems.Add(madoitac);
                    lvi.SubItems.Add(thoigianketthuc);
                    lvSanpham.Items.Add(lvi);
                }
                sqlReader.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
