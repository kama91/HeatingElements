namespace HeatingElements
{
    partial class MainForm
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
            this._diagramControl = new DevExpress.XtraDiagram.DiagramControl();
            this._btnShowParseData = new DevExpress.XtraEditors.SimpleButton();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._panel = new System.Windows.Forms.Panel();
            this._btnRun = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this._diagramControl)).BeginInit();
            this._panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _diagramControl
            // 
            this._diagramControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._diagramControl.Location = new System.Drawing.Point(0, 0);
            this._diagramControl.Name = "_diagramControl";
            this._diagramControl.OptionsBehavior.SelectedStencils = new DevExpress.Diagram.Core.StencilCollection(new string[] {
            "BasicShapes",
            "BasicFlowchartShapes"});
            this._diagramControl.OptionsView.CanvasSizeMode = DevExpress.Diagram.Core.CanvasSizeMode.Fill;
            this._diagramControl.OptionsView.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this._diagramControl.Size = new System.Drawing.Size(1451, 968);
            this._diagramControl.TabIndex = 0;
            this._diagramControl.Text = "diagramControl1";
            // 
            // _btnShowParseData
            // 
            this._btnShowParseData.Location = new System.Drawing.Point(625, 16);
            this._btnShowParseData.Name = "_btnShowParseData";
            this._btnShowParseData.Size = new System.Drawing.Size(136, 34);
            this._btnShowParseData.TabIndex = 1;
            this._btnShowParseData.Text = "Show";
            this._btnShowParseData.Click += new System.EventHandler(this._btnOpenFile_Click);
            // 
            // _openFileDialog
            // 
            this._openFileDialog.FileName = "_openFileDialog";
            // 
            // _panel
            // 
            this._panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._panel.Controls.Add(this._btnRun);
            this._panel.Controls.Add(this._btnShowParseData);
            this._panel.Location = new System.Drawing.Point(0, 906);
            this._panel.MaximumSize = new System.Drawing.Size(1452, 65);
            this._panel.MinimumSize = new System.Drawing.Size(1452, 65);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(1452, 65);
            this._panel.TabIndex = 2;
            // 
            // _btnRun
            // 
            this._btnRun.Location = new System.Drawing.Point(780, 16);
            this._btnRun.Name = "_btnRun";
            this._btnRun.Size = new System.Drawing.Size(136, 34);
            this._btnRun.TabIndex = 2;
            this._btnRun.Text = "Run";
            this._btnRun.Click += new System.EventHandler(this._btnRun_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 968);
            this.Controls.Add(this._panel);
            this.Controls.Add(this._diagramControl);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this._diagramControl)).EndInit();
            this._panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDiagram.DiagramControl _diagramControl;
        private DevExpress.XtraEditors.SimpleButton _btnShowParseData;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
        private System.Windows.Forms.Panel _panel;
        private DevExpress.XtraEditors.SimpleButton _btnRun;
    }
}

