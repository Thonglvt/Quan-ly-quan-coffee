using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLL_SanPham
    {
        DAL_SanPham dalSP;

        public List<tblSanPham> getAll()
        {
            dalSP = new DAL_SanPham();
            return dalSP.getAll();
        }
    }
}
