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

namespace GUI
{
    public partial class FrmChamCong : DevExpress.XtraEditors.XtraForm
    {
        BLL_ChamCong bllChC;
        BLL_ChiTietChamCong bllCTCC;
        public FrmChamCong()
        {
            InitializeComponent();
            cboThang.SelectedIndex = 0;
        }

        private void FrmChamCong_Load(object sender, EventArgs e)
        {
            loadCbo();
            loadData();
            dongGiaoTac();

        }
        void loadData()
        {
            bllChC = new BLL_ChamCong();
            gcKyCong.DataSource = bllChC.getAllChamCong();
        }
        void loadCbo()
        {
            List<string> lstNam = new List<string>();
            for (int i = 2000; i <= DateTime.Now.Year; i++)
            {
                lstNam.Add(i.ToString());
            }
            cboNam.DataSource = lstNam;
            cboNam.SelectedIndex = cboNam.Items.Count - 1;
        }
        void dongGiaoTac()
        {
            btnLuuTop.Enabled = false;
            lbThang.Enabled = false;
            lbNam.Enabled = false;
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dongGiaoTac();
            loadData();
            loadCbo();
            btnThemTop.Enabled = true;
        }

        private void btnThemTop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThemTop.Enabled = false;
            btnLuuTop.Enabled = true;
            lbThang.Enabled = true;
            lbNam.Enabled = true;
        }

        private void btnLuuTop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(cboThang.SelectedIndex<0)
            {
                XtraMessageBox.Show("Vui lòng chọn "+lbThang.Text, "Thông báo [Message]"
                         , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboNam.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn " + lbNam.Text, "Thông báo [Message]"
                         , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var thang = cboThang.SelectedItem;
            var nam = cboNam.SelectedItem;

            string maChC = thang.ToString() + nam.ToString();

            bllChC = new BLL_ChamCong();
            //Check đã có kỳ công của tháng trong năm hay chưa
            if(bllChC.checkKhoaChinh(maChC))
            {
                XtraMessageBox.Show("Tháng " +thang.ToString()+" năm "+nam.ToString()+" đã phát sinh kỳ công trước đó." , "Thông báo [Message]"
                         , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    

            tblChamCong chC = new tblChamCong();
            chC.MaChamCong = maChC;
            chC.Thang = Convert.ToInt32(thang);
            chC.Nam= Convert.ToInt32(nam);
            chC.TrangThai = false;

            string kqInsert = bllChC.insert(chC);


            if (kqInsert.Equals("1"))
            {
                acThongBao.Show(this, "Thông báo", "Thêm mới thành công."
                       , "", Properties.Resources.success2___Copy, new Message());
                XtraMessageBox.Show("Phát sinh kỳ công thành công", "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.None);
                dongGiaoTac();
                loadData();
                btnThemTop.Enabled = true;

                //Add chitiet ky cong
                bllCTCC = new BLL_ChiTietChamCong();
                    string kqInserCTKC = bllCTCC.PhatSinhCTCC(chC.MaChamCong, Convert.ToInt32(thang), Convert.ToInt32(nam));

            }
            else
            {
                XtraMessageBox.Show("Error: " + kqInsert, "Thông báo [Message]"
                      , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXemBangC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var maKyCong = gvKyCong.GetRowCellValue(gvKyCong.FocusedRowHandle, gvKyCong.Columns["MaChamCong"]);
            var thang = gvKyCong.GetRowCellValue(gvKyCong.FocusedRowHandle, gvKyCong.Columns["Thang"]);
            var nam = gvKyCong.GetRowCellValue(gvKyCong.FocusedRowHandle, gvKyCong.Columns["Nam"]);


            if (maKyCong != null && thang != null&& nam != null)
            {
                FrmChiTietCong frm = new FrmChiTietCong(maKyCong.ToString(), Convert.ToInt32(thang),Convert.ToInt32(nam));

                frm.Show();
            }
        }
    }
}