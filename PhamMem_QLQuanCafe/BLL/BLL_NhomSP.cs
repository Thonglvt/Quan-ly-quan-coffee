using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BLL_NhomSP
    {
        DAL_NhomSP dalNSP;
        public List<tblNhomSP> getAll()
        {
            dalNSP = new DAL_NhomSP();
            return dalNSP.getAll();
        }
    }
}
