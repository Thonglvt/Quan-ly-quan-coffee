using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_ChamCong
    {
        QL_QuanCafeUpdateDataContext db;

        public List<tblChamCong> getAllChamCong()
        {
            db = new QL_QuanCafeUpdateDataContext();

            return db.tblChamCongs.ToList();
        }
        //public bool checkKhoaNgoai_MaCa(string pMaCa)
        //{
        //    db = new QL_QuanCafeDataContext();
        //    var cc = db.tblChamCongs.FirstOrDefault(t => t.MaCa == pMaCa);
        //    return cc != null ? true : false;
        //}

        public string insert(tblChamCong pChamCong)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                db.tblChamCongs.InsertOnSubmit(pChamCong);
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string update(tblChamCong pChamCong)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                var dkc = db.tblChamCongs.FirstOrDefault(n => n.MaChamCong == pChamCong.MaChamCong);
                if (dkc != null)
                {
                    dkc.Thang = pChamCong.Thang;
                    dkc.Nam = pChamCong.Thang;
                    dkc.TrangThai = pChamCong.TrangThai;
                }
                db.SubmitChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string delete(string pMaChC)
        {
            try
            {
                db = new QL_QuanCafeUpdateDataContext();
                tblChamCong chC = db.tblChamCongs.FirstOrDefault(n => n.MaChamCong == pMaChC);
                db.tblChamCongs.DeleteOnSubmit(chC);
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
