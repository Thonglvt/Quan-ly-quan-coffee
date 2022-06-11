using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLL_DangKyCa
    {
        DAL_DangKyCa dalDKC;


        public List<tblDangKyCa> getAllDangKyCa()
        {
            dalDKC = new DAL_DangKyCa();
            return dalDKC.getAllDangKyCa();
        }
        public bool checkKhoaNgoai_MaNV(string pMaNV)
        {
            dalDKC = new DAL_DangKyCa();
            return dalDKC.checkKhoaNgoai_MaNV(pMaNV);
        }
        public bool checkKhoaNgoai_MaCa(string pMaCa)
        {
            dalDKC = new DAL_DangKyCa();
            return dalDKC.checkKhoaNgoai_MaCa(pMaCa);
        }

        /// <summary>
        /// Kiểm tra nhân viên đã đăng ký ca làm việc này chưa
        /// Return true (đã đăng ký)
        /// </summary>
        /// <param name="pMaNV"></param>
        /// <param name="pMaCa"></param>
        /// <returns></returns>
        public bool checkNhanVienDaDKyCa(string pMaNV, string pMaCa)
        {
            dalDKC = new DAL_DangKyCa();
            return dalDKC.checkNhanVienDaDKyCa(pMaNV, pMaCa);
        }
        //
        public string insert(tblDangKyCa pDKyCa)
        {
            dalDKC = new DAL_DangKyCa();
            return dalDKC.insert(pDKyCa);
        }
        public string update(tblDangKyCa pDKyCa)
        {
            dalDKC = new DAL_DangKyCa();
            return dalDKC.update(pDKyCa);
        }
        public string delete(int pMaDKCa)
        {
            dalDKC = new DAL_DangKyCa();
            return dalDKC.delete(pMaDKCa);
        }
    }
}
