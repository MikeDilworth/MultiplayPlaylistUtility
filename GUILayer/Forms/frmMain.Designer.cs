namespace GUILayer.Forms
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miSelectDefaultShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetStatusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAboutBox = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentShow = new System.Windows.Forms.Label();
            this.lblCurrentShowHeader = new System.Windows.Forms.Label();
            this.lblPlaylistNameHeader = new System.Windows.Forms.Label();
            this.lblPlaylistName = new System.Windows.Forms.Label();
            this.lblTrioChannelHeader = new System.Windows.Forms.Label();
            this.lblTrioChannel = new System.Windows.Forms.Label();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Question = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timerStatusUpdate = new System.Windows.Forms.Timer(this.components);
            this.gbTime = new System.Windows.Forms.GroupBox();
            this.lblIpAddress = new System.Windows.Forms.Label();
            this.lblHostName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectShow = new System.Windows.Forms.Button();
            this.availableShowsGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.availablePlaylistsGrid = new System.Windows.Forms.DataGridView();
            this.btnSelectPlaylist = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.gbTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableShowsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availablePlaylistsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.utilitiesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(976, 24);
            this.menuStrip1.TabIndex = 48;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExit});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.programToolStripMenuItem.Text = "&Program";
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(92, 22);
            this.miExit.Text = "E&xit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSelectDefaultShow,
            this.toolStripMenuItem1,
            this.resetStatusBarToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.utilitiesToolStripMenuItem.Text = "&Utilities";
            // 
            // miSelectDefaultShow
            // 
            this.miSelectDefaultShow.Name = "miSelectDefaultShow";
            this.miSelectDefaultShow.Size = new System.Drawing.Size(170, 22);
            this.miSelectDefaultShow.Text = "&Select Default Show";
            this.miSelectDefaultShow.Click += new System.EventHandler(this.miSelectDefaultShow_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(167, 6);
            // 
            // resetStatusBarToolStripMenuItem
            // 
            this.resetStatusBarToolStripMenuItem.Name = "resetStatusBarToolStripMenuItem";
            this.resetStatusBarToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.resetStatusBarToolStripMenuItem.Text = "&Reset Status Bar";
            this.resetStatusBarToolStripMenuItem.Click += new System.EventHandler(this.resetStatusBarToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAboutBox});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // miAboutBox
            // 
            this.miAboutBox.Name = "miAboutBox";
            this.miAboutBox.Size = new System.Drawing.Size(103, 22);
            this.miAboutBox.Text = "&About";
            this.miAboutBox.Click += new System.EventHandler(this.miAboutBox_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 384);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(976, 22);
            this.statusStrip.TabIndex = 53;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ActiveLinkColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStripStatusLabel.BackColor = System.Drawing.Color.SpringGreen;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabel.Text = "N/A";
            // 
            // lblCurrentShow
            // 
            this.lblCurrentShow.AutoSize = true;
            this.lblCurrentShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentShow.Location = new System.Drawing.Point(390, 44);
            this.lblCurrentShow.Name = "lblCurrentShow";
            this.lblCurrentShow.Size = new System.Drawing.Size(34, 16);
            this.lblCurrentShow.TabIndex = 86;
            this.lblCurrentShow.Text = "N/A";
            // 
            // lblCurrentShowHeader
            // 
            this.lblCurrentShowHeader.AutoSize = true;
            this.lblCurrentShowHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentShowHeader.Location = new System.Drawing.Point(278, 44);
            this.lblCurrentShowHeader.Name = "lblCurrentShowHeader";
            this.lblCurrentShowHeader.Size = new System.Drawing.Size(115, 16);
            this.lblCurrentShowHeader.TabIndex = 85;
            this.lblCurrentShowHeader.Text = "Selected Show:";
            // 
            // lblPlaylistNameHeader
            // 
            this.lblPlaylistNameHeader.AutoSize = true;
            this.lblPlaylistNameHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaylistNameHeader.Location = new System.Drawing.Point(536, 44);
            this.lblPlaylistNameHeader.Name = "lblPlaylistNameHeader";
            this.lblPlaylistNameHeader.Size = new System.Drawing.Size(108, 16);
            this.lblPlaylistNameHeader.TabIndex = 88;
            this.lblPlaylistNameHeader.Text = "Playlist Name:";
            // 
            // lblPlaylistName
            // 
            this.lblPlaylistName.AutoSize = true;
            this.lblPlaylistName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaylistName.Location = new System.Drawing.Point(641, 44);
            this.lblPlaylistName.Name = "lblPlaylistName";
            this.lblPlaylistName.Size = new System.Drawing.Size(34, 16);
            this.lblPlaylistName.TabIndex = 89;
            this.lblPlaylistName.Text = "N/A";
            // 
            // lblTrioChannelHeader
            // 
            this.lblTrioChannelHeader.AutoSize = true;
            this.lblTrioChannelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrioChannelHeader.Location = new System.Drawing.Point(769, 44);
            this.lblTrioChannelHeader.Name = "lblTrioChannelHeader";
            this.lblTrioChannelHeader.Size = new System.Drawing.Size(100, 16);
            this.lblTrioChannelHeader.TabIndex = 90;
            this.lblTrioChannelHeader.Text = "Trio Channel:";
            // 
            // lblTrioChannel
            // 
            this.lblTrioChannel.AutoSize = true;
            this.lblTrioChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrioChannel.Location = new System.Drawing.Point(866, 44);
            this.lblTrioChannel.Name = "lblTrioChannel";
            this.lblTrioChannel.Size = new System.Drawing.Size(34, 16);
            this.lblTrioChannel.TabIndex = 91;
            this.lblTrioChannel.Text = "N/A";
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Type.DataPropertyName = "questionType";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // st
            // 
            this.st.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.st.DataPropertyName = "stateOffice";
            this.st.HeaderText = "mxID/st/ofc";
            this.st.Name = "st";
            // 
            // Category
            // 
            this.Category.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Category.DataPropertyName = "shortMXLabel";
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            // 
            // Question
            // 
            this.Question.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Question.DataPropertyName = "fullMXLabel";
            this.Question.HeaderText = "Question";
            this.Question.Name = "Question";
            // 
            // rowText
            // 
            this.rowText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rowText.DataPropertyName = "rowText";
            this.rowText.HeaderText = "rowText";
            this.rowText.Name = "rowText";
            // 
            // Subset
            // 
            this.Subset.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Subset.DataPropertyName = "subsetName";
            this.Subset.HeaderText = "Subset";
            this.Subset.Name = "Subset";
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.Black;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.Red;
            this.timeLabel.Location = new System.Drawing.Point(6, 17);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(248, 20);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Time";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerStatusUpdate
            // 
            this.timerStatusUpdate.Interval = 1000;
            this.timerStatusUpdate.Tick += new System.EventHandler(this.timerStatusUpdate_Tick);
            // 
            // gbTime
            // 
            this.gbTime.Controls.Add(this.timeLabel);
            this.gbTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTime.Location = new System.Drawing.Point(12, 27);
            this.gbTime.Name = "gbTime";
            this.gbTime.Size = new System.Drawing.Size(260, 42);
            this.gbTime.TabIndex = 119;
            this.gbTime.TabStop = false;
            this.gbTime.Text = "CURRENT TIME";
            // 
            // lblIpAddress
            // 
            this.lblIpAddress.AutoSize = true;
            this.lblIpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpAddress.Location = new System.Drawing.Point(122, 80);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(34, 16);
            this.lblIpAddress.TabIndex = 121;
            this.lblIpAddress.Text = "N/A";
            // 
            // lblHostName
            // 
            this.lblHostName.AutoSize = true;
            this.lblHostName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostName.Location = new System.Drawing.Point(230, 80);
            this.lblHostName.Name = "lblHostName";
            this.lblHostName.Size = new System.Drawing.Size(34, 16);
            this.lblHostName.TabIndex = 122;
            this.lblHostName.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 123;
            this.label3.Text = "Host PC Info:";
            // 
            // btnSelectShow
            // 
            this.btnSelectShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectShow.Image = global::GUILayer.Properties.Resources.StatusAnnotations_Complete_and_ok_16xLG_color;
            this.btnSelectShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectShow.Location = new System.Drawing.Point(213, 325);
            this.btnSelectShow.Name = "btnSelectShow";
            this.btnSelectShow.Size = new System.Drawing.Size(130, 40);
            this.btnSelectShow.TabIndex = 125;
            this.btnSelectShow.Text = " Select\r\n(Ctrl-S)";
            this.btnSelectShow.UseVisualStyleBackColor = true;
            // 
            // availableShowsGrid
            // 
            this.availableShowsGrid.AllowUserToAddRows = false;
            this.availableShowsGrid.AllowUserToDeleteRows = false;
            this.availableShowsGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.availableShowsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.availableShowsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.availableShowsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.availableShowsGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.availableShowsGrid.Location = new System.Drawing.Point(77, 116);
            this.availableShowsGrid.MultiSelect = false;
            this.availableShowsGrid.Name = "availableShowsGrid";
            this.availableShowsGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.availableShowsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.availableShowsGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.availableShowsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.availableShowsGrid.Size = new System.Drawing.Size(402, 196);
            this.availableShowsGrid.TabIndex = 124;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Title";
            this.dataGridViewTextBoxColumn2.HeaderText = "Show Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 360;
            // 
            // availablePlaylistsGrid
            // 
            this.availablePlaylistsGrid.AllowUserToAddRows = false;
            this.availablePlaylistsGrid.AllowUserToDeleteRows = false;
            this.availablePlaylistsGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.availablePlaylistsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.availablePlaylistsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.availablePlaylistsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.availablePlaylistsGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.availablePlaylistsGrid.Location = new System.Drawing.Point(494, 116);
            this.availablePlaylistsGrid.MultiSelect = false;
            this.availablePlaylistsGrid.Name = "availablePlaylistsGrid";
            this.availablePlaylistsGrid.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.availablePlaylistsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.availablePlaylistsGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.availablePlaylistsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.availablePlaylistsGrid.Size = new System.Drawing.Size(402, 196);
            this.availablePlaylistsGrid.TabIndex = 126;
            // 
            // btnSelectPlaylist
            // 
            this.btnSelectPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectPlaylist.Image = global::GUILayer.Properties.Resources.StatusAnnotations_Complete_and_ok_16xLG_color;
            this.btnSelectPlaylist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectPlaylist.Location = new System.Drawing.Point(626, 325);
            this.btnSelectPlaylist.Name = "btnSelectPlaylist";
            this.btnSelectPlaylist.Size = new System.Drawing.Size(130, 40);
            this.btnSelectPlaylist.TabIndex = 127;
            this.btnSelectPlaylist.Text = " Select\r\n(Ctrl-P)";
            this.btnSelectPlaylist.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PlaylistName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Playlist Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 360;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(976, 406);
            this.Controls.Add(this.btnSelectPlaylist);
            this.Controls.Add(this.availablePlaylistsGrid);
            this.Controls.Add(this.btnSelectShow);
            this.Controls.Add(this.availableShowsGrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblHostName);
            this.Controls.Add(this.lblIpAddress);
            this.Controls.Add(this.gbTime);
            this.Controls.Add(this.lblTrioChannel);
            this.Controls.Add(this.lblTrioChannelHeader);
            this.Controls.Add(this.lblPlaylistName);
            this.Controls.Add(this.lblPlaylistNameHeader);
            this.Controls.Add(this.lblCurrentShow);
            this.Controls.Add(this.lblCurrentShowHeader);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Election Graphics Stack Builder Application  Version ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gbTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.availableShowsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availablePlaylistsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miAboutBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miSelectDefaultShow;
        private System.Windows.Forms.Label lblCurrentShow;
        private System.Windows.Forms.Label lblCurrentShowHeader;
        private System.Windows.Forms.Label lblPlaylistNameHeader;
        private System.Windows.Forms.Label lblPlaylistName;
        private System.Windows.Forms.Label lblTrioChannelHeader;
        private System.Windows.Forms.Label lblTrioChannel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resetStatusBarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn st;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Question;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subset;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer timerStatusUpdate;
        private System.Windows.Forms.GroupBox gbTime;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.Label lblHostName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectShow;
        private System.Windows.Forms.DataGridView availableShowsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView availablePlaylistsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnSelectPlaylist;
    }
}

