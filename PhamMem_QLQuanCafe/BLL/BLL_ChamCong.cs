using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BLL_ChamCong
    {
        DAL_ChamCong dalChC;

        /// <summary>
        /// Hàm trả về true nếu tồn tại mã ca trong bảng Chấm công
        /// </summary>
        /// <param name="pMaCa"></param>
        /// <returns>True: tồn tại khóa ngoại</returns>
        //public bool checkKhoaNgoai_MaCa(string pMaCa)
        //{
        //    dalChC = new DAL_ChamCong();
        //    return dalChC.checkKhoaNgoai_MaCa(pMaCa);
        //}

        public List<tblChamCong> getAllChamCong()
        {
            dalChC = new DAL_ChamCong();
            return dalChC.getAllChamCong();
        }

        /// <summary>
        /// Hàm trả vể true nếu tồn tại khóa chính
        /// </summary>
        /// <param name="pMaChC"></param>
        /// <returns>True: tồn tại mãs</returns>
        public bool checkKhoaChinh(string pMaChC)
        {
            dalChC = new DAL_ChamCong();
            List<tblChamCong> lstChC = dalChC.getAllChamCong();
            foreach (tblChamCong chC in lstChC)
            {
                if (chC.MaChamCong.Trim().Equals(pMaChC.Trim()))
                    return true;
            }
            return false;
        }


        public string insert(tblChamCong pChamCong)
        {
            return dalChC.insert(pChamCong);
        }
        public string update(tblChamCong pChamCong)
        {
            return dalChC.update(pChamCong);
        }
        public string delete(string pMaChC)
        {
            return dalChC.delete(pMaChC);
        }
    }
}
