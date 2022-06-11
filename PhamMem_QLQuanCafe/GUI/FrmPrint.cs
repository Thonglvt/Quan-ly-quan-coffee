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

namespace GUI
{
    public partial class FrmPrint : DevExpress.XtraEditors.XtraForm
    {
        public FrmPrint()
        {
            InitializeComponent();
        }

        public void printInvoice(List<DTO_KhachHangHoaDon> lstKHHD)
        {
            InvoiceReport report = new InvoiceReport();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
            {
                p.Visible = true;
            }
            report.InitData(lstKHHD);
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            report.RequestParameters = false;
        }
    }
}