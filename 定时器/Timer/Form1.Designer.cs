namespace MyTimer
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxSecond2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxSecond1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxColon2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxMinute2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxMinute1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxColon1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxHour2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxHour1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecond2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecond1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinute2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinute1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHour2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHour1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStart.ForeColor = System.Drawing.Color.Black;
            this.buttonStart.Location = new System.Drawing.Point(12, 75);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(58, 30);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "开始";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonPause
            // 
            this.buttonPause.Enabled = false;
            this.buttonPause.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonPause.ForeColor = System.Drawing.Color.Black;
            this.buttonPause.Location = new System.Drawing.Point(83, 75);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(58, 30);
            this.buttonPause.TabIndex = 6;
            this.buttonPause.Text = "暂停";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStop.ForeColor = System.Drawing.Color.Black;
            this.buttonStop.Location = new System.Drawing.Point(154, 75);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(58, 30);
            this.buttonStop.TabIndex = 7;
            this.buttonStop.Text = "停止";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pictureBoxSecond2
            // 
            this.pictureBoxSecond2.Location = new System.Drawing.Point(183, 10);
            this.pictureBoxSecond2.Name = "pictureBoxSecond2";
            this.pictureBoxSecond2.Size = new System.Drawing.Size(28, 47);
            this.pictureBoxSecond2.TabIndex = 23;
            this.pictureBoxSecond2.TabStop = false;
            // 
            // pictureBoxSecond1
            // 
            this.pictureBoxSecond1.Location = new System.Drawing.Point(158, 10);
            this.pictureBoxSecond1.Name = "pictureBoxSecond1";
            this.pictureBoxSecond1.Size = new System.Drawing.Size(28, 47);
            this.pictureBoxSecond1.TabIndex = 21;
            this.pictureBoxSecond1.TabStop = false;
            // 
            // pictureBoxColon2
            // 
            this.pictureBoxColon2.Location = new System.Drawing.Point(135, 10);
            this.pictureBoxColon2.Name = "pictureBoxColon2";
            this.pictureBoxColon2.Size = new System.Drawing.Size(28, 47);
            this.pictureBoxColon2.TabIndex = 22;
            this.pictureBoxColon2.TabStop = false;
            // 
            // pictureBoxMinute2
            // 
            this.pictureBoxMinute2.Location = new System.Drawing.Point(111, 10);
            this.pictureBoxMinute2.Name = "pictureBoxMinute2";
            this.pictureBoxMinute2.Size = new System.Drawing.Size(28, 47);
            this.pictureBoxMinute2.TabIndex = 20;
            this.pictureBoxMinute2.TabStop = false;
            // 
            // pictureBoxMinute1
            // 
            this.pictureBoxMinute1.Location = new System.Drawing.Point(86, 10);
            this.pictureBoxMinute1.Name = "pictureBoxMinute1";
            this.pictureBoxMinute1.Size = new System.Drawing.Size(28, 47);
            this.pictureBoxMinute1.TabIndex = 19;
            this.pictureBoxMinute1.TabStop = false;
            // 
            // pictureBoxColon1
            // 
            this.pictureBoxColon1.Location = new System.Drawing.Point(61, 10);
            this.pictureBoxColon1.Name = "pictureBoxColon1";
            this.pictureBoxColon1.Size = new System.Drawing.Size(28, 47);
            this.pictureBoxColon1.TabIndex = 18;
            this.pictureBoxColon1.TabStop = false;
            // 
            // pictureBoxHour2
            // 
            this.pictureBoxHour2.Location = new System.Drawing.Point(36, 10);
            this.pictureBoxHour2.Name = "pictureBoxHour2";
            this.pictureBoxHour2.Size = new System.Drawing.Size(28, 47);
            this.pictureBoxHour2.TabIndex = 17;
            this.pictureBoxHour2.TabStop = false;
            // 
            // pictureBoxHour1
            // 
            this.pictureBoxHour1.Location = new System.Drawing.Point(11, 10);
            this.pictureBoxHour1.Name = "pictureBoxHour1";
            this.pictureBoxHour1.Size = new System.Drawing.Size(28, 47);
            this.pictureBoxHour1.TabIndex = 16;
            this.pictureBoxHour1.TabStop = false;
            this.pictureBoxHour1.Click += new System.EventHandler(this.pictureBoxHour1_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.buttonStop;
            this.ClientSize = new System.Drawing.Size(226, 119);
            this.Controls.Add(this.pictureBoxSecond2);
            this.Controls.Add(this.pictureBoxSecond1);
            this.Controls.Add(this.pictureBoxColon2);
            this.Controls.Add(this.pictureBoxMinute2);
            this.Controls.Add(this.pictureBoxMinute1);
            this.Controls.Add(this.pictureBoxColon1);
            this.Controls.Add(this.pictureBoxHour2);
            this.Controls.Add(this.pictureBoxHour1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计时器";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecond2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecond1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinute2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinute1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHour2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHour1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBoxSecond2;
        private System.Windows.Forms.PictureBox pictureBoxSecond1;
        private System.Windows.Forms.PictureBox pictureBoxColon2;
        private System.Windows.Forms.PictureBox pictureBoxMinute2;
        private System.Windows.Forms.PictureBox pictureBoxMinute1;
        private System.Windows.Forms.PictureBox pictureBoxColon1;
        private System.Windows.Forms.PictureBox pictureBoxHour2;
        private System.Windows.Forms.PictureBox pictureBoxHour1;
    }
}

