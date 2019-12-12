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
    public partial class frmThemDTKMSP : Form
    {
        SqlConnection conn = null;
        string strConn = "Data Source=PCKael;Initial Catalog=Store;Integrated Security=True";
        public frmThemDTKMSP()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
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
                sqlCommand.CommandText = "add_doitac_khuyenmai_sanpham";
                sqlCommand.Connection = conn;

                SqlParameter paraMaKhuyenMai = new SqlParameter("@saleoff_ID", SqlDbType.VarChar, 10);
                paraMaKhuyenMai.Value = txtMaKhuyenMai.Text;
                sqlCommand.Parameters.Add(paraMaKhuyenMai);
                SqlParameter paraMaSanPham = new SqlParameter("@product_ID", SqlDbType.NVarChar, 10);
                paraMaSanPham.Value = txtMaSanPham.Text;
                sqlCommand.Parameters.Add(paraMaSanPham);
                SqlParameter paraMaDoiTac = new SqlParameter("@partner_ID", SqlDbType.NVarChar, 10);
                paraMaDoiTac.Value = txtMaDoiTac.Text;
                sqlCommand.Parameters.Add(paraMaDoiTac);

                int ret = sqlCommand.ExecuteNonQuery();
                if (ret > 0)
                {
                    MessageBox.Show("Bạn đã thêm thành công!");
                    txtMaKhuyenMai.Text = "";
                    txtMaSanPham.Text = "";
                    txtMaDoiTac.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn hủy bỏ thao tác ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
