namespace Chess
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
            this.MenuItemGame = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemBegin = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemGame});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemGame
            // 
            this.MenuItemGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemBegin,
            this.MenuItemUndo,
            this.toolStripMenuItem1,
            this.MenuItemSave,
            this.MenuItemOpen});
            this.MenuItemGame.Name = "MenuItemGame";
            this.MenuItemGame.Size = new System.Drawing.Size(44, 21);
            this.MenuItemGame.Text = "游戏";
            // 
            // MenuItemBegin
            // 
            this.MenuItemBegin.Name = "MenuItemBegin";
            this.MenuItemBegin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.MenuItemBegin.Size = new System.Drawing.Size(192, 22);
            this.MenuItemBegin.Text = "go go go";
            this.MenuItemBegin.Click += new System.EventHandler(this.MenuItemBegin_Click);
            // 
            // MenuItemUndo
            // 
            this.MenuItemUndo.Name = "MenuItemUndo";
            this.MenuItemUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.MenuItemUndo.Size = new System.Drawing.Size(192, 22);
            this.MenuItemUndo.Text = "我后悔啦啦啦";
            this.MenuItemUndo.ToolTipText = "悔棋";
            this.MenuItemUndo.Click += new System.EventHandler(this.MenuItemUndo_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(189, 6);
            // 
            // MenuItemSave
            // 
            this.MenuItemSave.Name = "MenuItemSave";
            this.MenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuItemSave.Size = new System.Drawing.Size(192, 22);
            this.MenuItemSave.Text = "保存残局";
            this.MenuItemSave.ToolTipText = "保存残局";
            this.MenuItemSave.Click += new System.EventHandler(this.MenuItemSave_Click);
            // 
            // MenuItemOpen
            // 
            this.MenuItemOpen.Name = "MenuItemOpen";
            this.MenuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuItemOpen.Size = new System.Drawing.Size(192, 22);
            this.MenuItemOpen.Text = "打开残局";
            this.MenuItemOpen.ToolTipText = "打开残局";
            this.MenuItemOpen.Click += new System.EventHandler(this.MenuItemOpen_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.chs";
            this.openFileDialog1.Filter = "所有文件|*.*|残局文件|*.chs";
            this.openFileDialog1.InitialDirectory = "c:\\";
            this.openFileDialog1.Title = "打开残局";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "*.chs";
            this.saveFileDialog1.Filter = "所有文件|*.*|残局文件|*.chs";
            this.saveFileDialog1.InitialDirectory = "c:\\";
            this.saveFileDialog1.Title = "保存残局";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 357);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "中国象棋";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGame;
        private System.Windows.Forms.ToolStripMenuItem MenuItemBegin;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

