namespace H___Invoicing_Solutions
{
    partial class reports
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reports));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkAllCust = new System.Windows.Forms.CheckBox();
            this.checkSignledate = new System.Windows.Forms.CheckBox();
            this.checkMultidate = new System.Windows.Forms.CheckBox();
            this.checkSinglename = new System.Windows.Forms.CheckBox();
            this.checkSinglesales = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkNosort = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxstatus = new System.Windows.Forms.ComboBox();
            this.btndelstore = new System.Windows.Forms.Button();
            this.btnaddstore = new System.Windows.Forms.Button();
            this.btndeletes = new System.Windows.Forms.Button();
            this.btnadds = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkMultiname = new System.Windows.Forms.CheckBox();
            this.datagridname = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxstorename = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkMultisale = new System.Windows.Forms.CheckBox();
            this.dataGridsales = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxsales = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.Undo = new System.Windows.Forms.Button();
            this.btnpview = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.datagridload = new System.Windows.Forms.DataGridView();
            this.btnload = new System.Windows.Forms.Button();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridsales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridload)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkAllCust);
            this.groupBox1.Controls.Add(this.checkSignledate);
            this.groupBox1.Controls.Add(this.checkMultidate);
            this.groupBox1.Controls.Add(this.checkSinglename);
            this.groupBox1.Controls.Add(this.checkSinglesales);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btndelstore);
            this.groupBox1.Controls.Add(this.btnaddstore);
            this.groupBox1.Controls.Add(this.btndeletes);
            this.groupBox1.Controls.Add(this.btnadds);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.checkMultiname);
            this.groupBox1.Controls.Add(this.datagridname);
            this.groupBox1.Controls.Add(this.comboBoxstorename);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkMultisale);
            this.groupBox1.Controls.Add(this.dataGridsales);
            this.groupBox1.Controls.Add(this.comboBoxsales);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(13, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1159, 201);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Settings";
            // 
            // checkAllCust
            // 
            this.checkAllCust.AutoSize = true;
            this.checkAllCust.Location = new System.Drawing.Point(521, 178);
            this.checkAllCust.Name = "checkAllCust";
            this.checkAllCust.Size = new System.Drawing.Size(84, 17);
            this.checkAllCust.TabIndex = 22;
            this.checkAllCust.Text = "All Customer";
            this.checkAllCust.UseVisualStyleBackColor = true;
            this.checkAllCust.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkSignledate
            // 
            this.checkSignledate.AutoSize = true;
            this.checkSignledate.Location = new System.Drawing.Point(53, 94);
            this.checkSignledate.Name = "checkSignledate";
            this.checkSignledate.Size = new System.Drawing.Size(77, 17);
            this.checkSignledate.TabIndex = 21;
            this.checkSignledate.Text = "Single Sort";
            this.checkSignledate.UseVisualStyleBackColor = true;
            this.checkSignledate.CheckedChanged += new System.EventHandler(this.checkSignledate_CheckedChanged);
            // 
            // checkMultidate
            // 
            this.checkMultidate.AutoSize = true;
            this.checkMultidate.Location = new System.Drawing.Point(136, 94);
            this.checkMultidate.Name = "checkMultidate";
            this.checkMultidate.Size = new System.Drawing.Size(70, 17);
            this.checkMultidate.TabIndex = 20;
            this.checkMultidate.Text = "Multi Sort";
            this.checkMultidate.UseVisualStyleBackColor = true;
            this.checkMultidate.CheckedChanged += new System.EventHandler(this.checkMultidate_CheckedChanged);
            // 
            // checkSinglename
            // 
            this.checkSinglename.AutoSize = true;
            this.checkSinglename.Location = new System.Drawing.Point(611, 178);
            this.checkSinglename.Name = "checkSinglename";
            this.checkSinglename.Size = new System.Drawing.Size(77, 17);
            this.checkSinglename.TabIndex = 19;
            this.checkSinglename.Text = "Signle Sort";
            this.checkSinglename.UseVisualStyleBackColor = true;
            this.checkSinglename.CheckedChanged += new System.EventHandler(this.checkSinglename_CheckedChanged);
            // 
            // checkSinglesales
            // 
            this.checkSinglesales.AutoSize = true;
            this.checkSinglesales.Location = new System.Drawing.Point(324, 178);
            this.checkSinglesales.Name = "checkSinglesales";
            this.checkSinglesales.Size = new System.Drawing.Size(77, 17);
            this.checkSinglesales.TabIndex = 18;
            this.checkSinglesales.Text = "Single Sort";
            this.checkSinglesales.UseVisualStyleBackColor = true;
            this.checkSinglesales.CheckedChanged += new System.EventHandler(this.checkSinglesales_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkNosort);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboBoxstatus);
            this.groupBox2.Location = new System.Drawing.Point(968, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 170);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "More Options";
            // 
            // checkNosort
            // 
            this.checkNosort.AutoSize = true;
            this.checkNosort.Location = new System.Drawing.Point(9, 125);
            this.checkNosort.Name = "checkNosort";
            this.checkNosort.Size = new System.Drawing.Size(62, 17);
            this.checkNosort.TabIndex = 22;
            this.checkNosort.Text = "No Sort";
            this.checkNosort.UseVisualStyleBackColor = true;
            this.checkNosort.CheckedChanged += new System.EventHandler(this.checkNosort_CheckedChanged);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(6, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 44);
            this.label6.TabIndex = 22;
            this.label6.Text = "* By Enabling Report will be only sortedby date.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Status";
            // 
            // comboBoxstatus
            // 
            this.comboBoxstatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxstatus.FormattingEnabled = true;
            this.comboBoxstatus.Items.AddRange(new object[] {
            "Unpaid",
            "Paid",
            "Returned"});
            this.comboBoxstatus.Location = new System.Drawing.Point(9, 40);
            this.comboBoxstatus.Name = "comboBoxstatus";
            this.comboBoxstatus.Size = new System.Drawing.Size(162, 21);
            this.comboBoxstatus.TabIndex = 18;
            // 
            // btndelstore
            // 
            this.btndelstore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndelstore.Enabled = false;
            this.btndelstore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelstore.ForeColor = System.Drawing.Color.Transparent;
            this.btndelstore.Image = ((System.Drawing.Image)(resources.GetObject("btndelstore.Image")));
            this.btndelstore.Location = new System.Drawing.Point(723, 23);
            this.btndelstore.Name = "btndelstore";
            this.btndelstore.Size = new System.Drawing.Size(41, 39);
            this.btndelstore.TabIndex = 16;
            this.btndelstore.UseVisualStyleBackColor = true;
            this.btndelstore.Click += new System.EventHandler(this.btndelstore_Click);
            // 
            // btnaddstore
            // 
            this.btnaddstore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnaddstore.Enabled = false;
            this.btnaddstore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddstore.ForeColor = System.Drawing.Color.Transparent;
            this.btnaddstore.Image = ((System.Drawing.Image)(resources.GetObject("btnaddstore.Image")));
            this.btnaddstore.Location = new System.Drawing.Point(676, 23);
            this.btnaddstore.Name = "btnaddstore";
            this.btnaddstore.Size = new System.Drawing.Size(41, 39);
            this.btnaddstore.TabIndex = 15;
            this.btnaddstore.UseVisualStyleBackColor = true;
            this.btnaddstore.Click += new System.EventHandler(this.btnaddstore_Click);
            // 
            // btndeletes
            // 
            this.btndeletes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndeletes.Enabled = false;
            this.btndeletes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeletes.ForeColor = System.Drawing.Color.Transparent;
            this.btndeletes.Image = ((System.Drawing.Image)(resources.GetObject("btndeletes.Image")));
            this.btndeletes.Location = new System.Drawing.Point(439, 22);
            this.btndeletes.Name = "btndeletes";
            this.btndeletes.Size = new System.Drawing.Size(41, 39);
            this.btndeletes.TabIndex = 14;
            this.btndeletes.UseVisualStyleBackColor = true;
            this.btndeletes.Click += new System.EventHandler(this.btndeletes_Click);
            // 
            // btnadds
            // 
            this.btnadds.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadds.Enabled = false;
            this.btnadds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadds.ForeColor = System.Drawing.Color.Transparent;
            this.btnadds.Image = ((System.Drawing.Image)(resources.GetObject("btnadds.Image")));
            this.btnadds.Location = new System.Drawing.Point(392, 22);
            this.btnadds.Name = "btnadds";
            this.btnadds.Size = new System.Drawing.Size(41, 39);
            this.btnadds.TabIndex = 13;
            this.btnadds.UseVisualStyleBackColor = true;
            this.btnadds.Click += new System.EventHandler(this.btnadds_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(493, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Customer List";
            // 
            // checkMultiname
            // 
            this.checkMultiname.AutoSize = true;
            this.checkMultiname.Location = new System.Drawing.Point(694, 179);
            this.checkMultiname.Name = "checkMultiname";
            this.checkMultiname.Size = new System.Drawing.Size(70, 17);
            this.checkMultiname.TabIndex = 11;
            this.checkMultiname.Text = "Multi Sort";
            this.checkMultiname.UseVisualStyleBackColor = true;
            this.checkMultiname.CheckedChanged += new System.EventHandler(this.checkMultiname_CheckedChanged);
            // 
            // datagridname
            // 
            this.datagridname.AllowUserToAddRows = false;
            this.datagridname.AllowUserToDeleteRows = false;
            this.datagridname.AllowUserToResizeColumns = false;
            this.datagridname.AllowUserToResizeRows = false;
            this.datagridname.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridname.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.storename});
            this.datagridname.Enabled = false;
            this.datagridname.Location = new System.Drawing.Point(496, 68);
            this.datagridname.Name = "datagridname";
            this.datagridname.ReadOnly = true;
            this.datagridname.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.datagridname.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridname.Size = new System.Drawing.Size(268, 105);
            this.datagridname.TabIndex = 10;
            this.datagridname.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "No#";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // storename
            // 
            this.storename.HeaderText = "Name";
            this.storename.Name = "storename";
            this.storename.ReadOnly = true;
            this.storename.Width = 180;
            // 
            // comboBoxstorename
            // 
            this.comboBoxstorename.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxstorename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxstorename.Enabled = false;
            this.comboBoxstorename.FormattingEnabled = true;
            this.comboBoxstorename.Location = new System.Drawing.Point(496, 32);
            this.comboBoxstorename.Name = "comboBoxstorename";
            this.comboBoxstorename.Size = new System.Drawing.Size(174, 21);
            this.comboBoxstorename.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Salesman";
            // 
            // checkMultisale
            // 
            this.checkMultisale.AutoSize = true;
            this.checkMultisale.Location = new System.Drawing.Point(407, 178);
            this.checkMultisale.Name = "checkMultisale";
            this.checkMultisale.Size = new System.Drawing.Size(70, 17);
            this.checkMultisale.TabIndex = 7;
            this.checkMultisale.Text = "Multi Sort";
            this.checkMultisale.UseVisualStyleBackColor = true;
            this.checkMultisale.CheckedChanged += new System.EventHandler(this.checkMultisale_CheckedChanged);
            // 
            // dataGridsales
            // 
            this.dataGridsales.AllowUserToAddRows = false;
            this.dataGridsales.AllowUserToDeleteRows = false;
            this.dataGridsales.AllowUserToResizeColumns = false;
            this.dataGridsales.AllowUserToResizeRows = false;
            this.dataGridsales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridsales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.name});
            this.dataGridsales.Enabled = false;
            this.dataGridsales.Location = new System.Drawing.Point(234, 68);
            this.dataGridsales.Name = "dataGridsales";
            this.dataGridsales.ReadOnly = true;
            this.dataGridsales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridsales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridsales.Size = new System.Drawing.Size(243, 105);
            this.dataGridsales.TabIndex = 6;
            // 
            // no
            // 
            this.no.HeaderText = "No#";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.Width = 50;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // comboBoxsales
            // 
            this.comboBoxsales.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxsales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxsales.Enabled = false;
            this.comboBoxsales.FormattingEnabled = true;
            this.comboBoxsales.Location = new System.Drawing.Point(234, 32);
            this.comboBoxsales.Name = "comboBoxsales";
            this.comboBoxsales.Size = new System.Drawing.Size(141, 21);
            this.comboBoxsales.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(53, 68);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(147, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(53, 33);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(147, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Undo
            // 
            this.Undo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Undo.Enabled = false;
            this.Undo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Undo.ForeColor = System.Drawing.Color.Transparent;
            this.Undo.Image = ((System.Drawing.Image)(resources.GetObject("Undo.Image")));
            this.Undo.Location = new System.Drawing.Point(1105, 486);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(70, 63);
            this.Undo.TabIndex = 21;
            this.Undo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Undo.UseVisualStyleBackColor = true;
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // btnpview
            // 
            this.btnpview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnpview.Enabled = false;
            this.btnpview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpview.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnpview.Image = ((System.Drawing.Image)(resources.GetObject("btnpview.Image")));
            this.btnpview.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnpview.Location = new System.Drawing.Point(1002, 486);
            this.btnpview.Name = "btnpview";
            this.btnpview.Size = new System.Drawing.Size(78, 63);
            this.btnpview.TabIndex = 20;
            this.btnpview.Text = "View";
            this.btnpview.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnpview.UseVisualStyleBackColor = true;
            this.btnpview.Click += new System.EventHandler(this.btnpview_Click);
            // 
            // btnprint
            // 
            this.btnprint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnprint.Enabled = false;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnprint.Location = new System.Drawing.Point(904, 486);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(78, 63);
            this.btnprint.TabIndex = 19;
            this.btnprint.Text = "Print Bill";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // datagridload
            // 
            this.datagridload.AllowUserToAddRows = false;
            this.datagridload.AllowUserToDeleteRows = false;
            this.datagridload.AllowUserToResizeColumns = false;
            this.datagridload.AllowUserToResizeRows = false;
            this.datagridload.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.datagridload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridload.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagridload.Location = new System.Drawing.Point(28, 19);
            this.datagridload.Name = "datagridload";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridload.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.datagridload.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.datagridload.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridload.Size = new System.Drawing.Size(645, 186);
            this.datagridload.TabIndex = 22;
            // 
            // btnload
            // 
            this.btnload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnload.ForeColor = System.Drawing.Color.Transparent;
            this.btnload.Image = ((System.Drawing.Image)(resources.GetObject("btnload.Image")));
            this.btnload.Location = new System.Drawing.Point(606, 221);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(65, 46);
            this.btnload.TabIndex = 23;
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.button1_Click);
            this.btnload.MouseHover += new System.EventHandler(this.btnload_MouseHover);
            // 
            // btnrefresh
            // 
            this.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrefresh.Enabled = false;
            this.btnrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrefresh.ForeColor = System.Drawing.Color.Transparent;
            this.btnrefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnrefresh.Image")));
            this.btnrefresh.Location = new System.Drawing.Point(531, 221);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(65, 46);
            this.btnrefresh.TabIndex = 24;
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.button1_Click_1);
            this.btnrefresh.MouseHover += new System.EventHandler(this.btnrefresh_MouseHover);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnload);
            this.groupBox3.Controls.Add(this.btnrefresh);
            this.groupBox3.Controls.Add(this.datagridload);
            this.groupBox3.Location = new System.Drawing.Point(13, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(683, 282);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report Data";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.Undo);
            this.Controls.Add(this.btnpview);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "H-Invoicing Solutions | Reports";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Info_FormClosing);
            this.Load += new System.EventHandler(this.Info_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridsales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridload)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkMultiname;
        private System.Windows.Forms.DataGridView datagridname;
        private System.Windows.Forms.ComboBox comboBoxstorename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkMultisale;
        private System.Windows.Forms.DataGridView dataGridsales;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.ComboBox comboBoxsales;
        private System.Windows.Forms.Button btndelstore;
        private System.Windows.Forms.Button btnaddstore;
        private System.Windows.Forms.Button btndeletes;
        private System.Windows.Forms.Button btnadds;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxstatus;
        private System.Windows.Forms.CheckBox checkSignledate;
        private System.Windows.Forms.CheckBox checkMultidate;
        private System.Windows.Forms.CheckBox checkSinglename;
        private System.Windows.Forms.CheckBox checkSinglesales;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button Undo;
        private System.Windows.Forms.Button btnpview;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.DataGridView datagridload;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.CheckBox checkNosort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn storename;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkAllCust;
    }
}