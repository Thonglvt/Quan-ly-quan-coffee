using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_HoaDonBanHang
    {
        QL_QuanCafeUpdateDataContext db;

        public List<tblHoaDonBanHang> getAll()
        {
            db = new QL_QuanCafeUpdateDataContext();
            return db.tblHoaDonBanHangs.ToList();
        }
        public tblHoaDonBanHang getHDByMaBanCoKhach(string pMaBan)
        {
            db = new QL_QuanCafeUpdateDataContext();
            //Tìm bàn trạng thái có khách
            tblBan ban = new tblBan();
            ban = db.tblBans.FirstOrDefault(t => t.MaBan == pMaBan && t.TrangThai == true);
            if (ban == null)
                return null;
            //Tìm hóa đơn cuối cùng tại bàn đó
            tblHoaDonBanHang hdLast = new tblHoaDonBanHang();
            hdLast = db.tblHoaDonBanHangs.OrderByDescending(l => l.NgayLap).FirstOrDefault(t => t.MaBan == pMaBan);
            return (hdLast != null) ? hdLast : null;
        }

        public tblHoaDonBanHang getHDBy_MaHD(string pMaHD)
        {
            db = new QL_QuanCafeUpdateDataContext();
            return db.tblHoaDonBanHangs.FirstOrDefault(t => t.MaHD == pMaHD);
        }
        public List<DTO_KhachHangHoaDon> getHD_KH_NV()
        {
            db = new QL_QuanCafeUpdateDataContext();
            var lst = from a in db.tblHoaDonBanHangs
                      join b in db.tblKhachHangs on a.MaKH equals b.MaKH
                      join c in db.tblNhanViens on a.MaNV equals c.MaNV
                      join d in db.tblBans on a.MaBan equals d.MaBan
                      select new DTO_KhachHangHoaDon
                      {
                          TenBan = d.TenBan,
                          STT = 0,
                          MaHD = a.MaHD,
                          TenKH = b.TenKH,
                          TenNV = c.TenNV,
                          MaNV = a.MaNV,
                          MaBan = a.MaBan,
                          NgayLap = Convert.ToDateTime(a.NgayLap),
                          PhuThu = Convert.ToInt32(a.PhuThu),
                          GiamGia = Convert.ToInt32(a.GiamGia),
                          TongTien = Convert.ToDouble(a.TongTien),
                          StrTrangThai = (Convert.ToBoolean(a.TrangThai) == true) ? "Đã thanh toán" : "Chưa thanh toán"
                      };
            return lst.ToList();
        }
        
        public string insert(tblHoaDonBanHang pHDBH)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                db.tblHoaDonBanHangs.InsertOnSubmit(pHDBH);
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string chuyenDoiTrangThaiHD(string pMaHD)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                var hdbh = db.tblHoaDonBanHangs.FirstOrDefault(n => n.MaHD == pMaHD);
                if (hdbh != null)
                {
                    hdbh.TrangThai = !hdbh.TrangThai;
                }
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string update(tblHoaDonBanHang pHDBH)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                var hdbh = db.tblHoaDonBanHangs.FirstOrDefault(n => n.MaHD == pHDBH.MaHD);
                if (hdbh != null)
                {
                    hdbh.PhuThu = pHDBH.PhuThu;
                    hdbh.GiamGia = pHDBH.GiamGia;
                    hdbh.TrangThai = pHDBH.TrangThai;
                    hdbh.MaBan = pHDBH.MaBan;
                }
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string delete(string pMaHD)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                tblHoaDonBanHang hdbh = db.tblHoaDonBanHangs.FirstOrDefault(n => n.MaHD == pMaHD);
                db.tblHoaDonBanHangs.DeleteOnSubmit(hdbh);
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
