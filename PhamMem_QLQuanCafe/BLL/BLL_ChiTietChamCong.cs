using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BLL_ChiTietChamCong
    {
        DAL_ChiTietChamCong dalCTCC;
        //public bool checkKhoaNgoai_MaNV(string pMaNV)
        //{
        //    dalCTCC = new DAL_ChiTietChamCong();
        //    return dalCTCC.checkKhoaNgoai_MaNV(pMaNV);
        //}

		public string PhatSinhCTCC(string pMaChC, int thang, int nam)
		{
            dalCTCC = new DAL_ChiTietChamCong();
            return dalCTCC.PhatSinhCTCC(pMaChC, thang, nam);
        }
		public List<DTO_ChiTietChamCong> GetChiTietChCongByMaChamCong(string pMaChCong)
		{
            dalCTCC = new DAL_ChiTietChamCong();
            return dalCTCC.GetChiTietChCongByMaChamCong(pMaChCong);
        }
		public List<DTO_ChiTietChamCong> GetChiTietChCongByMaChamCongThangNam(string pMaChCong, int pThang, int pNam)
		{
            dalCTCC = new DAL_ChiTietChamCong();
            return dalCTCC.GetChiTietChCongByMaChamCongThangNam(pMaChCong, pThang, pNam);
        }
		public List<DTO_ChiTietChamCong> GetChiTietChCongByMaChamCongThangNamMaCa(string pMaChCong, int pThang, int pNam, string pMaCa)
		{
            dalCTCC = new DAL_ChiTietChamCong();
            return dalCTCC.GetChiTietChCongByMaChamCongThangNamMaCa(pMaChCong, pThang, pNam,pMaCa);
        }
		public string insert(tblChiTietChamCong pCTChC)
		{
			dalCTCC = new DAL_ChiTietChamCong();
			return dalCTCC.insert(pCTChC);
		}
		public string update(tblChiTietChamCong pCTChC)
		{
			dalCTCC = new DAL_ChiTietChamCong();
			return dalCTCC.update(pCTChC);
		}
		public string delete(string pMaChC)
		{
			dalCTCC = new DAL_ChiTietChamCong();
			return dalCTCC.delete(pMaChC);
		}
	}
}
