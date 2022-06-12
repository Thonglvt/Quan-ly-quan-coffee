using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using DTO;
using System.Collections.Generic;

namespace GUI
{
    public partial class InvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public InvoiceReport()
        {
            InitializeComponent();
        }

        private void xrTableCell6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        public void InitData(List<DTO_KhachHangHoaDon> pLstKHHD, double pTienKDua,double pTienThoi)
        {
            string tenKH = "";
            DateTime ngaylap = new DateTime();
            string maHD = "";
            string maBan = "";
            foreach (DTO_KhachHangHoaDon item in pLstKHHD)
            {
                pKhachHang.Value = item.TenKH;
                pNgayLap.Value = item.NgayLap;
                pMaHD.Value = item.MaHD;
                pBan.Value = item.MaBan;
                this.pTienKDua.Value = pTienKDua;
                this.pTienThoi.Value = pTienThoi;
                objectDataSource2.DataSource = pLstKHHD;
                break;
            }
           
            
        }
    }
}
