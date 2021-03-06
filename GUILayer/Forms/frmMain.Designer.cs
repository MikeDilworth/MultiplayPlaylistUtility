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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetStatusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAboutBox = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentShow = new System.Windows.Forms.Label();
            this.lblCurrentShowHeader = new System.Windows.Forms.Label();
            this.lblPlaylistNameHeader = new System.Windows.Forms.Label();
            this.lblCurrentPlaylist = new System.Windows.Forms.Label();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Question = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeOfDayLabel = new System.Windows.Forms.Label();
            this.timerStatusUpdate = new System.Windows.Forms.Timer(this.components);
            this.gbTime = new System.Windows.Forms.GroupBox();
            this.lblIpAddress = new System.Windows.Forms.Label();
            this.lblHostName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCopyShow = new System.Windows.Forms.Button();
            this.availableShowsGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefreshShowPlaylistLists = new System.Windows.Forms.Button();
            this.lblShowDirectory = new System.Windows.Forms.Label();
            this.lblShowDirectoryHeader = new System.Windows.Forms.Label();
            this.tbDebug = new System.Windows.Forms.TextBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.indicatorDestinationMSE = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.indicatorSourceMSE = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.lblSourceMSE = new System.Windows.Forms.Label();
            this.lblDestinationMSE = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timeOfLastCopyLabel = new System.Windows.Forms.Label();
            this.rbSelectFNC = new System.Windows.Forms.RadioButton();
            this.rbSelectFBN = new System.Windows.Forms.RadioButton();
            this.lblNetworkSelect = new System.Windows.Forms.Label();
            this.availablePlaylistsGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.gbTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableShowsGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(552, 24);
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
            this.resetStatusBarToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.utilitiesToolStripMenuItem.Text = "&Utilities";
            // 
            // resetStatusBarToolStripMenuItem
            // 
            this.resetStatusBarToolStripMenuItem.Name = "resetStatusBarToolStripMenuItem";
            this.resetStatusBarToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 528);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(552, 22);
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
            this.lblCurrentShow.Location = new System.Drawing.Point(133, 160);
            this.lblCurrentShow.Name = "lblCurrentShow";
            this.lblCurrentShow.Size = new System.Drawing.Size(34, 16);
            this.lblCurrentShow.TabIndex = 86;
            this.lblCurrentShow.Text = "N/A";
            // 
            // lblCurrentShowHeader
            // 
            this.lblCurrentShowHeader.AutoSize = true;
            this.lblCurrentShowHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentShowHeader.Location = new System.Drawing.Point(20, 160);
            this.lblCurrentShowHeader.Name = "lblCurrentShowHeader";
            this.lblCurrentShowHeader.Size = new System.Drawing.Size(115, 16);
            this.lblCurrentShowHeader.TabIndex = 85;
            this.lblCurrentShowHeader.Text = "Selected Show:";
            // 
            // lblPlaylistNameHeader
            // 
            this.lblPlaylistNameHeader.AutoSize = true;
            this.lblPlaylistNameHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaylistNameHeader.Location = new System.Drawing.Point(20, 186);
            this.lblPlaylistNameHeader.Name = "lblPlaylistNameHeader";
            this.lblPlaylistNameHeader.Size = new System.Drawing.Size(108, 16);
            this.lblPlaylistNameHeader.TabIndex = 88;
            this.lblPlaylistNameHeader.Text = "Playlist Name:";
            // 
            // lblCurrentPlaylist
            // 
            this.lblCurrentPlaylist.AutoSize = true;
            this.lblCurrentPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPlaylist.Location = new System.Drawing.Point(133, 186);
            this.lblCurrentPlaylist.Name = "lblCurrentPlaylist";
            this.lblCurrentPlaylist.Size = new System.Drawing.Size(34, 16);
            this.lblCurrentPlaylist.TabIndex = 89;
            this.lblCurrentPlaylist.Text = "N/A";
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
            // timeOfDayLabel
            // 
            this.timeOfDayLabel.BackColor = System.Drawing.Color.Black;
            this.timeOfDayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeOfDayLabel.ForeColor = System.Drawing.Color.Red;
            this.timeOfDayLabel.Location = new System.Drawing.Point(6, 17);
            this.timeOfDayLabel.Name = "timeOfDayLabel";
            this.timeOfDayLabel.Size = new System.Drawing.Size(248, 20);
            this.timeOfDayLabel.TabIndex = 0;
            this.timeOfDayLabel.Text = "--";
            this.timeOfDayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerStatusUpdate
            // 
            this.timerStatusUpdate.Interval = 1000;
            this.timerStatusUpdate.Tick += new System.EventHandler(this.timerStatusUpdate_Tick);
            // 
            // gbTime
            // 
            this.gbTime.Controls.Add(this.timeOfDayLabel);
            this.gbTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTime.Location = new System.Drawing.Point(12, 27);
            this.gbTime.Name = "gbTime";
            this.gbTime.Size = new System.Drawing.Size(260, 42);
            this.gbTime.TabIndex = 119;
            this.gbTime.TabStop = false;
            this.gbTime.Text = "Current Time";
            // 
            // lblIpAddress
            // 
            this.lblIpAddress.AutoSize = true;
            this.lblIpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpAddress.Location = new System.Drawing.Point(133, 213);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(34, 16);
            this.lblIpAddress.TabIndex = 121;
            this.lblIpAddress.Text = "N/A";
            // 
            // lblHostName
            // 
            this.lblHostName.AutoSize = true;
            this.lblHostName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostName.Location = new System.Drawing.Point(238, 213);
            this.lblHostName.Name = "lblHostName";
            this.lblHostName.Size = new System.Drawing.Size(34, 16);
            this.lblHostName.TabIndex = 122;
            this.lblHostName.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 123;
            this.label3.Text = "Host PC Info:";
            // 
            // btnCopyShow
            // 
            this.btnCopyShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyShow.Image = global::GUILayer.Properties.Resources.StatusAnnotations_Complete_and_ok_16xLG_color;
            this.btnCopyShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyShow.Location = new System.Drawing.Point(278, 451);
            this.btnCopyShow.Name = "btnCopyShow";
            this.btnCopyShow.Size = new System.Drawing.Size(260, 65);
            this.btnCopyShow.TabIndex = 125;
            this.btnCopyShow.Text = "Copy Show (F1)";
            this.btnCopyShow.UseVisualStyleBackColor = true;
            this.btnCopyShow.Click += new System.EventHandler(this.btnCopyPlaylist_Click);
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
            this.availableShowsGrid.Location = new System.Drawing.Point(12, 237);
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
            this.availableShowsGrid.Size = new System.Drawing.Size(260, 196);
            this.availableShowsGrid.TabIndex = 124;
            this.availableShowsGrid.SelectionChanged += new System.EventHandler(this.availableShowsGrid_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Title";
            this.dataGridViewTextBoxColumn2.HeaderText = "Show Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 360;
            // 
            // btnRefreshShowPlaylistLists
            // 
            this.btnRefreshShowPlaylistLists.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshShowPlaylistLists.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshShowPlaylistLists.Image")));
            this.btnRefreshShowPlaylistLists.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshShowPlaylistLists.Location = new System.Drawing.Point(12, 451);
            this.btnRefreshShowPlaylistLists.Name = "btnRefreshShowPlaylistLists";
            this.btnRefreshShowPlaylistLists.Size = new System.Drawing.Size(260, 65);
            this.btnRefreshShowPlaylistLists.TabIndex = 126;
            this.btnRefreshShowPlaylistLists.Text = "  Refresh Show && Playlist Grids";
            this.btnRefreshShowPlaylistLists.UseVisualStyleBackColor = true;
            this.btnRefreshShowPlaylistLists.Click += new System.EventHandler(this.btnRefreshShowPlaylistLists_Click);
            // 
            // lblShowDirectory
            // 
            this.lblShowDirectory.AutoSize = true;
            this.lblShowDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowDirectory.Location = new System.Drawing.Point(133, 133);
            this.lblShowDirectory.Name = "lblShowDirectory";
            this.lblShowDirectory.Size = new System.Drawing.Size(34, 16);
            this.lblShowDirectory.TabIndex = 128;
            this.lblShowDirectory.Text = "N/A";
            // 
            // lblShowDirectoryHeader
            // 
            this.lblShowDirectoryHeader.AutoSize = true;
            this.lblShowDirectoryHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowDirectoryHeader.Location = new System.Drawing.Point(20, 133);
            this.lblShowDirectoryHeader.Name = "lblShowDirectoryHeader";
            this.lblShowDirectoryHeader.Size = new System.Drawing.Size(116, 16);
            this.lblShowDirectoryHeader.TabIndex = 127;
            this.lblShowDirectoryHeader.Text = "Show Directory:";
            // 
            // tbDebug
            // 
            this.tbDebug.Location = new System.Drawing.Point(12, 550);
            this.tbDebug.Multiline = true;
            this.tbDebug.Name = "tbDebug";
            this.tbDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDebug.Size = new System.Drawing.Size(549, 142);
            this.tbDebug.TabIndex = 129;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.indicatorDestinationMSE,
            this.indicatorSourceMSE});
            this.shapeContainer1.Size = new System.Drawing.Size(552, 550);
            this.shapeContainer1.TabIndex = 130;
            this.shapeContainer1.TabStop = false;
            // 
            // indicatorDestinationMSE
            // 
            this.indicatorDestinationMSE.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.indicatorDestinationMSE.CornerRadius = 2;
            this.indicatorDestinationMSE.FillColor = System.Drawing.Color.Gray;
            this.indicatorDestinationMSE.FillGradientColor = System.Drawing.Color.Red;
            this.indicatorDestinationMSE.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.indicatorDestinationMSE.Location = new System.Drawing.Point(293, 76);
            this.indicatorDestinationMSE.Name = "indicatorDestinationMSE";
            this.indicatorDestinationMSE.Size = new System.Drawing.Size(19, 19);
            // 
            // indicatorSourceMSE
            // 
            this.indicatorSourceMSE.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.indicatorSourceMSE.CornerRadius = 2;
            this.indicatorSourceMSE.FillColor = System.Drawing.Color.Gray;
            this.indicatorSourceMSE.FillGradientColor = System.Drawing.Color.Red;
            this.indicatorSourceMSE.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.indicatorSourceMSE.Location = new System.Drawing.Point(22, 75);
            this.indicatorSourceMSE.Name = "indicatorSourceMSE";
            this.indicatorSourceMSE.Size = new System.Drawing.Size(19, 19);
            // 
            // lblSourceMSE
            // 
            this.lblSourceMSE.AutoSize = true;
            this.lblSourceMSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceMSE.Location = new System.Drawing.Point(53, 78);
            this.lblSourceMSE.Name = "lblSourceMSE";
            this.lblSourceMSE.Size = new System.Drawing.Size(93, 16);
            this.lblSourceMSE.TabIndex = 131;
            this.lblSourceMSE.Text = "Source MSE";
            // 
            // lblDestinationMSE
            // 
            this.lblDestinationMSE.AutoSize = true;
            this.lblDestinationMSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinationMSE.Location = new System.Drawing.Point(329, 80);
            this.lblDestinationMSE.Name = "lblDestinationMSE";
            this.lblDestinationMSE.Size = new System.Drawing.Size(122, 16);
            this.lblDestinationMSE.TabIndex = 132;
            this.lblDestinationMSE.Text = "Destination MSE";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.timeOfLastCopyLabel);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(278, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 42);
            this.groupBox1.TabIndex = 133;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time of Last Copy";
            // 
            // timeOfLastCopyLabel
            // 
            this.timeOfLastCopyLabel.BackColor = System.Drawing.Color.Black;
            this.timeOfLastCopyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeOfLastCopyLabel.ForeColor = System.Drawing.Color.Red;
            this.timeOfLastCopyLabel.Location = new System.Drawing.Point(6, 17);
            this.timeOfLastCopyLabel.Name = "timeOfLastCopyLabel";
            this.timeOfLastCopyLabel.Size = new System.Drawing.Size(248, 20);
            this.timeOfLastCopyLabel.TabIndex = 0;
            this.timeOfLastCopyLabel.Text = "--";
            this.timeOfLastCopyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbSelectFNC
            // 
            this.rbSelectFNC.AutoSize = true;
            this.rbSelectFNC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSelectFNC.Location = new System.Drawing.Point(136, 104);
            this.rbSelectFNC.Name = "rbSelectFNC";
            this.rbSelectFNC.Size = new System.Drawing.Size(56, 20);
            this.rbSelectFNC.TabIndex = 134;
            this.rbSelectFNC.TabStop = true;
            this.rbSelectFNC.Text = "FNC";
            this.rbSelectFNC.UseVisualStyleBackColor = true;
            this.rbSelectFNC.CheckedChanged += new System.EventHandler(this.rbSelectFNC_CheckedChanged);
            // 
            // rbSelectFBN
            // 
            this.rbSelectFBN.AutoSize = true;
            this.rbSelectFBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSelectFBN.Location = new System.Drawing.Point(196, 104);
            this.rbSelectFBN.Name = "rbSelectFBN";
            this.rbSelectFBN.Size = new System.Drawing.Size(56, 20);
            this.rbSelectFBN.TabIndex = 135;
            this.rbSelectFBN.TabStop = true;
            this.rbSelectFBN.Text = "FBN";
            this.rbSelectFBN.UseVisualStyleBackColor = true;
            this.rbSelectFBN.CheckedChanged += new System.EventHandler(this.rbSelectFBN_CheckedChanged);
            // 
            // lblNetworkSelect
            // 
            this.lblNetworkSelect.AutoSize = true;
            this.lblNetworkSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkSelect.Location = new System.Drawing.Point(20, 106);
            this.lblNetworkSelect.Name = "lblNetworkSelect";
            this.lblNetworkSelect.Size = new System.Drawing.Size(116, 16);
            this.lblNetworkSelect.TabIndex = 136;
            this.lblNetworkSelect.Text = "Network Select:";
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
            this.availablePlaylistsGrid.Location = new System.Drawing.Point(278, 237);
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
            this.availablePlaylistsGrid.Size = new System.Drawing.Size(260, 196);
            this.availablePlaylistsGrid.TabIndex = 137;
            this.availablePlaylistsGrid.SelectionChanged += new System.EventHandler(this.availablePlaylistsGrid_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "title";
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
            this.ClientSize = new System.Drawing.Size(552, 550);
            this.Controls.Add(this.availablePlaylistsGrid);
            this.Controls.Add(this.lblNetworkSelect);
            this.Controls.Add(this.rbSelectFBN);
            this.Controls.Add(this.rbSelectFNC);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDestinationMSE);
            this.Controls.Add(this.lblSourceMSE);
            this.Controls.Add(this.tbDebug);
            this.Controls.Add(this.lblShowDirectory);
            this.Controls.Add(this.lblShowDirectoryHeader);
            this.Controls.Add(this.btnRefreshShowPlaylistLists);
            this.Controls.Add(this.btnCopyShow);
            this.Controls.Add(this.availableShowsGrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblHostName);
            this.Controls.Add(this.lblIpAddress);
            this.Controls.Add(this.gbTime);
            this.Controls.Add(this.lblCurrentPlaylist);
            this.Controls.Add(this.lblPlaylistNameHeader);
            this.Controls.Add(this.lblCurrentShow);
            this.Controls.Add(this.lblCurrentShowHeader);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multi-Play Playlist Utility  Version ";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gbTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.availableShowsGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblCurrentShow;
        private System.Windows.Forms.Label lblCurrentShowHeader;
        private System.Windows.Forms.Label lblPlaylistNameHeader;
        private System.Windows.Forms.Label lblCurrentPlaylist;
        private System.Windows.Forms.ToolStripMenuItem resetStatusBarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn st;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Question;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subset;
        private System.Windows.Forms.Label timeOfDayLabel;
        private System.Windows.Forms.Timer timerStatusUpdate;
        private System.Windows.Forms.GroupBox gbTime;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.Label lblHostName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCopyShow;
        private System.Windows.Forms.DataGridView availableShowsGrid;
        private System.Windows.Forms.Button btnRefreshShowPlaylistLists;
        private System.Windows.Forms.Label lblShowDirectory;
        private System.Windows.Forms.Label lblShowDirectoryHeader;
        private System.Windows.Forms.TextBox tbDebug;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape indicatorSourceMSE;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape indicatorDestinationMSE;
        private System.Windows.Forms.Label lblSourceMSE;
        private System.Windows.Forms.Label lblDestinationMSE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label timeOfLastCopyLabel;
        private System.Windows.Forms.RadioButton rbSelectFNC;
        private System.Windows.Forms.RadioButton rbSelectFBN;
        private System.Windows.Forms.Label lblNetworkSelect;
        private System.Windows.Forms.DataGridView availablePlaylistsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}

