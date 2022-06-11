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

namespace GUI
{
    public partial class FrmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        BLL_NhanVien bllNV;
        BLL_AutoCreateID bllAutoCrID;
        BLL_CheckTextbox bllCheckTxt;
        BLL_DangKyCa bllDKC;
        BLL_ChiTietChamCong bllCTCC;
        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            loadData();
            dongGiaoTac();

            //Add giới tính
            List<string> lstGT = new List<string>();
            lstGT.Add("Nam");
            lstGT.Add("Nữ");
            GridLookUpEditGioiTinh.DataSource = lstGT;

            btnLuuGV.Click += BtnLuuGV_Click;
            btnXoaOnGV.Click += BtnXoaOnGV_Click;
        }

        private void BtnXoaOnGV_Click(object sender, EventArgs e)
        {
            bllNV = new BLL_NhanVien();
            var maNV = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, gvNhanVien.Columns["MaNV"]);
            if(maNV!=null)
            {
                //Check khóa ngoại trên bảng DangKyCa
                if (bllDKC.checkKhoaNgoai_MaNV(maNV.ToString()))
                {
                    XtraMessageBox.Show("Nhân viên có mã #"+maNV.ToString()+" đã đăng ký ca không thể xóa.", "Thông báo [Message]"
                           , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Check khóa ngoại trên bảng Chấm công
                //if (bllCTCC.checkKhoaNgoai_MaNV(maNV.ToString()))
                //{
                //    XtraMessageBox.Show("Nhân viên có mã #" + maNV.ToString() + " đã được chấm công không thể xóa.", "Thông báo [Message]"
                //           , MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                if (XtraMessageBox.Show("Bạn có muốn xóa nhân viên có mã #"+maNV.ToString()+" không?", "Xác nhận", MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.No)
                {
                    string kqDelete = bllNV.deleteNV(maNV.ToString());
                    if (kqDelete.Equals("1"))
                    {
                        acThongBao.Show(this, "Thông báo", "Xóa thành công."
                           , "", Properties.Resources.success2___Copy, new Message());
                        XtraMessageBox.Show("Xóa thành công nhân viên có mã #" + maNV.ToString(), "Thông báo [Message]"
                               , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        XtraMessageBox.Show("Error: " + kqDelete, "Thông báo [Message]"
                              , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                

            }    
        }

        private void BtnLuuGV_Click(object sender, EventArgs e)
        {
            var maNV = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, gvNhanVien.Columns["MaNV"]);
            var tenNV = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, gvNhanVien.Columns["TenNV"]);
            var ngaySinh = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, gvNhanVien.Columns["NgaySinh"]);
            var gioiTinh = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, gvNhanVien.Columns["GioiTinh"]);
            var sdt = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, gvNhanVien.Columns["SDT"]);
            var diaChi = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, gvNhanVien.Columns["DiaChi"]);
            var cmnd = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, gvNhanVien.Columns["CCCD"]);
            var trangThai = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, gvNhanVien.Columns["TrangThai"]);

            if (maNV != null && tenNV != null && ngaySinh != null && gioiTinh != null && sdt != null
                && diaChi != null && cmnd != null && trangThai != null)
            {
                tblNhanVien nv = new tblNhanVien();
                nv.MaNV = maNV.ToString().Trim();
                nv.TenNV = tenNV.ToString().Trim();
                nv.NgaySinh = Convert.ToDateTime(ngaySinh);
                nv.GioiTinh = gioiTinh.ToString().Trim();
                nv.DiaChi = diaChi.ToString().Trim();
                nv.SDT = sdt.ToString().Trim();
                nv.CCCD = cmnd.ToString().Trim();
                nv.TrangThai = Convert.ToBoolean(trangThai);

                string kqUpd = bllNV.updateNV(nv);
                if (kqUpd.Equals("1"))
                {
                    acThongBao.Show(this, "Thông báo", "Cập nhật thành công."
                       , "", Properties.Resources.success2___Copy, new Message());
                    XtraMessageBox.Show("Cập nhật thành công.", "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.None);
                    dongGiaoTac();
                    loadData();
                }
                else
                {
                    XtraMessageBox.Show("Error: " + kqUpd, "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        void loadData()
        {
            bllNV = new BLL_NhanVien();
            gcNhanVien.DataSource = bllNV.getAllNhanVien();
            gvNhanVien.BestFitColumns();
        }
        void dongGiaoTac()
        {
            btnSuaNV.Enabled = false;
            btnLuuNV.Enabled = false;

            lbDiaChi.Enabled = false;
            lbGioiTinh.Enabled = false;
            lbMaNV.Enabled = false;
            lbNgaySinh.Enabled = false;
            lbSDT.Enabled = false;
            lbTenNV.Enabled = false;
            lbCCCD.Enabled = false;

            txtCMND.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtMaNV.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtTenNV.Text = string.Empty;
            deNgaySinh.ResetText();


            radioGroupGT.SelectedIndex = 0;

        }

        private void btnThemNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bllAutoCrID = new BLL_AutoCreateID();
            btnLuuNV.Enabled = true;
            btnThemNV.Enabled = false;
            //Tạo tự động mã nhân viên
            txtMaNV.Text = bllAutoCrID.create_ID_NV();
            //Mở các filed nhập liệu
            lbDiaChi.Enabled = true;
            lbGioiTinh.Enabled = true;
            lbNgaySinh.Enabled = true;
            lbSDT.Enabled = true;
            lbTenNV.Enabled = true;
            lbCCCD.Enabled = true;
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadData();
            dongGiaoTac();
            btnThemNV.Enabled = true;
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            bllCheckTxt = new BLL_CheckTextbox();
            if (!BLL_CheckTextbox.CheckPhone(txtSDT.Text) && txtSDT.Text.Trim()!=string.Empty)
            {
                errorProviderSDT.SetError(txtSDT, "Số điện thoại không đúng định dạng");
            }    
            else
            {
                errorProviderSDT.Clear();
            }    
        }

        private void btnLuuNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Kiểm tra rỗng
            if(txtTenNV.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show(lbTenNV.Text+" không được để trống.", "Thông báo [Message]"
                       , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return;
            }
            if (deNgaySinh.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn " + lbNgaySinh.Text, "Thông báo [Message]"
                       , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                deNgaySinh.Focus();
                return;
            }
            if (txtSDT.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show(lbSDT.Text + " không được để trống.", "Thông báo [Message]"
                       , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            if (txtCMND.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show(lbCCCD.Text + " không được để trống.", "Thông báo [Message]"
                       , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCMND.Focus();
                return;
            }
            //Check cmnd/cccd trùng
            if (bllNV.checkTonTaiCMND(txtCMND.Text))
            {
                XtraMessageBox.Show(lbCCCD.Text + " đã tồn tại.", "Thông báo [Message]"
                       , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCMND.Focus();
                return;
            }
            //Check SDT trùng
            if (bllNV.checkTonTaiSDT(txtSDT.Text))
            {
                XtraMessageBox.Show(lbSDT.Text + " đã tồn tại.", "Thông báo [Message]"
                       , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            //Insert nhân viên
            tblNhanVien nv = new tblNhanVien();
            nv.MaNV = txtMaNV.Text.Trim();
            nv.TenNV = txtTenNV.Text.Trim();
            nv.NgaySinh = Convert.ToDateTime(deNgaySinh.EditValue);
            nv.GioiTinh = radioGroupGT.EditValue.ToString();
            nv.DiaChi = txtDiaChi.Text.Trim();
            nv.SDT = txtSDT.Text.Trim();
            nv.CCCD = txtCMND.Text.Trim();
            nv.ChucVu = 3;
            nv.NgayVaoLam =DateTime.Now;
            nv.MatKhau = "12345678";
            nv.TaiKhoan = "nv";
            nv.TrangThai = true;

            string kqInsert = bllNV.insertNV(nv);
            if(kqInsert.Equals("1"))
            {
                acThongBao.Show(this, "Thông báo", "Thêm mới thành công."
                       , "", Properties.Resources.success2___Copy, new Message());
                XtraMessageBox.Show("Thêm thành công nhân viên có mã #"+txtMaNV.Text+".", "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.None);
                dongGiaoTac();
                loadData();
            }   
            else
            {
                XtraMessageBox.Show("Error: "+kqInsert, "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}