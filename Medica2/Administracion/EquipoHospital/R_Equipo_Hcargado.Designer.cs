namespace Medica2.Administracion.EquipoHospital
{
    partial class R_Equipo_Hcargado
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
            this.r_Equipo_H_Cargado1 = new Medica2.Administracion.EquipoHospital.R_Equipo_H_Cargado();
            ((System.ComponentModel.ISupportInitialize)(this.r_Equipo_H_Cargado1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ReportEngineConnection = "engine=Embedded";
            instanceReportSource1.ReportDocument = this.r_Equipo_H_Cargado1;
            this.reportViewer1.ReportSource = instanceReportSource1;
            this.reportViewer1.Size = new System.Drawing.Size(835, 533);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // r_Equipo_H_Cargado1
            // 
            this.r_Equipo_H_Cargado1.Name = "R_Equipo_H_Cargado";
            // 
            // R_Equipo_Hcargado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 533);
            this.Controls.Add(this.reportViewer1);
            this.Name = "R_Equipo_Hcargado";
            this.Text = "R_Equipo_Hcargado";
            ((System.ComponentModel.ISupportInitialize)(this.r_Equipo_H_Cargado1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;
        private R_Equipo_H_Cargado r_Equipo_H_Cargado1;
    }
}