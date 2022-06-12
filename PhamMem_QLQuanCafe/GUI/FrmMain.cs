using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            skin();
        }
        void skin()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Office 2016 Colorful";
        }
        //Hàm thêm form vào main form
        void addForm(Type tForm)
        {
            //Kiểm tra hiện tại form đã mở hay chưa?
            foreach (Form frm in MdiChildren)
            {
                //Nếu đang mở thì active lên
                if (frm.GetType() == tForm)
                {
                    frm.Activate();
                    return;
                }
            }
            //Add form vào Control
            Form f = (Form)Activator.CreateInstance(tForm);
            f.MdiParent = this;
            f.Show();
        }
        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addForm(typeof(FrmNhanVien));
        }

        private void btnCaLamViec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addForm(typeof(FrmCaLamViec));
        }

        private void btnChamCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addForm(typeof(FrmChamCong));
        }

        private void btnGoiMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //addForm(typeof(FrmNghiepVuChinh));
            FrmNghiepVuChinh frm = new FrmNghiepVuChinh();
            frm.ShowDialog();

        }

        private void btnHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addForm(typeof(FrmHoaDonBanHang));
        }
    }
}
