using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using DevExpress.XtraGrid.Views.Grid;

namespace GUI
{
    public partial class FrmHoaDonBanHang : DevExpress.XtraEditors.XtraForm
    {
        BLL_HoaDonBanHang bllHDBH;
        BLL_NhanVien bllNV;
        public FrmHoaDonBanHang()
        {
            InitializeComponent();
        }


        #region Method
        void loadGridControl()
        {
            bllHDBH = new BLL_HoaDonBanHang();
            gcHoaDon.DataSource = bllHDBH.getHD_KH_NV();
        }
        void loadCbo()
        {
            cboThongKe.Items.Add("Theo nhân viên");
            cboThongKe.Items.Add("Theo ngày lập hóa đơn");

            bllNV = new BLL_NhanVien();
            sleNV.Properties.DataSource = bllNV.getAllNhanVien();
            sleNV.Properties.DisplayMember = "TenNV";
            sleNV.Properties.ValueMember = "MaNV";


        }
        #endregion
        #region Event
        private void FrmHoaDonBanHang_Load(object sender, EventArgs e)
        {
            loadGridControl();
            loadCbo();
        }
        private void gvHD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var maHD = gvHD.GetRowCellValue(gvHD.FocusedRowHandle, gvHD.Columns["MaHD"]);
            var ngayLap = gvHD.GetRowCellValue(gvHD.FocusedRowHandle, gvHD.Columns["NgayLap"]);
            var nhanVien = gvHD.GetRowCellValue(gvHD.FocusedRowHandle, gvHD.Columns["TenNV"]);
            var ban = gvHD.GetRowCellValue(gvHD.FocusedRowHandle, gvHD.Columns["TenBan"]);
            var phuThu = gvHD.GetRowCellValue(gvHD.FocusedRowHandle, gvHD.Columns["PhuThu"]);
            var giamGia = gvHD.GetRowCellValue(gvHD.FocusedRowHandle, gvHD.Columns["GiamGia"]);
            var khachHang = gvHD.GetRowCellValue(gvHD.FocusedRowHandle, gvHD.Columns["TenKH"]);
            var trangThai = gvHD.GetRowCellValue(gvHD.FocusedRowHandle, gvHD.Columns["StrTrangThai"]);
            var tongTien = gvHD.GetRowCellValue(gvHD.FocusedRowHandle, gvHD.Columns["TongTien"]);

            try
            {
                txtMaHD.Text = maHD.ToString();
                dENgayLapHD.EditValue = Convert.ToDateTime(ngayLap);
                txtNhanVIen.Text = nhanVien.ToString();
                txtBan.Text = ban.ToString();
                txtPhuThu.Text = phuThu.ToString();
                txtGiamGia.Text = giamGia.ToString();
                txtKH.Text = khachHang.ToString();
                cboTrangThai.Text = trangThai.ToString();
                txtTongTien.Text = tongTien.ToString();
            }
            catch (Exception)
            {
                return;
            }

        }
        private void gvHD_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "StrTrangThai")
            {
                string stt = View.GetRowCellDisplayText(e.RowHandle, View.Columns["StrTrangThai"]);
                if (stt.Equals("Chưa thanh toán"))
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                else
                {
                    e.Appearance.ForeColor = Color.LimeGreen;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Italic);
                }
            }
        }
        private void cboThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThongKe.SelectedIndex == 0)
            {
                lbNV.Enabled = true;
                lbNgayBD.Enabled = false;
                lbNgayKT.Enabled = false;
            }
            else
            {
                lbNV.Enabled = false;
                lbNgayBD.Enabled = true;
                lbNgayKT.Enabled = true;
            }
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cboThongKe.SelectedIndex == 0)
            {
                if (sleNV.EditValue == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo [Message]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bllHDBH = new BLL_HoaDonBanHang();
                List<DTO_KhachHangHoaDon> lst = bllHDBH.getHD_KH_NV_ByMaNV(sleNV.EditValue.ToString());
                gcHoaDon.DataSource = lst;
                txtSoLuongKQ.Text = lst.Count.ToString();
                txtTongDoanhThu.Text = string.Format("{0:0,0 đ}", lst.Sum(t => t.TongTien));
            }
            else if(cboThongKe.SelectedIndex == 1)
            {
                if (deNgayBD.EditValue == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn ngày bắt đầu.", "Thông báo [Message]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (deNgayKT.EditValue == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn ngày kết thúc.", "Thông báo [Message]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Convert.ToDateTime(deNgayKT.EditValue) < Convert.ToDateTime(deNgayBD.EditValue))
                {
                    XtraMessageBox.Show("Vui lòng chọn ngày kết thúc lớn hơn ngày bắt đầu.", "Thông báo [Message]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                List<DTO_KhachHangHoaDon> lst = bllHDBH.getHD_KH_NV().Where(t => t.NgayLap >= Convert.ToDateTime(deNgayBD.EditValue) && t.NgayLap <= Convert.ToDateTime(deNgayKT.EditValue)).ToList();
                gcHoaDon.DataSource = lst;
                txtSoLuongKQ.Text = lst.Count.ToString();
                txtTongDoanhThu.Text = string.Format("{0:0,0 đ}", lst.Sum(t => t.TongTien));
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadGridControl();
            loadCbo();
        }
        #endregion

        

        
    }
}