using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLL_KhachHang
    {
        DAL_KhachHang dalKH;
        public List<tblKhachHang> getAll()
        {
            dalKH = new DAL_KhachHang();
            return dalKH.getAll();
        }
    }
}
