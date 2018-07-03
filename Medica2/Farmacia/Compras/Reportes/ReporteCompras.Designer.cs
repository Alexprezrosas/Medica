namespace Medica2.Farmacia.Compras.Reportes
{
    partial class ReporteCompras
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteCompras));
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
            this.nUM_FACTURACaptionTextBox = new Telerik.Reporting.TextBox();
            this.nOMBRECaptionTextBox = new Telerik.Reporting.TextBox();
            this.rFCCaptionTextBox = new Telerik.Reporting.TextBox();
            this.t_CELULARCaptionTextBox = new Telerik.Reporting.TextBox();
            this.fECHA_COMPRACaptionTextBox = new Telerik.Reporting.TextBox();
            this.fECHA_VENCIMIENTOCaptionTextBox = new Telerik.Reporting.TextBox();
            this.tOTALCaptionTextBox = new Telerik.Reporting.TextBox();
            this.nUM_FACTURAGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.nUM_FACTURAGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.nOMBREDataTextBox = new Telerik.Reporting.TextBox();
            this.rFCDataTextBox = new Telerik.Reporting.TextBox();
            this.t_CELULARDataTextBox = new Telerik.Reporting.TextBox();
            this.fECHA_COMPRADataTextBox = new Telerik.Reporting.TextBox();
            this.fECHA_VENCIMIENTODataTextBox = new Telerik.Reporting.TextBox();
            this.tOTALDataTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "BaseDatos";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.SelectCommand = resources.GetString("sqlDataSource1.SelectCommand");
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23333333432674408D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.nUM_FACTURACaptionTextBox,
            this.fECHA_COMPRACaptionTextBox,
            this.fECHA_VENCIMIENTOCaptionTextBox,
            this.nOMBRECaptionTextBox,
            this.rFCCaptionTextBox,
            this.t_CELULARCaptionTextBox,
            this.tOTALCaptionTextBox});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.22499999403953552D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // nUM_FACTURACaptionTextBox
            // 
            this.nUM_FACTURACaptionTextBox.CanGrow = true;
            this.nUM_FACTURACaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.nUM_FACTURACaptionTextBox.Name = "nUM_FACTURACaptionTextBox";
            this.nUM_FACTURACaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.699999988079071D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.nUM_FACTURACaptionTextBox.StyleName = "Caption";
            this.nUM_FACTURACaptionTextBox.Value = "Factura";
            // 
            // nOMBRECaptionTextBox
            // 
            this.nOMBRECaptionTextBox.CanGrow = true;
            this.nOMBRECaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.71674549579620361D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.nOMBRECaptionTextBox.Name = "nOMBRECaptionTextBox";
            this.nOMBRECaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.699999988079071D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.nOMBRECaptionTextBox.StyleName = "Caption";
            this.nOMBRECaptionTextBox.Value = "Proveedor";
            // 
            // rFCCaptionTextBox
            // 
            this.rFCCaptionTextBox.CanGrow = true;
            this.rFCCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.4168243408203125D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.rFCCaptionTextBox.Name = "rFCCaptionTextBox";
            this.rFCCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.699999988079071D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.rFCCaptionTextBox.StyleName = "Caption";
            this.rFCCaptionTextBox.Value = "RFC";
            // 
            // t_CELULARCaptionTextBox
            // 
            this.t_CELULARCaptionTextBox.CanGrow = true;
            this.t_CELULARCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1169030666351318D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.t_CELULARCaptionTextBox.Name = "t_CELULARCaptionTextBox";
            this.t_CELULARCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78301799297332764D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.t_CELULARCaptionTextBox.StyleName = "Caption";
            this.t_CELULARCaptionTextBox.Value = "Teléfono";
            // 
            // fECHA_COMPRACaptionTextBox
            // 
            this.fECHA_COMPRACaptionTextBox.CanGrow = true;
            this.fECHA_COMPRACaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.9000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.fECHA_COMPRACaptionTextBox.Name = "fECHA_COMPRACaptionTextBox";
            this.fECHA_COMPRACaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1999212503433228D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.fECHA_COMPRACaptionTextBox.StyleName = "Caption";
            this.fECHA_COMPRACaptionTextBox.Value = "Fecha de compra";
            // 
            // fECHA_VENCIMIENTOCaptionTextBox
            // 
            this.fECHA_VENCIMIENTOCaptionTextBox.CanGrow = true;
            this.fECHA_VENCIMIENTOCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.0999999046325684D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.fECHA_VENCIMIENTOCaptionTextBox.Name = "fECHA_VENCIMIENTOCaptionTextBox";
            this.fECHA_VENCIMIENTOCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4675995111465454D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.fECHA_VENCIMIENTOCaptionTextBox.StyleName = "Caption";
            this.fECHA_VENCIMIENTOCaptionTextBox.Value = "Fecha de vencimiento";
            // 
            // tOTALCaptionTextBox
            // 
            this.tOTALCaptionTextBox.CanGrow = true;
            this.tOTALCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.5676779747009277D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.tOTALCaptionTextBox.Name = "tOTALCaptionTextBox";
            this.tOTALCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.699999988079071D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.tOTALCaptionTextBox.StyleName = "Caption";
            this.tOTALCaptionTextBox.Value = "Total";
            // 
            // nUM_FACTURAGroupHeaderSection
            // 
            this.nUM_FACTURAGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23333333432674408D);
            this.nUM_FACTURAGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1});
            this.nUM_FACTURAGroupHeaderSection.Name = "nUM_FACTURAGroupHeaderSection";
            // 
            // nUM_FACTURAGroupFooterSection
            // 
            this.nUM_FACTURAGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.22499999403953552D);
            this.nUM_FACTURAGroupFooterSection.Name = "nUM_FACTURAGroupFooterSection";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.699999988079071D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox1.StyleName = "Data";
            this.textBox1.Value = "= Fields.NUM_FACTURA";
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.787401556968689D);
            this.pageHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox,
            this.reportNameTextBox});
            this.pageHeader.Name = "pageHeader";
            // 
            // reportNameTextBox
            // 
            this.reportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9333768654614687E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.reportNameTextBox.Name = "reportNameTextBox";
            this.reportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.2510504722595215D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.reportNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.reportNameTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.reportNameTextBox.StyleName = "PageInfo";
            this.reportNameTextBox.Value = "Reporte de Compras";
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
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.0593836307525635D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1917059421539307D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.2510108947753906D), Telerik.Reporting.Drawing.Unit.Inch(0.787401556968689D));
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
            this.nOMBREDataTextBox,
            this.rFCDataTextBox,
            this.t_CELULARDataTextBox,
            this.fECHA_COMPRADataTextBox,
            this.fECHA_VENCIMIENTODataTextBox,
            this.tOTALDataTextBox});
            this.detail.Name = "detail";
            // 
            // nOMBREDataTextBox
            // 
            this.nOMBREDataTextBox.CanGrow = true;
            this.nOMBREDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.73333334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.nOMBREDataTextBox.Name = "nOMBREDataTextBox";
            this.nOMBREDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.699999988079071D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.nOMBREDataTextBox.StyleName = "Data";
            this.nOMBREDataTextBox.Value = "= Fields.NOMBRE";
            // 
            // rFCDataTextBox
            // 
            this.rFCDataTextBox.CanGrow = true;
            this.rFCDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.4168243408203125D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.rFCDataTextBox.Name = "rFCDataTextBox";
            this.rFCDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.699999988079071D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.rFCDataTextBox.StyleName = "Data";
            this.rFCDataTextBox.Value = "= Fields.RFC";
            // 
            // t_CELULARDataTextBox
            // 
            this.t_CELULARDataTextBox.CanGrow = true;
            this.t_CELULARDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1999211311340332D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.t_CELULARDataTextBox.Name = "t_CELULARDataTextBox";
            this.t_CELULARDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.699999988079071D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.t_CELULARDataTextBox.StyleName = "Data";
            this.t_CELULARDataTextBox.Value = "= Fields.T_CELULAR";
            // 
            // fECHA_COMPRADataTextBox
            // 
            this.fECHA_COMPRADataTextBox.CanGrow = true;
            this.fECHA_COMPRADataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.0999999046325684D), Telerik.Reporting.Drawing.Unit.Inch(0.01666666753590107D));
            this.fECHA_COMPRADataTextBox.Name = "fECHA_COMPRADataTextBox";
            this.fECHA_COMPRADataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.699999988079071D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.fECHA_COMPRADataTextBox.StyleName = "Data";
            this.fECHA_COMPRADataTextBox.Value = "= Fields.FECHA_COMPRA";
            // 
            // fECHA_VENCIMIENTODataTextBox
            // 
            this.fECHA_VENCIMIENTODataTextBox.CanGrow = true;
            this.fECHA_VENCIMIENTODataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.fECHA_VENCIMIENTODataTextBox.Name = "fECHA_VENCIMIENTODataTextBox";
            this.fECHA_VENCIMIENTODataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.699999988079071D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.fECHA_VENCIMIENTODataTextBox.StyleName = "Data";
            this.fECHA_VENCIMIENTODataTextBox.Value = "= Fields.FECHA_VENCIMIENTO";
            // 
            // tOTALDataTextBox
            // 
            this.tOTALDataTextBox.CanGrow = true;
            this.tOTALDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.5676779747009277D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tOTALDataTextBox.Name = "tOTALDataTextBox";
            this.tOTALDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.699999988079071D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.tOTALDataTextBox.StyleName = "Data";
            this.tOTALDataTextBox.Value = "= Fields.TOTAL";
            // 
            // ReporteCompras
            // 
            this.DataSource = this.sqlDataSource1;
            group1.GroupFooter = this.labelsGroupFooterSection;
            group1.GroupHeader = this.labelsGroupHeaderSection;
            group1.Name = "labelsGroup";
            group2.GroupFooter = this.nUM_FACTURAGroupFooterSection;
            group2.GroupHeader = this.nUM_FACTURAGroupHeaderSection;
            group2.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.NUM_FACTURA"));
            group2.Name = "nUM_FACTURAGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1,
            group2});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.nUM_FACTURAGroupHeaderSection,
            this.nUM_FACTURAGroupFooterSection,
            this.pageHeader,
            this.pageFooter,
            this.reportFooter,
            this.detail});
            this.Name = "ReporteCompras";
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
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.2843837738037109D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox nUM_FACTURACaptionTextBox;
        private Telerik.Reporting.TextBox nOMBRECaptionTextBox;
        private Telerik.Reporting.TextBox rFCCaptionTextBox;
        private Telerik.Reporting.TextBox t_CELULARCaptionTextBox;
        private Telerik.Reporting.TextBox fECHA_COMPRACaptionTextBox;
        private Telerik.Reporting.TextBox fECHA_VENCIMIENTOCaptionTextBox;
        private Telerik.Reporting.TextBox tOTALCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection nUM_FACTURAGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.GroupFooterSection nUM_FACTURAGroupFooterSection;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox nOMBREDataTextBox;
        private Telerik.Reporting.TextBox rFCDataTextBox;
        private Telerik.Reporting.TextBox t_CELULARDataTextBox;
        private Telerik.Reporting.TextBox fECHA_COMPRADataTextBox;
        private Telerik.Reporting.TextBox fECHA_VENCIMIENTODataTextBox;
        private Telerik.Reporting.TextBox tOTALDataTextBox;
    }
}