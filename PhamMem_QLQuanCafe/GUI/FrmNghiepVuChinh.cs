using BLL;
using DevExpress.XtraEditors;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmNghiepVuChinh : DevExpress.XtraEditors.XtraForm
    {
        BLL_Ban bllBan;
        BLL_NhomSP bllNSP;
        BLL_SanPham bllSP;
        BLL_BangGia bllBG;
        BLL_HoaDonBanHang bllHDBH;
        BLL_KhachHang bllKH;
        BLL_ChiTietHoaDonBanHang bllCTHDBH;
        BLL_AutoCreateID bllACID;
        //
        tblBan banDangChon;
        List<DTO_KhachHangHoaDon> HDKH_HienTai;
        tblHoaDonBanHang HD_HienTai = new tblHoaDonBanHang();
        public double tongTienWhenChange;

        public FrmNghiepVuChinh()
        {
            InitializeComponent();
        }

        private void FrmNghiepVuChinh_Load(object sender, EventArgs e)
        {
            loaddAll();
            btnXoaCTHD.Click += BtnXoaCTHD_Click;
            btnMoBan.Enabled = false;
        }

       
        private void loaddAll()
        {
            loadBan();
            loadNhomSP();
            loadSanPham();
            loadSearhLookupEdit();
        }
        private void emptyCTHD()
        {
            sleBan_CTHD.EditValue = null;
            sleKH.EditValue = null;
            deNgayLapHD.EditValue = null;
            txtMaHD.Text = string.Empty;
            txtNhanVien.Text = string.Empty;
            txtTrangThai.Text = "Trống";
            gcCTHD.DataSource = null;
            //gcCTHD.RefreshDataSource();
            //Gán dữ liệu tổng tiền, giảm giá, phụ thu
            txtTongTienCTHD.Text = string.Empty;
            txtPhuThu.Value = 0;
            txtGiamGia.Value = 0;
            txtTongTienHD.Text = string.Empty;
            //Tính giá phụ thu thông qua % phụ thu
            txtGiaPhuThu.Text = string.Empty;
            //Tính giá giảm giá thu thông qua % giảm giá
            txtGiaGiamGia.Text = string.Empty;
            //
            txtTienNhan.Value = 0;
            txtTienThua.Text = string.Empty;
        }
        private void loadTextboxHD()
        {
            if (this.HD_HienTai != null)
            {
                sleBan_CTHD.EditValue = this.HD_HienTai.MaBan;
                sleKH.EditValue = this.HD_HienTai.MaKH;
                deNgayLapHD.EditValue = this.HD_HienTai.NgayLap;
                txtMaHD.Text = this.HD_HienTai.MaHD;
                txtNhanVien.Text = this.HD_HienTai.MaNV;
                txtTrangThai.Text = (this.HD_HienTai.TrangThai == true) ? "Có khách" : "Trống";
            }
        }
        public static int tableWidth = 100;
        public static int tableHeigth = 100;

        #region Method
        void doiTrangThaiBan(bool? pCoNguoi, ref Button btn)
        {
            if (pCoNguoi == true)
            {
                btn.BackColor = Color.Red;
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.LightGray;
                btn.ForeColor = Color.Black;
            }    
        }
        void loadBan()
        {
            fplHienThiBan.Controls.Clear();
            bllBan = new BLL_Ban();
            List<tblBan> lstBan = bllBan.getAll();
            foreach (tblBan ban in lstBan)
            {
                Button btn = new Button() { Width = FrmNghiepVuChinh.tableWidth, Height = FrmNghiepVuChinh.tableHeigth };
                btn.Text = ban.TenBan;
                btn.Name = ban.MaBan;
                btn.Image = Properties.Resources.iconban2;
                btn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                btn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
                //Trái, Trên, phải, dưới
                btn.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
                //Kiểm tra trạng thái bàn
                doiTrangThaiBan(Convert.ToBoolean(ban.TrangThai), ref btn);
                //doiTrangThaiBan(ban.TrangThai, ref btn);
                fplHienThiBan.Controls.Add(btn);
                btn.Click += Btn_Click;
            }
           
        }
        void loadSearhLookupEdit()
        {
            bllBan = new BLL_Ban();
            sleBan_CTHD.Properties.DataSource = bllBan.getAll();
            sleBan_CTHD.Properties.DisplayMember = "TenBan";
            sleBan_CTHD.Properties.ValueMember = "MaBan";

            bllKH = new BLL_KhachHang();
            sleKH.Properties.DataSource = bllKH.getAll();
            sleKH.Properties.DisplayMember = "TenKH";
            sleKH.Properties.ValueMember = "MaKH";
        }
        void loadNhomSP()
        {
            bllNSP = new BLL_NhomSP();
            List<tblNhomSP> lstNhomSP = bllNSP.getAll();
            gcNhomSP.DataSource = lstNhomSP;
        }
        void loadSanPham()
        {
            bllBG = new BLL_BangGia();
            gcTU.DataSource = bllBG.getBangGiaSP();
        }
        void ganTextBoxTongTien(double tongTienCTHD,decimal phuThu,double giaPhuThu,decimal giamGia,double giaGiamGia,double tongTienHD,double tienNhan)
        {
            //Gán dữ liệu tổng tiền, giảm giá, phụ thu
            txtTongTienCTHD.Text = string.Format("{0:0,0 đ}", tongTienCTHD);
            txtPhuThu.Value = Convert.ToDecimal(phuThu);
            txtGiamGia.Value = Convert.ToDecimal(giamGia);
            txtTongTienHD.Text = string.Format("{0:0,0 đ}", tongTienHD);
            //Tính giá phụ thu thông qua % phụ thu
            txtGiaPhuThu.Text = string.Format("+"+"{0:0,0 đ}", giaPhuThu);
            //Tính giá giảm giá thu thông qua % giảm giá
            txtGiaGiamGia.Text = string.Format("{0:0,0 đ}", giaGiamGia);
        }
        #endregion

        #region Event
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loaddAll();
            btnMoBan.Enabled = false;
            emptyCTHD();
            txtThanhTienOfMon.Text = string.Empty;
            DTO_SessionHoaDon.HDKH_HienTai = new List<DTO_KhachHangHoaDon>();
            DTO_SessionHoaDon.HD_HienTai = new tblHoaDonBanHang();

        }
        private void Btn_Click(object sender, EventArgs e)
        {
            bllBan = new BLL_Ban();
            bllHDBH = new BLL_HoaDonBanHang();
            Button btn = sender as Button;
            //Lưu thôn tin bàn đang chọn
            banDangChon = new tblBan();
            banDangChon = bllBan.findBanByMa(btn.Name);

            //Nếu bàn trống
            if (btn.BackColor != Color.Red)
            {
                //Enable btn Mở bàn
                btnMoBan.Enabled = true;
                btnThemMon.Enabled = false;
                btnThanhToan.Enabled = false;
                btnHuyBan.Enabled = false;
                btnTachBan.Enabled = false;
                btnGopBan.Enabled = false;
                emptyCTHD();
                sleBan_CTHD.EditValue = btn.Name;
                DTO_SessionHoaDon.HD_HienTai = new tblHoaDonBanHang();
                DTO_SessionHoaDon.HDKH_HienTai = new List<DTO_KhachHangHoaDon>();
                return;
            }
            //Đóng mở bàn
            btnMoBan.Enabled = false;
            btnThemMon.Enabled = true;
            tblHoaDonBanHang hd = new tblHoaDonBanHang();
            hd = bllHDBH.getHDByMaBanCoKhach(btn.Name);
            
            if (hd!=null)
            {
                //
                DTO_SessionHoaDon.HD_HienTai = new tblHoaDonBanHang();
                DTO_SessionHoaDon.HD_HienTai = bllHDBH.getHDByMaBanCoKhach(btn.Name);
                //
                sleBan_CTHD.EditValue = hd.MaBan;
                sleKH.EditValue = hd.MaKH;
                deNgayLapHD.EditValue = hd.NgayLap;
                txtMaHD.Text = hd.MaHD;
                txtNhanVien.Text = hd.MaNV;
                txtTrangThai.Text = "Có khách";
                //Add vào gridview chi tiết hóa đơn
                bllCTHDBH = new BLL_ChiTietHoaDonBanHang();
                //Gán Hóa đơn khách hàng hiện tại
                DTO_SessionHoaDon.HDKH_HienTai = new List<DTO_KhachHangHoaDon>();
                DTO_SessionHoaDon.HDKH_HienTai = bllCTHDBH.getAll_KH_BG_SP_ByMaHD(hd.MaHD);
                //Mở nút hủy bàn nếu bàn chưa có món (chưa có cthd)
                btnHuyBan.Enabled = (DTO_SessionHoaDon.HDKH_HienTai.Count == 0) ? true : false;
                //Đóng nút thanh toán khi chưa có món (chưa có cthd)
                btnThanhToan.Enabled = (DTO_SessionHoaDon.HDKH_HienTai.Count == 0) ? false : true;
                btnTachBan.Enabled = (DTO_SessionHoaDon.HDKH_HienTai.Count == 0) ? false : true;
                btnGopBan.Enabled = (DTO_SessionHoaDon.HDKH_HienTai.Count == 0) ? false : true;

                List<DTO_KhachHangHoaDon> khhd = bllCTHDBH.getAll_KH_BG_SP_ByMaHD(hd.MaHD);
                gcCTHD.DataSource = khhd;

                //Gán dữ liệu tổng tiền, giảm giá, phụ thu
                double tongTienCTHD = khhd.Sum(t => t.ThanhTien);
                decimal phuThu = Convert.ToDecimal(hd.PhuThu);
                decimal giamGia = Convert.ToDecimal(hd.GiamGia);
                double tongTienHD = Convert.ToDouble(hd.TongTien);
                double giaPhuThu = (tongTienHD * Convert.ToDouble(phuThu)) / 100;
                double giaGiamGia = (tongTienHD * Convert.ToDouble(giamGia)) / 100;
                
                ganTextBoxTongTien(tongTienCTHD, phuThu, giaPhuThu, giamGia, giaGiamGia, tongTienHD, 0);
            }

        }
        private void BtnXoaCTHD_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa món này?", "Thông báo [Message]"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //Xóa
            var maHD = gvChiTietHD.GetRowCellValue(gvChiTietHD.FocusedRowHandle, gvChiTietHD.Columns["MaHD"]);
            var maBG = gvChiTietHD.GetRowCellValue(gvChiTietHD.FocusedRowHandle, gvChiTietHD.Columns["MaBangGia"]);
            //
            if(maHD!=null && maBG!=null)
            {
                string kqDelCTHD = bllCTHDBH.delete(maHD.ToString(), Convert.ToInt32(maBG));
                if (kqDelCTHD.Equals("1"))
                {
                    bllCTHDBH = new BLL_ChiTietHoaDonBanHang();
                    DTO_SessionHoaDon.HDKH_HienTai = bllCTHDBH.getAll_KH_BG_SP_ByMaHD(maHD.ToString());
                    if(DTO_SessionHoaDon.HDKH_HienTai.Count==0)
                    {
                        btnThanhToan.Enabled = false;
                        btnHuyBan.Enabled = true;
                        emptyCTHD();
                    }
                    gcCTHD.DataSource = DTO_SessionHoaDon.HDKH_HienTai;
                    return;
                }
                XtraMessageBox.Show("Error: " + kqDelCTHD, "Thông báo [Message]"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            
        }
        private void gvThucUong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var tenMon = gvThucUong.GetRowCellValue(gvThucUong.FocusedRowHandle, gvThucUong.Columns["TenSP"]);
            var donGia = gvThucUong.GetRowCellValue(gvThucUong.FocusedRowHandle, gvThucUong.Columns["Gia"]);

            txtTenMon.Text = (tenMon != null) ? tenMon.ToString() : string.Empty;
            txtThanhTienOfMon.Text = (donGia != null) ? string.Format("{0:0,0 đ}",donGia) : string.Empty;

            txtSoLuong.Value = 1;
        }
        private void gvNhomSP_Click(object sender, EventArgs e)
        {
            var maNhom = gvNhomSP.GetRowCellValue(gvNhomSP.FocusedRowHandle, gvNhomSP.Columns["MaNhomSP"]);
            if (maNhom != null)
            {
                gcTU.DataSource = bllBG.getBangGiaSPByMaNhom(maNhom.ToString());
            }   
        }
        private void txtPhuThu_ValueChanged(object sender, EventArgs e)
        {
            double phuThu = Convert.ToDouble(txtPhuThu.Value.ToString());
            double giamGia = Convert.ToDouble(txtGiamGia.Value.ToString());

            if (DTO_SessionHoaDon.HDKH_HienTai.Count>0)
            {
                double tongTien = DTO_SessionHoaDon.HDKH_HienTai.Sum(t => t.ThanhTien);
                double tienPhuThu = ((tongTien * phuThu) / 100.0);
                double tienGiamGia = ((tongTien * giamGia) / 100.0);

                txtGiaPhuThu.Text = string.Format("+"+"{0:0,0 đ}", tienPhuThu);
                txtTongTienHD.Text = string.Format("{0:0,0 đ}", (tongTien + tienPhuThu)-tienGiamGia);

                this.tongTienWhenChange = (tongTien + tienPhuThu) - tienGiamGia;
                double tienNhan = Convert.ToDouble(txtTienNhan.Value.ToString());
                if (tienNhan >= this.tongTienWhenChange)
                    txtTienThua.Text = string.Format("{0:0,0 đ}", tienNhan - this.tongTienWhenChange);
            }

        }
        private void txtGiamGia_ValueChanged(object sender, EventArgs e)
        {
            double phuThu = Convert.ToDouble(txtPhuThu.Value.ToString());
            double giamGia = Convert.ToDouble(txtGiamGia.Value.ToString());

            if (DTO_SessionHoaDon.HDKH_HienTai.Count > 0)
            {
                double tongTien = DTO_SessionHoaDon.HDKH_HienTai.Sum(t => t.ThanhTien);
                double tienGiamGia = ((tongTien * giamGia) / 100.0);
                double tienPhuThu = ((tongTien * phuThu) / 100.0);

                txtGiaGiamGia.Text = string.Format("{0:0,0 đ}", tienGiamGia);
                txtTongTienHD.Text = string.Format("{0:0,0 đ}", (tongTien + tienPhuThu) - tienGiamGia);
                this.tongTienWhenChange = (tongTien + tienPhuThu) - tienGiamGia;

                double tienNhan = Convert.ToDouble(txtTienNhan.Value.ToString());
                if (tienNhan >= this.tongTienWhenChange)
                    txtTienThua.Text = string.Format("{0:0,0 đ}", tienNhan - this.tongTienWhenChange);
            }
        }
        private void txtTienNhan_ValueChanged(object sender, EventArgs e)
        {
            double tienNhan = Convert.ToDouble(txtTienNhan.Value.ToString());
            if (tienNhan >= this.tongTienWhenChange && DTO_SessionHoaDon.HDKH_HienTai.Count>0)
                txtTienThua.Text = string.Format("{0:0,0 đ}", tienNhan - this.tongTienWhenChange);

        }
        private void txtSoLuong_ValueChanged(object sender, EventArgs e)
        {
            var donGia = gvThucUong.GetRowCellValue(gvThucUong.FocusedRowHandle, gvThucUong.Columns["Gia"]);
            var soLuong = txtSoLuong.Value;
            if (donGia != null && soLuong != null)
            {
                txtThanhTienOfMon.Text = string.Format("{0:0,0 đ}", Convert.ToDouble(donGia) * Convert.ToDouble(soLuong));
            }
        }
        private void btnMoBan_Click(object sender, EventArgs e)
        {
            bllACID = new BLL_AutoCreateID();
            bllBan = new BLL_Ban();
            bllHDBH = new BLL_HoaDonBanHang();
            //Thêm vào Hóa đơn
            tblHoaDonBanHang hdbh = new tblHoaDonBanHang();
            hdbh.MaHD = bllACID.create_ID_HD(); //Tạo mã hóa đơn tự động 
            hdbh.MaNV = "06062022NV000001";
            hdbh.MaKH = "06062022KH000001";
            hdbh.MaBan = this.banDangChon.MaBan;
            hdbh.NgayLap = DateTime.Now;
            hdbh.PhuThu = 0;
            hdbh.GiamGia = 0;
            hdbh.TongTien = 0;
            hdbh.TrangThai = false;//Chưa thanh toán
            //Lưu tạm hd hiện tại
            DTO_SessionHoaDon.HD_HienTai = hdbh;
            string insHD = bllHDBH.insert(hdbh);
            if (!insHD.Equals("1"))
            {
                XtraMessageBox.Show("Error: " + insHD, "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                XtraMessageBox.Show("Đã mở "+this.banDangChon.TenBan+" [Trạng thái: Có khách]", "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            //Gán dữ liệu cho các text HD
            loadTextboxHD();
            //Cập nhật trạng thái bàn thành có khách (true)
            this.banDangChon.TrangThai = true;
            string kqUpdate = bllBan.update(banDangChon);
            if(!kqUpdate.Equals("1"))
            {
                XtraMessageBox.Show("Error: "+ kqUpdate, "Thông báo [Message]"
                          , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnMoBan.Enabled = false;
            btnThemMon.Enabled = true;
            btnHuyBan.Enabled = true;
            loadBan();
            //...
        }
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            var maMon = gvThucUong.GetRowCellValue(gvThucUong.FocusedRowHandle, gvThucUong.Columns["MaSP"]);
            var TenMon = gvThucUong.GetRowCellValue(gvThucUong.FocusedRowHandle, gvThucUong.Columns["TenSP"]);
            var maSize = gvThucUong.GetRowCellValue(gvThucUong.FocusedRowHandle, gvThucUong.Columns["MaSize"]);
            int soLuong = Convert.ToInt32(txtSoLuong.Value);

            if (DTO_SessionHoaDon.HD_HienTai.MaHD==null)
            {
                return;
            }    
            string maHD = DTO_SessionHoaDon.HD_HienTai.MaHD;

            //Kiểm tra khi số lượng = 0
            if(soLuong <=0)
            {
                XtraMessageBox.Show("Vui lòng nhập số lượng phải lớn hơn 0", "Thông báo [Message]"
                              , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
                return;
            }
            
            if (maMon != null && maSize != null && TenMon!=null)
            {
                double tongTienCTHD;
                decimal phuThu;
                decimal giamGia;
                double giaPhuThu;
                double giaGiamGia;
                double giaGiamGia_set;

                //Tìm bảng giá sản phẩm cửa size này
                bllBG = new BLL_BangGia();
                int maBangGia = bllBG.findBy_MaSP_MaSize(Convert.ToInt32(maMon), maSize.ToString()).MaBangGia;

                //Thêm cthd
                bllCTHDBH = new BLL_ChiTietHoaDonBanHang();
                tblChiTietHD cthd = new tblChiTietHD();
                cthd.MaHD = maHD;
                cthd.MaBangGia = maBangGia;
                cthd.SoLuong = soLuong;
                //Kiểm tra nếu đã có thì cập nhật số lượng
                var checkCTHD = bllCTHDBH.Find_KH_BG_SP_By_MaHD_MaSP(maHD, maBangGia);
                if (checkCTHD != null)
                {
                    string kqUpd = bllCTHDBH.updateSoLuongTang(cthd);
                    gcCTHD.DataSource = bllCTHDBH.getAll_KH_BG_SP_ByMaHD(maHD);
                    //Gán Hóa đơn khách hàng hiện tại
                    DTO_SessionHoaDon.HD_HienTai = bllHDBH.getHDBy_MaHD(maHD);
                    DTO_SessionHoaDon.HDKH_HienTai = bllCTHDBH.getAll_KH_BG_SP_ByMaHD(maHD);
                    //
                    //Gán dữ liệu tổng tiền, giảm giá, phụ thu
                    tongTienCTHD = DTO_SessionHoaDon.HDKH_HienTai.Sum(t => t.ThanhTien);
                     phuThu = Convert.ToDecimal(DTO_SessionHoaDon.HD_HienTai.PhuThu);
                     giamGia = Convert.ToDecimal(DTO_SessionHoaDon.HD_HienTai.GiamGia);
                     giaGiamGia_set = Convert.ToDouble(DTO_SessionHoaDon.HD_HienTai.TongTien);
                     giaPhuThu = (giaGiamGia_set * Convert.ToDouble(phuThu)) / 100;
                     giaGiamGia = (giaGiamGia_set * Convert.ToDouble(giamGia)) / 100;

                    ganTextBoxTongTien(tongTienCTHD, phuThu, giaPhuThu, giamGia, giaGiamGia, giaGiamGia_set, 0);
                    return;
                }
                //Thêm
                string kqInsCTHD = bllCTHDBH.insert(cthd);
                if (!kqInsCTHD.Equals("1"))
                {
                    XtraMessageBox.Show("Error: " + kqInsCTHD, "Thông báo [Message]"
                              , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    acThongBao.Show(this, "Thông báo", "Thêm "+ TenMon+" thành công."
                           , "", Properties.Resources.success2___Copy, new Message());
                }
                //Load lại lưới chi tiết đơn hàng
                gcCTHD.DataSource = bllCTHDBH.getAll_KH_BG_SP_ByMaHD(maHD);
                //Gán Hóa đơn khách hàng hiện tại
                DTO_SessionHoaDon.HD_HienTai = bllHDBH.getHDBy_MaHD(maHD);
                DTO_SessionHoaDon.HDKH_HienTai = bllCTHDBH.getAll_KH_BG_SP_ByMaHD(maHD);
                //
                //Mở nút thanh toán khi có món (Có cthd)
                btnThanhToan.Enabled = (DTO_SessionHoaDon.HDKH_HienTai.Count == 0) ? false : true;
                //Gán dữ liệu tổng tiền, giảm giá, phụ thu
                tongTienCTHD = DTO_SessionHoaDon.HDKH_HienTai.Sum(t => t.ThanhTien);
                 phuThu = Convert.ToDecimal(DTO_SessionHoaDon.HD_HienTai.PhuThu);
                 giamGia = Convert.ToDecimal(DTO_SessionHoaDon.HD_HienTai.GiamGia);
                giaGiamGia_set = Convert.ToDouble(DTO_SessionHoaDon.HD_HienTai.TongTien);
                 giaPhuThu = (giaGiamGia_set * Convert.ToDouble(phuThu)) / 100;
                 giaGiamGia = (giaGiamGia_set * Convert.ToDouble(giamGia)) / 100;

                ganTextBoxTongTien(tongTienCTHD, phuThu, giaPhuThu, giamGia, giaGiamGia, giaGiamGia_set, 0);


            }
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            bllHDBH = new BLL_HoaDonBanHang();
            bllBan = new BLL_Ban();
            try
            {
                    //Cập nhật trạng thái hóa đơn đã thanh toán
                    string kqUpdHD = bllHDBH.chuyenDoiTrangThaiHD(DTO_SessionHoaDon.HD_HienTai.MaHD);
                    //Cập nhật trạng thái bàn thành trống
                    string kqUpdBan = bllBan.chuyenDoiTrangThaiBan(DTO_SessionHoaDon.HD_HienTai.MaBan);
                loaddAll();
                emptyCTHD();
                btnThanhToan.Enabled = false;
                btnThemMon.Enabled = false;
                btnHuyBan.Enabled = false;
                btnTachBan.Enabled = false;
                btnGopBan.Enabled = false;
            }
            catch (Exception)
            {
                return;
            }
           

        }
        private void btnHuyBan_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn hủy bàn?", "Thông báo [Message]"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //Xóa hóa đơn rỗng
            bllHDBH = new BLL_HoaDonBanHang();
            bllBan = new BLL_Ban();
            string kqDelHD = bllHDBH.delete(DTO_SessionHoaDon.HD_HienTai.MaHD);
            if (kqDelHD.Equals("1"))
            {
                XtraMessageBox.Show("Đã hủy bàn.", "Thông báo [Message]"
                , MessageBoxButtons.OK, MessageBoxIcon.None);
                string kqUpdTT = bllBan.chuyenDoiTrangThaiBan(DTO_SessionHoaDon.HD_HienTai.MaBan);
                loaddAll();
                emptyCTHD();
                btnHuyBan.Enabled = false;
                return;
            }
            XtraMessageBox.Show("Error: "+kqDelHD, "Thông báo [Message]"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
       
        #endregion


    }
}