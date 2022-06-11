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
    public partial class FrmCaLamViec : DevExpress.XtraEditors.XtraForm
    {
        BLL_CaLamViec bllCLV;
        BLL_NhanVien bllNV;
        BLL_ChamCong bllChC;
        BLL_DangKyCa bllDKC;

        public FrmCaLamViec()
        {
            InitializeComponent();
        }

        private void FrmCaLamViec_Load(object sender, EventArgs e)
        {
            loadData();
            loadSearchLookupEdit();
            dongGiaoTac();

            btnLuuOnGV.Click += BtnLuuOnGV_Click;
            btnXoaOnGV.Click += BtnXoaOnGV_Click;
        }

        private void BtnXoaOnGV_Click(object sender, EventArgs e)
        {
            bllChC = new BLL_ChamCong();
            bllDKC = new BLL_DangKyCa();
            var maCa = gvCaLamViec.GetRowCellValue(gvCaLamViec.FocusedRowHandle, gvCaLamViec.Columns["MaCa"]);
            var tenCa = gvCaLamViec.GetRowCellValue(gvCaLamViec.FocusedRowHandle, gvCaLamViec.Columns["TenCa"]);

            //Check khóa ngoại trên bảng ChamCong
            //Check khóa ngoại trên bảng DangKyCa
            if (bllDKC.checkKhoaNgoai_MaCa(maCa.ToString().Trim()))
            {
                XtraMessageBox.Show("Không thể xóa ca làm việc này.\n(Ca #" + maCa.ToString().Trim() + " đã đã có nhân viên đăng ký làm việc).", "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Thực hiện xóa
            if (XtraMessageBox.Show("Bạn có muốn xóa ca #" + maCa.ToString().Trim() + "("+tenCa.ToString().Trim()+") không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
            {
                string kqDel = bllCLV.delete(maCa.ToString().Trim());
                if (kqDel.Equals("1"))
                {
                    acThongBao.Show(this, "Thông báo", "Xóa thành công."
                           , "", Properties.Resources.success2___Copy, new Message());
                    XtraMessageBox.Show("Xóa thành công ca #" + maCa.ToString().Trim() + "(" + tenCa.ToString().Trim()+").", "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.None);
                    dongGiaoTac();
                    loadData();
                }
                else
                {
                    XtraMessageBox.Show("Error: " + kqDel, "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            


        }

        private void BtnLuuOnGV_Click(object sender, EventArgs e)
        {
            var maCa = gvCaLamViec.GetRowCellValue(gvCaLamViec.FocusedRowHandle, gvCaLamViec.Columns["MaCa"]);
            var tenCa = gvCaLamViec.GetRowCellValue(gvCaLamViec.FocusedRowHandle, gvCaLamViec.Columns["TenCa"]);
            var gioBD = gvCaLamViec.GetRowCellValue(gvCaLamViec.FocusedRowHandle, gvCaLamViec.Columns["GioBD"]);
            var gioKT = gvCaLamViec.GetRowCellValue(gvCaLamViec.FocusedRowHandle, gvCaLamViec.Columns["GioKT"]);
            var soTien = gvCaLamViec.GetRowCellValue(gvCaLamViec.FocusedRowHandle, gvCaLamViec.Columns["SoTien"]);

            if(maCa!=null && tenCa!=null && gioBD != null && gioKT != null && soTien != null)
            {
                if(tenCa.ToString().Trim() == string.Empty)
                {
                    XtraMessageBox.Show(lbTenCa.Text + " không được để trống.", "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (soTien.ToString().Equals("0"))
                {
                    XtraMessageBox.Show(lbSoTien.Text + " không được để trống.", "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tblCaLamViec clv = new tblCaLamViec();
                clv.MaCa = maCa.ToString();
                clv.TenCa = tenCa.ToString();
                clv.GioBD = string.Format("{0:T}",Convert.ToDateTime(gioBD));
                clv.GioKT = string.Format("{0:T}", Convert.ToDateTime(gioKT));
                clv.SoTien = Convert.ToDecimal(soTien);

                string kqUpd = bllCLV.update(clv);
                if (kqUpd.Equals("1"))
                {
                    acThongBao.Show(this, "Thông báo", "Cập nhật thành công."
                           , "", Properties.Resources.success2___Copy, new Message());
                    XtraMessageBox.Show("Cập nhật thành công ca làm việc #" + clv.MaCa + "(" + clv.TenCa + ").", "Thông báo [Message]"
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

        private void loadData()
        {
            bllCLV = new BLL_CaLamViec();
            gcCaLamViec.DataSource = bllCLV.getAllCaLamViec();
        }
        private void loadSearchLookupEdit()
        {
            bllNV = new BLL_NhanVien();
            sleNhanVien.Properties.DataSource = bllNV.getAllNhanVien();
            sleNhanVien.Properties.DisplayMember = "TenNV";
            sleNhanVien.Properties.ValueMember = "MaNV";

        }
        private void dongGiaoTac()
        {
            btnDangKyCa.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;


            layoutControlGroupNhapLieu.Enabled = false;
            sleNhanVien.ResetText();
            //txtMaCLV.Enabled = false;
            //txtSoTien.Enabled = false;
            //txtTenCLV.Enabled = false;
            //teGioBD.Enabled = false;
            //teGioKT.Enabled = false;

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnLuu.Enabled = true;
            //Mở nhập liệu
            layoutControlGroupNhapLieu.Enabled = true;
            //txtMaCLV.Enabled = false;
            //txtSoTien.Enabled = false;
            //txtTenCLV.Enabled = false;
            //teGioBD.Enabled = false;
            //teGioKT.Enabled = false;
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dongGiaoTac();
            loadData();
        }

        private void chkeTaoMaTuDong_CheckedChanged(object sender, EventArgs e)
        {
            if(chkeTaoMaTuDong.Checked == true)
            {
                txtMaCLV.Enabled = false;
                txtMaCLV.Text = bllCLV.AutoCreateID(10, false);
            }  
            else
            {
                txtMaCLV.Enabled = true;
                txtMaCLV.Focus();
                txtMaCLV.Text = string.Empty;
            }    
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Kiểm tra rỗng
            if(txtMaCLV.Text.Trim()==string.Empty)
            {
                XtraMessageBox.Show(lbMaCa.Text + " không được để trống.", "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCLV.Focus();
                return;
            }
            if (txtTenCLV.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show(lbTenCa.Text + " không được để trống.", "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCLV.Focus();
                return;
            }
            if (teGioBD.EditValue ==null)
            {
                XtraMessageBox.Show(lbGioBD.Text + " không được để trống.", "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                teGioBD.Focus();
                return;
            }
            if (teGioKT.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show(lbGioKT.Text + " không được để trống.", "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                teGioKT.Focus();
                return;
            }
            if (txtSoTien.EditValue == null || txtSoTien.EditValue.ToString().Equals("0"))
            {
                XtraMessageBox.Show(lbSoTien.Text + " không được để trống.", "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTien.Focus();
                return;
            }

            //Thêm
            tblCaLamViec clv = new tblCaLamViec();
            clv.MaCa = txtMaCLV.Text.Trim();
            clv.TenCa = txtTenCLV.Text.Trim();
            clv.GioBD = string.Format( "{0:T}",teGioBD.EditValue);
            clv.GioKT = string.Format("{0:T}", teGioKT.EditValue);
            clv.SoTien = Convert.ToDecimal(txtSoTien.EditValue);
            string kqInsert = bllCLV.insert(clv);
            if (kqInsert.Equals("1"))
            {
                acThongBao.Show(this, "Thông báo", "Thêm mới thành công."
                       , "", Properties.Resources.success2___Copy, new Message());
                XtraMessageBox.Show("Thêm thành công ca làm việc #" + txtMaCLV.Text + "("+txtTenCLV.Text+").", "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.None);
                dongGiaoTac();
                loadData();
            }
            else
            {
                XtraMessageBox.Show("Error: " + kqInsert, "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void sleNhanVien_EditValueChanged(object sender, EventArgs e)
        {
            btnDangKyCa.Enabled = true;   
        }

        private void btnDangKyCa_Click(object sender, EventArgs e)
        {
            bllDKC = new BLL_DangKyCa();
            var maNV = sleNhanVien.EditValue;
            var tenNV = sleNhanVien.Text;

            var maCa = gvCaLamViec.GetRowCellValue(gvCaLamViec.FocusedRowHandle, gvCaLamViec.Columns["MaCa"]);
            var tenCa = gvCaLamViec.GetRowCellValue(gvCaLamViec.FocusedRowHandle, gvCaLamViec.Columns["TenCa"]);

            if (maNV != null && maCa != null)
            {
                //Kiểm tra nhân viên này đã đăng ký ca này chưa
                if(bllDKC.checkNhanVienDaDKyCa(maNV.ToString(), maCa.ToString()))
                {
                    XtraMessageBox.Show("Nhân viên này đã đăng ký ca làm việc này rồi.", "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }    
                tblDangKyCa dkc = new tblDangKyCa();
                dkc.MaCa = maCa.ToString();
                dkc.MaNV = maNV.ToString();
                dkc.NgayDKCa = DateTime.Now;
                string kqDKCa = bllDKC.insert(dkc);
                if (kqDKCa.Equals("1"))
                {
                    acThongBao.Show(this, "Thông báo", "Đăng ký thành công."
                           , "", Properties.Resources.success2___Copy, new Message());
                    XtraMessageBox.Show("Đăng ký thành công.\n\nNhân viên " + tenNV.ToString() + "(#" + dkc.MaNV 
                        + ") đăng ký ca #" + dkc.MaCa + "(" + tenCa.ToString() + ").", "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.None);
                    dongGiaoTac();
                    btnDangKyCa.Enabled = true;
                    loadData();
                    loadSearchLookupEdit();
                }
                else
                {
                    XtraMessageBox.Show("Error: " + kqDKCa, "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnDSDKCa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDSDangKyCa frm = new FrmDSDangKyCa();

            frm.ShowDialog();
        }
    }
}