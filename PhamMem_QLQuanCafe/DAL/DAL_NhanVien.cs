using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    
    public class DAL_NhanVien
    {
        QL_QuanCafeUpdateDataContext db;

        public List<tblNhanVien> getAllNhanVien()
        {
            db = new QL_QuanCafeUpdateDataContext();
            return db.tblNhanViens.ToList();
        }

        public string insertNV(tblNhanVien pNhanVien)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                db.tblNhanViens.InsertOnSubmit(pNhanVien);
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string updateNV(tblNhanVien pNhanVien)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                var nv = db.tblNhanViens.FirstOrDefault(n => n.MaNV == pNhanVien.MaNV);
                if (nv != null)
                {
                    nv.TenNV = pNhanVien.TenNV;
                    nv.NgaySinh = pNhanVien.NgaySinh;
                    nv.GioiTinh = pNhanVien.GioiTinh;
                    nv.DiaChi = pNhanVien.DiaChi;
                    nv.SDT = pNhanVien.SDT;
                    nv.CCCD = pNhanVien.CCCD;
                    nv.TrangThai = pNhanVien.TrangThai;
                }    
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string deleteNV(string pMaNV)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                tblNhanVien nv = db.tblNhanViens.FirstOrDefault(n => n.MaNV == pMaNV);
                db.tblNhanViens.DeleteOnSubmit(nv);
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
