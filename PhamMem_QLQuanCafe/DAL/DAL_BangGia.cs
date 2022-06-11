using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_BangGia
    {
        QL_QuanCafeUpdateDataContext db;
        public List<DTO_BangGiaSanPham> getBangGiaSP()
        {
            db = new QL_QuanCafeUpdateDataContext();
            var lst = from a in db.tblBangGias
                      join b in db.tblSanPhams
                      on a.MaSP equals b.MaSP
                      select new DTO_BangGiaSanPham
                      {
                          MaSP = Convert.ToInt32(a.MaSP),
                          TenSP = b.TenSP,
                          Hinh = b.Hinh,
                          TrangThai = Convert.ToBoolean(b.TrangThai),
                          MaNhomSP = b.MaNhomSP,
                          MaBangGia = a.MaBangGia,
                          MaSize = a.MaSize,
                          Gia = Convert.ToDouble(a.Gia),
                          NgayCapNhat = Convert.ToDateTime(a.NgayCapNhat),

                      };
            return (lst != null) ? lst.ToList():null;
        }
        public List<DTO_BangGiaSanPham> getBangGiaSPByMaNhom(string pMaNhom)
        {
            db = new QL_QuanCafeUpdateDataContext();
            var lst = from a in db.tblBangGias
                      join b in db.tblSanPhams.Where(t=>t.MaNhomSP==pMaNhom)
                      on a.MaSP equals b.MaSP
                      select new DTO_BangGiaSanPham
                      {
                          MaSP = Convert.ToInt32(a.MaSP),
                          TenSP = b.TenSP,
                          Hinh = b.Hinh,
                          TrangThai = Convert.ToBoolean(b.TrangThai),
                          MaNhomSP = b.MaNhomSP,
                          MaBangGia = a.MaBangGia,
                          MaSize = a.MaSize,
                          Gia = Convert.ToDouble(a.Gia),
                          NgayCapNhat = Convert.ToDateTime(a.NgayCapNhat),

                      };
            return (lst != null) ? lst.ToList() : null;
        }
        public tblBangGia findBy_MaSP_MaSize(int pMaSP, string pMaSize)
        {
            db = new QL_QuanCafeUpdateDataContext();
            return db.tblBangGias.FirstOrDefault(t=>t.MaSP==pMaSP&& t.MaSize==pMaSize);
        }
    }
}
