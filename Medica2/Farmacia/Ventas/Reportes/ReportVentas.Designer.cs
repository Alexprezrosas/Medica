namespace Medica2.Farmacia.Ventas.Reportes
{
    partial class ReportVentas
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportVentas));
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group2 = new Telerik.Reporting.Group();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.nOMBREGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.nOMBREGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.nOMBRE_MEDICaptionTextBox = new Telerik.Reporting.TextBox();
            this.cOMENTARIOCaptionTextBox = new Telerik.Reporting.TextBox();
            this.cANTIDADCaptionTextBox = new Telerik.Reporting.TextBox();
            this.cOSTOCaptionTextBox = new Telerik.Reporting.TextBox();
            this.sUBTOTALCaptionTextBox = new Telerik.Reporting.TextBox();
            this.cLIENTECaptionTextBox = new Telerik.Reporting.TextBox();
            this.fECHA_CREACIONCaptionTextBox = new Telerik.Reporting.TextBox();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.a_PATERNODataTextBox = new Telerik.Reporting.TextBox();
            this.a_MATERNODataTextBox = new Telerik.Reporting.TextBox();
            this.nOMBRE_MEDIDataTextBox = new Telerik.Reporting.TextBox();
            this.cOMENTARIODataTextBox = new Telerik.Reporting.TextBox();
            this.cANTIDADDataTextBox = new Telerik.Reporting.TextBox();
            this.cOSTODataTextBox = new Telerik.Reporting.TextBox();
            this.sUBTOTALDataTextBox = new Telerik.Reporting.TextBox();
            this.cLIENTEDataTextBox = new Telerik.Reporting.TextBox();
            this.fECHA_CREACIONDataTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "BaseDatos";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.SelectCommand = resources.GetString("sqlDataSource1.SelectCommand");
            // 
            // nOMBREGroupHeaderSection
            // 
            this.nOMBREGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23333333432674408D);
            this.nOMBREGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2,
            this.a_PATERNODataTextBox,
            this.a_MATERNODataTextBox});
            this.nOMBREGroupHeaderSection.Name = "nOMBREGroupHeaderSection";
            // 
            // nOMBREGroupFooterSection
            // 
            this.nOMBREGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.22499999403953552D);
            this.nOMBREGroupFooterSection.Name = "nOMBREGroupFooterSection";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.68333333730697632D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "Nombre";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.70007884502410889D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0999213457107544D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox2.StyleName = "Data";
            this.textBox2.Value = "= Fields.NOMBRE";
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.24992115795612335D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.nOMBRE_MEDICaptionTextBox,
            this.cOMENTARIOCaptionTextBox,
            this.cANTIDADCaptionTextBox,
            this.cOSTOCaptionTextBox,
            this.sUBTOTALCaptionTextBox,
            this.cLIENTECaptionTextBox,
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
            // nOMBRE_MEDICaptionTextBox
            // 
            this.nOMBRE_MEDICaptionTextBox.CanGrow = true;
            this.nOMBRE_MEDICaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.800078809261322D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.nOMBRE_MEDICaptionTextBox.Name = "nOMBRE_MEDICaptionTextBox";
            this.nOMBRE_MEDICaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.140905499458313D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.nOMBRE_MEDICaptionTextBox.StyleName = "Caption";
            this.nOMBRE_MEDICaptionTextBox.Value = "Medicamento";
            // 
            // cOMENTARIOCaptionTextBox
            // 
            this.cOMENTARIOCaptionTextBox.CanGrow = true;
            this.cOMENTARIOCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.9410631656646729D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.cOMENTARIOCaptionTextBox.Name = "cOMENTARIOCaptionTextBox";
            this.cOMENTARIOCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0589368343353272D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cOMENTARIOCaptionTextBox.StyleName = "Caption";
            this.cOMENTARIOCaptionTextBox.Value = "Descripción";
            // 
            // cANTIDADCaptionTextBox
            // 
            this.cANTIDADCaptionTextBox.CanGrow = true;
            this.cANTIDADCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.0000786781311035D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.cANTIDADCaptionTextBox.Name = "cANTIDADCaptionTextBox";
            this.cANTIDADCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69992148876190186D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cANTIDADCaptionTextBox.StyleName = "Caption";
            this.cANTIDADCaptionTextBox.Value = "Cantidad";
            // 
            // cOSTOCaptionTextBox
            // 
            this.cOSTOCaptionTextBox.CanGrow = true;
            this.cOSTOCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.7000782489776611D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.cOSTOCaptionTextBox.Name = "cOSTOCaptionTextBox";
            this.cOSTOCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.56573492288589478D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cOSTOCaptionTextBox.StyleName = "Caption";
            this.cOSTOCaptionTextBox.Value = "Costo";
            // 
            // sUBTOTALCaptionTextBox
            // 
            this.sUBTOTALCaptionTextBox.CanGrow = true;
            this.sUBTOTALCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2658915519714355D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.sUBTOTALCaptionTextBox.Name = "sUBTOTALCaptionTextBox";
            this.sUBTOTALCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.68333339691162109D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.sUBTOTALCaptionTextBox.StyleName = "Caption";
            this.sUBTOTALCaptionTextBox.Value = "Subtotal";
            // 
            // cLIENTECaptionTextBox
            // 
            this.cLIENTECaptionTextBox.CanGrow = true;
            this.cLIENTECaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.cLIENTECaptionTextBox.Name = "cLIENTECaptionTextBox";
            this.cLIENTECaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78333336114883423D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cLIENTECaptionTextBox.StyleName = "Caption";
            this.cLIENTECaptionTextBox.Value = "Cliente";
            // 
            // fECHA_CREACIONCaptionTextBox
            // 
            this.fECHA_CREACIONCaptionTextBox.CanGrow = true;
            this.fECHA_CREACIONCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.949303150177002D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.fECHA_CREACIONCaptionTextBox.Name = "fECHA_CREACIONCaptionTextBox";
            this.fECHA_CREACIONCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3184137344360352D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.fECHA_CREACIONCaptionTextBox.StyleName = "Caption";
            this.fECHA_CREACIONCaptionTextBox.Value = "FECHA_CREACION";
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23333333432674408D);
            this.pageHeader.Name = "pageHeader";
            // 
            // reportNameTextBox
            // 
            this.reportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0.36666667461395264D));
            this.reportNameTextBox.Name = "reportNameTextBox";
            this.reportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.2010498046875D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.reportNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.reportNameTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.reportNameTextBox.StyleName = "PageInfo";
            this.reportNameTextBox.Value = "Reporte de ventas generales";
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
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.nOMBRE_MEDIDataTextBox,
            this.cOMENTARIODataTextBox,
            this.cANTIDADDataTextBox,
            this.cOSTODataTextBox,
            this.sUBTOTALDataTextBox,
            this.fECHA_CREACIONDataTextBox,
            this.cLIENTEDataTextBox});
            this.detail.Name = "detail";
            // 
            // a_PATERNODataTextBox
            // 
            this.a_PATERNODataTextBox.CanGrow = true;
            this.a_PATERNODataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.8000787496566773D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.a_PATERNODataTextBox.Name = "a_PATERNODataTextBox";
            this.a_PATERNODataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.92322826385498047D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.a_PATERNODataTextBox.StyleName = "Data";
            this.a_PATERNODataTextBox.Value = "= Fields.A_PATERNO";
            // 
            // a_MATERNODataTextBox
            // 
            this.a_MATERNODataTextBox.CanGrow = true;
            this.a_MATERNODataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7233858108520508D), Telerik.Reporting.Drawing.Unit.Inch(0.02019704133272171D));
            this.a_MATERNODataTextBox.Name = "a_MATERNODataTextBox";
            this.a_MATERNODataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.97661417722702026D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.a_MATERNODataTextBox.StyleName = "Data";
            this.a_MATERNODataTextBox.Value = "= Fields.A_MATERNO";
            // 
            // nOMBRE_MEDIDataTextBox
            // 
            this.nOMBRE_MEDIDataTextBox.CanGrow = true;
            this.nOMBRE_MEDIDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.800078809261322D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.nOMBRE_MEDIDataTextBox.Name = "nOMBRE_MEDIDataTextBox";
            this.nOMBRE_MEDIDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.140905499458313D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.nOMBRE_MEDIDataTextBox.StyleName = "Data";
            this.nOMBRE_MEDIDataTextBox.Value = "= Fields.NOMBRE_MEDI";
            // 
            // cOMENTARIODataTextBox
            // 
            this.cOMENTARIODataTextBox.CanGrow = true;
            this.cOMENTARIODataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.9410631656646729D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.cOMENTARIODataTextBox.Name = "cOMENTARIODataTextBox";
            this.cOMENTARIODataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0589368343353272D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cOMENTARIODataTextBox.StyleName = "Data";
            this.cOMENTARIODataTextBox.Value = "= Fields.COMENTARIO";
            // 
            // cANTIDADDataTextBox
            // 
            this.cANTIDADDataTextBox.CanGrow = true;
            this.cANTIDADDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.0000786781311035D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.cANTIDADDataTextBox.Name = "cANTIDADDataTextBox";
            this.cANTIDADDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69992148876190186D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cANTIDADDataTextBox.StyleName = "Data";
            this.cANTIDADDataTextBox.Value = "= Fields.CANTIDAD";
            // 
            // cOSTODataTextBox
            // 
            this.cOSTODataTextBox.CanGrow = true;
            this.cOSTODataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.7000782489776611D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.cOSTODataTextBox.Name = "cOSTODataTextBox";
            this.cOSTODataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.56573492288589478D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cOSTODataTextBox.StyleName = "Data";
            this.cOSTODataTextBox.Value = "= Fields.COSTO";
            // 
            // sUBTOTALDataTextBox
            // 
            this.sUBTOTALDataTextBox.CanGrow = true;
            this.sUBTOTALDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2658915519714355D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.sUBTOTALDataTextBox.Name = "sUBTOTALDataTextBox";
            this.sUBTOTALDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.68333339691162109D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.sUBTOTALDataTextBox.StyleName = "Data";
            this.sUBTOTALDataTextBox.Value = "= Fields.SUBTOTAL";
            // 
            // cLIENTEDataTextBox
            // 
            this.cLIENTEDataTextBox.CanGrow = true;
            this.cLIENTEDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9164224290288985E-05D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.cLIENTEDataTextBox.Name = "cLIENTEDataTextBox";
            this.cLIENTEDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.7999609112739563D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cLIENTEDataTextBox.StyleName = "Data";
            this.cLIENTEDataTextBox.Value = "= Fields.CLIENTE";
            // 
            // fECHA_CREACIONDataTextBox
            // 
            this.fECHA_CREACIONDataTextBox.CanGrow = true;
            this.fECHA_CREACIONDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.949303150177002D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.fECHA_CREACIONDataTextBox.Name = "fECHA_CREACIONDataTextBox";
            this.fECHA_CREACIONDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3183746337890625D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.fECHA_CREACIONDataTextBox.StyleName = "Data";
            this.fECHA_CREACIONDataTextBox.Value = "= Fields.FECHA_CREACION";
            // 
            // ReportVentas
            // 
            this.DataSource = this.sqlDataSource1;
            group1.GroupFooter = this.nOMBREGroupFooterSection;
            group1.GroupHeader = this.nOMBREGroupHeaderSection;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.NOMBRE"));
            group1.Name = "nOMBREGroup";
            group2.GroupFooter = this.labelsGroupFooterSection;
            group2.GroupHeader = this.labelsGroupHeaderSection;
            group2.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1,
            group2});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.nOMBREGroupHeaderSection,
            this.nOMBREGroupFooterSection,
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.reportFooter,
            this.detail});
            this.Name = "ReportVentas";
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
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.2677168846130371D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection nOMBREGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox a_PATERNODataTextBox;
        private Telerik.Reporting.TextBox a_MATERNODataTextBox;
        private Telerik.Reporting.GroupFooterSection nOMBREGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox nOMBRE_MEDICaptionTextBox;
        private Telerik.Reporting.TextBox cOMENTARIOCaptionTextBox;
        private Telerik.Reporting.TextBox cANTIDADCaptionTextBox;
        private Telerik.Reporting.TextBox cOSTOCaptionTextBox;
        private Telerik.Reporting.TextBox sUBTOTALCaptionTextBox;
        private Telerik.Reporting.TextBox cLIENTECaptionTextBox;
        private Telerik.Reporting.TextBox fECHA_CREACIONCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox nOMBRE_MEDIDataTextBox;
        private Telerik.Reporting.TextBox cOMENTARIODataTextBox;
        private Telerik.Reporting.TextBox cANTIDADDataTextBox;
        private Telerik.Reporting.TextBox cOSTODataTextBox;
        private Telerik.Reporting.TextBox sUBTOTALDataTextBox;
        private Telerik.Reporting.TextBox fECHA_CREACIONDataTextBox;
        private Telerik.Reporting.TextBox cLIENTEDataTextBox;
    }
}