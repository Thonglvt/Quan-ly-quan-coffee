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
using DevExpress.XtraBars;

namespace GUI
{
    public partial class FrmDialogDoiBan : DevExpress.XtraEditors.XtraForm
    {
        BLL_Ban bllBan;
        BLL_HoaDonBanHang bllHDBH;
        //
        public delegate void LoadDLFormCha();
        public LoadDLFormCha ReloadData_FormCha;


        public FrmDialogDoiBan()
        {
            InitializeComponent();
        }
        public FrmDialogDoiBan(FrmNghiepVuChinh frm)
        {
            InitializeComponent();
        }


        #region Method
        void loadSLE()
        {
            bllBan = new BLL_Ban();
            sleBan_CTHD.Properties.DataSource = bllBan.getBanTrong();
            sleBan_CTHD.Properties.DisplayMember = "TenBan";
            sleBan_CTHD.Properties.ValueMember = "MaBan";

        }
        #endregion
        #region Event
        private void FrmDialogDoiBan_Load(object sender, EventArgs e)
        {
            loadSLE();
            btnBan1.Text = DTO_SessionHoaDon.banDangChon.TenBan;
        }
        private void sleBan_CTHD_BeforePopup(object sender, EventArgs e)
        {
            loadSLE();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnDoi_Click(object sender, EventArgs e)
        {
            bllBan = new BLL_Ban();
            bllHDBH = new BLL_HoaDonBanHang();
            var maBan = sleBan_CTHD.EditValue;
            var tenBan = sleBan_CTHD.Text;
            if (maBan != null && tenBan != null)
            {
                //Chuyển đổi trạng thái bàn củ
                string cdOld = bllBan.chuyenDoiTrangThaiBan(DTO_SessionHoaDon.banDangChon.MaBan);
                //Chuyển đổi trạng thái bàn mới
                string cdNew = bllBan.chuyenDoiTrangThaiBan(maBan.ToString());

                DTO_SessionHoaDon.HD_HienTai.MaBan = maBan.ToString();
                string kqChuyenBanOfHD = bllHDBH.update(DTO_SessionHoaDon.HD_HienTai);
                if (kqChuyenBanOfHD.Equals("1"))
                {
                    string banOld = DTO_SessionHoaDon.banDangChon.TenBan;
                    DTO_SessionHoaDon.danhSachBan = bllBan.getAll();
                    DTO_SessionHoaDon.banDangChon = bllBan.findBanByMa(maBan.ToString());

                    if (ReloadData_FormCha != null)
                        ReloadData_FormCha();
                    XtraMessageBox.Show("Đã đổi " + banOld + " sang " + tenBan, "Thông báo [Message]"
                              , MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }
            }

        }
        #endregion




    }
}