namespace xdf.document.reader
{
    partial class FrmReader
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReader));
            toolStrip1 = new ToolStrip();
            tlsBtnOpen = new ToolStripButton();
            tlsBtnCopy = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            picInput = new PictureBox();
            txtResult = new TextBox();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picInput).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tlsBtnOpen, tlsBtnCopy });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(986, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // tlsBtnOpen
            // 
            tlsBtnOpen.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tlsBtnOpen.ForeColor = SystemColors.ControlText;
            tlsBtnOpen.Image = (Image)resources.GetObject("tlsBtnOpen.Image");
            tlsBtnOpen.ImageTransparentColor = Color.Magenta;
            tlsBtnOpen.Name = "tlsBtnOpen";
            tlsBtnOpen.Size = new Size(37, 22);
            tlsBtnOpen.Text = "打开";
            tlsBtnOpen.ToolTipText = "打开";
            tlsBtnOpen.Click += tlsBtnOpen_Click;
            // 
            // tlsBtnCopy
            // 
            tlsBtnCopy.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tlsBtnCopy.ForeColor = SystemColors.ControlText;
            tlsBtnCopy.Image = (Image)resources.GetObject("tlsBtnCopy.Image");
            tlsBtnCopy.ImageTransparentColor = Color.Magenta;
            tlsBtnCopy.Name = "tlsBtnCopy";
            tlsBtnCopy.Size = new Size(37, 22);
            tlsBtnCopy.Text = "复制";
            tlsBtnCopy.ToolTipText = "复制阅读结果";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 25);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(picInput);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtResult);
            splitContainer1.Size = new Size(986, 666);
            splitContainer1.SplitterDistance = 473;
            splitContainer1.TabIndex = 2;
            // 
            // picInput
            // 
            picInput.Dock = DockStyle.Fill;
            picInput.Location = new Point(0, 0);
            picInput.Name = "picInput";
            picInput.Size = new Size(473, 666);
            picInput.SizeMode = PictureBoxSizeMode.StretchImage;
            picInput.TabIndex = 0;
            picInput.TabStop = false;
            // 
            // txtResult
            // 
            txtResult.Dock = DockStyle.Fill;
            txtResult.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtResult.Location = new Point(0, 0);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(509, 666);
            txtResult.TabIndex = 1;
            // 
            // FrmReader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 691);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Name = "FrmReader";
            Text = "智能档案阅读器 - Xiang's";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tlsBtnOpen;
        private ToolStripButton tlsBtnCopy;
        private SplitContainer splitContainer1;
        private PictureBox picInput;
        private TextBox txtResult;
    }
}
