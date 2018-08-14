namespace Pencil
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveAsPic = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDrawing = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLine = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCircle = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSketch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemWidth = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemColor = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOther = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemScreenPen = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRectangle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCircle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSketch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButtonWidth = new System.Windows.Forms.ToolStripSplitButton();
            this.ToolStripMenuItem1px = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2px = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem4px = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem8px = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButtonColor = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItemRed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemYellow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBlack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabelMousePosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelDraw = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile,
            this.MenuItemDrawing,
            this.MenuItemSetting,
            this.MenuItemView,
            this.MenuItemOther});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(748, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemNew,
            this.MenuItemOpen,
            this.MenuItemSave,
            this.MenuItemSaveAs,
            this.MenuItemSaveAsPic,
            this.toolStripMenuItem3,
            this.MenuItemClose});
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(44, 21);
            this.MenuItemFile.Text = "文件";
            // 
            // MenuItemNew
            // 
            this.MenuItemNew.Image = global::Pencil.Properties.Resources.file_new;
            this.MenuItemNew.Name = "MenuItemNew";
            this.MenuItemNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.MenuItemNew.Size = new System.Drawing.Size(149, 22);
            this.MenuItemNew.Text = "新建";
            this.MenuItemNew.ToolTipText = "新建一个文件";
            this.MenuItemNew.Click += new System.EventHandler(this.MenuItemNew_Click);
            // 
            // MenuItemOpen
            // 
            this.MenuItemOpen.Image = global::Pencil.Properties.Resources.file_open;
            this.MenuItemOpen.Name = "MenuItemOpen";
            this.MenuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuItemOpen.Size = new System.Drawing.Size(149, 22);
            this.MenuItemOpen.Text = "打开";
            this.MenuItemOpen.ToolTipText = "打开现有文件";
            this.MenuItemOpen.Click += new System.EventHandler(this.MenuItemOpen_Click);
            // 
            // MenuItemSave
            // 
            this.MenuItemSave.Image = global::Pencil.Properties.Resources.file_save;
            this.MenuItemSave.Name = "MenuItemSave";
            this.MenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.MenuItemSave.Size = new System.Drawing.Size(149, 22);
            this.MenuItemSave.Text = "保存";
            this.MenuItemSave.ToolTipText = "保存到当前文件";
            this.MenuItemSave.Click += new System.EventHandler(this.MenuItemSave_Click);
            // 
            // MenuItemSaveAs
            // 
            this.MenuItemSaveAs.Name = "MenuItemSaveAs";
            this.MenuItemSaveAs.Size = new System.Drawing.Size(149, 22);
            this.MenuItemSaveAs.Text = "另存为";
            this.MenuItemSaveAs.ToolTipText = "另存为一个新文件";
            this.MenuItemSaveAs.Click += new System.EventHandler(this.MenuItemSaveAs_Click);
            // 
            // MenuItemSaveAsPic
            // 
            this.MenuItemSaveAsPic.Name = "MenuItemSaveAsPic";
            this.MenuItemSaveAsPic.Size = new System.Drawing.Size(149, 22);
            this.MenuItemSaveAsPic.Text = "另存为图片";
            this.MenuItemSaveAsPic.ToolTipText = "另存为一个图片文件";
            this.MenuItemSaveAsPic.Click += new System.EventHandler(this.MenuItemSaveAsPic_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(146, 6);
            // 
            // MenuItemClose
            // 
            this.MenuItemClose.Name = "MenuItemClose";
            this.MenuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MenuItemClose.Size = new System.Drawing.Size(149, 22);
            this.MenuItemClose.Text = "关闭";
            this.MenuItemClose.ToolTipText = "关闭当前程序";
            this.MenuItemClose.Click += new System.EventHandler(this.MenuItemClose_Click);
            // 
            // MenuItemDrawing
            // 
            this.MenuItemDrawing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemLine,
            this.MenuItemRectangle,
            this.MenuItemCircle,
            this.MenuItemSketch,
            this.toolStripMenuItem1,
            this.MenuItemStop,
            this.toolStripMenuItem2,
            this.MenuItemUndo,
            this.MenuItemRedo});
            this.MenuItemDrawing.Name = "MenuItemDrawing";
            this.MenuItemDrawing.Size = new System.Drawing.Size(44, 21);
            this.MenuItemDrawing.Text = "绘图";
            // 
            // MenuItemLine
            // 
            this.MenuItemLine.Image = global::Pencil.Properties.Resources.line;
            this.MenuItemLine.Name = "MenuItemLine";
            this.MenuItemLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.MenuItemLine.Size = new System.Drawing.Size(157, 22);
            this.MenuItemLine.Text = "直线";
            this.MenuItemLine.ToolTipText = "绘制直线";
            this.MenuItemLine.Click += new System.EventHandler(this.MenuItemLine_Click);
            // 
            // MenuItemRectangle
            // 
            this.MenuItemRectangle.Image = global::Pencil.Properties.Resources.rectangle;
            this.MenuItemRectangle.Name = "MenuItemRectangle";
            this.MenuItemRectangle.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.MenuItemRectangle.Size = new System.Drawing.Size(157, 22);
            this.MenuItemRectangle.Text = "矩形";
            this.MenuItemRectangle.ToolTipText = "绘制矩形";
            this.MenuItemRectangle.Click += new System.EventHandler(this.MenuItemRectangle_Click);
            // 
            // MenuItemCircle
            // 
            this.MenuItemCircle.Image = global::Pencil.Properties.Resources.circle;
            this.MenuItemCircle.Name = "MenuItemCircle";
            this.MenuItemCircle.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.MenuItemCircle.Size = new System.Drawing.Size(157, 22);
            this.MenuItemCircle.Text = "圆";
            this.MenuItemCircle.ToolTipText = "绘制圆";
            this.MenuItemCircle.Click += new System.EventHandler(this.MenuItemCircle_Click);
            // 
            // MenuItemSketch
            // 
            this.MenuItemSketch.Image = global::Pencil.Properties.Resources.sketch;
            this.MenuItemSketch.Name = "MenuItemSketch";
            this.MenuItemSketch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.MenuItemSketch.Size = new System.Drawing.Size(157, 22);
            this.MenuItemSketch.Text = "徒手画";
            this.MenuItemSketch.ToolTipText = "徒手画";
            this.MenuItemSketch.Click += new System.EventHandler(this.MenuItemSketch_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 6);
            // 
            // MenuItemStop
            // 
            this.MenuItemStop.Image = global::Pencil.Properties.Resources.stop;
            this.MenuItemStop.Name = "MenuItemStop";
            this.MenuItemStop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuItemStop.Size = new System.Drawing.Size(157, 22);
            this.MenuItemStop.Text = "停止";
            this.MenuItemStop.ToolTipText = "停止绘图";
            this.MenuItemStop.Click += new System.EventHandler(this.MenuItemStop_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(154, 6);
            // 
            // MenuItemUndo
            // 
            this.MenuItemUndo.Image = global::Pencil.Properties.Resources.undo;
            this.MenuItemUndo.Name = "MenuItemUndo";
            this.MenuItemUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.MenuItemUndo.Size = new System.Drawing.Size(157, 22);
            this.MenuItemUndo.Text = "撤销";
            this.MenuItemUndo.ToolTipText = "撤销图元";
            this.MenuItemUndo.Click += new System.EventHandler(this.MenuItemUndo_Click);
            // 
            // MenuItemRedo
            // 
            this.MenuItemRedo.Image = global::Pencil.Properties.Resources.redo;
            this.MenuItemRedo.Name = "MenuItemRedo";
            this.MenuItemRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.MenuItemRedo.Size = new System.Drawing.Size(157, 22);
            this.MenuItemRedo.Text = "重做";
            this.MenuItemRedo.ToolTipText = "重做图元";
            this.MenuItemRedo.Click += new System.EventHandler(this.MenuItemRedo_Click);
            // 
            // MenuItemSetting
            // 
            this.MenuItemSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemWidth,
            this.MenuItemColor});
            this.MenuItemSetting.Name = "MenuItemSetting";
            this.MenuItemSetting.Size = new System.Drawing.Size(44, 21);
            this.MenuItemSetting.Text = "设置";
            // 
            // MenuItemWidth
            // 
            this.MenuItemWidth.Image = global::Pencil.Properties.Resources.width;
            this.MenuItemWidth.Name = "MenuItemWidth";
            this.MenuItemWidth.Size = new System.Drawing.Size(100, 22);
            this.MenuItemWidth.Text = "线宽";
            this.MenuItemWidth.ToolTipText = "设置画笔线宽";
            this.MenuItemWidth.Click += new System.EventHandler(this.MenuItemWidth_Click);
            // 
            // MenuItemColor
            // 
            this.MenuItemColor.Image = global::Pencil.Properties.Resources.color;
            this.MenuItemColor.Name = "MenuItemColor";
            this.MenuItemColor.Size = new System.Drawing.Size(100, 22);
            this.MenuItemColor.Text = "颜色";
            this.MenuItemColor.ToolTipText = "设置画笔颜色";
            this.MenuItemColor.Click += new System.EventHandler(this.MenuItemColor_Click);
            // 
            // MenuItemView
            // 
            this.MenuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemZoomIn,
            this.MenuItemZoomOut});
            this.MenuItemView.Name = "MenuItemView";
            this.MenuItemView.Size = new System.Drawing.Size(44, 21);
            this.MenuItemView.Text = "查看";
            // 
            // MenuItemZoomIn
            // 
            this.MenuItemZoomIn.Image = global::Pencil.Properties.Resources.ZoomIn;
            this.MenuItemZoomIn.Name = "MenuItemZoomIn";
            this.MenuItemZoomIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.MenuItemZoomIn.Size = new System.Drawing.Size(147, 22);
            this.MenuItemZoomIn.Text = "放大";
            this.MenuItemZoomIn.Click += new System.EventHandler(this.MenuItemZoomIn_Click);
            // 
            // MenuItemZoomOut
            // 
            this.MenuItemZoomOut.Image = global::Pencil.Properties.Resources.ZoomOut;
            this.MenuItemZoomOut.Name = "MenuItemZoomOut";
            this.MenuItemZoomOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuItemZoomOut.Size = new System.Drawing.Size(147, 22);
            this.MenuItemZoomOut.Text = "缩小";
            this.MenuItemZoomOut.Click += new System.EventHandler(this.MenuItemZoomOut_Click);
            // 
            // MenuItemOther
            // 
            this.MenuItemOther.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemScreenPen});
            this.MenuItemOther.Name = "MenuItemOther";
            this.MenuItemOther.Size = new System.Drawing.Size(44, 21);
            this.MenuItemOther.Text = "其它";
            // 
            // MenuItemScreenPen
            // 
            this.MenuItemScreenPen.Image = global::Pencil.Properties.Resources.screen_pen;
            this.MenuItemScreenPen.Name = "MenuItemScreenPen";
            this.MenuItemScreenPen.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.MenuItemScreenPen.Size = new System.Drawing.Size(145, 22);
            this.MenuItemScreenPen.Text = "屏幕画笔";
            this.MenuItemScreenPen.Click += new System.EventHandler(this.MenuItemScreenPen_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLine,
            this.toolStripButtonRectangle,
            this.toolStripButtonCircle,
            this.toolStripButtonSketch,
            this.toolStripSeparator1,
            this.toolStripButtonStop,
            this.toolStripSeparator2,
            this.toolStripButtonUndo,
            this.toolStripButtonRedo,
            this.toolStripSplitButtonWidth,
            this.toolStripSplitButtonColor,
            this.toolStripSeparator3,
            this.toolStripButtonZoomIn,
            this.toolStripButtonZoomOut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(748, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonLine
            // 
            this.toolStripButtonLine.Image = global::Pencil.Properties.Resources.line;
            this.toolStripButtonLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLine.Name = "toolStripButtonLine";
            this.toolStripButtonLine.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonLine.Text = "直线";
            this.toolStripButtonLine.ToolTipText = "绘制直线";
            this.toolStripButtonLine.Click += new System.EventHandler(this.MenuItemLine_Click);
            // 
            // toolStripButtonRectangle
            // 
            this.toolStripButtonRectangle.Image = global::Pencil.Properties.Resources.rectangle;
            this.toolStripButtonRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRectangle.Name = "toolStripButtonRectangle";
            this.toolStripButtonRectangle.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonRectangle.Text = "矩形";
            this.toolStripButtonRectangle.ToolTipText = "绘制矩形";
            this.toolStripButtonRectangle.Click += new System.EventHandler(this.MenuItemRectangle_Click);
            // 
            // toolStripButtonCircle
            // 
            this.toolStripButtonCircle.Image = global::Pencil.Properties.Resources.circle;
            this.toolStripButtonCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCircle.Name = "toolStripButtonCircle";
            this.toolStripButtonCircle.Size = new System.Drawing.Size(40, 22);
            this.toolStripButtonCircle.Text = "圆";
            this.toolStripButtonCircle.ToolTipText = "绘制圆";
            this.toolStripButtonCircle.Click += new System.EventHandler(this.MenuItemCircle_Click);
            // 
            // toolStripButtonSketch
            // 
            this.toolStripButtonSketch.Image = global::Pencil.Properties.Resources.sketch;
            this.toolStripButtonSketch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSketch.Name = "toolStripButtonSketch";
            this.toolStripButtonSketch.Size = new System.Drawing.Size(64, 22);
            this.toolStripButtonSketch.Text = "徒手画";
            this.toolStripButtonSketch.ToolTipText = "徒手画";
            this.toolStripButtonSketch.Click += new System.EventHandler(this.MenuItemSketch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.Image = global::Pencil.Properties.Resources.stop;
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonStop.Text = "停止";
            this.toolStripButtonStop.ToolTipText = "停止绘制";
            this.toolStripButtonStop.Click += new System.EventHandler(this.MenuItemStop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonUndo
            // 
            this.toolStripButtonUndo.Image = global::Pencil.Properties.Resources.undo;
            this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndo.Name = "toolStripButtonUndo";
            this.toolStripButtonUndo.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonUndo.Text = "撤销";
            this.toolStripButtonUndo.ToolTipText = "撤销图元";
            this.toolStripButtonUndo.Click += new System.EventHandler(this.MenuItemUndo_Click);
            // 
            // toolStripButtonRedo
            // 
            this.toolStripButtonRedo.Image = global::Pencil.Properties.Resources.redo;
            this.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRedo.Name = "toolStripButtonRedo";
            this.toolStripButtonRedo.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonRedo.Text = "重做";
            this.toolStripButtonRedo.ToolTipText = "重做图元";
            this.toolStripButtonRedo.Click += new System.EventHandler(this.MenuItemRedo_Click);
            // 
            // toolStripSplitButtonWidth
            // 
            this.toolStripSplitButtonWidth.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1px,
            this.ToolStripMenuItem2px,
            this.ToolStripMenuItem4px,
            this.ToolStripMenuItem8px});
            this.toolStripSplitButtonWidth.Image = global::Pencil.Properties.Resources.width;
            this.toolStripSplitButtonWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonWidth.Name = "toolStripSplitButtonWidth";
            this.toolStripSplitButtonWidth.Size = new System.Drawing.Size(64, 22);
            this.toolStripSplitButtonWidth.Text = "线宽";
            this.toolStripSplitButtonWidth.ToolTipText = "设置画笔线宽";
            this.toolStripSplitButtonWidth.ButtonClick += new System.EventHandler(this.MenuItemWidth_Click);
            // 
            // ToolStripMenuItem1px
            // 
            this.ToolStripMenuItem1px.Image = global::Pencil.Properties.Resources.width1;
            this.ToolStripMenuItem1px.Name = "ToolStripMenuItem1px";
            this.ToolStripMenuItem1px.Size = new System.Drawing.Size(97, 22);
            this.ToolStripMenuItem1px.Text = "1px";
            this.ToolStripMenuItem1px.ToolTipText = "设置线宽为1px";
            this.ToolStripMenuItem1px.Click += new System.EventHandler(this.ToolStripMenuItem1px_Click);
            // 
            // ToolStripMenuItem2px
            // 
            this.ToolStripMenuItem2px.Image = global::Pencil.Properties.Resources.width2;
            this.ToolStripMenuItem2px.Name = "ToolStripMenuItem2px";
            this.ToolStripMenuItem2px.Size = new System.Drawing.Size(97, 22);
            this.ToolStripMenuItem2px.Text = "2px";
            this.ToolStripMenuItem2px.ToolTipText = "设置线宽为2px";
            this.ToolStripMenuItem2px.Click += new System.EventHandler(this.ToolStripMenuItem2px_Click);
            // 
            // ToolStripMenuItem4px
            // 
            this.ToolStripMenuItem4px.Image = global::Pencil.Properties.Resources.width4;
            this.ToolStripMenuItem4px.Name = "ToolStripMenuItem4px";
            this.ToolStripMenuItem4px.Size = new System.Drawing.Size(97, 22);
            this.ToolStripMenuItem4px.Text = "4px";
            this.ToolStripMenuItem4px.ToolTipText = "设置线宽为4px";
            this.ToolStripMenuItem4px.Click += new System.EventHandler(this.ToolStripMenuItem4px_Click);
            // 
            // ToolStripMenuItem8px
            // 
            this.ToolStripMenuItem8px.Image = global::Pencil.Properties.Resources.width8;
            this.ToolStripMenuItem8px.Name = "ToolStripMenuItem8px";
            this.ToolStripMenuItem8px.Size = new System.Drawing.Size(97, 22);
            this.ToolStripMenuItem8px.Text = "8px";
            this.ToolStripMenuItem8px.ToolTipText = "设置线宽为8px";
            this.ToolStripMenuItem8px.Click += new System.EventHandler(this.ToolStripMenuItem8px_Click);
            // 
            // toolStripSplitButtonColor
            // 
            this.toolStripSplitButtonColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemRed,
            this.toolStripMenuItemGreen,
            this.toolStripMenuItemBlue,
            this.toolStripMenuItemYellow,
            this.toolStripMenuItemBlack});
            this.toolStripSplitButtonColor.Image = global::Pencil.Properties.Resources.color;
            this.toolStripSplitButtonColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonColor.Name = "toolStripSplitButtonColor";
            this.toolStripSplitButtonColor.Size = new System.Drawing.Size(64, 22);
            this.toolStripSplitButtonColor.Text = "颜色";
            this.toolStripSplitButtonColor.ToolTipText = "设置画笔颜色";
            this.toolStripSplitButtonColor.ButtonClick += new System.EventHandler(this.MenuItemColor_Click);
            // 
            // toolStripMenuItemRed
            // 
            this.toolStripMenuItemRed.Image = global::Pencil.Properties.Resources.color_red;
            this.toolStripMenuItemRed.Name = "toolStripMenuItemRed";
            this.toolStripMenuItemRed.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItemRed.Text = "红色";
            this.toolStripMenuItemRed.ToolTipText = "设置颜色为红色";
            this.toolStripMenuItemRed.Click += new System.EventHandler(this.toolStripMenuItemRed_Click);
            // 
            // toolStripMenuItemGreen
            // 
            this.toolStripMenuItemGreen.Image = global::Pencil.Properties.Resources.color_green;
            this.toolStripMenuItemGreen.Name = "toolStripMenuItemGreen";
            this.toolStripMenuItemGreen.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItemGreen.Text = "绿色";
            this.toolStripMenuItemGreen.ToolTipText = "设置颜色为绿色";
            this.toolStripMenuItemGreen.Click += new System.EventHandler(this.toolStripMenuItemGreen_Click);
            // 
            // toolStripMenuItemBlue
            // 
            this.toolStripMenuItemBlue.Image = global::Pencil.Properties.Resources.color_blue;
            this.toolStripMenuItemBlue.Name = "toolStripMenuItemBlue";
            this.toolStripMenuItemBlue.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItemBlue.Text = "蓝色";
            this.toolStripMenuItemBlue.ToolTipText = "设置颜色为蓝色";
            this.toolStripMenuItemBlue.Click += new System.EventHandler(this.toolStripMenuItemBlue_Click);
            // 
            // toolStripMenuItemYellow
            // 
            this.toolStripMenuItemYellow.Image = global::Pencil.Properties.Resources.color_yellow;
            this.toolStripMenuItemYellow.Name = "toolStripMenuItemYellow";
            this.toolStripMenuItemYellow.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItemYellow.Text = "黄色";
            this.toolStripMenuItemYellow.ToolTipText = "设置颜色为黄色";
            this.toolStripMenuItemYellow.Click += new System.EventHandler(this.toolStripMenuItemYellow_Click);
            // 
            // toolStripMenuItemBlack
            // 
            this.toolStripMenuItemBlack.Image = global::Pencil.Properties.Resources.color_black;
            this.toolStripMenuItemBlack.Name = "toolStripMenuItemBlack";
            this.toolStripMenuItemBlack.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItemBlack.Text = "黑色";
            this.toolStripMenuItemBlack.ToolTipText = "设置颜色为黑色";
            this.toolStripMenuItemBlack.Click += new System.EventHandler(this.toolStripMenuItemBlack_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonZoomIn
            // 
            this.toolStripButtonZoomIn.Image = global::Pencil.Properties.Resources.ZoomIn;
            this.toolStripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomIn.Name = "toolStripButtonZoomIn";
            this.toolStripButtonZoomIn.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonZoomIn.Text = "放大";
            this.toolStripButtonZoomIn.Click += new System.EventHandler(this.MenuItemZoomIn_Click);
            // 
            // toolStripButtonZoomOut
            // 
            this.toolStripButtonZoomOut.Image = global::Pencil.Properties.Resources.ZoomOut;
            this.toolStripButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomOut.Name = "toolStripButtonZoomOut";
            this.toolStripButtonZoomOut.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonZoomOut.Text = "缩小";
            this.toolStripButtonZoomOut.Click += new System.EventHandler(this.MenuItemZoomOut_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabelMousePosition,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 482);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(748, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // StatusLabelMousePosition
            // 
            this.StatusLabelMousePosition.BackColor = System.Drawing.SystemColors.Control;
            this.StatusLabelMousePosition.Name = "StatusLabelMousePosition";
            this.StatusLabelMousePosition.Size = new System.Drawing.Size(93, 17);
            this.StatusLabelMousePosition.Text = "鼠标：x=  , y= ";
            this.StatusLabelMousePosition.Click += new System.EventHandler(this.StatusLabelMousePosition_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "*.dwg";
            this.saveFileDialog1.Filter = "所有文件|*.*|图形文件(*.dwg)|*.dwg";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.InitialDirectory = "c:\\";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.dwg";
            this.openFileDialog1.Filter = "所有文件|*.*|图形文件(*.dwg)|*.dwg";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.InitialDirectory = "c:\\";
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.FileName = "*.gif";
            this.saveFileDialog2.Filter = "所有文件|*.*|GIF文件|*.gif|JPG文件|*.jpg";
            this.saveFileDialog2.FilterIndex = 2;
            this.saveFileDialog2.InitialDirectory = "c:\\";
            this.saveFileDialog2.Title = "保存为图片";
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BackColor = System.Drawing.Color.Silver;
            this.panelContainer.Controls.Add(this.panelDraw);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 50);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(748, 432);
            this.panelContainer.TabIndex = 3;
            // 
            // panelDraw
            // 
            this.panelDraw.BackColor = System.Drawing.Color.White;
            this.panelDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDraw.Location = new System.Drawing.Point(0, 0);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(660, 410);
            this.panelDraw.TabIndex = 0;
            this.panelDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDraw_Paint);
            this.panelDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelDraw_MouseMove);
            this.panelDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDraw_MouseDown);
            this.panelDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelDraw_MouseUp);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(748, 504);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "画笔";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDrawing;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLine;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRectangle;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCircle;
        private System.Windows.Forms.ToolStripMenuItem MenuItemStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSetting;
        private System.Windows.Forms.ToolStripMenuItem MenuItemWidth;
        private System.Windows.Forms.ToolStripMenuItem MenuItemColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUndo;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRedo;
        public System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonUndo;
        private System.Windows.Forms.ToolStripButton toolStripButtonLine;
        private System.Windows.Forms.ToolStripButton toolStripButtonRectangle;
        private System.Windows.Forms.ToolStripButton toolStripButtonCircle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonRedo;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonWidth;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1px;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2px;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem4px;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem8px;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonColor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRed;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGreen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBlue;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBlack;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemYellow;
        public System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelMousePosition;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNew;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveAsPic;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem MenuItemClose;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSketch;
        private System.Windows.Forms.ToolStripButton toolStripButtonSketch;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelDraw;
        private System.Windows.Forms.ToolStripMenuItem MenuItemView;
        private System.Windows.Forms.ToolStripMenuItem MenuItemZoomIn;
        private System.Windows.Forms.ToolStripMenuItem MenuItemZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomOut;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOther;
        private System.Windows.Forms.ToolStripMenuItem MenuItemScreenPen;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

