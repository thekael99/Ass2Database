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
    public partial class frmHienThiSoLuongSanPhamDoiTac : Form
    {
        public frmHienThiSoLuongSanPhamDoiTac()
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
                sqlCommand.CommandText = "p_hien_thi_so_luong_san_pham_doi_tac";
                sqlCommand.Connection = conn;

                SqlParameter paraSoLuong = new SqlParameter("@so_luong", SqlDbType.Int);
                paraSoLuong.Value = Int32.Parse(txtSoLuong.Text);
                sqlCommand.Parameters.Add(paraSoLuong);

                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                lvSanpham.Items.Clear();
                while (sqlReader.Read())
                {
                    string masanpham = sqlReader.GetString(0);
                    string soluong = sqlReader.GetInt32(1).ToString();

                    ListViewItem lvi = new ListViewItem(masanpham);
                    lvi.SubItems.Add(soluong);
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
