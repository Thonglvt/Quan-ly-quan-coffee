using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLL_HoaDonBanHang
    {
        DAL_HoaDonBanHang dalHDBD;
        public List<tblHoaDonBanHang> getAll()
        {
            dalHDBD = new DAL_HoaDonBanHang();
            return dalHDBD.getAll();
        }
        public tblHoaDonBanHang getHDByMaBanCoKhach(string pMaBan)
        {
            dalHDBD = new DAL_HoaDonBanHang();
            return dalHDBD.getHDByMaBanCoKhach(pMaBan);
        }
        public tblHoaDonBanHang getHDBy_MaHD(string pMaHD)
        {
            dalHDBD = new DAL_HoaDonBanHang();
            return dalHDBD.getHDBy_MaHD(pMaHD);
        }
        public string chuyenDoiTrangThaiHD(string pMaHD)
        {
            dalHDBD = new DAL_HoaDonBanHang();
            return dalHDBD.chuyenDoiTrangThaiHD(pMaHD);
        }
        public string insert(tblHoaDonBanHang pHDBH)
        {
            dalHDBD = new DAL_HoaDonBanHang();
            return dalHDBD.insert(pHDBH);
        }
        public string update(tblHoaDonBanHang pHDBH)
        {
            dalHDBD = new DAL_HoaDonBanHang();
            return dalHDBD.update(pHDBH);
        }
        public string delete(string pMaHD)
        {
            dalHDBD = new DAL_HoaDonBanHang();
            return dalHDBD.delete(pMaHD);
        }
    }
}
