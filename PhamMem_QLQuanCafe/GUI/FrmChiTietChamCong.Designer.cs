
namespace GUI
{
    partial class FrmChiTietChamCong
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThemTop = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuuTop = new DevExpress.XtraBars.BarButtonItem();
            this.btnLamMoi = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.acThongBao = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.layoutControlTop = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlBottom = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.lbThang = new DevExpress.XtraLayout.LayoutControlItem();
            this.lbNam = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.gcCTCC = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlTop)).BeginInit();
            this.layoutControlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlBottom)).BeginInit();
            this.layoutControlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCTCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThemTop,
            this.btnLuuTop,
            this.btnLamMoi,
            this.barButtonItem5});
            this.barManager1.MainMenu = this.bar1;
            this.barManager1.MaxItemId = 9;
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(424, 188);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThemTop, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLuuTop, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLamMoi),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // btnThemTop
            // 
            this.btnThemTop.Caption = "Thêm";
            this.btnThemTop.Id = 0;
            this.btnThemTop.ImageOptions.Image = global::GUI.Properties.Resources.add_16x16;
            this.btnThemTop.ImageOptions.LargeImage = global::GUI.Properties.Resources.add_32x32;
            this.btnThemTop.Name = "btnThemTop";
            this.btnThemTop.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnLuuTop
            // 
            this.btnLuuTop.Caption = "Lưu";
            this.btnLuuTop.Id = 1;
            this.btnLuuTop.ImageOptions.Image = global::GUI.Properties.Resources.saveall_16x16;
            this.btnLuuTop.ImageOptions.LargeImage = global::GUI.Properties.Resources.saveall_32x32;
            this.btnLuuTop.Name = "btnLuuTop";
            this.btnLuuTop.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Caption = "Refresh";
            this.btnLamMoi.Id = 5;
            this.btnLamMoi.ImageOptions.Image = global::GUI.Properties.Resources.recurrence_16x16;
            this.btnLamMoi.ImageOptions.LargeImage = global::GUI.Properties.Resources.recurrence_32x32;
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Danh sách đăng ký ca";
            this.barButtonItem5.Id = 8;
            this.barButtonItem5.ImageOptions.Image = global::GUI.Properties.Resources.chartsshowlegend_16x16;
            this.barButtonItem5.ImageOptions.LargeImage = global::GUI.Properties.Resources.chartsshowlegend_32x32;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1270, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 756);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1270, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 726);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(1270, 30);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Size = new System.Drawing.Size(0, 726);
            // 
            // layoutControlTop
            // 
            this.layoutControlTop.Controls.Add(this.layoutControl2);
            this.layoutControlTop.Controls.Add(this.layoutControl1);
            this.layoutControlTop.Controls.Add(this.cboThang);
            this.layoutControlTop.Controls.Add(this.cboNam);
            this.layoutControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControlTop.Location = new System.Drawing.Point(0, 30);
            this.layoutControlTop.Name = "layoutControlTop";
            this.layoutControlTop.Root = this.Root;
            this.layoutControlTop.Size = new System.Drawing.Size(1270, 73);
            this.layoutControlTop.TabIndex = 4;
            this.layoutControlTop.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lbThang,
            this.lbNam,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1270, 73);
            this.Root.TextVisible = false;
            // 
            // layoutControlBottom
            // 
            this.layoutControlBottom.Controls.Add(this.gcCTCC);
            this.layoutControlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlBottom.Location = new System.Drawing.Point(0, 103);
            this.layoutControlBottom.Name = "layoutControlBottom";
            this.layoutControlBottom.Root = this.layoutControlGroup1;
            this.layoutControlBottom.Size = new System.Drawing.Size(1270, 653);
            this.layoutControlBottom.TabIndex = 5;
            this.layoutControlBottom.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1270, 653);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // cboNam
            // 
            this.cboNam.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(372, 19);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(79, 29);
            this.cboNam.TabIndex = 5;
            // 
            // cboThang
            // 
            this.cboThang.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboThang.Location = new System.Drawing.Point(233, 19);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(73, 29);
            this.cboThang.TabIndex = 4;
            // 
            // lbThang
            // 
            this.lbThang.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbThang.AppearanceItemCaption.Options.UseFont = true;
            this.lbThang.Control = this.cboThang;
            this.lbThang.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbThang.CustomizationFormText = "Tháng";
            this.lbThang.Location = new System.Drawing.Point(166, 0);
            this.lbThang.Name = "lbThang";
            this.lbThang.Size = new System.Drawing.Size(139, 53);
            this.lbThang.Spacing = new DevExpress.XtraLayout.Utils.Padding(7, 7, 7, 7);
            this.lbThang.Text = "Tháng";
            this.lbThang.TextSize = new System.Drawing.Size(36, 16);
            // 
            // lbNam
            // 
            this.lbNam.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbNam.AppearanceItemCaption.Options.UseFont = true;
            this.lbNam.Control = this.cboNam;
            this.lbNam.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbNam.CustomizationFormText = "Năm";
            this.lbNam.Location = new System.Drawing.Point(305, 0);
            this.lbNam.Name = "lbNam";
            this.lbNam.Size = new System.Drawing.Size(145, 53);
            this.lbNam.Spacing = new DevExpress.XtraLayout.Utils.Padding(7, 7, 7, 7);
            this.lbNam.Text = "Năm";
            this.lbNam.TextSize = new System.Drawing.Size(36, 16);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Location = new System.Drawing.Point(462, 12);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup2;
            this.layoutControl1.Size = new System.Drawing.Size(796, 49);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.layoutControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(450, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(800, 53);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(796, 49);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Location = new System.Drawing.Point(12, 12);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup3;
            this.layoutControl2.Size = new System.Drawing.Size(162, 49);
            this.layoutControl2.TabIndex = 7;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.layoutControl2;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(166, 53);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(162, 49);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // gcCTCC
            // 
            this.gcCTCC.Location = new System.Drawing.Point(12, 12);
            this.gcCTCC.MainView = this.gridView1;
            this.gcCTCC.MenuManager = this.barManager1;
            this.gcCTCC.Name = "gcCTCC";
            this.gcCTCC.Size = new System.Drawing.Size(1246, 629);
            this.gcCTCC.TabIndex = 4;
            this.gcCTCC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcCTCC;
            this.gridView1.Name = "gridView1";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gcCTCC;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1250, 633);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // FrmChiTietChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 756);
            this.Controls.Add(this.layoutControlBottom);
            this.Controls.Add(this.layoutControlTop);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmChiTietChamCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHI TIẾT CHẤM CÔNG";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlTop)).EndInit();
            this.layoutControlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlBottom)).EndInit();
            this.layoutControlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCTCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThemTop;
        private DevExpress.XtraBars.BarButtonItem btnLuuTop;
        private DevExpress.XtraBars.BarButtonItem btnLamMoi;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.Alerter.AlertControl acThongBao;
        private DevExpress.XtraLayout.LayoutControl layoutControlBottom;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControlTop;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.ComboBox cboNam;
        private DevExpress.XtraLayout.LayoutControlItem lbThang;
        private DevExpress.XtraLayout.LayoutControlItem lbNam;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gcCTCC;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}