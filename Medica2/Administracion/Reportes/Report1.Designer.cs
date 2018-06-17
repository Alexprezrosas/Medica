namespace Medica2.Administracion.Reportes
{
    partial class Report1
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.nOMBRE_MEDIDataTextBox = new Telerik.Reporting.TextBox();
            this.cOMENTARIODataTextBox = new Telerik.Reporting.TextBox();
            this.cANTIDADDataTextBox = new Telerik.Reporting.TextBox();
            this.p_COMPRADataTextBox = new Telerik.Reporting.TextBox();
            this.p_MEDICOSDataTextBox = new Telerik.Reporting.TextBox();
            this.p_VENTADataTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Medica2.Properties.Settings.MEDICASILOEv3ConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.SelectCommand = "SELECT NOMBRE_MEDI, CANTIDAD, COMENTARIO, P_VENTA, P_COMPRA, P_MEDICOS\r\nFROM     " +
    "CATALOGO_MEDICAMENTOS";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Mm(42.299999237060547D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.nOMBRE_MEDIDataTextBox,
            this.cOMENTARIODataTextBox,
            this.cANTIDADDataTextBox,
            this.p_COMPRADataTextBox,
            this.p_MEDICOSDataTextBox,
            this.p_VENTADataTextBox});
            this.detail.Name = "detail";
            // 
            // nOMBRE_MEDIDataTextBox
            // 
            this.nOMBRE_MEDIDataTextBox.CanGrow = false;
            this.nOMBRE_MEDIDataTextBox.CanShrink = false;
            this.nOMBRE_MEDIDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.23267717659473419D));
            this.nOMBRE_MEDIDataTextBox.Name = "nOMBRE_MEDIDataTextBox";
            this.nOMBRE_MEDIDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.5511810779571533D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.nOMBRE_MEDIDataTextBox.Value = "= Fields.NOMBRE_MEDI";
            // 
            // cOMENTARIODataTextBox
            // 
            this.cOMENTARIODataTextBox.CanGrow = false;
            this.cOMENTARIODataTextBox.CanShrink = false;
            this.cOMENTARIODataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.43267717957496643D));
            this.cOMENTARIODataTextBox.Name = "cOMENTARIODataTextBox";
            this.cOMENTARIODataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.5511810779571533D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cOMENTARIODataTextBox.Value = "= Fields.COMENTARIO";
            // 
            // cANTIDADDataTextBox
            // 
            this.cANTIDADDataTextBox.CanGrow = false;
            this.cANTIDADDataTextBox.CanShrink = false;
            this.cANTIDADDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.63267719745635986D));
            this.cANTIDADDataTextBox.Name = "cANTIDADDataTextBox";
            this.cANTIDADDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.5511810779571533D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cANTIDADDataTextBox.Value = "= Fields.CANTIDAD";
            // 
            // p_COMPRADataTextBox
            // 
            this.p_COMPRADataTextBox.CanGrow = false;
            this.p_COMPRADataTextBox.CanShrink = false;
            this.p_COMPRADataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.83267718553543091D));
            this.p_COMPRADataTextBox.Name = "p_COMPRADataTextBox";
            this.p_COMPRADataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.5511810779571533D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_COMPRADataTextBox.Value = "= Fields.P_COMPRA";
            // 
            // p_MEDICOSDataTextBox
            // 
            this.p_MEDICOSDataTextBox.CanGrow = false;
            this.p_MEDICOSDataTextBox.CanShrink = false;
            this.p_MEDICOSDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.032677173614502D));
            this.p_MEDICOSDataTextBox.Name = "p_MEDICOSDataTextBox";
            this.p_MEDICOSDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.5511810779571533D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_MEDICOSDataTextBox.Value = "= Fields.P_MEDICOS";
            // 
            // p_VENTADataTextBox
            // 
            this.p_VENTADataTextBox.CanGrow = false;
            this.p_VENTADataTextBox.CanShrink = false;
            this.p_VENTADataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.2326772212982178D));
            this.p_VENTADataTextBox.Name = "p_VENTADataTextBox";
            this.p_VENTADataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.5511810779571533D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_VENTADataTextBox.Value = "= Fields.P_VENTA";
            // 
            // Report1
            // 
            this.DataSource = this.sqlDataSource1;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "Report1";
            this.PageSettings.ColumnCount = 2;
            this.PageSettings.ColumnSpacing = Telerik.Reporting.Drawing.Unit.Mm(2.5D);
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(16.5D), Telerik.Reporting.Drawing.Unit.Mm(10.589990615844727D), Telerik.Reporting.Drawing.Unit.Mm(20D), Telerik.Reporting.Drawing.Unit.Mm(23.189994812011719D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Mm(90.199996948242188D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox nOMBRE_MEDIDataTextBox;
        private Telerik.Reporting.TextBox cOMENTARIODataTextBox;
        private Telerik.Reporting.TextBox cANTIDADDataTextBox;
        private Telerik.Reporting.TextBox p_COMPRADataTextBox;
        private Telerik.Reporting.TextBox p_MEDICOSDataTextBox;
        private Telerik.Reporting.TextBox p_VENTADataTextBox;
    }
}