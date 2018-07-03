namespace Medica2.Farmacia.Materiales.Reportes
{
    partial class ReportMateriales
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group2 = new Telerik.Reporting.Group();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.nOMBRE_MEDICaptionTextBox = new Telerik.Reporting.TextBox();
            this.cANTIDADCaptionTextBox = new Telerik.Reporting.TextBox();
            this.u_MEDIDACaptionTextBox = new Telerik.Reporting.TextBox();
            this.p_COMPRACaptionTextBox = new Telerik.Reporting.TextBox();
            this.p_MEDICOSCaptionTextBox = new Telerik.Reporting.TextBox();
            this.p_VENTACaptionTextBox = new Telerik.Reporting.TextBox();
            this.cOD_BARRASCaptionTextBox = new Telerik.Reporting.TextBox();
            this.cFDICaptionTextBox = new Telerik.Reporting.TextBox();
            this.nOMBRE_MEDIGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.nOMBRE_MEDIGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.cOMENTARIODataTextBox = new Telerik.Reporting.TextBox();
            this.cANTIDADDataTextBox = new Telerik.Reporting.TextBox();
            this.u_MEDIDADataTextBox = new Telerik.Reporting.TextBox();
            this.p_COMPRADataTextBox = new Telerik.Reporting.TextBox();
            this.p_MEDICOSDataTextBox = new Telerik.Reporting.TextBox();
            this.p_VENTADataTextBox = new Telerik.Reporting.TextBox();
            this.cOD_BARRASDataTextBox = new Telerik.Reporting.TextBox();
            this.cFDIDataTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "BaseDatos";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.SelectCommand = "SELECT NOMBRE_MEDI, COMENTARIO, CANTIDAD, U_MEDIDA, P_COMPRA, P_VENTA, P_MEDICOS," +
    " COD_BARRAS, CFDI\r\nFROM     CATALOGO_MEDICAMENTOS\r\nWHERE STATUS = \'Activo\' and A" +
    "LMACEN = \'Materiales\'";
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23333333432674408D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.nOMBRE_MEDICaptionTextBox,
            this.cANTIDADCaptionTextBox,
            this.u_MEDIDACaptionTextBox,
            this.p_COMPRACaptionTextBox,
            this.p_MEDICOSCaptionTextBox,
            this.p_VENTACaptionTextBox,
            this.cOD_BARRASCaptionTextBox,
            this.cFDICaptionTextBox});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.22499999403953552D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // nOMBRE_MEDICaptionTextBox
            // 
            this.nOMBRE_MEDICaptionTextBox.CanGrow = true;
            this.nOMBRE_MEDICaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.nOMBRE_MEDICaptionTextBox.Name = "nOMBRE_MEDICaptionTextBox";
            this.nOMBRE_MEDICaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.88333326578140259D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.nOMBRE_MEDICaptionTextBox.StyleName = "Caption";
            this.nOMBRE_MEDICaptionTextBox.Value = "Nombre";
            // 
            // cANTIDADCaptionTextBox
            // 
            this.cANTIDADCaptionTextBox.CanGrow = true;
            this.cANTIDADCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.90007883310317993D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.cANTIDADCaptionTextBox.Name = "cANTIDADCaptionTextBox";
            this.cANTIDADCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69984245300292969D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cANTIDADCaptionTextBox.StyleName = "Caption";
            this.cANTIDADCaptionTextBox.Value = "Cantidad";
            // 
            // u_MEDIDACaptionTextBox
            // 
            this.u_MEDIDACaptionTextBox.CanGrow = true;
            this.u_MEDIDACaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.u_MEDIDACaptionTextBox.Name = "u_MEDIDACaptionTextBox";
            this.u_MEDIDACaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.7000001072883606D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.u_MEDIDACaptionTextBox.StyleName = "Caption";
            this.u_MEDIDACaptionTextBox.Value = "UMedida";
            // 
            // p_COMPRACaptionTextBox
            // 
            this.p_COMPRACaptionTextBox.CanGrow = true;
            this.p_COMPRACaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.3000791072845459D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.p_COMPRACaptionTextBox.Name = "p_COMPRACaptionTextBox";
            this.p_COMPRACaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.67419075965881348D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_COMPRACaptionTextBox.StyleName = "Caption";
            this.p_COMPRACaptionTextBox.Value = "PCompra";
            // 
            // p_MEDICOSCaptionTextBox
            // 
            this.p_MEDICOSCaptionTextBox.CanGrow = true;
            this.p_MEDICOSCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.9743483066558838D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.p_MEDICOSCaptionTextBox.Name = "p_MEDICOSCaptionTextBox";
            this.p_MEDICOSCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.67419075965881348D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_MEDICOSCaptionTextBox.StyleName = "Caption";
            this.p_MEDICOSCaptionTextBox.Value = "PMedicos";
            // 
            // p_VENTACaptionTextBox
            // 
            this.p_VENTACaptionTextBox.CanGrow = true;
            this.p_VENTACaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6486175060272217D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.p_VENTACaptionTextBox.Name = "p_VENTACaptionTextBox";
            this.p_VENTACaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.67419075965881348D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_VENTACaptionTextBox.StyleName = "Caption";
            this.p_VENTACaptionTextBox.Value = "PVenta";
            // 
            // cOD_BARRASCaptionTextBox
            // 
            this.cOD_BARRASCaptionTextBox.CanGrow = true;
            this.cOD_BARRASCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.3228869438171387D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.cOD_BARRASCaptionTextBox.Name = "cOD_BARRASCaptionTextBox";
            this.cOD_BARRASCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.97711330652236938D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cOD_BARRASCaptionTextBox.StyleName = "Caption";
            this.cOD_BARRASCaptionTextBox.Value = "CBarras";
            // 
            // cFDICaptionTextBox
            // 
            this.cFDICaptionTextBox.CanGrow = true;
            this.cFDICaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.3000788688659668D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.cFDICaptionTextBox.Name = "cFDICaptionTextBox";
            this.cFDICaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.79992109537124634D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cFDICaptionTextBox.StyleName = "Caption";
            this.cFDICaptionTextBox.Value = "CFDI";
            // 
            // nOMBRE_MEDIGroupHeaderSection
            // 
            this.nOMBRE_MEDIGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.4666273295879364D);
            this.nOMBRE_MEDIGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.cOMENTARIODataTextBox,
            this.cANTIDADDataTextBox,
            this.u_MEDIDADataTextBox,
            this.p_COMPRADataTextBox,
            this.p_MEDICOSDataTextBox,
            this.p_VENTADataTextBox,
            this.cOD_BARRASDataTextBox,
            this.cFDIDataTextBox});
            this.nOMBRE_MEDIGroupHeaderSection.Name = "nOMBRE_MEDIGroupHeaderSection";
            // 
            // nOMBRE_MEDIGroupFooterSection
            // 
            this.nOMBRE_MEDIGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.22499999403953552D);
            this.nOMBRE_MEDIGroupFooterSection.Name = "nOMBRE_MEDIGroupFooterSection";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.67419075965881348D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox1.StyleName = "Data";
            this.textBox1.Value = "= Fields.NOMBRE_MEDI";
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23333333432674408D);
            this.pageHeader.Name = "pageHeader";
            // 
            // reportNameTextBox
            // 
            this.reportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.033333335071802139D), Telerik.Reporting.Drawing.Unit.Inch(0.26666668057441711D));
            this.reportNameTextBox.Name = "reportNameTextBox";
            this.reportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.2010498046875D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.reportNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.reportNameTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.reportNameTextBox.StyleName = "PageInfo";
            this.reportNameTextBox.Value = "Reporte de materiales";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23333333432674408D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooter.Name = "pageFooter";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0921916961669922D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.1255249977111816D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0921916961669922D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.80406826734542847D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox,
            this.reportNameTextBox});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.2343831062316895D), Telerik.Reporting.Drawing.Unit.Inch(0.787401556968689D));
            this.titleTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "Medica de Especialidades Siloe";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.22499999403953552D);
            this.reportFooter.Name = "reportFooter";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23333333432674408D);
            this.detail.Name = "detail";
            // 
            // cOMENTARIODataTextBox
            // 
            this.cOMENTARIODataTextBox.CanGrow = true;
            this.cOMENTARIODataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.033333335071802139D), Telerik.Reporting.Drawing.Unit.Inch(0.21674533188343048D));
            this.cOMENTARIODataTextBox.Name = "cOMENTARIODataTextBox";
            this.cOMENTARIODataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.86666661500930786D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cOMENTARIODataTextBox.StyleName = "Data";
            this.cOMENTARIODataTextBox.Value = "= Fields.COMENTARIO";
            // 
            // cANTIDADDataTextBox
            // 
            this.cANTIDADDataTextBox.CanGrow = true;
            this.cANTIDADDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.90007883310317993D), Telerik.Reporting.Drawing.Unit.Inch(0.12926499545574188D));
            this.cANTIDADDataTextBox.Name = "cANTIDADDataTextBox";
            this.cANTIDADDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.67419075965881348D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cANTIDADDataTextBox.StyleName = "Data";
            this.cANTIDADDataTextBox.Value = "= Fields.CANTIDAD";
            // 
            // u_MEDIDADataTextBox
            // 
            this.u_MEDIDADataTextBox.CanGrow = true;
            this.u_MEDIDADataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.5743483304977417D), Telerik.Reporting.Drawing.Unit.Inch(0.12926499545574188D));
            this.u_MEDIDADataTextBox.Name = "u_MEDIDADataTextBox";
            this.u_MEDIDADataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.67419075965881348D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.u_MEDIDADataTextBox.StyleName = "Data";
            this.u_MEDIDADataTextBox.Value = "= Fields.U_MEDIDA";
            // 
            // p_COMPRADataTextBox
            // 
            this.p_COMPRADataTextBox.CanGrow = true;
            this.p_COMPRADataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2486176490783691D), Telerik.Reporting.Drawing.Unit.Inch(0.12926499545574188D));
            this.p_COMPRADataTextBox.Name = "p_COMPRADataTextBox";
            this.p_COMPRADataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.72565215826034546D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_COMPRADataTextBox.StyleName = "Data";
            this.p_COMPRADataTextBox.Value = "= Fields.P_COMPRA";
            // 
            // p_MEDICOSDataTextBox
            // 
            this.p_MEDICOSDataTextBox.CanGrow = true;
            this.p_MEDICOSDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.9743483066558838D), Telerik.Reporting.Drawing.Unit.Inch(0.12926499545574188D));
            this.p_MEDICOSDataTextBox.Name = "p_MEDICOSDataTextBox";
            this.p_MEDICOSDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.67419075965881348D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_MEDICOSDataTextBox.StyleName = "Data";
            this.p_MEDICOSDataTextBox.Value = "= Fields.P_MEDICOS";
            // 
            // p_VENTADataTextBox
            // 
            this.p_VENTADataTextBox.CanGrow = true;
            this.p_VENTADataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6486175060272217D), Telerik.Reporting.Drawing.Unit.Inch(0.12926499545574188D));
            this.p_VENTADataTextBox.Name = "p_VENTADataTextBox";
            this.p_VENTADataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.67419075965881348D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_VENTADataTextBox.StyleName = "Data";
            this.p_VENTADataTextBox.Value = "= Fields.P_VENTA";
            // 
            // cOD_BARRASDataTextBox
            // 
            this.cOD_BARRASDataTextBox.CanGrow = true;
            this.cOD_BARRASDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.3228869438171387D), Telerik.Reporting.Drawing.Unit.Inch(0.12926499545574188D));
            this.cOD_BARRASDataTextBox.Name = "cOD_BARRASDataTextBox";
            this.cOD_BARRASDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.97711330652236938D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cOD_BARRASDataTextBox.StyleName = "Data";
            this.cOD_BARRASDataTextBox.Value = "= Fields.COD_BARRAS";
            // 
            // cFDIDataTextBox
            // 
            this.cFDIDataTextBox.CanGrow = true;
            this.cFDIDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.3000788688659668D), Telerik.Reporting.Drawing.Unit.Inch(0.12926499545574188D));
            this.cFDIDataTextBox.Name = "cFDIDataTextBox";
            this.cFDIDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.79992109537124634D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cFDIDataTextBox.StyleName = "Data";
            this.cFDIDataTextBox.Value = "= Fields.CFDI";
            // 
            // ReportMateriales
            // 
            this.DataSource = this.sqlDataSource1;
            group1.GroupFooter = this.labelsGroupFooterSection;
            group1.GroupHeader = this.labelsGroupHeaderSection;
            group1.Name = "labelsGroup";
            group2.GroupFooter = this.nOMBRE_MEDIGroupFooterSection;
            group2.GroupHeader = this.nOMBRE_MEDIGroupHeaderSection;
            group2.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.NOMBRE_MEDI"));
            group2.Name = "nOMBRE_MEDIGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1,
            group2});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.nOMBRE_MEDIGroupHeaderSection,
            this.nOMBRE_MEDIGroupFooterSection,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.reportFooter,
            this.detail});
            this.Name = "ReportMateriales";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(97)))), ((int)(((byte)(74)))));
            styleRule2.Style.Font.Name = "Georgia";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule3.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(174)))), ((int)(((byte)(173)))));
            styleRule3.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(168)))), ((int)(((byte)(212)))));
            styleRule3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Dotted;
            styleRule3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            styleRule3.Style.Font.Name = "Georgia";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule4.Style.Font.Name = "Georgia";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule5.Style.Font.Name = "Georgia";
            styleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.2343831062316895D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox nOMBRE_MEDICaptionTextBox;
        private Telerik.Reporting.TextBox cANTIDADCaptionTextBox;
        private Telerik.Reporting.TextBox u_MEDIDACaptionTextBox;
        private Telerik.Reporting.TextBox p_COMPRACaptionTextBox;
        private Telerik.Reporting.TextBox p_MEDICOSCaptionTextBox;
        private Telerik.Reporting.TextBox p_VENTACaptionTextBox;
        private Telerik.Reporting.TextBox cOD_BARRASCaptionTextBox;
        private Telerik.Reporting.TextBox cFDICaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection nOMBRE_MEDIGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.GroupFooterSection nOMBRE_MEDIGroupFooterSection;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox cOMENTARIODataTextBox;
        private Telerik.Reporting.TextBox cANTIDADDataTextBox;
        private Telerik.Reporting.TextBox u_MEDIDADataTextBox;
        private Telerik.Reporting.TextBox p_COMPRADataTextBox;
        private Telerik.Reporting.TextBox p_MEDICOSDataTextBox;
        private Telerik.Reporting.TextBox p_VENTADataTextBox;
        private Telerik.Reporting.TextBox cOD_BARRASDataTextBox;
        private Telerik.Reporting.TextBox cFDIDataTextBox;
    }
}