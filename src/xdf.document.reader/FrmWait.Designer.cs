namespace xdf.document.reader
{
    partial class FrmWait
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
            lblMessage = new Label();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.Location = new Point(12, 9);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(374, 138);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "文书/档案读取中 ...";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmWait
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 156);
            Controls.Add(lblMessage);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmWait";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "请稍等";
            ResumeLayout(false);
        }

        #endregion

        private Label lblMessage;
    }
}