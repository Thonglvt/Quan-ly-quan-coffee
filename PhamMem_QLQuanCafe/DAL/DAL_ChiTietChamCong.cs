using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_ChiTietChamCong
    {
		QL_QuanCafeUpdateDataContext db;

		public List<DTO_ChiTietChamCong> GetChiTietChCongByMaChamCong(string pMaChCong)
        {
			db = new QL_QuanCafeUpdateDataContext();
			var lst = from a in db.tblChiTietChamCongs.Where(t=>t.MaChamCong == pMaChCong)
					  join b in db.tblDangKyCas on a.MaDKCa equals b.MaDKCa
					  join c in db.tblNhanViens.Where(t=>t.TrangThai==true)
					  on b.MaNV equals c.MaNV
					  select new DTO_ChiTietChamCong
					  {
						  MaChamCong = a.MaChamCong,
						  MaDKCa = a.MaDKCa.ToString(),
						  MaNV = c.MaNV,
						  TenNV = c.TenNV,
						  Ngay1 = a.Ngay1,
						  Ngay2 = a.Ngay2,
						  Ngay3 = a.Ngay3,
						  Ngay4 = a.Ngay4,
						  Ngay5 = a.Ngay5,
						  Ngay6 = a.Ngay6,
						  Ngay7 = a.Ngay7,
						  Ngay8 = a.Ngay8,
						  Ngay9 = a.Ngay9,
						  Ngay10 = a.Ngay10,
						  Ngay11 = a.Ngay11,
						  Ngay12 = a.Ngay12,
						  Ngay13 = a.Ngay13,
						  Ngay14 = a.Ngay14,
						  Ngay15 = a.Ngay15,
						  Ngay16 = a.Ngay16,
						  Ngay17 = a.Ngay17,
						  Ngay18 = a.Ngay18,
						  Ngay19 = a.Ngay19,
						  Ngay20 = a.Ngay20,
						  Ngay21 = a.Ngay21,
						  Ngay22 = a.Ngay22,
						  Ngay23 = a.Ngay23,
						  Ngay24 = a.Ngay24,
						  Ngay25 = a.Ngay25,
						  Ngay26 = a.Ngay26,
						  Ngay27 = a.Ngay27,
						  Ngay28 = a.Ngay28,
						  Ngay29 = a.Ngay29,
						  Ngay30 = a.Ngay30,
						  Ngay31 = a.Ngay31,
						  TongNgayCong = "0",
					  };
			//Cập nhật tổng ngày công
			List<DTO_ChiTietChamCong> lstDTO = lst.ToList<DTO_ChiTietChamCong>();
			capNhatTongNgayCong(ref lstDTO);

			return lstDTO;
        }
		public List<DTO_ChiTietChamCong> GetChiTietChCongByMaChamCongThangNam(string pMaChCong, int pThang,int pNam)
		{
			db = new QL_QuanCafeUpdateDataContext();
			var lst = from a in db.tblChiTietChamCongs.Where(t=>t.MaChamCong == pMaChCong)
					  join d in db.tblChamCongs.Where(t=>t.Thang==pThang&&t.Nam==pNam) 
					  on a.MaChamCong equals d.MaChamCong
					  join b in db.tblDangKyCas on a.MaDKCa equals b.MaDKCa
					  join c in db.tblNhanViens.Where(t=>t.TrangThai==true)
					  on b.MaNV equals c.MaNV
					  select new DTO_ChiTietChamCong
					  {
						  MaChamCong = a.MaChamCong,
						  MaDKCa = a.MaDKCa.ToString(),
						  MaNV = c.MaNV,
						  TenNV = c.TenNV,
						  Ngay1 = a.Ngay1,
						  Ngay2 = a.Ngay2,
						  Ngay3 = a.Ngay3,
						  Ngay4 = a.Ngay4,
						  Ngay5 = a.Ngay5,
						  Ngay6 = a.Ngay6,
						  Ngay7 = a.Ngay7,
						  Ngay8 = a.Ngay8,
						  Ngay9 = a.Ngay9,
						  Ngay10 = a.Ngay10,
						  Ngay11 = a.Ngay11,
						  Ngay12 = a.Ngay12,
						  Ngay13 = a.Ngay13,
						  Ngay14 = a.Ngay14,
						  Ngay15 = a.Ngay15,
						  Ngay16 = a.Ngay16,
						  Ngay17 = a.Ngay17,
						  Ngay18 = a.Ngay18,
						  Ngay19 = a.Ngay19,
						  Ngay20 = a.Ngay20,
						  Ngay21 = a.Ngay21,
						  Ngay22 = a.Ngay22,
						  Ngay23 = a.Ngay23,
						  Ngay24 = a.Ngay24,
						  Ngay25 = a.Ngay25,
						  Ngay26 = a.Ngay26,
						  Ngay27 = a.Ngay27,
						  Ngay28 = a.Ngay28,
						  Ngay29 = a.Ngay29,
						  Ngay30 = a.Ngay30,
						  Ngay31 = a.Ngay31,
						  TongNgayCong = "0",
					  };
			//Cập nhật tổng ngày công
			List<DTO_ChiTietChamCong> lstDTO = lst.ToList<DTO_ChiTietChamCong>();
			capNhatTongNgayCong(ref lstDTO);
			return lst.ToList<DTO_ChiTietChamCong>();
		}
		public List<DTO_ChiTietChamCong> GetChiTietChCongByMaChamCongThangNamMaCa(string pMaChCong, int pThang, int pNam,string pMaCa)
		{
			db = new QL_QuanCafeUpdateDataContext();
			var lst = from a in db.tblChiTietChamCongs.Where(t => t.MaChamCong == pMaChCong)
					  join d in db.tblChamCongs.Where(t => t.Thang == pThang && t.Nam == pNam)
					  on a.MaChamCong equals d.MaChamCong
					  join b in db.tblDangKyCas.Where(t=>t.MaCa == pMaCa) 
					  on a.MaDKCa equals b.MaDKCa
					  join c in db.tblNhanViens.Where(t => t.TrangThai == true)
					  on b.MaNV equals c.MaNV
					  select new DTO_ChiTietChamCong
					  {
						  MaChamCong = a.MaChamCong,
						  MaDKCa = a.MaDKCa.ToString(),
						  MaNV = c.MaNV,
						  TenNV = c.TenNV,
						  Ngay1 = a.Ngay1,
						  Ngay2 = a.Ngay2,
						  Ngay3 = a.Ngay3,
						  Ngay4 = a.Ngay4,
						  Ngay5 = a.Ngay5,
						  Ngay6 = a.Ngay6,
						  Ngay7 = a.Ngay7,
						  Ngay8 = a.Ngay8,
						  Ngay9 = a.Ngay9,
						  Ngay10 = a.Ngay10,
						  Ngay11 = a.Ngay11,
						  Ngay12 = a.Ngay12,
						  Ngay13 = a.Ngay13,
						  Ngay14 = a.Ngay14,
						  Ngay15 = a.Ngay15,
						  Ngay16 = a.Ngay16,
						  Ngay17 = a.Ngay17,
						  Ngay18 = a.Ngay18,
						  Ngay19 = a.Ngay19,
						  Ngay20 = a.Ngay20,
						  Ngay21 = a.Ngay21,
						  Ngay22 = a.Ngay22,
						  Ngay23 = a.Ngay23,
						  Ngay24 = a.Ngay24,
						  Ngay25 = a.Ngay25,
						  Ngay26 = a.Ngay26,
						  Ngay27 = a.Ngay27,
						  Ngay28 = a.Ngay28,
						  Ngay29 = a.Ngay29,
						  Ngay30 = a.Ngay30,
						  Ngay31 = a.Ngay31,
						  TongNgayCong = "0",
					  };
			//Cập nhật tổng ngày công
			List<DTO_ChiTietChamCong> lstDTO = lst.ToList<DTO_ChiTietChamCong>();
			capNhatTongNgayCong(ref lstDTO);
			return lst.ToList<DTO_ChiTietChamCong>();
		}


		public void capNhatTongNgayCong(ref List<DTO_ChiTietChamCong> pLstCTCC)
        {

			foreach (DTO_ChiTietChamCong item in pLstCTCC)
            {
				int demNgCong = 0;
				demNgCong = (item.Ngay1.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay2.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay3.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay4.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay5.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay6.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay7.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay8.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay9.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay10.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay11.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay12.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay13.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay14.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay15.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay16.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay17.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay18.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay19.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay20.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay21.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay22.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay23.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay24.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay25.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay26.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay27.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay28.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay29.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;
				demNgCong = (item.Ngay30.ToLower().Equals("x")) ? demNgCong + 1 : demNgCong;

				item.TongNgayCong = demNgCong.ToString();
			}
        }
		/// <summary>
		/// return true: pMaNV đã được sử dụng
		/// </summary>
		/// <param name="pMaNV"></param>
		/// <returns></returns>
		//public bool checkKhoaNgoai_MaNV(string pMaNV)
  //      {
  //          db = new QL_QuanCafeDataContext();
  //          var nv = db.tblChiTietChamCongs.FirstOrDefault(t => t.MaNV == pMaNV);
  //          return nv == null ? false : true;
  //      }

		public string PhatSinhCTCC(string pMaChC, int thang, int nam)
		{
            try
            {
				db = new QL_QuanCafeUpdateDataContext();
				var lstDKCa = from a in db.tblDangKyCas
							join b in db.tblNhanViens.Where(nv=>nv.TrangThai == true)
							on a.MaNV equals b.MaNV
							select a;
				if (lstDKCa.Count<tblDangKyCa>() == 0) return "0";
				
                foreach (var item in lstDKCa)
				{
					List<string> listDay = new List<string>();

					for (int j = 1; j <= GetDayNumber(thang, nam); j++)
					{
						DateTime newDate = new DateTime(nam, thang, j);

						switch (newDate.DayOfWeek.ToString())
						{
							case "Sunday":
								listDay.Add("CN");
								break;
							case "Saturday":
								listDay.Add("T7");
								break;
							default:
								listDay.Add("");
								break;
						}
					}

					switch (listDay.Count)
					{
						case 28:
							listDay.Add("");
							listDay.Add("");
							listDay.Add("");
							break;
						case 29:
							listDay.Add("");
							listDay.Add("");
							break;
						case 30:
							listDay.Add("");
							break;
					}

					tblChiTietChamCong chiTietKC = new tblChiTietChamCong();
					chiTietKC.MaChamCong = pMaChC;
					chiTietKC.MaDKCa = item.MaDKCa;
					chiTietKC.Ngay1 = listDay[0];
					chiTietKC.Ngay2 = listDay[1];
					chiTietKC.Ngay3 = listDay[2];
					chiTietKC.Ngay4 = listDay[3];
					chiTietKC.Ngay5 = listDay[4];
					chiTietKC.Ngay6 = listDay[5];
					chiTietKC.Ngay7 = listDay[6];
					chiTietKC.Ngay8 = listDay[7];
					chiTietKC.Ngay9 = listDay[8];
					chiTietKC.Ngay10 = listDay[9];
					chiTietKC.Ngay11 = listDay[10];
					chiTietKC.Ngay12 = listDay[11];
					chiTietKC.Ngay13 = listDay[12];
					chiTietKC.Ngay14 = listDay[13];
					chiTietKC.Ngay15 = listDay[14];
					chiTietKC.Ngay16 = listDay[15];
					chiTietKC.Ngay17 = listDay[16];
					chiTietKC.Ngay18 = listDay[17];
					chiTietKC.Ngay19 = listDay[18];
					chiTietKC.Ngay20 = listDay[19];
					chiTietKC.Ngay21 = listDay[20];
					chiTietKC.Ngay22 = listDay[21];
					chiTietKC.Ngay23 = listDay[22];
					chiTietKC.Ngay24 = listDay[23];
					chiTietKC.Ngay25 = listDay[24];
					chiTietKC.Ngay26 = listDay[25];
					chiTietKC.Ngay27 = listDay[26];
					chiTietKC.Ngay28 = listDay[27];
					chiTietKC.Ngay29 = listDay[28];
					chiTietKC.Ngay30 = listDay[29];
					chiTietKC.Ngay31 = listDay[30];

					db.tblChiTietChamCongs.InsertOnSubmit(chiTietKC);
					db.SubmitChanges();
				}
			}
            catch (Exception ex)
            {
				return ex.Message;
            }
			return "1";
		}
		private int GetDayNumber(int thang, int nam)
		{
			int dayNumber = 0;
			switch (thang)
			{
				case 2:
					dayNumber = (nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0 ? 29 : 28;
					break;

				case 4:
				case 6:
				case 9:
				case 11:
					dayNumber = 30;
					break;

				case 1:
				case 3:
				case 5:
				case 7:
				case 8:
				case 10:
				case 12:
					dayNumber = 31;
					break;
			}

			return dayNumber;
		}

		public string insert(tblChiTietChamCong pCTChC)
		{
			try
			{
				db = new QL_QuanCafeUpdateDataContext();
				db.tblChiTietChamCongs.InsertOnSubmit(pCTChC);
				db.SubmitChanges();
				return "1";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
		public string update(tblChiTietChamCong pCTChC)
		{
			try
			{
				db = new QL_QuanCafeUpdateDataContext();
				var ctcc = db.tblChiTietChamCongs.FirstOrDefault(n => n.MaChamCong == pCTChC.MaChamCong && n.MaDKCa == pCTChC.MaDKCa);
				if (ctcc != null)
				{
					ctcc.Ngay1 = pCTChC.Ngay1;
					ctcc.Ngay2 = pCTChC.Ngay2;
					ctcc.Ngay3 = pCTChC.Ngay3;
					ctcc.Ngay4 = pCTChC.Ngay4;
					ctcc.Ngay5 = pCTChC.Ngay5;
					ctcc.Ngay6 = pCTChC.Ngay6;
					ctcc.Ngay7 = pCTChC.Ngay7;
					ctcc.Ngay8 = pCTChC.Ngay8;
					ctcc.Ngay9 = pCTChC.Ngay9;
					ctcc.Ngay10 = pCTChC.Ngay10;
					ctcc.Ngay11 = pCTChC.Ngay11;
					ctcc.Ngay12 = pCTChC.Ngay12;
					ctcc.Ngay13 = pCTChC.Ngay13;
					ctcc.Ngay14 = pCTChC.Ngay14;
					ctcc.Ngay15 = pCTChC.Ngay15;
					ctcc.Ngay16= pCTChC.Ngay16;
					ctcc.Ngay17 = pCTChC.Ngay17;
					ctcc.Ngay18 = pCTChC.Ngay18;
					ctcc.Ngay19 = pCTChC.Ngay19;
					ctcc.Ngay20 = pCTChC.Ngay20;
					ctcc.Ngay21 = pCTChC.Ngay21;
					ctcc.Ngay22 = pCTChC.Ngay22;
					ctcc.Ngay23 = pCTChC.Ngay23;
					ctcc.Ngay24 = pCTChC.Ngay24;
					ctcc.Ngay25 = pCTChC.Ngay25;
					ctcc.Ngay26 = pCTChC.Ngay26;
					ctcc.Ngay27 = pCTChC.Ngay27;
					ctcc.Ngay28 = pCTChC.Ngay28;
					ctcc.Ngay29 = pCTChC.Ngay29;
					ctcc.Ngay30 = pCTChC.Ngay30;
					ctcc.Ngay31 = pCTChC.Ngay31;
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
				tblChiTietChamCong chC = db.tblChiTietChamCongs.FirstOrDefault(n => n.MaChamCong == pMaChC);
				db.tblChiTietChamCongs.DeleteOnSubmit(chC);
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
