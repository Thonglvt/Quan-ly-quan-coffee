using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_NhomSP
    {
        QL_QuanCafeUpdateDataContext db;

        public List<tblNhomSP> getAll()
        {
            db = new QL_QuanCafeUpdateDataContext();
            return db.tblNhomSPs.ToList();
        }
    }
}
