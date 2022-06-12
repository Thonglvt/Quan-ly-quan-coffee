using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLL_Ban
    {
        DAL_Ban dalBan;
        //Lấy danh sách bàn
        public List<tblBan> getAll()
        {
            dalBan = new DAL_Ban();
            return dalBan.getAll();
        }
        public List<tblBan> getBanTrong()
        {
            dalBan = new DAL_Ban();
            return dalBan.getBanTrong().OrderBy(t=>Convert.ToInt32(t.MaBan)).ToList();
        }
        public tblBan findBanByMa(string pMaBan)
        {
            dalBan = new DAL_Ban();
            return dalBan.findBanByMa(pMaBan);
        }
        public string chuyenDoiTrangThaiBan(string pMaBan)
        {
            dalBan = new DAL_Ban();
            return dalBan.chuyenDoiTrangThaiBan(pMaBan);
        }

        public string insert(tblBan pBan)
        {
            dalBan = new DAL_Ban();
            return dalBan.insert(pBan);
        }
        public string update(tblBan pBan)
        {
            dalBan = new DAL_Ban();
            return dalBan.update(pBan);
        }
        public string delete(string pMaHD)
        {
            dalBan = new DAL_Ban();
            return dalBan.delete(pMaHD);
        }
    }
}
