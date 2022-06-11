using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_ChiTietHoaDonBanHang
    {
        QL_QuanCafeUpdateDataContext db;

        public List<tblChiTietHD> getAll()
        {
            db = new QL_QuanCafeUpdateDataContext();

            return db.tblChiTietHDs.ToList();
        }
        public List<DTO_KhachHangHoaDon> getAll_KH_BG_SP()
        {
            db = new QL_QuanCafeUpdateDataContext();
            var lst = from a in db.tblChiTietHDs
                      join b in db.tblBangGias on a.MaBangGia equals b.MaBangGia
                      join c in db.tblSanPhams on b.MaSP equals c.MaSP
                      join d in db.tblHoaDonBanHangs on a.MaHD equals d.MaHD
                      select new DTO_KhachHangHoaDon
                      {
                          STT = 0,
                          MaHD = a.MaHD,
                          MaNV = d.MaNV,
                          MaBan = d.MaBan,
                          NgayLap = Convert.ToDateTime(d.NgayLap),
                          PhuThu = Convert.ToInt32(d.PhuThu),
                          GiamGia = Convert.ToInt32(d.GiamGia),
                          TongTien = Convert.ToDouble(d.TongTien),
                          MaBangGia = Convert.ToInt32(a.MaBangGia),
                          MaSP = Convert.ToInt32(b.MaSP),
                          MaSize = b.MaSize,
                          TenSP = c.TenSP,
                          SoLuong = Convert.ToInt32(a.SoLuong),
                          DonGia = Convert.ToDouble(a.DonGia),
                          ThanhTien = Convert.ToDouble(a.ThanhTien),
                          TrangThai = Convert.ToBoolean(d.TrangThai),
                      };
            //Cập nhật stt
            int stt = 0;
            List<DTO_KhachHangHoaDon> lstKHHD = new List<DTO_KhachHangHoaDon>(); ;
            if (lst != null)
            {
                lstKHHD = lst.ToList();
            }
            foreach (DTO_KhachHangHoaDon item in lstKHHD)
            {
                item.STT = stt + 1;
                stt++;
            }
            return lstKHHD;
        }


        public List<DTO_KhachHangHoaDon> getAll_KH_BG_SP_ByMaHD(string pMaHD)
        {
            db = new QL_QuanCafeUpdateDataContext();
            var lst = from a in db.tblChiTietHDs.Where(t => t.MaHD == pMaHD)
                      join b in db.tblBangGias on a.MaBangGia equals b.MaBangGia
                      join c in db.tblSanPhams on b.MaSP equals c.MaSP
                      join d in db.tblHoaDonBanHangs on a.MaHD equals d.MaHD
                      join e in db.tblKhachHangs on d.MaKH equals e.MaKH
                      select new DTO_KhachHangHoaDon
                      {
                          STT = 0,
                          MaHD = a.MaHD,
                          MaNV = d.MaNV,
                          MaBan = d.MaBan,
                          TenKH = e.TenKH,
                          NgayLap = Convert.ToDateTime(d.NgayLap),
                          PhuThu = Convert.ToInt32(d.PhuThu),
                          GiamGia = Convert.ToInt32(d.GiamGia),
                          TongTien = Convert.ToDouble(d.TongTien),
                          MaBangGia = Convert.ToInt32(a.MaBangGia),
                          MaSP = Convert.ToInt32(b.MaSP),
                          MaSize = b.MaSize,
                          TenSP = c.TenSP,
                          SoLuong = Convert.ToInt32(a.SoLuong),
                          DonGia = Convert.ToDouble(a.DonGia),
                          ThanhTien = Convert.ToDouble(a.ThanhTien),
                          TrangThai = Convert.ToBoolean(d.TrangThai),
                      };
            //Cập nhật stt
            int stt = 0;
            List<DTO_KhachHangHoaDon> lstKHHD = new List<DTO_KhachHangHoaDon>(); ;
            if (lst != null)
            {
                lstKHHD = lst.ToList();
            }
            foreach (DTO_KhachHangHoaDon item in lstKHHD)
            {
                item.STT = stt + 1;
                stt++;
            }
            return lstKHHD;
        }
        //CRUD
        public string insert(tblChiTietHD pCTHD)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                db.tblChiTietHDs.InsertOnSubmit(pCTHD);
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string update(tblChiTietHD pCTHD)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                var ct = db.tblChiTietHDs.FirstOrDefault(n => n.MaHD == pCTHD.MaHD);
                if (ct != null)
                {
                    ct.MaBangGia = pCTHD.MaBangGia;
                    ct.SoLuong = pCTHD.SoLuong;
                }
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string updateSoLuongTang(tblChiTietHD pCTHD)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                var ct = db.tblChiTietHDs.FirstOrDefault(n => n.MaHD == pCTHD.MaHD && n.MaBangGia==pCTHD.MaBangGia);
                if (ct != null)
                {
                    ct.SoLuong += pCTHD.SoLuong;
                }
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string delete(string pMaHD, int pMaBG)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                tblChiTietHD ct = db.tblChiTietHDs.FirstOrDefault(n => n.MaHD == pMaHD&&n.MaBangGia== pMaBG);
                db.tblChiTietHDs.DeleteOnSubmit(ct);
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
