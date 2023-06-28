﻿namespace EASEncoder_UI
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.comboState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCounty = new System.Windows.Forms.Label();
            this.comboCounty = new System.Windows.Forms.ComboBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.comboCode = new System.Windows.Forms.ComboBox();
            this.lblOriginator = new System.Windows.Forms.Label();
            this.comboOriginator = new System.Windows.Forms.ComboBox();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.lblEventBegin = new System.Windows.Forms.Label();
            this.lblValidHours = new System.Windows.Forms.Label();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chkEbsTones = new System.Windows.Forms.CheckBox();
            this.chkNwsTone = new System.Windows.Forms.CheckBox();
            this.txtAnnouncement = new System.Windows.Forms.TextBox();
            this.btnGeneratePlay = new System.Windows.Forms.Button();
            this.datagridRegions = new System.Windows.Forms.DataGridView();
            this.btnAddRegion = new System.Windows.Forms.Button();
            this.lblAddedLocations = new System.Windows.Forms.Label();
            this.lblAnnouncement = new System.Windows.Forms.Label();
            this.comboLengthHour = new System.Windows.Forms.ComboBox();
            this.comboLengthMinutes = new System.Windows.Forms.ComboBox();
            this.lblValidMinutes = new System.Windows.Forms.Label();
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblOutputDirectory = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnGenerateCustom = new System.Windows.Forms.Button();
            this.btnTTSSettings = new System.Windows.Forms.Button();
            this.lblGeneratedHeader = new System.Windows.Forms.Label();
            this.txtGeneratedData = new System.Windows.Forms.TextBox();
            this.chkBurstHeaders = new System.Windows.Forms.CheckBox();
            this.btnGenerateTTSOnly = new System.Windows.Forms.Button();
            this.PlayCountdown = new System.Windows.Forms.Timer(this.components);
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblVoice = new System.Windows.Forms.Label();
            this.combo = new System.Windows.Forms.ComboBox();
            this.LocationContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopyHeader = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.EditContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolUndoRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.datagridRegions)).BeginInit();
            this.LocationContextMenu.SuspendLayout();
            this.EditContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboState
            // 
            this.comboState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboState.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboState.ForeColor = System.Drawing.Color.White;
            this.comboState.FormattingEnabled = true;
            this.comboState.Location = new System.Drawing.Point(9, 209);
            this.comboState.Margin = new System.Windows.Forms.Padding(2);
            this.comboState.Name = "comboState";
            this.comboState.Size = new System.Drawing.Size(236, 29);
            this.comboState.TabIndex = 6;
            this.comboState.Tag = "disable";
            this.comboState.SelectedIndexChanged += new System.EventHandler(this.ComboState_SelectedIndexChanged);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblState.Location = new System.Drawing.Point(6, 191);
            this.lblState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(33, 15);
            this.lblState.TabIndex = 100;
            this.lblState.Text = "State";
            // 
            // lblCounty
            // 
            this.lblCounty.AutoSize = true;
            this.lblCounty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCounty.Location = new System.Drawing.Point(265, 191);
            this.lblCounty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCounty.Name = "lblCounty";
            this.lblCounty.Size = new System.Drawing.Size(46, 15);
            this.lblCounty.TabIndex = 100;
            this.lblCounty.Text = "County";
            // 
            // comboCounty
            // 
            this.comboCounty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboCounty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCounty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboCounty.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboCounty.ForeColor = System.Drawing.Color.White;
            this.comboCounty.FormattingEnabled = true;
            this.comboCounty.Location = new System.Drawing.Point(268, 209);
            this.comboCounty.Margin = new System.Windows.Forms.Padding(2);
            this.comboCounty.Name = "comboCounty";
            this.comboCounty.Size = new System.Drawing.Size(217, 29);
            this.comboCounty.TabIndex = 7;
            this.comboCounty.Tag = "disable";
            this.comboCounty.SelectedIndexChanged += new System.EventHandler(this.ComboCounty_SelectedIndexChanged);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCode.Location = new System.Drawing.Point(6, 69);
            this.lblCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(35, 15);
            this.lblCode.TabIndex = 100;
            this.lblCode.Text = "Code";
            // 
            // comboCode
            // 
            this.comboCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboCode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboCode.ForeColor = System.Drawing.Color.White;
            this.comboCode.FormattingEnabled = true;
            this.comboCode.Location = new System.Drawing.Point(9, 86);
            this.comboCode.Margin = new System.Windows.Forms.Padding(2);
            this.comboCode.Name = "comboCode";
            this.comboCode.Size = new System.Drawing.Size(477, 29);
            this.comboCode.TabIndex = 2;
            this.comboCode.Tag = "disable";
            this.comboCode.SelectedIndexChanged += new System.EventHandler(this.ComboCode_SelectedIndexChanged);
            // 
            // lblOriginator
            // 
            this.lblOriginator.AutoSize = true;
            this.lblOriginator.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOriginator.Location = new System.Drawing.Point(6, 12);
            this.lblOriginator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOriginator.Name = "lblOriginator";
            this.lblOriginator.Size = new System.Drawing.Size(61, 15);
            this.lblOriginator.TabIndex = 100;
            this.lblOriginator.Text = "Originator";
            // 
            // comboOriginator
            // 
            this.comboOriginator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboOriginator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOriginator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboOriginator.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboOriginator.ForeColor = System.Drawing.Color.White;
            this.comboOriginator.FormattingEnabled = true;
            this.comboOriginator.Location = new System.Drawing.Point(9, 29);
            this.comboOriginator.Margin = new System.Windows.Forms.Padding(2);
            this.comboOriginator.Name = "comboOriginator";
            this.comboOriginator.Size = new System.Drawing.Size(278, 29);
            this.comboOriginator.TabIndex = 0;
            this.comboOriginator.Tag = "disable";
            this.comboOriginator.SelectedIndexChanged += new System.EventHandler(this.ComboOriginator_SelectedIndexChanged);
            // 
            // dateStart
            // 
            this.dateStart.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.dateStart.CalendarForeColor = System.Drawing.Color.White;
            this.dateStart.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dateStart.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dateStart.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dateStart.CalendarTrailingForeColor = System.Drawing.Color.DimGray;
            this.dateStart.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dateStart.Location = new System.Drawing.Point(9, 149);
            this.dateStart.Margin = new System.Windows.Forms.Padding(2);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(278, 29);
            this.dateStart.TabIndex = 3;
            this.dateStart.Tag = "disable";
            // 
            // lblEventBegin
            // 
            this.lblEventBegin.AutoSize = true;
            this.lblEventBegin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEventBegin.Location = new System.Drawing.Point(6, 132);
            this.lblEventBegin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEventBegin.Name = "lblEventBegin";
            this.lblEventBegin.Size = new System.Drawing.Size(98, 15);
            this.lblEventBegin.TabIndex = 100;
            this.lblEventBegin.Text = "Event Begin Time";
            // 
            // lblValidHours
            // 
            this.lblValidHours.AutoSize = true;
            this.lblValidHours.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblValidHours.Location = new System.Drawing.Point(296, 132);
            this.lblValidHours.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValidHours.Name = "lblValidHours";
            this.lblValidHours.Size = new System.Drawing.Size(93, 15);
            this.lblValidHours.TabIndex = 100;
            this.lblValidHours.Text = "Valid for (Hours)";
            // 
            // txtSender
            // 
            this.txtSender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtSender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSender.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSender.ForeColor = System.Drawing.Color.White;
            this.txtSender.Location = new System.Drawing.Point(299, 29);
            this.txtSender.Margin = new System.Windows.Forms.Padding(2);
            this.txtSender.MaxLength = 8;
            this.txtSender.Multiline = true;
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(187, 29);
            this.txtSender.TabIndex = 1;
            this.txtSender.Tag = "disable";
            this.txtSender.TextChanged += new System.EventHandler(this.txtSender_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(296, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 15);
            this.label7.TabIndex = 100;
            this.label7.Text = "Sender ID (8 Chars)";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGenerate.Location = new System.Drawing.Point(962, 311);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(147, 57);
            this.btnGenerate.TabIndex = 20;
            this.btnGenerate.Tag = "disable";
            this.btnGenerate.Text = "Save Output\r\nas *.WAV";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // chkEbsTones
            // 
            this.chkEbsTones.AutoSize = true;
            this.chkEbsTones.Checked = true;
            this.chkEbsTones.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEbsTones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEbsTones.Location = new System.Drawing.Point(508, 13);
            this.chkEbsTones.Margin = new System.Windows.Forms.Padding(2);
            this.chkEbsTones.Name = "chkEbsTones";
            this.chkEbsTones.Size = new System.Drawing.Size(189, 25);
            this.chkEbsTones.TabIndex = 11;
            this.chkEbsTones.Tag = "disable";
            this.chkEbsTones.Text = "Use EBS Attention Tone";
            this.chkEbsTones.UseVisualStyleBackColor = true;
            // 
            // chkNwsTone
            // 
            this.chkNwsTone.AutoSize = true;
            this.chkNwsTone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNwsTone.Location = new System.Drawing.Point(508, 41);
            this.chkNwsTone.Margin = new System.Windows.Forms.Padding(2);
            this.chkNwsTone.Name = "chkNwsTone";
            this.chkNwsTone.Size = new System.Drawing.Size(199, 25);
            this.chkNwsTone.TabIndex = 12;
            this.chkNwsTone.Tag = "disable";
            this.chkNwsTone.Text = "Use NWS Attention Tone";
            this.chkNwsTone.UseVisualStyleBackColor = true;
            // 
            // txtAnnouncement
            // 
            this.txtAnnouncement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnnouncement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtAnnouncement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnnouncement.ContextMenuStrip = this.EditContextMenu;
            this.txtAnnouncement.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnnouncement.ForeColor = System.Drawing.Color.White;
            this.txtAnnouncement.Location = new System.Drawing.Point(508, 86);
            this.txtAnnouncement.Margin = new System.Windows.Forms.Padding(2);
            this.txtAnnouncement.Multiline = true;
            this.txtAnnouncement.Name = "txtAnnouncement";
            this.txtAnnouncement.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAnnouncement.Size = new System.Drawing.Size(450, 343);
            this.txtAnnouncement.TabIndex = 14;
            this.txtAnnouncement.Tag = "disable";
            this.txtAnnouncement.TextChanged += new System.EventHandler(this.TxtAnnouncement_TextChanged);
            this.txtAnnouncement.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtAnnouncement_MouseUp);
            // 
            // btnGeneratePlay
            // 
            this.btnGeneratePlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneratePlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnGeneratePlay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeneratePlay.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePlay.Location = new System.Drawing.Point(962, 86);
            this.btnGeneratePlay.Margin = new System.Windows.Forms.Padding(2);
            this.btnGeneratePlay.Name = "btnGeneratePlay";
            this.btnGeneratePlay.Size = new System.Drawing.Size(147, 160);
            this.btnGeneratePlay.TabIndex = 18;
            this.btnGeneratePlay.Text = "PLAY";
            this.btnGeneratePlay.UseVisualStyleBackColor = false;
            this.btnGeneratePlay.Click += new System.EventHandler(this.Button1_Click);
            // 
            // datagridRegions
            // 
            this.datagridRegions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.datagridRegions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.datagridRegions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.datagridRegions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.NullValue = "Unknown Event Location";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridRegions.DefaultCellStyle = dataGridViewCellStyle1;
            this.datagridRegions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.datagridRegions.Location = new System.Drawing.Point(9, 267);
            this.datagridRegions.Margin = new System.Windows.Forms.Padding(2);
            this.datagridRegions.Name = "datagridRegions";
            this.datagridRegions.RowTemplate.Height = 24;
            this.datagridRegions.Size = new System.Drawing.Size(475, 218);
            this.datagridRegions.TabIndex = 9;
            this.datagridRegions.Tag = "disable";
            this.datagridRegions.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.datagridRegions_CellClick);
            // 
            // btnAddRegion
            // 
            this.btnAddRegion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAddRegion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddRegion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRegion.Location = new System.Drawing.Point(342, 242);
            this.btnAddRegion.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddRegion.Name = "btnAddRegion";
            this.btnAddRegion.Size = new System.Drawing.Size(142, 23);
            this.btnAddRegion.TabIndex = 8;
            this.btnAddRegion.Tag = "disable";
            this.btnAddRegion.Text = "Add Location";
            this.btnAddRegion.UseVisualStyleBackColor = false;
            this.btnAddRegion.Click += new System.EventHandler(this.BtnAddRegion_Click);
            // 
            // lblAddedLocations
            // 
            this.lblAddedLocations.AutoSize = true;
            this.lblAddedLocations.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddedLocations.Location = new System.Drawing.Point(6, 250);
            this.lblAddedLocations.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddedLocations.Name = "lblAddedLocations";
            this.lblAddedLocations.Size = new System.Drawing.Size(98, 15);
            this.lblAddedLocations.TabIndex = 100;
            this.lblAddedLocations.Text = "Event Location(s)";
            // 
            // lblAnnouncement
            // 
            this.lblAnnouncement.AutoSize = true;
            this.lblAnnouncement.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAnnouncement.Location = new System.Drawing.Point(506, 69);
            this.lblAnnouncement.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAnnouncement.Name = "lblAnnouncement";
            this.lblAnnouncement.Size = new System.Drawing.Size(114, 15);
            this.lblAnnouncement.TabIndex = 22;
            this.lblAnnouncement.Text = "Announcement Text";
            // 
            // comboLengthHour
            // 
            this.comboLengthHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboLengthHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLengthHour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboLengthHour.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboLengthHour.ForeColor = System.Drawing.Color.White;
            this.comboLengthHour.FormattingEnabled = true;
            this.comboLengthHour.Location = new System.Drawing.Point(299, 149);
            this.comboLengthHour.Margin = new System.Windows.Forms.Padding(2);
            this.comboLengthHour.Name = "comboLengthHour";
            this.comboLengthHour.Size = new System.Drawing.Size(83, 29);
            this.comboLengthHour.TabIndex = 4;
            this.comboLengthHour.Tag = "disable";
            // 
            // comboLengthMinutes
            // 
            this.comboLengthMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboLengthMinutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLengthMinutes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboLengthMinutes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboLengthMinutes.ForeColor = System.Drawing.Color.White;
            this.comboLengthMinutes.FormattingEnabled = true;
            this.comboLengthMinutes.Location = new System.Drawing.Point(395, 149);
            this.comboLengthMinutes.Margin = new System.Windows.Forms.Padding(2);
            this.comboLengthMinutes.Name = "comboLengthMinutes";
            this.comboLengthMinutes.Size = new System.Drawing.Size(91, 29);
            this.comboLengthMinutes.TabIndex = 5;
            this.comboLengthMinutes.Tag = "disable";
            // 
            // lblValidMinutes
            // 
            this.lblValidMinutes.AutoSize = true;
            this.lblValidMinutes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblValidMinutes.Location = new System.Drawing.Point(393, 132);
            this.lblValidMinutes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValidMinutes.Name = "lblValidMinutes";
            this.lblValidMinutes.Size = new System.Drawing.Size(104, 15);
            this.lblValidMinutes.TabIndex = 100;
            this.lblValidMinutes.Text = "Valid for (minutes)";
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtOutputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutputFile.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtOutputFile.ForeColor = System.Drawing.Color.White;
            this.txtOutputFile.Location = new System.Drawing.Point(908, 521);
            this.txtOutputFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.Size = new System.Drawing.Size(201, 29);
            this.txtOutputFile.TabIndex = 22;
            this.txtOutputFile.Tag = "disable";
            this.txtOutputFile.Text = "output";
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFileName.Location = new System.Drawing.Point(918, 504);
            this.lblFileName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(191, 15);
            this.lblFileName.TabIndex = 100;
            this.lblFileName.Text = "Output File Name (exclude file ext)";
            this.lblFileName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblOutput
            // 
            this.lblOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(505, 486);
            this.lblOutput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(161, 17);
            this.lblOutput.TabIndex = 100;
            this.lblOutput.Text = "Audio output is located in:";
            // 
            // lblOutputDirectory
            // 
            this.lblOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOutputDirectory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOutputDirectory.Location = new System.Drawing.Point(505, 503);
            this.lblOutputDirectory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutputDirectory.Name = "lblOutputDirectory";
            this.lblOutputDirectory.Size = new System.Drawing.Size(260, 49);
            this.lblOutputDirectory.TabIndex = 100;
            this.lblOutputDirectory.Text = "Unknown directory";
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAbout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAbout.Location = new System.Drawing.Point(962, 6);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(147, 36);
            this.btnAbout.TabIndex = 16;
            this.btnAbout.Tag = "disable";
            this.btnAbout.Text = "Open Fusion Settings";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // btnGenerateCustom
            // 
            this.btnGenerateCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnGenerateCustom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerateCustom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateCustom.Location = new System.Drawing.Point(962, 372);
            this.btnGenerateCustom.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerateCustom.Name = "btnGenerateCustom";
            this.btnGenerateCustom.Size = new System.Drawing.Size(147, 57);
            this.btnGenerateCustom.TabIndex = 21;
            this.btnGenerateCustom.Tag = "disable";
            this.btnGenerateCustom.Text = "Generate EAS from Custom Data";
            this.btnGenerateCustom.UseVisualStyleBackColor = false;
            this.btnGenerateCustom.Click += new System.EventHandler(this.Button1_Click_2);
            // 
            // btnTTSSettings
            // 
            this.btnTTSSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTTSSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnTTSSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTTSSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTTSSettings.Location = new System.Drawing.Point(962, 46);
            this.btnTTSSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnTTSSettings.Name = "btnTTSSettings";
            this.btnTTSSettings.Size = new System.Drawing.Size(147, 36);
            this.btnTTSSettings.TabIndex = 17;
            this.btnTTSSettings.Tag = "disable";
            this.btnTTSSettings.Text = "Open TTS Settings";
            this.btnTTSSettings.UseVisualStyleBackColor = false;
            this.btnTTSSettings.Click += new System.EventHandler(this.BtnTTSSettings_Click);
            // 
            // lblGeneratedHeader
            // 
            this.lblGeneratedHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGeneratedHeader.AutoSize = true;
            this.lblGeneratedHeader.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGeneratedHeader.Location = new System.Drawing.Point(6, 506);
            this.lblGeneratedHeader.Name = "lblGeneratedHeader";
            this.lblGeneratedHeader.Size = new System.Drawing.Size(178, 15);
            this.lblGeneratedHeader.TabIndex = 100;
            this.lblGeneratedHeader.Text = "Generated Message Header Data";
            // 
            // txtGeneratedData
            // 
            this.txtGeneratedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGeneratedData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtGeneratedData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGeneratedData.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtGeneratedData.ForeColor = System.Drawing.Color.White;
            this.txtGeneratedData.Location = new System.Drawing.Point(10, 524);
            this.txtGeneratedData.Name = "txtGeneratedData";
            this.txtGeneratedData.ReadOnly = true;
            this.txtGeneratedData.Size = new System.Drawing.Size(449, 22);
            this.txtGeneratedData.TabIndex = 10;
            this.txtGeneratedData.TextChanged += new System.EventHandler(this.TxtGeneratedData_TextChanged);
            // 
            // chkBurstHeaders
            // 
            this.chkBurstHeaders.AutoSize = true;
            this.chkBurstHeaders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBurstHeaders.Location = new System.Drawing.Point(723, 13);
            this.chkBurstHeaders.Margin = new System.Windows.Forms.Padding(2);
            this.chkBurstHeaders.Name = "chkBurstHeaders";
            this.chkBurstHeaders.Size = new System.Drawing.Size(118, 25);
            this.chkBurstHeaders.TabIndex = 13;
            this.chkBurstHeaders.Tag = "disable";
            this.chkBurstHeaders.Text = "Use SASMEX";
            this.chkBurstHeaders.UseVisualStyleBackColor = true;
            this.chkBurstHeaders.CheckedChanged += new System.EventHandler(this.chkBurstHeaders_CheckedChanged);
            // 
            // btnGenerateTTSOnly
            // 
            this.btnGenerateTTSOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateTTSOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnGenerateTTSOnly.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerateTTSOnly.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGenerateTTSOnly.Location = new System.Drawing.Point(962, 250);
            this.btnGenerateTTSOnly.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerateTTSOnly.Name = "btnGenerateTTSOnly";
            this.btnGenerateTTSOnly.Size = new System.Drawing.Size(147, 57);
            this.btnGenerateTTSOnly.TabIndex = 19;
            this.btnGenerateTTSOnly.Tag = "disable";
            this.btnGenerateTTSOnly.Text = "Play w/o headers\r\n& attention tones";
            this.btnGenerateTTSOnly.UseMnemonic = false;
            this.btnGenerateTTSOnly.UseVisualStyleBackColor = false;
            this.btnGenerateTTSOnly.Click += new System.EventHandler(this.btnGenerateTTSOnly_Click);
            // 
            // PlayCountdown
            // 
            this.PlayCountdown.Interval = 5;
            this.PlayCountdown.Tick += new System.EventHandler(this.PlayCountdown_Tick);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Magenta;
            this.lblVersion.Location = new System.Drawing.Point(921, 453);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(188, 44);
            this.lblVersion.TabIndex = 104;
            this.lblVersion.Text = "v0.0.0\r\nBunnyTub on Discord";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblVersion.Click += new System.EventHandler(this.label14_Click);
            // 
            // lblVoice
            // 
            this.lblVoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVoice.AutoSize = true;
            this.lblVoice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVoice.Location = new System.Drawing.Point(506, 435);
            this.lblVoice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVoice.Name = "lblVoice";
            this.lblVoice.Size = new System.Drawing.Size(248, 15);
            this.lblVoice.TabIndex = 107;
            this.lblVoice.Text = "Announcement Voice (will be added in v0.1.4)";
            // 
            // combo
            // 
            this.combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.combo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.combo.ForeColor = System.Drawing.Color.White;
            this.combo.FormattingEnabled = true;
            this.combo.Location = new System.Drawing.Point(509, 452);
            this.combo.Margin = new System.Windows.Forms.Padding(2);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(234, 29);
            this.combo.TabIndex = 15;
            this.combo.Tag = "disable";
            // 
            // LocationContextMenu
            // 
            this.LocationContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.LocationContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteLocationToolStripMenuItem});
            this.LocationContextMenu.Name = "LocationContextMenu";
            this.LocationContextMenu.ShowImageMargin = false;
            this.LocationContextMenu.Size = new System.Drawing.Size(132, 26);
            this.LocationContextMenu.Text = "Location";
            // 
            // deleteLocationToolStripMenuItem
            // 
            this.deleteLocationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.deleteLocationToolStripMenuItem.Name = "deleteLocationToolStripMenuItem";
            this.deleteLocationToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.deleteLocationToolStripMenuItem.Text = "Delete Location";
            this.deleteLocationToolStripMenuItem.ToolTipText = "Deletes the location.";
            this.deleteLocationToolStripMenuItem.Click += new System.EventHandler(this.deleteLocationToolStripMenuItem_Click);
            // 
            // btnCopyHeader
            // 
            this.btnCopyHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCopyHeader.BackgroundImage = global::EASEncoder_UI.Properties.Resources.placeholder;
            this.btnCopyHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCopyHeader.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCopyHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyHeader.Location = new System.Drawing.Point(464, 524);
            this.btnCopyHeader.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyHeader.Name = "btnCopyHeader";
            this.btnCopyHeader.Size = new System.Drawing.Size(22, 22);
            this.btnCopyHeader.TabIndex = 108;
            this.btnCopyHeader.Tag = "disable";
            this.btnCopyHeader.UseVisualStyleBackColor = false;
            this.btnCopyHeader.Click += new System.EventHandler(this.btnCopyHeader_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(723, 41);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 31);
            this.checkBox1.TabIndex = 109;
            this.checkBox1.Tag = "disable";
            this.checkBox1.Text = "Stress Test";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // EditContextMenu
            // 
            this.EditContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.EditContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolUndoRedo,
            this.toolStripSeparator1,
            this.toolCut,
            this.toolCopy,
            this.toolPaste,
            this.toolDelete,
            this.toolStripSeparator2,
            this.toolSelectAll,
            this.toolStripSeparator3,
            this.toolStripMenuItem8});
            this.EditContextMenu.Name = "LocationContextMenu";
            this.EditContextMenu.ShowImageMargin = false;
            this.EditContextMenu.Size = new System.Drawing.Size(156, 198);
            this.EditContextMenu.Text = "Edit";
            this.EditContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.EditContextMenu_Opening);
            // 
            // toolUndoRedo
            // 
            this.toolUndoRedo.ForeColor = System.Drawing.Color.White;
            this.toolUndoRedo.Name = "toolUndoRedo";
            this.toolUndoRedo.Size = new System.Drawing.Size(155, 22);
            this.toolUndoRedo.Text = "&Undo";
            this.toolUndoRedo.ToolTipText = "Rewinds the last action.";
            this.toolUndoRedo.Click += new System.EventHandler(this.toolUndoRedo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // toolCut
            // 
            this.toolCut.ForeColor = System.Drawing.Color.White;
            this.toolCut.Name = "toolCut";
            this.toolCut.Size = new System.Drawing.Size(155, 22);
            this.toolCut.Text = "Cu&t";
            this.toolCut.ToolTipText = "Cuts the text and copies it to the clipboard.";
            this.toolCut.Click += new System.EventHandler(this.toolCut_Click);
            // 
            // toolCopy
            // 
            this.toolCopy.ForeColor = System.Drawing.Color.White;
            this.toolCopy.Name = "toolCopy";
            this.toolCopy.Size = new System.Drawing.Size(155, 22);
            this.toolCopy.Text = "&Copy";
            this.toolCopy.ToolTipText = "Copies the text to the clipboard.";
            this.toolCopy.Click += new System.EventHandler(this.toolCopy_Click);
            // 
            // toolPaste
            // 
            this.toolPaste.ForeColor = System.Drawing.Color.White;
            this.toolPaste.Name = "toolPaste";
            this.toolPaste.Size = new System.Drawing.Size(155, 22);
            this.toolPaste.Text = "&Paste";
            this.toolPaste.ToolTipText = "Pastes text from the clipboard.";
            this.toolPaste.Click += new System.EventHandler(this.toolPaste_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.ForeColor = System.Drawing.Color.White;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(155, 22);
            this.toolDelete.Text = "&Delete";
            this.toolDelete.ToolTipText = "Deletes the selected text.";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // toolSelectAll
            // 
            this.toolSelectAll.ForeColor = System.Drawing.Color.White;
            this.toolSelectAll.Name = "toolSelectAll";
            this.toolSelectAll.Size = new System.Drawing.Size(155, 22);
            this.toolSelectAll.Text = "Select &All";
            this.toolSelectAll.ToolTipText = "Selects all the text.";
            this.toolSelectAll.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(152, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem12,
            this.toolStripMenuItem11,
            this.toolStripMenuItem10});
            this.toolStripMenuItem8.Enabled = false;
            this.toolStripMenuItem8.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem8.Text = "Templates";
            this.toolStripMenuItem8.ToolTipText = "Shows the templates.";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.toolStripMenuItem12.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem12.Text = "Test Demonstration";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.toolStripMenuItem11.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem11.Text = "Required Monthy Test";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.toolStripMenuItem10.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem10.Text = "Required Weekly Test";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1120, 561);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnCopyHeader);
            this.Controls.Add(this.lblVoice);
            this.Controls.Add(this.combo);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnGenerateTTSOnly);
            this.Controls.Add(this.chkBurstHeaders);
            this.Controls.Add(this.txtGeneratedData);
            this.Controls.Add(this.lblGeneratedHeader);
            this.Controls.Add(this.btnTTSSettings);
            this.Controls.Add(this.btnGenerateCustom);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.txtOutputFile);
            this.Controls.Add(this.lblValidMinutes);
            this.Controls.Add(this.comboLengthMinutes);
            this.Controls.Add(this.comboLengthHour);
            this.Controls.Add(this.lblAnnouncement);
            this.Controls.Add(this.lblAddedLocations);
            this.Controls.Add(this.btnAddRegion);
            this.Controls.Add(this.datagridRegions);
            this.Controls.Add(this.btnGeneratePlay);
            this.Controls.Add(this.txtAnnouncement);
            this.Controls.Add(this.chkNwsTone);
            this.Controls.Add(this.chkEbsTones);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSender);
            this.Controls.Add(this.lblValidHours);
            this.Controls.Add(this.lblEventBegin);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.lblOriginator);
            this.Controls.Add(this.comboOriginator);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.comboCode);
            this.Controls.Add(this.lblCounty);
            this.Controls.Add(this.comboCounty);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.comboState);
            this.Controls.Add(this.lblOutputDirectory);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1136, 600);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EASEncoder Fusion";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridRegions)).EndInit();
            this.LocationContextMenu.ResumeLayout(false);
            this.EditContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCounty;
        private System.Windows.Forms.ComboBox comboCounty;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.ComboBox comboCode;
        private System.Windows.Forms.Label lblOriginator;
        private System.Windows.Forms.ComboBox comboOriginator;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label lblEventBegin;
        private System.Windows.Forms.Label lblValidHours;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox chkEbsTones;
        private System.Windows.Forms.CheckBox chkNwsTone;
        private System.Windows.Forms.TextBox txtAnnouncement;
        private System.Windows.Forms.Button btnGeneratePlay;
        private System.Windows.Forms.DataGridView datagridRegions;
        private System.Windows.Forms.Button btnAddRegion;
        private System.Windows.Forms.Label lblAddedLocations;
        private System.Windows.Forms.Label lblAnnouncement;
        private System.Windows.Forms.ComboBox comboLengthHour;
        private System.Windows.Forms.ComboBox comboLengthMinutes;
        private System.Windows.Forms.Label lblValidMinutes;
        private System.Windows.Forms.TextBox txtOutputFile;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblOutputDirectory;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnGenerateCustom;
        private System.Windows.Forms.Button btnTTSSettings;
        private System.Windows.Forms.Label lblGeneratedHeader;
        private System.Windows.Forms.TextBox txtGeneratedData;
        private System.Windows.Forms.CheckBox chkBurstHeaders;
        private System.Windows.Forms.Button btnGenerateTTSOnly;
        private System.Windows.Forms.Timer PlayCountdown;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblVoice;
        private System.Windows.Forms.ComboBox combo;
        private System.Windows.Forms.ContextMenuStrip LocationContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteLocationToolStripMenuItem;
        private System.Windows.Forms.Button btnCopyHeader;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ContextMenuStrip EditContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolDelete;
        private System.Windows.Forms.ToolStripMenuItem toolUndoRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolCut;
        private System.Windows.Forms.ToolStripMenuItem toolCopy;
        private System.Windows.Forms.ToolStripMenuItem toolPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
    }
}

