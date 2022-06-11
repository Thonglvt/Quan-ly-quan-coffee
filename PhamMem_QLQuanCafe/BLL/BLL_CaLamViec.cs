using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    
    public class BLL_CaLamViec
    {
        DAL_CaLamViec dalCLV;

        public List<tblCaLamViec> getAllCaLamViec()
        {
            dalCLV = new DAL_CaLamViec();
            return dalCLV.getAllCaLamViec();
        }
        public string AutoCreateID(int size, bool lowerCase)
        {
            dalCLV = new DAL_CaLamViec();
            string id = "";
            do
            {
                id = dalCLV.AutoCreateID(size, lowerCase);
            } while (checkKhoaChinh(id));

            return id;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="pMaCaLV"></param>
        /// <returns>True: tồn tại</returns>
        public bool checkKhoaChinh(string pMaCaLV)
        {
            dalCLV = new DAL_CaLamViec();
            List<tblCaLamViec> lstCLV = dalCLV.getAllCaLamViec();
            foreach (tblCaLamViec clv in lstCLV)
            {
                if (clv.MaCa.Trim().Equals(pMaCaLV.Trim()))
                    return true;
            }
            return false;

        }


        public string insert(tblCaLamViec pCaLV)
        {
            dalCLV = new DAL_CaLamViec();
            return dalCLV.insert(pCaLV);
        }
        public string update(tblCaLamViec pCaLV)
        {
            dalCLV = new DAL_CaLamViec();
            return dalCLV.update(pCaLV);
        }
        public string delete(string pMaCa)
        {
            dalCLV = new DAL_CaLamViec();
            return dalCLV.delete(pMaCa);
        }
    }
}
