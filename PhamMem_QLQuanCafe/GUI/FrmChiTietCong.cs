using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.Export;
using System.IO;
using System.Diagnostics;

namespace GUI
{
    public partial class FrmChiTietCong : DevExpress.XtraEditors.XtraForm
    {

        BLL_ChiTietChamCong bllCTCC;
		BLL_HamXuLyChung bllHXLC;
		BLL_CaLamViec bllCLV;
		DataTable dataTableTmp;
		List<DTO_ChiTietChamCong> lstChiTietChCong; 
        static string MaKyCong = "";
		static int Thang = 6;
		static int Nam = 2022;
		public FrmChiTietCong(string pMaKyCong,int pThang,int pNam)
        {
            InitializeComponent();
            FrmChiTietCong.MaKyCong = pMaKyCong;
			FrmChiTietCong.Thang = pThang;
			FrmChiTietCong.Nam = pNam;

			//add searchlookupEdit
			DataTable dtThang = new DataTable();
			dtThang.Columns.Add("Thang");
            for (int i = 1; i <= 12; i++)
            {
				dtThang.Rows.Add(i);
			}
			DataTable dtNam = new DataTable();
			dtNam.Columns.Add("Nam");
			for (int i = 2017; i <= DateTime.Now.Year; i++)
			{
				dtNam.Rows.Add(i);
			}

			sleThang.Properties.DataSource = dtThang;
			sleThang.Properties.DisplayMember = "Thang";
			sleThang.Properties.ValueMember = "Thang";

			sleNam.Properties.DataSource = dtNam;
			sleNam.Properties.DisplayMember = "Nam";
			sleNam.Properties.ValueMember = "Nam";

			sleThang.EditValue = FrmChiTietCong.Thang;
			sleNam.EditValue = FrmChiTietCong.Nam;

			//lbThang.Enabled = false;
			//lbNam.Enabled = false;
			lbCLV.Enabled = false;

            //
            gvCTCC_View.CellValueChanging += GvCTCC_View_CellValueChanging;

		}


        private void GvCTCC_View_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
			//int indCell = gvCTCC_View.getfo

			for (int i = 0; i < gvCTCC_View.DataRowCount; i++)
            {
                //Duyệt qua column
                foreach (GridColumn column in gvCTCC_View.VisibleColumns)
                {
                    var cellValue = gvCTCC_View.GetRowCellValue(i, column.FieldName);
					//lstChiTietChCong[i] = e.Value.ToString();

					//lstChiTietChCong[i].Ngay2 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay3 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay4 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay5 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay6 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay7 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay8 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay9 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay10 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay11 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay12 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay13 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay14 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay15 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay16 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay17 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay18 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay19 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay20 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay21 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay22 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay23 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay24 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay25 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay26 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay27 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay28 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay29 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay30 = e.Value.ToString();
					//lstChiTietChCong[i].Ngay31 = e.Value.ToString();

				}
			}
        }

		private void FrmChiTietCong_Load(object sender, EventArgs e)
        {
            loadData();
			loadSle();
			CustomView(FrmChiTietCong.Thang, FrmChiTietCong.Nam);
		}
        void loadData()
        {
			bllCTCC = new BLL_ChiTietChamCong();
            gcCTCC.DataSource = bllCTCC.GetChiTietChCongByMaChamCong(FrmChiTietCong.MaKyCong);
            CustomView(FrmChiTietCong.Thang, FrmChiTietCong.Nam);
        }
		void loadSle()
        {
			bllCLV = new BLL_CaLamViec();
			sleCaLV.Properties.DataSource = bllCLV.getAllCaLamViec();
			sleCaLV.Properties.DisplayMember = "TenCa";
			sleCaLV.Properties.ValueMember = "MaCa";

		}

		private void CustomView(int thang, int nam)
		{
			bllHXLC = new BLL_HamXuLyChung();
            gvCTCC_View.RestoreLayoutFromXml(Application.StartupPath + @"\BangCong_Layout.xml");
            int i;
			foreach (GridColumn gridColumn in gvCTCC_View.Columns)
			{
				if (gridColumn.FieldName == "MaDKCa") continue;
				if (gridColumn.FieldName == "TenNV") continue;
				if (gridColumn.FieldName == "MaNV") continue;
				if (gridColumn.FieldName == "TongNgayCong") continue;

				RepositoryItemTextEdit textEdit = new RepositoryItemTextEdit();
				textEdit.Mask.MaskType = MaskType.RegEx;
				textEdit.Mask.EditMask = @"\p{Lu}+";
				gridColumn.ColumnEdit = textEdit;
			}

			for (i = 1; i <= bllHXLC.GetDayNumber(thang, nam); i++)
			{
				DateTime newDate = new DateTime(nam, thang, i);

				GridColumn column = new GridColumn();
				column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
				string fieldName = "Ngay" + i;
				switch (newDate.DayOfWeek.ToString())
				{
					case "Monday":
						column = gvCTCC_View.Columns[fieldName];
						column.Caption = "T.Hai " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.AppearanceCell.BackColor2 = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						//column.Width = 30;
						//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
						break;

					case "Tuesday":
						column = gvCTCC_View.Columns[fieldName];
						column.Caption = "T.Ba " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
						//column.Width = 30;
						break;

					case "Wednesday":
						column = gvCTCC_View.Columns[fieldName];
						column.Caption = "T.Tư " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
						//column.Width = 30;
						break;
					case "Thursday":
						column = gvCTCC_View.Columns[fieldName];
						column.Caption = "T.Năm " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
						//column.Width = 30;
						break;
					case "Friday":
						column = gvCTCC_View.Columns[fieldName];
						column.Caption = "T.Sáu " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
						//column.Width = 30;
						break;
					case "Saturday":
						column = gvCTCC_View.Columns[fieldName];
						column.Caption = "T.Bảy " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Red;
						column.AppearanceHeader.BackColor = Color.Aqua;
						column.AppearanceHeader.BackColor2 = Color.Aqua;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Cornsilk;
						column.OptionsColumn.AllowFocus = true;
						//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
						//column.Width = 30;
						break;
					case "Sunday":
						column = gvCTCC_View.Columns[fieldName];
						column.Caption = "CN " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Red;
						column.AppearanceHeader.BackColor = Color.DodgerBlue;
						column.AppearanceHeader.BackColor2 = Color.DodgerBlue;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.BurlyWood;
						//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
						//column.Width = 30;
						//column.OptionsColumn.AllowFocus = false;
						break;
				}
			}

			while (i <= 31)
			{
				gvCTCC_View.Columns[i + 1].Visible = false;
				i++;
			}

		}


		void luuTamVaoDatable()
        {
			dataTableTmp = new DataTable();
			int indexCol = 0;
			//add Field cột
			foreach (GridColumn item in gvCTCC_View.VisibleColumns)
			{
				dataTableTmp.Columns.Add(item.FieldName);
			}
            //Add dữ liệu cột
			for (int i = 0; i < gvCTCC_View.DataRowCount; i++)
            {
				DataRow dr = dataTableTmp.NewRow();
				foreach (GridColumn column in gvCTCC_View.VisibleColumns)
                {
                    var dataCell = gvCTCC_View.GetRowCellValue(i, column.FieldName);
                    if (dataCell != null)
                    {
						dr[column.FieldName] = dataCell.ToString();
                    }
                }
				//dataTableTmp.Rows.Add(dr);
			}
        }
        private void sleNam_EditValueChanged(object sender, EventArgs e)
        {
			lbThang.Enabled = true;
			bllCTCC = new BLL_ChiTietChamCong();
			var thang = sleThang.EditValue;
			var nam = sleNam.EditValue;
			var maCa = sleCaLV.EditValue;
						
			if (thang != null && nam != null)
			{
				if (checkChonCa.Checked == true && maCa != null)
				{
					gcCTCC.DataSource = bllCTCC.GetChiTietChCongByMaChamCongThangNamMaCa(thang.ToString() + nam.ToString(), Convert.ToInt32(thang), Convert.ToInt32(nam), maCa.ToString());
					CustomView(Convert.ToInt32(thang), Convert.ToInt32(nam));
				}
				else
                {
                    gcCTCC.DataSource = bllCTCC.GetChiTietChCongByMaChamCong(thang.ToString() + nam.ToString());
                    CustomView(Convert.ToInt32(thang), Convert.ToInt32(nam));
				}
			}
		}

        private void sleThang_EditValueChanged(object sender, EventArgs e)
        {
			bllCTCC = new BLL_ChiTietChamCong();
			var thang = sleThang.EditValue;
			var nam = sleNam.EditValue;
			var maCa = sleCaLV.EditValue;
			if (thang != null && nam != null)
			{
				if (checkChonCa.Checked == true && maCa!=null)
				{
					gcCTCC.DataSource = bllCTCC.GetChiTietChCongByMaChamCongThangNamMaCa(thang.ToString() + nam.ToString(), Convert.ToInt32(thang), Convert.ToInt32(nam), maCa.ToString());
					CustomView(Convert.ToInt32(thang), Convert.ToInt32(nam));
				}
				else
				{
					gcCTCC.DataSource = bllCTCC.GetChiTietChCongByMaChamCong(thang.ToString() + nam.ToString());
					CustomView(Convert.ToInt32(thang), Convert.ToInt32(nam));
				}
			}
		}

        private void sleCaLV_EditValueChanged(object sender, EventArgs e)
        {
			lbNam.Enabled = true;

			bllCTCC = new BLL_ChiTietChamCong();
			var thang = sleThang.EditValue;
			var nam = sleNam.EditValue;
			var maCa = sleCaLV.EditValue;
			if (lbThang.Enabled && lbNam.Enabled)
			{
				if (thang != null && nam != null)
				{
					gcCTCC.DataSource = bllCTCC.GetChiTietChCongByMaChamCongThangNamMaCa(thang.ToString() + nam.ToString(), Convert.ToInt32(thang), Convert.ToInt32(nam), maCa.ToString());
					CustomView(Convert.ToInt32(thang), Convert.ToInt32(nam));
				}
			}
			else
			{
				if (thang != null && nam != null && maCa != null)
				{
					gcCTCC.DataSource = bllCTCC.GetChiTietChCongByMaChamCongThangNamMaCa(thang.ToString() + nam.ToString(), Convert.ToInt32(thang), Convert.ToInt32(nam), maCa.ToString());
					CustomView(Convert.ToInt32(thang), Convert.ToInt32(nam));
				}
			}			
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
			loadData();
		}

        private void checkChonCa_CheckedChanged(object sender, EventArgs e)
        {
			lbCLV.Enabled = !lbCLV.Enabled;

			checkChonCa.ForeColor =  (checkChonCa.Checked==true)?Color.Green:Color.Red;
			bllCTCC = new BLL_ChiTietChamCong();
			var thang = sleThang.EditValue;
			var nam = sleNam.EditValue;
			var maCa = sleCaLV.EditValue;
			if (!checkChonCa.Checked)
            {
				if (thang != null && nam != null)
				{
					gcCTCC.DataSource = bllCTCC.GetChiTietChCongByMaChamCong(thang.ToString() + nam.ToString());
					CustomView(Convert.ToInt32(thang), Convert.ToInt32(nam));
				}
			}	
			else
            {
				if(maCa!=null)
                {
					gcCTCC.DataSource = bllCTCC.GetChiTietChCongByMaChamCongThangNamMaCa(thang.ToString() + nam.ToString(), Convert.ToInt32(thang), Convert.ToInt32(nam), maCa.ToString());
					CustomView(Convert.ToInt32(thang), Convert.ToInt32(nam));
				}					
            }				

        }

        private void btnLuuTop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Duyệt qua gridview
            for (int i = 0; i < gvCTCC_View.DataRowCount; i++)
            {
				//Duyệt qua column
                    try
                    {
						var maChamCong = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["MaChamCong"]);
						var MaDKCa = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["MaDKCa"]);
						var Ngay1 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay1"]);
						var Ngay2 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay2"]);
						var Ngay3 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay3"]);
						var Ngay4 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay4"]);
						var Ngay5 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay5"]);
						var Ngay6 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay6"]);
						var Ngay7 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay7"]);
						var Ngay8 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay8"]);
						var Ngay9 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay9"]);
						var Ngay10 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay10"]);
						var Ngay11 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay11"]);
						var Ngay12 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay12"]);
						var Ngay13 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay13"]);
						var Ngay14 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay14"]);
						var Ngay15 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay15"]);
						var Ngay16 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay16"]);
						var Ngay17 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay17"]);
						var Ngay18 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay18"]);
						var Ngay19 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay19"]);
						var Ngay20 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay20"]);
						var Ngay21 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay21"]);
						var Ngay22 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay22"]);
						var Ngay23 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay23"]);
						var Ngay24 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay24"]);
						var Ngay25 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay25"]);
						var Ngay26 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay26"]);
						var Ngay27 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay27"]);
						var Ngay28 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay28"]);
						var Ngay29 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay29"]);
						var Ngay30 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay30"]);
						var Ngay31 = gvCTCC_View.GetRowCellValue(i, gvCTCC_View.Columns["Ngay31"]);

						tblChiTietChamCong ctcc = new tblChiTietChamCong();
						ctcc.MaChamCong = maChamCong.ToString();
						ctcc.MaDKCa = Convert.ToInt32(MaDKCa);
						ctcc.Ngay1 = Ngay1.ToString();
						ctcc.Ngay2 = Ngay2.ToString();
						ctcc.Ngay3 = Ngay3.ToString();
						ctcc.Ngay4 = Ngay4.ToString();
						ctcc.Ngay5 = Ngay5.ToString();
						ctcc.Ngay6 = Ngay6.ToString();
						ctcc.Ngay7 = Ngay7.ToString();
						ctcc.Ngay8 = Ngay8.ToString();
						ctcc.Ngay9 = Ngay9.ToString();
						ctcc.Ngay10 = Ngay10.ToString();
						ctcc.Ngay11 = Ngay11.ToString();
						ctcc.Ngay12 = Ngay12.ToString();
						ctcc.Ngay13 = Ngay13.ToString();
						ctcc.Ngay14 = Ngay14.ToString();
						ctcc.Ngay15 = Ngay15.ToString();
						ctcc.Ngay16 = Ngay16.ToString();
						ctcc.Ngay17 = Ngay17.ToString();
						ctcc.Ngay18 = Ngay18.ToString();
						ctcc.Ngay19 = Ngay19.ToString();
						ctcc.Ngay20 = Ngay20.ToString();
						ctcc.Ngay21 = Ngay21.ToString();
						ctcc.Ngay22 = Ngay22.ToString();
						ctcc.Ngay23 = Ngay23.ToString();
						ctcc.Ngay24 = Ngay24.ToString();
						ctcc.Ngay25 = Ngay25.ToString();
						ctcc.Ngay26 = Ngay26.ToString();
						ctcc.Ngay27 = Ngay27.ToString();
						ctcc.Ngay28 = Ngay28.ToString();
						ctcc.Ngay29 = Ngay29.ToString();
						ctcc.Ngay30 = Ngay30.ToString();
						ctcc.Ngay31 = Ngay31.ToString();

					//UPDATE
					string kqUpd = bllCTCC.update(ctcc);
					}
					catch (Exception)
                    {
						return;
                    }	
			}
			acThongBao.Show(this, "Thông báo", "Cập nhật thành công."
				   , "", Properties.Resources.success2___Copy, new Message());
			XtraMessageBox.Show("Cập nhật thành công", "Thông báo [Message]"
				  , MessageBoxButtons.OK, MessageBoxIcon.None);
            loadData();
        }

        private void btnToday_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
			sleNam.EditValue = DateTime.Now.Year;
			sleThang.EditValue = DateTime.Now.Month;
		}
        private void btnIn_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
			try
			{
				if (gvCTCC_View.FocusedRowHandle < 0)
				{
					XtraMessageBox.Show("Không tìm thấy dữ liệu", "Thông báo [Message]"
				  , MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					var saveDialog = new SaveFileDialog();
					saveDialog.Title = @"Export file excel";
					saveDialog.FileName = "";
					saveDialog.Filter = "Excel (*.xlsx|*.xlsx|Excel 2003 (*.xls)|*.xls))";
					if (saveDialog.ShowDialog() == DialogResult.OK)
					{
						gvCTCC_View.OptionsPrint.AutoWidth = AutoSize;
						gvCTCC_View.OptionsPrint.ShowPrintExportProgress = true;
						gvCTCC_View.OptionsPrint.AllowCancelPrintExport = true;
						XlsxExportOptions options = new XlsxExportOptions();
						options.TextExportMode = TextExportMode.Text;
						options.ExportMode = XlsxExportMode.SingleFile;
						options.SheetName = @"sheet1";

						ExportSettings.DefaultExportType = ExportType.WYSIWYG;
						gvCTCC_View.ExportToXlsx(saveDialog.FileName, options);
					}
					if (File.Exists(saveDialog.FileName))
					{
						if (XtraMessageBox.Show("Export susscess.\nBạn có muốn mở file?", "Thông báo [Message]", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
						{
							Process.Start(saveDialog.FileName);
						}
						return;
					}


				}

			}
			catch (Exception ex)
			{
				XtraMessageBox.Show("Error: " + ex.Message, "Thông báo [Message]"
				  , MessageBoxButtons.OK, MessageBoxIcon.None);
			}
		}

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
			close();
		}
		void close()
        {
			if (XtraMessageBox.Show("Bạn có muốn lưu thay đổi?", "Thông báo [Message]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				btnLuuTop.PerformClick();
			this.Close();
		}

        private void FrmChiTietCong_FormClosing(object sender, FormClosingEventArgs e)
        {
		}
    }

}