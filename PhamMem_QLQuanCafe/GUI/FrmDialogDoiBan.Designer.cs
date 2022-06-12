
namespace GUI
{
    partial class FrmDialogDoiBan
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
            this.btnBan1 = new System.Windows.Forms.Button();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.sleBan_CTHD = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.sleBan_CTHD_View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaBan_CTHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenBan_CTHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnDong = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnDoi = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.sleBan_CTHD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleBan_CTHD_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBan1
            // 
            this.btnBan1.BackColor = System.Drawing.Color.Red;
            this.btnBan1.BackgroundImage = global::GUI.Properties.Resources.iconban2;
            this.btnBan1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBan1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnBan1.ForeColor = System.Drawing.Color.White;
            this.btnBan1.Location = new System.Drawing.Point(12, 32);
            this.btnBan1.Name = "btnBan1";
            this.btnBan1.Size = new System.Drawing.Size(100, 100);
            this.btnBan1.TabIndex = 0;
            this.btnBan1.Text = "Bàn 1";
            this.btnBan1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBan1.UseVisualStyleBackColor = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(118, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(138, 21);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Chuyển đến bàn";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(118, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(140, 21);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "------------------>";
            // 
            // sleBan_CTHD
            // 
            this.sleBan_CTHD.Location = new System.Drawing.Point(274, 36);
            this.sleBan_CTHD.Name = "sleBan_CTHD";
            this.sleBan_CTHD.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.sleBan_CTHD.Properties.Appearance.Options.UseFont = true;
            this.sleBan_CTHD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sleBan_CTHD.Properties.NullText = "Chọn bàn";
            this.sleBan_CTHD.Properties.PopupView = this.sleBan_CTHD_View;
            this.sleBan_CTHD.Size = new System.Drawing.Size(205, 24);
            this.sleBan_CTHD.TabIndex = 22;
            this.sleBan_CTHD.BeforePopup += new System.EventHandler(this.sleBan_CTHD_BeforePopup);
            // 
            // sleBan_CTHD_View
            // 
            this.sleBan_CTHD_View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaBan_CTHD,
            this.colTenBan_CTHD});
            this.sleBan_CTHD_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.sleBan_CTHD_View.Name = "sleBan_CTHD_View";
            this.sleBan_CTHD_View.OptionsEditForm.PopupEditFormWidth = 100;
            this.sleBan_CTHD_View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.sleBan_CTHD_View.OptionsView.ShowGroupPanel = false;
            // 
            // colMaBan_CTHD
            // 
            this.colMaBan_CTHD.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colMaBan_CTHD.AppearanceCell.Options.UseFont = true;
            this.colMaBan_CTHD.AppearanceCell.Options.UseTextOptions = true;
            this.colMaBan_CTHD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaBan_CTHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colMaBan_CTHD.AppearanceHeader.Options.UseFont = true;
            this.colMaBan_CTHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaBan_CTHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaBan_CTHD.Caption = "Mã bàn";
            this.colMaBan_CTHD.FieldName = "MaBan";
            this.colMaBan_CTHD.Name = "colMaBan_CTHD";
            this.colMaBan_CTHD.Visible = true;
            this.colMaBan_CTHD.VisibleIndex = 0;
            // 
            // colTenBan_CTHD
            // 
            this.colTenBan_CTHD.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colTenBan_CTHD.AppearanceCell.Options.UseFont = true;
            this.colTenBan_CTHD.AppearanceCell.Options.UseTextOptions = true;
            this.colTenBan_CTHD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenBan_CTHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colTenBan_CTHD.AppearanceHeader.Options.UseFont = true;
            this.colTenBan_CTHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenBan_CTHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenBan_CTHD.Caption = "Bàn số";
            this.colTenBan_CTHD.FieldName = "TenBan";
            this.colTenBan_CTHD.Name = "colTenBan_CTHD";
            this.colTenBan_CTHD.Visible = true;
            this.colTenBan_CTHD.VisibleIndex = 1;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDong});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(74, 151);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDong, true)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnDong
            // 
            this.btnDong.Caption = "Đóng";
            this.btnDong.Id = 0;
            this.btnDong.ImageOptions.SvgImage = global::GUI.Properties.Resources.del;
            this.btnDong.Name = "btnDong";
            this.btnDong.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDong_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(515, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 164);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(515, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 134);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(515, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 134);
            // 
            // btnDoi
            // 
            this.btnDoi.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDoi.Appearance.Options.UseFont = true;
            this.btnDoi.ImageOptions.Image = global::GUI.Properties.Resources.refresh_32x32;
            this.btnDoi.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDoi.Location = new System.Drawing.Point(366, 81);
            this.btnDoi.Name = "btnDoi";
            this.btnDoi.Size = new System.Drawing.Size(113, 51);
            this.btnDoi.TabIndex = 27;
            this.btnDoi.Text = "Đổi";
            this.btnDoi.Click += new System.EventHandler(this.btnDoi_Click);
            // 
            // FrmDialogDoiBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 164);
            this.Controls.Add(this.sleBan_CTHD);
            this.Controls.Add(this.btnDoi);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnBan1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::GUI.Properties.Resources.swapsmall;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDialogDoiBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐỔI BÀN";
            this.Load += new System.EventHandler(this.FrmDialogDoiBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sleBan_CTHD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleBan_CTHD_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBan1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit sleBan_CTHD;
        private DevExpress.XtraGrid.Views.Grid.GridView sleBan_CTHD_View;
        private DevExpress.XtraGrid.Columns.GridColumn colMaBan_CTHD;
        private DevExpress.XtraGrid.Columns.GridColumn colTenBan_CTHD;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnDong;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SimpleButton btnDoi;
    }
}