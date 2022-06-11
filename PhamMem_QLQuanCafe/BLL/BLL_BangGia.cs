using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BLL_BangGia
    {
        DAL_BangGia dalBG;
        public List<DTO_BangGiaSanPham> getBangGiaSP()
        {
            dalBG = new DAL_BangGia();
            return dalBG.getBangGiaSP();
        }
        public List<DTO_BangGiaSanPham> getBangGiaSPByMaNhom(string pMaNhom)
        {
            dalBG = new DAL_BangGia();
            return dalBG.getBangGiaSPByMaNhom(pMaNhom);
        }
        public tblBangGia findBy_MaSP_MaSize(int pMaSP,string pMaSize)
        {
            dalBG = new DAL_BangGia();
            return dalBG.findBy_MaSP_MaSize(pMaSP, pMaSize);
        }
    }
}
