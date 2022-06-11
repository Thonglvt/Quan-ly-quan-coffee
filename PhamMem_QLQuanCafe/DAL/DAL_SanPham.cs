using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_SanPham
    {
        QL_QuanCafeUpdateDataContext db;

        public List<tblSanPham> getAll()
        {
            db = new QL_QuanCafeUpdateDataContext();
            return db.tblSanPhams.ToList();
        }

       
    }
}
