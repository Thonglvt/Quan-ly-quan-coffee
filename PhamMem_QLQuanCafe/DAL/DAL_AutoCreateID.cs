using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_AutoCreateID
    {
        QL_QuanCafeUpdateDataContext db;
        //Tạo mã nhân viên
        public string create_ID_NV()
        {
            db = new QL_QuanCafeUpdateDataContext();
            string IDLast;
            string dateNow = DateTime.Now.ToShortDateString(); //lấy theo định dạng DD/MM/YYYY
            dateNow = dateNow.Replace("/", "");
            string ID = "";
            try
            {
                //Lấy mã cuối cùng
                IDLast = (db.tblNhanViens.OrderByDescending(p => p.MaNV.Substring(10, 6)).Select(p => p.MaNV).First().ToString()).Substring(10, 6);
                //Ép thành Int
                int IDInt = Convert.ToInt32(IDLast);
                //Thực hiện tăng dần
                ID = dateNow + "NV";
                if (IDInt >= 0 && IDInt < 9)
                    ID += "00000" + (IDInt + 1);
                else if (IDInt >= 9 && IDInt < 99)
                    ID += "0000" + (IDInt + 1);
                else if (IDInt >= 99 && IDInt < 999)
                    ID += "000" + (IDInt + 1);
                else if (IDInt >= 999 && IDInt < 9999)
                    ID += "00" + (IDInt + 1);
                else if (IDInt >= 9999 && IDInt < 99999)
                    ID += "0" + (IDInt + 1);

            }
            catch (Exception ex)
            {
                return dateNow + "NV000000";
            }

            return ID;
        }
        //Tạo mã HD
        public string create_ID_HD()
        {
            db = new QL_QuanCafeUpdateDataContext();
            string IDLast;
            string dateNow = DateTime.Now.ToShortDateString(); //lấy theo định dạng DD/MM/YYYY
            dateNow = dateNow.Replace("/", "");
            string ID = "";
            try
            {
                //Lấy mã cuối cùng
                var hdLast = db.tblHoaDonBanHangs.Where(t => t.MaHD.StartsWith(dateNow)).OrderByDescending(a=>a.MaHD).Select(t=>t.MaHD).First();

                if(hdLast==null)
                {
                    ID = dateNow + "HD" + "0000000";
                }    
                //Ép thành Int
                int IDInt = Convert.ToInt32(hdLast.Substring(11,6));
                //Thực hiện tăng dần
                ID = dateNow + "HD";
                if (IDInt >= 0 && IDInt < 9)
                    ID += "000000" + (IDInt + 1);
                else if (IDInt >= 9 && IDInt < 99)
                    ID += "00000" + (IDInt + 1);
                else if (IDInt >= 99 && IDInt < 999)
                    ID += "0000" + (IDInt + 1);
                else if (IDInt >= 999 && IDInt < 9999)
                    ID += "000" + (IDInt + 1);
                else if (IDInt >= 9999 && IDInt < 99999)
                    ID += "00" + (IDInt + 1);
                else 
                    ID += "0" + (IDInt + 1);

            }
            catch (Exception ex)
            {
                return dateNow + "HD0000000";
            }

            return ID;
        }
    }
}
