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
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.aLMACENCaptionTextBox = new Telerik.Reporting.TextBox();
            this.p_COMPRACaptionTextBox = new Telerik.Reporting.TextBox();
            this.p_MEDICOSCaptionTextBox = new Telerik.Reporting.TextBox();
            this.p_VENTACaptionTextBox = new Telerik.Reporting.TextBox();
            this.sTATUSCaptionTextBox = new Telerik.Reporting.TextBox();
            this.u_MEDIDACaptionTextBox = new Telerik.Reporting.TextBox();
            this.cADUCIDADCaptionTextBox = new Telerik.Reporting.TextBox();
            this.cANTIDADCaptionTextBox = new Telerik.Reporting.TextBox();
            this.cFDICaptionTextBox = new Telerik.Reporting.TextBox();
            this.cOD_BARRASCaptionTextBox = new Telerik.Reporting.TextBox();
            this.cOMENTARIOCaptionTextBox = new Telerik.Reporting.TextBox();
            this.fECHA_CREACIONCaptionTextBox = new Telerik.Reporting.TextBox();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.nOMBRE_MEDICaptionTextBox = new Telerik.Reporting.TextBox();
            this.nOMBRE_MEDIDataTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.aLMACENDataTextBox = new Telerik.Reporting.TextBox();
            this.p_COMPRADataTextBox = new Telerik.Reporting.TextBox();
            this.p_MEDICOSDataTextBox = new Telerik.Reporting.TextBox();
            this.p_VENTADataTextBox = new Telerik.Reporting.TextBox();
            this.sTATUSDataTextBox = new Telerik.Reporting.TextBox();
            this.u_MEDIDADataTextBox = new Telerik.Reporting.TextBox();
            this.cADUCIDADDataTextBox = new Telerik.Reporting.TextBox();
            this.cANTIDADDataTextBox = new Telerik.Reporting.TextBox();
            this.cFDIDataTextBox = new Telerik.Reporting.TextBox();
            this.cOD_BARRASDataTextBox = new Telerik.Reporting.TextBox();
            this.cOMENTARIODataTextBox = new Telerik.Reporting.TextBox();
            this.fECHA_CREACIONDataTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "BaseDatos";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.SelectCommand = "SELECT NOMBRE_MEDI, COMENTARIO, CANTIDAD, P_VENTA, P_COMPRA, P_MEDICOS, CADUCIDAD" +
    ", FECHA_CREACION, U_MEDIDA, COD_BARRAS, ALMACEN, CFDI, STATUS\r\nFROM     CATALOGO" +
    "_MEDICAMENTOS";
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23333333432674408D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.aLMACENCaptionTextBox,
            this.p_COMPRACaptionTextBox,
            this.p_MEDICOSCaptionTextBox,
            this.p_VENTACaptionTextBox,
            this.sTATUSCaptionTextBox,
            this.u_MEDIDACaptionTextBox,
            this.cADUCIDADCaptionTextBox,
            this.cANTIDADCaptionTextBox,
            this.cFDICaptionTextBox,
            this.cOD_BARRASCaptionTextBox,
            this.cOMENTARIOCaptionTextBox,
            this.fECHA_CREACIONCaptionTextBox});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.22499999403953552D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // aLMACENCaptionTextBox
            // 
            this.aLMACENCaptionTextBox.CanGrow = true;
            this.aLMACENCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.aLMACENCaptionTextBox.Name = "aLMACENCaptionTextBox";
            this.aLMACENCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.aLMACENCaptionTextBox.StyleName = "Caption";
            this.aLMACENCaptionTextBox.Value = "ALMACEN";
            // 
            // p_COMPRACaptionTextBox
            // 
            this.p_COMPRACaptionTextBox.CanGrow = true;
            this.p_COMPRACaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.55416667461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.p_COMPRACaptionTextBox.Name = "p_COMPRACaptionTextBox";
            this.p_COMPRACaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_COMPRACaptionTextBox.StyleName = "Caption";
            this.p_COMPRACaptionTextBox.Value = "P_COMPRA";
            // 
            // p_MEDICOSCaptionTextBox
            // 
            this.p_MEDICOSCaptionTextBox.CanGrow = true;
            this.p_MEDICOSCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.0916666984558106D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.p_MEDICOSCaptionTextBox.Name = "p_MEDICOSCaptionTextBox";
            this.p_MEDICOSCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_MEDICOSCaptionTextBox.StyleName = "Caption";
            this.p_MEDICOSCaptionTextBox.Value = "P_MEDICOS";
            // 
            // p_VENTACaptionTextBox
            // 
            this.p_VENTACaptionTextBox.CanGrow = true;
            this.p_VENTACaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6291667222976685D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.p_VENTACaptionTextBox.Name = "p_VENTACaptionTextBox";
            this.p_VENTACaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_VENTACaptionTextBox.StyleName = "Caption";
            this.p_VENTACaptionTextBox.Value = "P_VENTA";
            // 
            // sTATUSCaptionTextBox
            // 
            this.sTATUSCaptionTextBox.CanGrow = true;
            this.sTATUSCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1666667461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.sTATUSCaptionTextBox.Name = "sTATUSCaptionTextBox";
            this.sTATUSCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.sTATUSCaptionTextBox.StyleName = "Caption";
            this.sTATUSCaptionTextBox.Value = "STATUS";
            // 
            // u_MEDIDACaptionTextBox
            // 
            this.u_MEDIDACaptionTextBox.CanGrow = true;
            this.u_MEDIDACaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7041666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.u_MEDIDACaptionTextBox.Name = "u_MEDIDACaptionTextBox";
            this.u_MEDIDACaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.u_MEDIDACaptionTextBox.StyleName = "Caption";
            this.u_MEDIDACaptionTextBox.Value = "U_MEDIDA";
            // 
            // cADUCIDADCaptionTextBox
            // 
            this.cADUCIDADCaptionTextBox.CanGrow = true;
            this.cADUCIDADCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2416665554046631D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.cADUCIDADCaptionTextBox.Name = "cADUCIDADCaptionTextBox";
            this.cADUCIDADCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cADUCIDADCaptionTextBox.StyleName = "Caption";
            this.cADUCIDADCaptionTextBox.Value = "CADUCIDAD";
            // 
            // cANTIDADCaptionTextBox
            // 
            this.cANTIDADCaptionTextBox.CanGrow = true;
            this.cANTIDADCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.7791666984558105D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.cANTIDADCaptionTextBox.Name = "cANTIDADCaptionTextBox";
            this.cANTIDADCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cANTIDADCaptionTextBox.StyleName = "Caption";
            this.cANTIDADCaptionTextBox.Value = "CANTIDAD";
            // 
            // cFDICaptionTextBox
            // 
            this.cFDICaptionTextBox.CanGrow = true;
            this.cFDICaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.3166666030883789D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.cFDICaptionTextBox.Name = "cFDICaptionTextBox";
            this.cFDICaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cFDICaptionTextBox.StyleName = "Caption";
            this.cFDICaptionTextBox.Value = "CFDI";
            // 
            // cOD_BARRASCaptionTextBox
            // 
            this.cOD_BARRASCaptionTextBox.CanGrow = true;
            this.cOD_BARRASCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.8541665077209473D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.cOD_BARRASCaptionTextBox.Name = "cOD_BARRASCaptionTextBox";
            this.cOD_BARRASCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cOD_BARRASCaptionTextBox.StyleName = "Caption";
            this.cOD_BARRASCaptionTextBox.Value = "COD_BARRAS";
            // 
            // cOMENTARIOCaptionTextBox
            // 
            this.cOMENTARIOCaptionTextBox.CanGrow = true;
            this.cOMENTARIOCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.3916668891906738D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.cOMENTARIOCaptionTextBox.Name = "cOMENTARIOCaptionTextBox";
            this.cOMENTARIOCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cOMENTARIOCaptionTextBox.StyleName = "Caption";
            this.cOMENTARIOCaptionTextBox.Value = "COMENTARIO";
            // 
            // fECHA_CREACIONCaptionTextBox
            // 
            this.fECHA_CREACIONCaptionTextBox.CanGrow = true;
            this.fECHA_CREACIONCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9291667938232422D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.fECHA_CREACIONCaptionTextBox.Name = "fECHA_CREACIONCaptionTextBox";
            this.fECHA_CREACIONCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.fECHA_CREACIONCaptionTextBox.StyleName = "Caption";
            this.fECHA_CREACIONCaptionTextBox.Value = "FECHA_CREACION";
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23333333432674408D);
            this.pageHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.reportNameTextBox});
            this.pageHeader.Name = "pageHeader";
            // 
            // reportNameTextBox
            // 
            this.reportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.reportNameTextBox.Name = "reportNameTextBox";
            this.reportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4333333969116211D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.reportNameTextBox.StyleName = "PageInfo";
            this.reportNameTextBox.Value = "Report1";
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
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2083332538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2416665554046631D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2083332538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(1.0207349061965942D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox,
            this.nOMBRE_MEDICaptionTextBox,
            this.nOMBRE_MEDIDataTextBox});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4666666984558105D), Telerik.Reporting.Drawing.Unit.Inch(0.787401556968689D));
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "Report1";
            // 
            // nOMBRE_MEDICaptionTextBox
            // 
            this.nOMBRE_MEDICaptionTextBox.CanGrow = true;
            this.nOMBRE_MEDICaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0.80406826734542847D));
            this.nOMBRE_MEDICaptionTextBox.Name = "nOMBRE_MEDICaptionTextBox";
            this.nOMBRE_MEDICaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2083332538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.nOMBRE_MEDICaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.nOMBRE_MEDICaptionTextBox.StyleName = "Caption";
            this.nOMBRE_MEDICaptionTextBox.Value = "NOMBRE_MEDI:";
            // 
            // nOMBRE_MEDIDataTextBox
            // 
            this.nOMBRE_MEDIDataTextBox.CanGrow = true;
            this.nOMBRE_MEDIDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2416665554046631D), Telerik.Reporting.Drawing.Unit.Inch(0.80406826734542847D));
            this.nOMBRE_MEDIDataTextBox.Name = "nOMBRE_MEDIDataTextBox";
            this.nOMBRE_MEDIDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2083332538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.nOMBRE_MEDIDataTextBox.StyleName = "Data";
            this.nOMBRE_MEDIDataTextBox.Value = "= Fields.NOMBRE_MEDI";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.22499999403953552D);
            this.reportFooter.Name = "reportFooter";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23333333432674408D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.aLMACENDataTextBox,
            this.p_COMPRADataTextBox,
            this.p_MEDICOSDataTextBox,
            this.p_VENTADataTextBox,
            this.sTATUSDataTextBox,
            this.u_MEDIDADataTextBox,
            this.cADUCIDADDataTextBox,
            this.cANTIDADDataTextBox,
            this.cFDIDataTextBox,
            this.cOD_BARRASDataTextBox,
            this.cOMENTARIODataTextBox,
            this.fECHA_CREACIONDataTextBox});
            this.detail.Name = "detail";
            // 
            // aLMACENDataTextBox
            // 
            this.aLMACENDataTextBox.CanGrow = true;
            this.aLMACENDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.aLMACENDataTextBox.Name = "aLMACENDataTextBox";
            this.aLMACENDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.aLMACENDataTextBox.StyleName = "Data";
            this.aLMACENDataTextBox.Value = "= Fields.ALMACEN";
            // 
            // p_COMPRADataTextBox
            // 
            this.p_COMPRADataTextBox.CanGrow = true;
            this.p_COMPRADataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.55416667461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.p_COMPRADataTextBox.Name = "p_COMPRADataTextBox";
            this.p_COMPRADataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_COMPRADataTextBox.StyleName = "Data";
            this.p_COMPRADataTextBox.Value = "= Fields.P_COMPRA";
            // 
            // p_MEDICOSDataTextBox
            // 
            this.p_MEDICOSDataTextBox.CanGrow = true;
            this.p_MEDICOSDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.0916666984558106D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.p_MEDICOSDataTextBox.Name = "p_MEDICOSDataTextBox";
            this.p_MEDICOSDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_MEDICOSDataTextBox.StyleName = "Data";
            this.p_MEDICOSDataTextBox.Value = "= Fields.P_MEDICOS";
            // 
            // p_VENTADataTextBox
            // 
            this.p_VENTADataTextBox.CanGrow = true;
            this.p_VENTADataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6291667222976685D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.p_VENTADataTextBox.Name = "p_VENTADataTextBox";
            this.p_VENTADataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.p_VENTADataTextBox.StyleName = "Data";
            this.p_VENTADataTextBox.Value = "= Fields.P_VENTA";
            // 
            // sTATUSDataTextBox
            // 
            this.sTATUSDataTextBox.CanGrow = true;
            this.sTATUSDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1666667461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.sTATUSDataTextBox.Name = "sTATUSDataTextBox";
            this.sTATUSDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.sTATUSDataTextBox.StyleName = "Data";
            this.sTATUSDataTextBox.Value = "= Fields.STATUS";
            // 
            // u_MEDIDADataTextBox
            // 
            this.u_MEDIDADataTextBox.CanGrow = true;
            this.u_MEDIDADataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7041666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.u_MEDIDADataTextBox.Name = "u_MEDIDADataTextBox";
            this.u_MEDIDADataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.u_MEDIDADataTextBox.StyleName = "Data";
            this.u_MEDIDADataTextBox.Value = "= Fields.U_MEDIDA";
            // 
            // cADUCIDADDataTextBox
            // 
            this.cADUCIDADDataTextBox.CanGrow = true;
            this.cADUCIDADDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2416665554046631D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.cADUCIDADDataTextBox.Name = "cADUCIDADDataTextBox";
            this.cADUCIDADDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cADUCIDADDataTextBox.StyleName = "Data";
            this.cADUCIDADDataTextBox.Value = "= Fields.CADUCIDAD";
            // 
            // cANTIDADDataTextBox
            // 
            this.cANTIDADDataTextBox.CanGrow = true;
            this.cANTIDADDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.7791666984558105D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.cANTIDADDataTextBox.Name = "cANTIDADDataTextBox";
            this.cANTIDADDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cANTIDADDataTextBox.StyleName = "Data";
            this.cANTIDADDataTextBox.Value = "= Fields.CANTIDAD";
            // 
            // cFDIDataTextBox
            // 
            this.cFDIDataTextBox.CanGrow = true;
            this.cFDIDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.3166666030883789D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.cFDIDataTextBox.Name = "cFDIDataTextBox";
            this.cFDIDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cFDIDataTextBox.StyleName = "Data";
            this.cFDIDataTextBox.Value = "= Fields.CFDI";
            // 
            // cOD_BARRASDataTextBox
            // 
            this.cOD_BARRASDataTextBox.CanGrow = true;
            this.cOD_BARRASDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.8541665077209473D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.cOD_BARRASDataTextBox.Name = "cOD_BARRASDataTextBox";
            this.cOD_BARRASDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cOD_BARRASDataTextBox.StyleName = "Data";
            this.cOD_BARRASDataTextBox.Value = "= Fields.COD_BARRAS";
            // 
            // cOMENTARIODataTextBox
            // 
            this.cOMENTARIODataTextBox.CanGrow = true;
            this.cOMENTARIODataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.3916668891906738D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.cOMENTARIODataTextBox.Name = "cOMENTARIODataTextBox";
            this.cOMENTARIODataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cOMENTARIODataTextBox.StyleName = "Data";
            this.cOMENTARIODataTextBox.Value = "= Fields.COMENTARIO";
            // 
            // fECHA_CREACIONDataTextBox
            // 
            this.fECHA_CREACIONDataTextBox.CanGrow = true;
            this.fECHA_CREACIONDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9291667938232422D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.fECHA_CREACIONDataTextBox.Name = "fECHA_CREACIONDataTextBox";
            this.fECHA_CREACIONDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52083331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.fECHA_CREACIONDataTextBox.StyleName = "Data";
            this.fECHA_CREACIONDataTextBox.Value = "= Fields.FECHA_CREACION";
            // 
            // Report1
            // 
            this.DataSource = this.sqlDataSource1;
            group1.GroupFooter = this.labelsGroupFooterSection;
            group1.GroupHeader = this.labelsGroupHeaderSection;
            group1.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.reportFooter,
            this.detail});
            this.Name = "Report1";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Bold = true;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule3.Style.Color = System.Drawing.Color.Black;
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule5.Style.Font.Name = "Tahoma";
            styleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4666666984558105D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox aLMACENCaptionTextBox;
        private Telerik.Reporting.TextBox p_COMPRACaptionTextBox;
        private Telerik.Reporting.TextBox p_MEDICOSCaptionTextBox;
        private Telerik.Reporting.TextBox p_VENTACaptionTextBox;
        private Telerik.Reporting.TextBox sTATUSCaptionTextBox;
        private Telerik.Reporting.TextBox u_MEDIDACaptionTextBox;
        private Telerik.Reporting.TextBox cADUCIDADCaptionTextBox;
        private Telerik.Reporting.TextBox cANTIDADCaptionTextBox;
        private Telerik.Reporting.TextBox cFDICaptionTextBox;
        private Telerik.Reporting.TextBox cOD_BARRASCaptionTextBox;
        private Telerik.Reporting.TextBox cOMENTARIOCaptionTextBox;
        private Telerik.Reporting.TextBox fECHA_CREACIONCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.TextBox nOMBRE_MEDICaptionTextBox;
        private Telerik.Reporting.TextBox nOMBRE_MEDIDataTextBox;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox aLMACENDataTextBox;
        private Telerik.Reporting.TextBox p_COMPRADataTextBox;
        private Telerik.Reporting.TextBox p_MEDICOSDataTextBox;
        private Telerik.Reporting.TextBox p_VENTADataTextBox;
        private Telerik.Reporting.TextBox sTATUSDataTextBox;
        private Telerik.Reporting.TextBox u_MEDIDADataTextBox;
        private Telerik.Reporting.TextBox cADUCIDADDataTextBox;
        private Telerik.Reporting.TextBox cANTIDADDataTextBox;
        private Telerik.Reporting.TextBox cFDIDataTextBox;
        private Telerik.Reporting.TextBox cOD_BARRASDataTextBox;
        private Telerik.Reporting.TextBox cOMENTARIODataTextBox;
        private Telerik.Reporting.TextBox fECHA_CREACIONDataTextBox;
    }
}