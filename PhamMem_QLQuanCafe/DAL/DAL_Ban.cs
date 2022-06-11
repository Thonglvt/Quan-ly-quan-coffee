using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_Ban
    {
        QL_QuanCafeUpdateDataContext db;

        public List<tblBan> getAll()
        {
            db = new QL_QuanCafeUpdateDataContext();
            return db.tblBans.OrderBy(t=>Convert.ToInt32(t.MaBan)).ToList();
        }
        public tblBan findBanByMa(string pMaBan)
        {
            db = new QL_QuanCafeUpdateDataContext();
            return db.tblBans.FirstOrDefault(t => t.MaBan == pMaBan);
        }
        public string chuyenDoiTrangThaiBan(string pMaBan)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                var ban = db.tblBans.FirstOrDefault(n => n.MaBan == pMaBan);
                if (ban != null)
                {
                    ban.TrangThai = !ban.TrangThai;
                }
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string insert(tblBan pBan)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                db.tblBans.InsertOnSubmit(pBan);
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string update(tblBan pBan)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                var ban = db.tblBans.FirstOrDefault(n => n.MaBan == pBan.MaBan);
                if (ban != null)
                {
                    ban.TenBan = pBan.TenBan;
                    ban.SoCho = pBan.SoCho;
                    ban.TrangThai = true;
                }
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string delete(string pMaBan)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                tblBan ban = db.tblBans.FirstOrDefault(n => n.MaBan == pMaBan);
                db.tblBans.DeleteOnSubmit(ban);
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
