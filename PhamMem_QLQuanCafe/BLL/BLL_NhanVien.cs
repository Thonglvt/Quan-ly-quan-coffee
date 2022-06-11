using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BLL_NhanVien
    {
        DAL_NhanVien dalNV;
        public List<tblNhanVien> getAllNhanVien()
        {
            dalNV = new DAL_NhanVien();
            return dalNV.getAllNhanVien();
        }
        public bool checkTonTaiCMND(string pCmnd)// true: tồn tại,  false: ko tồn tại
        {
            dalNV = new DAL_NhanVien();
            List<tblNhanVien> lstNV = dalNV.getAllNhanVien();
            foreach (tblNhanVien nv in lstNV)
            {
                if (nv.CCCD.Trim().Equals(pCmnd.Trim()))
                    return true;
            }
            return false;
        }
        public bool checkTonTaiSDT(string pSdt)// true: tồn tại,  false: ko tồn tại
        {
            dalNV = new DAL_NhanVien();
            List<tblNhanVien> lstNV = dalNV.getAllNhanVien();
            foreach (tblNhanVien nv in lstNV)
            {
                if (nv.SDT.Trim().Equals(pSdt.Trim()))
                    return true;
            }
            return false;
        }

        public string insertNV(tblNhanVien pNhanVien)
        {
            dalNV = new DAL_NhanVien();
            return dalNV.insertNV(pNhanVien);
        }
        public string updateNV(tblNhanVien pNhanVien)
        {
            dalNV = new DAL_NhanVien();
            return dalNV.updateNV(pNhanVien);
        }
        public string deleteNV(string pMaNV)
        {
            dalNV = new DAL_NhanVien();
            return dalNV.deleteNV(pMaNV);
        }
    }
}
