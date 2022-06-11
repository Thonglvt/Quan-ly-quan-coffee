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
    public partial class FrmDSDangKyCa : DevExpress.XtraEditors.XtraForm
    {
        BLL_DangKyCa bllDKC;
        BLL_NhanVien bllNV;
        BLL_CaLamViec bllCLV;
        BLL_ChamCong bllChC;
        public FrmDSDangKyCa()
        {
            InitializeComponent();
        }

        private void FrmDSDangKyCa_Load(object sender, EventArgs e)
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
            var maCa = gvDangKyCa.GetRowCellValue(gvDangKyCa.FocusedRowHandle, gvDangKyCa.Columns["MaCa"]);
            var maDKCa = gvDangKyCa.GetRowCellValue(gvDangKyCa.FocusedRowHandle, gvDangKyCa.Columns["MaDKCa"]);
            ////Check ca này đã có kỳ công chưa
            ////Check khóa ngoại trên bảng ChamCong
            //if (bllChC.checkKhoaNgoai_MaCa(maCa.ToString().Trim()))
            //{
            //    XtraMessageBox.Show("Không thể xóa.\n(Ca #" + maCa.ToString().Trim() + " đã đã đươc sử dụng để chấm công).", "Thông báo [Message]"
            //          , MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //Thực hiện xóa
            if (XtraMessageBox.Show("Bạn có muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
            {
                string kqDel = bllDKC.delete(Convert.ToInt32(maDKCa));
                if (kqDel.Equals("1"))
                {
                    acThongBao.Show(this, "Thông báo", "Xóa thành công."
                           , "", Properties.Resources.success2___Copy, new Message());
                    XtraMessageBox.Show("Xóa thành công.", "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.None);
                    dongGiaoTac();
                    loadData();
                    loadSearchLookupEdit();
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
            var maDKCa = gvDangKyCa.GetRowCellValue(gvDangKyCa.FocusedRowHandle, gvDangKyCa.Columns["MaDKCa"]);
            var maCa = gvDangKyCa.GetRowCellValue(gvDangKyCa.FocusedRowHandle, gvDangKyCa.Columns["MaCa"]);
            var maNV = gvDangKyCa.GetRowCellValue(gvDangKyCa.FocusedRowHandle, gvDangKyCa.Columns["MaNV"]);


            if(maDKCa!=null && maCa != null && maNV != null)
            {
                bllDKC = new BLL_DangKyCa();
                tblDangKyCa dkc = new tblDangKyCa();
                dkc.MaDKCa = Convert.ToInt32(maDKCa);
                dkc.MaCa = maCa.ToString();
                dkc.MaNV= maNV.ToString();

                string kqUpd = bllDKC.update(dkc);
                if (kqUpd.Equals("1"))
                {
                    acThongBao.Show(this, "Thông báo", "Cập nhật thành công."
                           , "", Properties.Resources.success2___Copy, new Message());
                    XtraMessageBox.Show("Cập nhật thành công.", "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.None);
                    dongGiaoTac();
                    loadData();
                    loadSearchLookupEdit();
                    btnThem.Enabled = true;
                }
                else
                {
                    XtraMessageBox.Show("Error: " + kqUpd, "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        private void dongGiaoTac()
        {
            btnDKCa.Enabled = false;
            layoutControlGroupNhapLieu.Enabled = false;
        }
        private void loadData()
        {
            bllDKC = new BLL_DangKyCa();
            gcDangKyCa.DataSource = bllDKC.getAllDangKyCa();
        }
        private void loadSearchLookupEdit()
        {
            bllCLV = new BLL_CaLamViec();
            bllNV = new BLL_NhanVien();
            //lookupEdit Ca làm việc
            sleCaLamViecSub.DataSource = bllCLV.getAllCaLamViec();
            sleCaLamViecSub.DisplayMember = "TenCa";
            sleCaLamViecSub.ValueMember = "MaCa";

            sleCaLV.Properties.DataSource = bllCLV.getAllCaLamViec();
            sleCaLV.Properties.DisplayMember = "TenCa";
            sleCaLV.Properties.ValueMember = "MaCa";
            //lookupEdit Nhân viên
            sleNVSub.DataSource = bllNV.getAllNhanVien();
            sleNVSub.DisplayMember = "TenNV";
            sleNVSub.ValueMember = "MaNV";

            sleNV.Properties.DataSource = bllNV.getAllNhanVien();
            sleNV.Properties.DisplayMember = "TenNV";
            sleNV.Properties.ValueMember = "MaNV";


        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadData();
            dongGiaoTac();
            loadSearchLookupEdit();
            btnThem.Enabled = true;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThem.Enabled = false;
            btnDKCa.Enabled = true;
            layoutControlGroupNhapLieu.Enabled = true;
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnDKCa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var clv = sleCaLV.EditValue;
            var nv = sleNV.EditValue;
            var tenCa = sleCaLV.Text;
            var tenNV = sleNV.Text;

            //Kiểm tra khi chưa chọn ca làm việc
            if (clv==null)
            {
                XtraMessageBox.Show("Vui lòng chọn "+ lbCaLamViec.Text, "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sleCaLV.Focus();
                return;
            }
            //Kiểm tra khi chưa chọn nhân viên
            if (nv == null)
            {
                XtraMessageBox.Show("Vui lòng chọn " + lbNhanVien.Text, "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sleCaLV.Focus();
                return;
            }
            //Insert
            bllDKC = new BLL_DangKyCa();
            tblDangKyCa dkc = new tblDangKyCa();
            dkc.MaCa = clv.ToString();
            dkc.MaNV = nv.ToString();
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
                loadData();
                loadSearchLookupEdit();
                btnThem.Enabled = true;
            }
            else
            {
                XtraMessageBox.Show("Error: " + kqDKCa, "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }
    }
}