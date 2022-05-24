
namespace Lococo.Forms.overlay
{
    partial class o_browser
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
            this.webViewer = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // webViewer
            // 
            this.webViewer.CreationProperties = null;
            this.webViewer.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewer.Location = new System.Drawing.Point(5, 30);
            this.webViewer.Name = "webViewer";
            this.webViewer.Size = new System.Drawing.Size(467, 444);
            this.webViewer.TabIndex = 0;
            this.webViewer.ZoomFactor = 1D;
            this.webViewer.ZoomFactorChanged += new System.EventHandler<System.EventArgs>(this.webViewer_ZoomFactorChanged);
            // 
            // o_browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.webViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "o_browser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Lococo - Overlay";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.overlayForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.overlayForm_Paint);
            this.Move += new System.EventHandler(this.overlayForm_Move);
            this.Resize += new System.EventHandler(this.overlayForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.webViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewer;
    }
}