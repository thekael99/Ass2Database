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
    public partial class frmCapNhatDTKMSP : Form
    {
        string makhuyenmai;
        string masanpham;
        string madoitac;
        public frmCapNhatDTKMSP(string makhuyenmai, string masanpham, string madoitac)
        {
            InitializeComponent();
            
            txtMaKhuyenMai.Text = makhuyenmai;
            txtMaDoiTac.Text = madoitac;
            txtMaSanPham.Text = masanpham;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn dừng cập nhật?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnHoantat_Click(object sender, EventArgs e)
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
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "update tblKMSPDT set makhuyenmai=@makhuyenmai,masanpham=@masanpham,madoitac=@madoitac where makhuyenmai=@makhuyenmai";
                sqlCommand.Connection = conn;

                this.makhuyenmai = txtMaKhuyenMai.Text;
                this.masanpham = txtMaSanPham.Text;
                this.madoitac = txtMaDoiTac.Text;

                sqlCommand.Parameters.Add("@makhuyenmai", SqlDbType.VarChar, 10).Value = this.makhuyenmai;
                sqlCommand.Parameters.Add("@masanpham", SqlDbType.VarChar, 10).Value = this.masanpham;
                sqlCommand.Parameters.Add("@madoitac", SqlDbType.VarChar, 10).Value = this.madoitac;

                int ret = sqlCommand.ExecuteNonQuery();
                if (ret > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
