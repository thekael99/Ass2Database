using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass2Database
{
    public partial class frmMainInterface : Form
    {
        
        public frmMainInterface()
        {
            InitializeComponent();
            lvChucNang.Items.Clear();

            ListViewItem item10 = new ListViewItem("Thêm Đối tác Khuyến Mãi Sản Phẩm");
            item10.SubItems.Add("Thắng");
            ListViewItem item11 = new ListViewItem("Xem danh sách sản phẩm đang khuyến mãi");
            item11.SubItems.Add("Thắng");
            ListViewItem item12 = new ListViewItem("Xem danh sách sản phẩm đối tác");
            item12.SubItems.Add("Thắng");
            ListViewItem item13 = new ListViewItem("Chỉnh sửa danh sách Đối tác Khuyến Mãi Sản Phẩm");
            item13.SubItems.Add("Thắng");

            lvChucNang.Items.Add(item10);
            lvChucNang.Items.Add(item11);
            lvChucNang.Items.Add(item12);
            lvChucNang.Items.Add(item13);
        }

        private void lvChucNang_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            string getFunction = null;
            if(lvChucNang.SelectedItems.Count==1)
            {
                getFunction = lvChucNang.SelectedItems[0].SubItems[0].Text;
            }
            else if(lvChucNang.SelectedItems.Count==0)
            {
                MessageBox.Show("Bạn chưa chọn chức năng!");
                return; 
            }
            else
            {
                MessageBox.Show("Lựa chọn của bạn không hợp lệ!");
                return;
            }
            if (getFunction!=null)
            {                
                if (getFunction == "Thêm Đối tác Khuyến Mãi Sản Phẩm")
                {
                    frmThemDTKMSP frm = new frmThemDTKMSP();
                    frm.ShowDialog();
                }                
                else if (getFunction == "Xem danh sách sản phẩm đang khuyến mãi")
                {
                    frmHienThiSanPhamConKhuyenMai frm = new frmHienThiSanPhamConKhuyenMai();
                    frm.ShowDialog();
                }
                else if (getFunction == "Xem danh sách sản phẩm đối tác")
                {
                    frmHienThiSoLuongSanPhamDoiTac frm = new frmHienThiSoLuongSanPhamDoiTac();
                    frm.ShowDialog();
                }
                else if (getFunction == "Chỉnh sửa danh sách Đối tác Khuyến Mãi Sản Phẩm")
                {
                    frmTatCaDTKMSP frm = new frmTatCaDTKMSP();
                    frm.ShowDialog();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
