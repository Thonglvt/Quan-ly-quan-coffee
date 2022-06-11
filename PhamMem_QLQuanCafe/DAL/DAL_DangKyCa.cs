using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_DangKyCa
    {
        QL_QuanCafeUpdateDataContext db;

        public List<tblDangKyCa> getAllDangKyCa()
        {
            db = new QL_QuanCafeUpdateDataContext();
            return db.tblDangKyCas.ToList();
        }

        /// <summary>
        /// return true: pMaNV đã được sử dụng
        /// </summary>
        /// <param name="pMaNV"></param>
        /// <returns></returns>
        public bool checkKhoaNgoai_MaNV(string pMaNV)
        {
            db = new QL_QuanCafeUpdateDataContext();
            var nv = db.tblDangKyCas.FirstOrDefault(t => t.MaNV == pMaNV);
            return nv == null ? false : true;
        }
        /// <summary>
        /// return true: pMaCa đã được sử dụng
        /// </summary>
        /// <param name="pMaCa"></param>
        /// <returns> True: tồn tại khóa ngoại</returns>
        public bool checkKhoaNgoai_MaCa(string pMaCa)
        {
            db = new QL_QuanCafeUpdateDataContext();
            var dkc = db.tblDangKyCas.FirstOrDefault(t => t.MaCa == pMaCa);
            return (dkc != null) ? true : false;
        }
        /// <summary>
        /// Kiểm tra nhân viên đã đăng ký ca làm việc này chưa
        /// Return true (đã đăng ký)
        /// </summary>
        /// <param name="pMaNV"></param>
        /// <param name="pMaCa"></param>
        /// <returns></returns>
        public bool checkNhanVienDaDKyCa(string pMaNV,string pMaCa)
        {
            db = new QL_QuanCafeUpdateDataContext();
            var dky = db.tblDangKyCas.FirstOrDefault(t => t.MaCa == pMaCa && t.MaNV == pMaNV);
            return (dky != null) ? true : false;
        }
        //
        public string insert(tblDangKyCa pDKyCa)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                db.tblDangKyCas.InsertOnSubmit(pDKyCa);
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string update(tblDangKyCa pDKyCa)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                var dkc = db.tblDangKyCas.FirstOrDefault(n => n.MaDKCa == pDKyCa.MaDKCa);
                if (dkc != null)
                {
                    dkc.MaCa = pDKyCa.MaCa;
                    dkc.MaNV = pDKyCa.MaNV;
                }
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string delete(int pMaDKCa)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                tblDangKyCa dkc = db.tblDangKyCas.FirstOrDefault(n => n.MaDKCa == pMaDKCa);
                db.tblDangKyCas.DeleteOnSubmit(dkc);
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
