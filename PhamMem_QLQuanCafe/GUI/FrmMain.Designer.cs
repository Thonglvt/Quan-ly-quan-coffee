
namespace GUI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnCaLamViec = new DevExpress.XtraBars.BarButtonItem();
            this.btnChamCong = new DevExpress.XtraBars.BarButtonItem();
            this.btnGoiMon = new DevExpress.XtraBars.BarButtonItem();
            this.btnHoaDon = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageThuNgan = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageNhanSu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnNhanVien,
            this.btnCaLamViec,
            this.btnChamCong,
            this.btnGoiMon,
            this.btnHoaDon,
            this.skinRibbonGalleryBarItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 9;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageThuNgan,
            this.ribbonPageNhanSu,
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1250, 193);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Caption = "Nhân viên";
            this.btnNhanVien.Id = 1;
            this.btnNhanVien.ImageOptions.Image = global::GUI.Properties.Resources.usergroup_16x16;
            this.btnNhanVien.ImageOptions.LargeImage = global::GUI.Properties.Resources.usergroup_32x32;
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhanVien_ItemClick);
            // 
            // btnCaLamViec
            // 
            this.btnCaLamViec.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.btnCaLamViec.Caption = "Ca làm việc";
            this.btnCaLamViec.Id = 2;
            this.btnCaLamViec.ImageOptions.Image = global::GUI.Properties.Resources.switchtimescalesto_16x16;
            this.btnCaLamViec.ImageOptions.LargeImage = global::GUI.Properties.Resources.switchtimescalesto_32x32;
            this.btnCaLamViec.Name = "btnCaLamViec";
            this.btnCaLamViec.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnCaLamViec.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCaLamViec_ItemClick);
            // 
            // btnChamCong
            // 
            this.btnChamCong.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.btnChamCong.Caption = "Chấm công";
            this.btnChamCong.Id = 3;
            this.btnChamCong.ImageOptions.Image = global::GUI.Properties.Resources.weekend_16x16;
            this.btnChamCong.ImageOptions.LargeImage = global::GUI.Properties.Resources.weekend_32x32;
            this.btnChamCong.Name = "btnChamCong";
            this.btnChamCong.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnChamCong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChamCong_ItemClick);
            // 
            // btnGoiMon
            // 
            this.btnGoiMon.Caption = "Gọi món";
            this.btnGoiMon.Id = 6;
            this.btnGoiMon.ImageOptions.Image = global::GUI.Properties.Resources.tableproperties_16x16;
            this.btnGoiMon.ImageOptions.LargeImage = global::GUI.Properties.Resources.tableproperties_32x32;
            this.btnGoiMon.Name = "btnGoiMon";
            this.btnGoiMon.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnGoiMon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGoiMon_ItemClick);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.btnHoaDon.Caption = "Hóa đơn bán hàng";
            this.btnHoaDon.Id = 7;
            this.btnHoaDon.ImageOptions.Image = global::GUI.Properties.Resources.iconHD2;
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnHoaDon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHoaDon_ItemClick);
            // 
            // ribbonPageThuNgan
            // 
            this.ribbonPageThuNgan.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPageThuNgan.Name = "ribbonPageThuNgan";
            this.ribbonPageThuNgan.Text = "Thu ngân";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnGoiMon);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageNhanSu
            // 
            this.ribbonPageNhanSu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPageNhanSu.Name = "ribbonPageNhanSu";
            this.ribbonPageNhanSu.Text = "Nhân sự";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNhanVien, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCaLamViec, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnChamCong, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Quản lý chấm công";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Quản lý";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnHoaDon, true);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbonControl1;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Giao diện";
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 8;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 787);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ QUÁN CAFE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageNhanSu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnCaLamViec;
        private DevExpress.XtraBars.BarButtonItem btnChamCong;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem btnGoiMon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageThuNgan;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnHoaDon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
    }
}

