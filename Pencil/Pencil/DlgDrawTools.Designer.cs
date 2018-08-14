namespace Pencil
{
    partial class DlgDrawTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgDrawTools));
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonLine = new System.Windows.Forms.Button();
            this.buttonRectangle = new System.Windows.Forms.Button();
            this.buttonCircle = new System.Windows.Forms.Button();
            this.buttonSketch = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonWidth = new System.Windows.Forms.Button();
            this.buttonColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Image = global::Pencil.Properties.Resources.exit;
            this.buttonExit.Location = new System.Drawing.Point(204, 46);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(58, 29);
            this.buttonExit.TabIndex = 22;
            this.buttonExit.Text = "退出";
            this.buttonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonLine
            // 
            this.buttonLine.Image = global::Pencil.Properties.Resources.line;
            this.buttonLine.Location = new System.Drawing.Point(12, 11);
            this.buttonLine.Name = "buttonLine";
            this.buttonLine.Size = new System.Drawing.Size(58, 29);
            this.buttonLine.TabIndex = 15;
            this.buttonLine.Text = "直线";
            this.buttonLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLine.UseVisualStyleBackColor = true;
            this.buttonLine.Click += new System.EventHandler(this.buttonLine_Click);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.Image = global::Pencil.Properties.Resources.rectangle;
            this.buttonRectangle.Location = new System.Drawing.Point(76, 11);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(58, 29);
            this.buttonRectangle.TabIndex = 16;
            this.buttonRectangle.Text = "矩形";
            this.buttonRectangle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRectangle.UseVisualStyleBackColor = true;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangle_Click);
            // 
            // buttonCircle
            // 
            this.buttonCircle.Image = global::Pencil.Properties.Resources.circle;
            this.buttonCircle.Location = new System.Drawing.Point(140, 11);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(58, 29);
            this.buttonCircle.TabIndex = 17;
            this.buttonCircle.Text = "圆";
            this.buttonCircle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // buttonSketch
            // 
            this.buttonSketch.Image = global::Pencil.Properties.Resources.sketch;
            this.buttonSketch.Location = new System.Drawing.Point(204, 11);
            this.buttonSketch.Name = "buttonSketch";
            this.buttonSketch.Size = new System.Drawing.Size(58, 29);
            this.buttonSketch.TabIndex = 18;
            this.buttonSketch.Text = "徒手";
            this.buttonSketch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSketch.UseVisualStyleBackColor = true;
            this.buttonSketch.Click += new System.EventHandler(this.buttonSketch_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Image = global::Pencil.Properties.Resources.undo;
            this.buttonUndo.Location = new System.Drawing.Point(140, 46);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(58, 29);
            this.buttonUndo.TabIndex = 19;
            this.buttonUndo.Text = "撤销";
            this.buttonUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // buttonWidth
            // 
            this.buttonWidth.Image = global::Pencil.Properties.Resources.width;
            this.buttonWidth.Location = new System.Drawing.Point(12, 46);
            this.buttonWidth.Name = "buttonWidth";
            this.buttonWidth.Size = new System.Drawing.Size(58, 29);
            this.buttonWidth.TabIndex = 20;
            this.buttonWidth.Text = "线宽";
            this.buttonWidth.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonWidth.UseVisualStyleBackColor = true;
            this.buttonWidth.Click += new System.EventHandler(this.buttonWidth_Click);
            // 
            // buttonColor
            // 
            this.buttonColor.Image = global::Pencil.Properties.Resources.color;
            this.buttonColor.Location = new System.Drawing.Point(76, 46);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(58, 29);
            this.buttonColor.TabIndex = 21;
            this.buttonColor.Text = "颜色";
            this.buttonColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // DlgDrawTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 87);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonLine);
            this.Controls.Add(this.buttonRectangle);
            this.Controls.Add(this.buttonCircle);
            this.Controls.Add(this.buttonSketch);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.buttonWidth);
            this.Controls.Add(this.buttonColor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgDrawTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "绘图工具箱";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DlgDrawTools_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DlgDrawTools_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonLine;
        private System.Windows.Forms.Button buttonRectangle;
        private System.Windows.Forms.Button buttonCircle;
        private System.Windows.Forms.Button buttonSketch;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonWidth;
        private System.Windows.Forms.Button buttonColor;
    }
}