namespace Medica2.Administracion.Cirugias
{
    partial class R_Cirugias_Aplicadas
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
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            this.reportViewer1 = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.r_Ciru_Aplicadas1 = new Medica2.Administracion.Cirugias.R_Ciru_Aplicadas();
            ((System.ComponentModel.ISupportInitialize)(this.r_Ciru_Aplicadas1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ReportEngineConnection = "engine=Embedded";
            instanceReportSource1.ReportDocument = this.r_Ciru_Aplicadas1;
            this.reportViewer1.ReportSource = instanceReportSource1;
            this.reportViewer1.Size = new System.Drawing.Size(940, 557);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // r_Ciru_Aplicadas1
            // 
            this.r_Ciru_Aplicadas1.Name = "R_Ciru_Aplicadas";
            // 
            // R_Cirugias_Aplicadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 557);
            this.Controls.Add(this.reportViewer1);
            this.Name = "R_Cirugias_Aplicadas";
            this.Text = "R_Cirugias_Aplicadas";
            ((System.ComponentModel.ISupportInitialize)(this.r_Ciru_Aplicadas1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;
        private R_Ciru_Aplicadas r_Ciru_Aplicadas1;
    }
}