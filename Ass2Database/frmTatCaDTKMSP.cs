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
    public partial class frmTatCaDTKMSP : Form
    {
        SqlConnection conn = null;
        string strConn = "Data Source=PCKael;Initial Catalog=Store;Integrated Security=True";
        public void getListOrder()
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
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "SELECT * FROM dbo.tblKMSPDT";
                sqlCommand.Connection = conn;
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                lvDonhang.Items.Clear();
                while (sqlReader.Read())
                {
                    ListViewItem lvi = new ListViewItem(sqlReader.GetString(0));
                    lvi.SubItems.Add(sqlReader.GetString(1));
                    lvi.SubItems.Add(sqlReader.GetString(2));
                    lvDonhang.Items.Add(lvi);
                }
                sqlReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public frmTatCaDTKMSP()
        {
            InitializeComponent();
            getListOrder();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn thật sự muốn đóng!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDonhang.SelectedItems.Count == 1)
            {
                string makhuyenmai = lvDonhang.SelectedItems[0].SubItems[0].Text;
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
                    sqlCommand.CommandText = "delete from tblKMSPDT where makhuyenmai=@makhuyenmai";
                    sqlCommand.Connection = conn;
                    sqlCommand.Parameters.Add("@makhuyenmai", SqlDbType.VarChar, 10).Value = makhuyenmai;
                    int ret = sqlCommand.ExecuteNonQuery();
                    if (ret > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                        getListOrder();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (lvDonhang.SelectedItems.Count > 1)
            {
                MessageBox.Show("Lựa chọn không hợp lệ!");
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn đơn hàng cần xóa!");
            }
        }

        string makhuyenmai;
        string masanpham;
        string madoitac;
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (lvDonhang.SelectedItems.Count == 1)
            {
                this.makhuyenmai = lvDonhang.SelectedItems[0].SubItems[0].Text;
                this.masanpham = lvDonhang.SelectedItems[0].SubItems[1].Text;
                this.madoitac = lvDonhang.SelectedItems[0].SubItems[2].Text;

                frmCapNhatDTKMSP frmChild = new frmCapNhatDTKMSP(this.makhuyenmai, this.masanpham, this.madoitac);
                frmChild.ShowDialog();
                getListOrder();


            }
            else if (lvDonhang.SelectedItems.Count > 1)
            {
                MessageBox.Show("Lựa chọn không hợp lệ!");
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn đơn hàng cần cập nhật!");
            }
        }
    }
}
