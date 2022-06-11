using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLL_ChiTietHoaDonBanHang
    {
        DAL_ChiTietHoaDonBanHang dalCTHDBH;
        public List<tblChiTietHD> getAll()
        {
            dalCTHDBH = new DAL_ChiTietHoaDonBanHang();

            return dalCTHDBH.getAll();
        }
        public List<tblChiTietHD> getAllByMaHD(string pMaHD)
        {
            dalCTHDBH = new DAL_ChiTietHoaDonBanHang();

            return dalCTHDBH.getAll().Where(t=>t.MaHD==pMaHD).ToList();
        }
        //public List<DTO_KhachHangHoaDon> getAll_KH_BG_SP_ByMaHD(string pMaHD)
        //{
        //    dalCTHDBH = new DAL_ChiTietHoaDonBanHang();
        //    return dalCTHDBH.getAll_KH_BG_SP().Where(t => t.MaHD == pMaHD).ToList();
        //}
        public List<DTO_KhachHangHoaDon> getAll_KH_BG_SP_ByMaHD(string pMaHD)
        {
            dalCTHDBH = new DAL_ChiTietHoaDonBanHang();
            return dalCTHDBH.getAll_KH_BG_SP_ByMaHD(pMaHD);
        }
        public DTO_KhachHangHoaDon Find_KH_BG_SP_By_MaHD_MaSP(string pMaHD,int pMaBG)
        {
            dalCTHDBH = new DAL_ChiTietHoaDonBanHang();
            return dalCTHDBH.getAll_KH_BG_SP().FirstOrDefault(t => t.MaHD == pMaHD && t.MaBangGia==pMaBG);
        }


        //CRUD
        public string insert(tblChiTietHD pCTHD)
        {
            dalCTHDBH = new DAL_ChiTietHoaDonBanHang();
            return dalCTHDBH.insert(pCTHD);
        }
        public string update(tblChiTietHD pCTHD)
        {
            dalCTHDBH = new DAL_ChiTietHoaDonBanHang();
            return dalCTHDBH.update(pCTHD);
        }
        public string updateSoLuongTang(tblChiTietHD pCTHD)
        {
            dalCTHDBH = new DAL_ChiTietHoaDonBanHang();
            return dalCTHDBH.updateSoLuongTang(pCTHD);
        }
        public string delete(string pMaHD, int pMaBG)
        {
            dalCTHDBH = new DAL_ChiTietHoaDonBanHang();
            return dalCTHDBH.delete(pMaHD, pMaBG);
        }
    }
}
