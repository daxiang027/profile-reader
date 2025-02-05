namespace xdf.document.reader
{
    partial class FrmMutiPageReader
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMutiPageReader));
            toolStrip1 = new ToolStrip();
            tlsBtnReset = new ToolStripButton();
            tlsBtnAdd = new ToolStripButton();
            tlsBtnRead = new ToolStripButton();
            lsvPages = new ListView();
            imgsMain = new ImageList(components);
            splitContainer1 = new SplitContainer();
            picMain = new PictureBox();
            ctmPage = new ContextMenuStrip(components);
            tlsMnuCopyPageText = new ToolStripMenuItem();
            splitContainer2 = new SplitContainer();
            txtResult = new TextBox();
            toolStrip2 = new ToolStrip();
            tlsbtnCopyResult = new ToolStripButton();
            txtLogs = new TextBox();
            toolStrip3 = new ToolStrip();
            tlsBtnClear = new ToolStripButton();
            btnAboutme = new ToolStripButton();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMain).BeginInit();
            ctmPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            toolStrip2.SuspendLayout();
            toolStrip3.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tlsBtnReset, tlsBtnAdd, tlsBtnRead, btnAboutme });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1492, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // tlsBtnReset
            // 
            tlsBtnReset.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tlsBtnReset.Image = (Image)resources.GetObject("tlsBtnReset.Image");
            tlsBtnReset.ImageTransparentColor = Color.Magenta;
            tlsBtnReset.Name = "tlsBtnReset";
            tlsBtnReset.Size = new Size(54, 22);
            tlsBtnReset.Text = "重置(&Q)";
            tlsBtnReset.Click += tlsBtnReset_Click;
            // 
            // tlsBtnAdd
            // 
            tlsBtnAdd.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tlsBtnAdd.ForeColor = SystemColors.ControlText;
            tlsBtnAdd.Image = (Image)resources.GetObject("tlsBtnAdd.Image");
            tlsBtnAdd.ImageTransparentColor = Color.Magenta;
            tlsBtnAdd.Name = "tlsBtnAdd";
            tlsBtnAdd.Size = new Size(52, 22);
            tlsBtnAdd.Text = "添加(&A)";
            tlsBtnAdd.ToolTipText = "添加文档页图片";
            tlsBtnAdd.Click += tlsBtnAdd_Click;
            // 
            // tlsBtnRead
            // 
            tlsBtnRead.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tlsBtnRead.Image = (Image)resources.GetObject("tlsBtnRead.Image");
            tlsBtnRead.ImageTransparentColor = Color.Magenta;
            tlsBtnRead.Name = "tlsBtnRead";
            tlsBtnRead.Size = new Size(52, 22);
            tlsBtnRead.Text = "分析(&X)";
            tlsBtnRead.Click += tlsBtnRead_Click;
            // 
            // lsvPages
            // 
            lsvPages.Dock = DockStyle.Top;
            lsvPages.LargeImageList = imgsMain;
            lsvPages.Location = new Point(0, 25);
            lsvPages.MultiSelect = false;
            lsvPages.Name = "lsvPages";
            lsvPages.Size = new Size(1492, 224);
            lsvPages.TabIndex = 3;
            lsvPages.UseCompatibleStateImageBehavior = false;
            // 
            // imgsMain
            // 
            imgsMain.ColorDepth = ColorDepth.Depth32Bit;
            imgsMain.ImageSize = new Size(128, 128);
            imgsMain.TransparentColor = Color.Transparent;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 249);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(picMain);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1492, 698);
            splitContainer1.SplitterDistance = 706;
            splitContainer1.TabIndex = 4;
            // 
            // picMain
            // 
            picMain.ContextMenuStrip = ctmPage;
            picMain.Dock = DockStyle.Fill;
            picMain.Location = new Point(0, 0);
            picMain.Name = "picMain";
            picMain.Size = new Size(706, 698);
            picMain.SizeMode = PictureBoxSizeMode.Zoom;
            picMain.TabIndex = 0;
            picMain.TabStop = false;
            // 
            // ctmPage
            // 
            ctmPage.ImageScalingSize = new Size(24, 24);
            ctmPage.Items.AddRange(new ToolStripItem[] { tlsMnuCopyPageText });
            ctmPage.Name = "contextMenuStrip1";
            ctmPage.Size = new Size(173, 26);
            ctmPage.Opening += ctmPage_Opening;
            // 
            // tlsMnuCopyPageText
            // 
            tlsMnuCopyPageText.Name = "tlsMnuCopyPageText";
            tlsMnuCopyPageText.Size = new Size(172, 22);
            tlsMnuCopyPageText.Text = "复制文字到剪切板";
            tlsMnuCopyPageText.Click += tlsMnuCopyPageText_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(txtResult);
            splitContainer2.Panel1.Controls.Add(toolStrip2);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(txtLogs);
            splitContainer2.Panel2.Controls.Add(toolStrip3);
            splitContainer2.Size = new Size(782, 698);
            splitContainer2.SplitterDistance = 265;
            splitContainer2.TabIndex = 0;
            // 
            // txtResult
            // 
            txtResult.Dock = DockStyle.Fill;
            txtResult.Location = new Point(0, 25);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Both;
            txtResult.Size = new Size(782, 240);
            txtResult.TabIndex = 1;
            // 
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(24, 24);
            toolStrip2.Items.AddRange(new ToolStripItem[] { tlsbtnCopyResult });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(782, 25);
            toolStrip2.TabIndex = 0;
            toolStrip2.Text = "toolStrip2";
            // 
            // tlsbtnCopyResult
            // 
            tlsbtnCopyResult.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tlsbtnCopyResult.Image = (Image)resources.GetObject("tlsbtnCopyResult.Image");
            tlsbtnCopyResult.ImageTransparentColor = Color.Magenta;
            tlsbtnCopyResult.Name = "tlsbtnCopyResult";
            tlsbtnCopyResult.Size = new Size(52, 22);
            tlsbtnCopyResult.Text = "复制(&C)";
            tlsbtnCopyResult.ToolTipText = "复制内容到剪切板";
            // 
            // txtLogs
            // 
            txtLogs.Dock = DockStyle.Fill;
            txtLogs.Location = new Point(0, 25);
            txtLogs.Multiline = true;
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.ScrollBars = ScrollBars.Both;
            txtLogs.Size = new Size(782, 404);
            txtLogs.TabIndex = 2;
            // 
            // toolStrip3
            // 
            toolStrip3.ImageScalingSize = new Size(24, 24);
            toolStrip3.Items.AddRange(new ToolStripItem[] { tlsBtnClear });
            toolStrip3.Location = new Point(0, 0);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(782, 25);
            toolStrip3.TabIndex = 3;
            toolStrip3.Text = "toolStrip3";
            // 
            // tlsBtnClear
            // 
            tlsBtnClear.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tlsBtnClear.Image = (Image)resources.GetObject("tlsBtnClear.Image");
            tlsBtnClear.ImageTransparentColor = Color.Magenta;
            tlsBtnClear.Name = "tlsBtnClear";
            tlsBtnClear.Size = new Size(53, 22);
            tlsBtnClear.Text = "清空(&D)";
            tlsBtnClear.ToolTipText = "复制内容到剪切板";
            tlsBtnClear.Click += tlsBtnClear_Click;
            // 
            // btnAboutme
            // 
            btnAboutme.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnAboutme.Image = (Image)resources.GetObject("btnAboutme.Image");
            btnAboutme.ImageTransparentColor = Color.Magenta;
            btnAboutme.Name = "btnAboutme";
            btnAboutme.Size = new Size(52, 22);
            btnAboutme.Text = "关于(&A)";
            btnAboutme.Click += btnAboutme_Click;
            // 
            // FrmMutiPageReader
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1492, 947);
            Controls.Add(splitContainer1);
            Controls.Add(lsvPages);
            Controls.Add(toolStrip1);
            Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FrmMutiPageReader";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Intelligent Profile Reader";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picMain).EndInit();
            ctmPage.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tlsBtnAdd;
        private ToolStripButton tlsBtnRead;
        private ListView lsvPages;
        private SplitContainer splitContainer1;
        private PictureBox picMain;
        private SplitContainer splitContainer2;
        private ToolStripButton tlsBtnReset;
        private ToolStrip toolStrip2;
        private ToolStripButton tlsbtnCopyResult;
        private ImageList imgsMain;
        private TextBox txtResult;
        private TextBox txtLogs;
        private ToolStrip toolStrip3;
        private ToolStripButton tlsBtnClear;
        private ContextMenuStrip ctmPage;
        private ToolStripMenuItem tlsMnuCopyPageText;
        private ToolStripButton btnAboutme;
    }
}