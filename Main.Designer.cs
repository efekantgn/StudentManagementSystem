namespace StudentManagementSystem
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCourseAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCourseEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCourseRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCourseDelete = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Silver;
            this.gridControl.EmbeddedNavigator.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.gridControl.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl.EmbeddedNavigator.Appearance.Options.UseBorderColor = true;
            this.gridControl.EmbeddedNavigator.AutoSize = true;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gridControl.Location = new System.Drawing.Point(0, 141);
            this.gridControl.LookAndFeel.SkinName = "VS2010";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView1;
            this.gridControl.Margin = new System.Windows.Forms.Padding(0);
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(790, 458);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bbiPrintPreview,
            this.bsiRecordsCount,
            this.bbiNew,
            this.bbiEdit,
            this.bbiDelete,
            this.bbiRefresh,
            this.barBtnAdd,
            this.barBtnEdit,
            this.barBtnRefresh,
            this.barBtnDelete,
            this.barBtnCourseAdd,
            this.barBtnCourseEdit,
            this.barBtnCourseRefresh,
            this.barBtnCourseDelete});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 34;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage3});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(790, 141);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            this.ribbonControl.SelectedPageChanged += new System.EventHandler(this.RobbonSelectedPageChanged);
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Id = 29;
            this.bbiPrintPreview.Name = "bbiPrintPreview";
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // bbiNew
            // 
            this.bbiNew.Id = 21;
            this.bbiNew.Name = "bbiNew";
            // 
            // bbiEdit
            // 
            this.bbiEdit.Id = 22;
            this.bbiEdit.Name = "bbiEdit";
            // 
            // bbiDelete
            // 
            this.bbiDelete.Id = 23;
            this.bbiDelete.Name = "bbiDelete";
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Id = 24;
            this.bbiRefresh.Name = "bbiRefresh";
            // 
            // barBtnAdd
            // 
            this.barBtnAdd.Caption = "Add";
            this.barBtnAdd.Id = 25;
            this.barBtnAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnAdd.ImageOptions.SvgImage")));
            this.barBtnAdd.Name = "barBtnAdd";
            this.barBtnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnAdd_ItemClick);
            // 
            // barBtnEdit
            // 
            this.barBtnEdit.Caption = "Edit";
            this.barBtnEdit.Id = 26;
            this.barBtnEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnEdit.ImageOptions.SvgImage")));
            this.barBtnEdit.Name = "barBtnEdit";
            this.barBtnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnEdit_ItemClick);
            // 
            // barBtnRefresh
            // 
            this.barBtnRefresh.Caption = "Refresh";
            this.barBtnRefresh.Id = 27;
            this.barBtnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnRefresh.ImageOptions.SvgImage")));
            this.barBtnRefresh.Name = "barBtnRefresh";
            this.barBtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnRefresh_ItemClick);
            // 
            // barBtnDelete
            // 
            this.barBtnDelete.Caption = "Delete";
            this.barBtnDelete.Id = 28;
            this.barBtnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnDelete.ImageOptions.SvgImage")));
            this.barBtnDelete.Name = "barBtnDelete";
            this.barBtnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDelete_ItemClick);
            // 
            // barBtnCourseAdd
            // 
            this.barBtnCourseAdd.Caption = "Add";
            this.barBtnCourseAdd.Id = 30;
            this.barBtnCourseAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnCourseAdd.ImageOptions.SvgImage")));
            this.barBtnCourseAdd.Name = "barBtnCourseAdd";
            this.barBtnCourseAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCourseAdd_ItemClick);
            // 
            // barBtnCourseEdit
            // 
            this.barBtnCourseEdit.Caption = "Edit";
            this.barBtnCourseEdit.Id = 31;
            this.barBtnCourseEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnCourseEdit.ImageOptions.SvgImage")));
            this.barBtnCourseEdit.Name = "barBtnCourseEdit";
            this.barBtnCourseEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCourseEdit_ItemClick);
            // 
            // barBtnCourseRefresh
            // 
            this.barBtnCourseRefresh.Caption = "Refresh";
            this.barBtnCourseRefresh.Id = 32;
            this.barBtnCourseRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnCourseRefresh.ImageOptions.SvgImage")));
            this.barBtnCourseRefresh.Name = "barBtnCourseRefresh";
            this.barBtnCourseRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCourseRefresh_ItemClick);
            // 
            // barBtnCourseDelete
            // 
            this.barBtnCourseDelete.Caption = "Delete";
            this.barBtnCourseDelete.Id = 33;
            this.barBtnCourseDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnCourseDelete.ImageOptions.SvgImage")));
            this.barBtnCourseDelete.Name = "barBtnCourseDelete";
            this.barBtnCourseDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCourseDelete_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Student";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barBtnAdd);
            this.ribbonPageGroup4.ItemLinks.Add(this.barBtnEdit);
            this.ribbonPageGroup4.ItemLinks.Add(this.barBtnRefresh);
            this.ribbonPageGroup4.ItemLinks.Add(this.barBtnDelete);
            this.ribbonPageGroup4.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Course";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barBtnCourseAdd);
            this.ribbonPageGroup5.ItemLinks.Add(this.barBtnCourseEdit);
            this.ribbonPageGroup5.ItemLinks.Add(this.barBtnCourseRefresh);
            this.ribbonPageGroup5.ItemLinks.Add(this.barBtnCourseDelete);
            this.ribbonPageGroup5.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ribbonStatusBar.Dock = System.Windows.Forms.DockStyle.None;
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 575);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(790, 24);
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Student";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Courses";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 599);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Name = "Main";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.BarButtonItem bbiPrintPreview;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barBtnAdd;
        private DevExpress.XtraBars.BarButtonItem barBtnEdit;
        private DevExpress.XtraBars.BarButtonItem barBtnRefresh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barBtnDelete;
        private DevExpress.XtraBars.BarButtonItem barBtnCourseAdd;
        private DevExpress.XtraBars.BarButtonItem barBtnCourseEdit;
        private DevExpress.XtraBars.BarButtonItem barBtnCourseRefresh;
        private DevExpress.XtraBars.BarButtonItem barBtnCourseDelete;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
    }
}