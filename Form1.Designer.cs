namespace 퀵드로우
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolExist = new System.Windows.Forms.ToolStripButton();
            this.toolNext = new System.Windows.Forms.ToolStripButton();
            this.toolClear = new System.Windows.Forms.ToolStripButton();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(57)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolExist,
            this.toolNext,
            this.toolClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(982, 47);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolExist
            // 
            this.toolExist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolExist.Image = ((System.Drawing.Image)(resources.GetObject("toolExist.Image")));
            this.toolExist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExist.Name = "toolExist";
            this.toolExist.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.toolExist.Size = new System.Drawing.Size(44, 24);
            this.toolExist.Text = "toolStripButton1";
            this.toolExist.Click += new System.EventHandler(this.toolExist_Click);
            // 
            // toolNext
            // 
            this.toolNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNext.Image = ((System.Drawing.Image)(resources.GetObject("toolNext.Image")));
            this.toolNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNext.Name = "toolNext";
            this.toolNext.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.toolNext.Size = new System.Drawing.Size(44, 24);
            this.toolNext.Text = "toolStripButton2";
            this.toolNext.Click += new System.EventHandler(this.toolNext_Click);
            // 
            // toolClear
            // 
            this.toolClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolClear.Image = ((System.Drawing.Image)(resources.GetObject("toolClear.Image")));
            this.toolClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClear.Name = "toolClear";
            this.toolClear.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.toolClear.Size = new System.Drawing.Size(44, 24);
            this.toolClear.Text = "toolStripButton3";
            this.toolClear.Click += new System.EventHandler(this.toolClear_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTimer.Location = new System.Drawing.Point(454, 13);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(74, 28);
            this.lblTimer.TabIndex = 2;
            this.lblTimer.Text = "00 : 20";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(57)))));
            this.lblText.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(125)))), ((int)(((byte)(34)))));
            this.lblText.Location = new System.Drawing.Point(12, 13);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(79, 28);
            this.lblText.TabIndex = 3;
            this.lblText.Text = " 그리기";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Quick, Draw!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolExist;
        private System.Windows.Forms.ToolStripButton toolNext;
        private System.Windows.Forms.ToolStripButton toolClear;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblText;
    }
}

