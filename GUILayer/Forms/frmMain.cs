//////////////////////////////////////////////////////////////////////////////
// MULTI-PLAY PLAYLIST UTILITY - MAIN APPLICATION FORM
// Version 1.0.0
// M. Dilworth  Rev: 01/17/2017
//////////////////////////////////////////////////////////////////////////////

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Linq;
using log4net.Appender;
using LogicLayer.CommonClasses;
using MSEInterface;
using MSEInterface.DataModel;
// Required for implementing logging to status bar

//
// NOTES:
//
// 1. Code modified 8/17/2016 to use new approach provided by Viz for managing groups and elements within groups.
//

namespace GUILayer.Forms
{
    // Implement IAppender interface from log4net
    public partial class frmMain : Form, IAppender
    {

        #region Globals
        DateTime referenceTime = DateTime.MaxValue;

        public Boolean enableShowSelectControls = false;

        #endregion

        #region Collection & binding list definitions
        /// <summary>
        /// Define classes for collections and logic
        /// </summary>
        
        internal static readonly XNamespace Atom = "http://www.w3.org/2005/Atom";

        // Instantiate MSE classes
        MANAGE_GROUPS group = new MANAGE_GROUPS();
        MANAGE_PLAYLISTS playlist = new MANAGE_PLAYLISTS();
        MANAGE_TEMPLATES template = new MANAGE_TEMPLATES();
        MANAGE_SHOWS show = new MANAGE_SHOWS();
        MANAGE_ELEMENTS element = new MANAGE_ELEMENTS();

        // Read in MSE settings from config file and set default directories and parameters
        string mseEndpoint1 = string.Empty;
        string mseEndpoint2 = string.Empty;
        string topLevelShowsDirectoryURI = string.Empty;
        string masterPlaylistsDirectoryURI = string.Empty;
        string currentShowName = string.Empty;
        string ProducerElementsPlaylistName = string.Empty;

        // Read in database connection strings
        string LoggingDBConnectionString = Properties.Settings.Default.LoggingDBConnectionString;

        // Define the binding list object for the list of available shows
        private BindingList<ShowObject> showNames;
        // The sublist ID to be returned 
        public string selectedShow { get; set; }

        #endregion

        #region Logger instantiation - uses reflection to get module name
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Logging & status setup
        // This method used to implement IAppender interface from log4net; to support custom appends to status strip
        public void DoAppend(log4net.Core.LoggingEvent loggingEvent)
        {
            // Set text on status bar only if logging level is DEBUG or ERROR
            if ((loggingEvent.Level.Name == "ERROR") | (loggingEvent.Level.Name == "DEBUG"))
            {
                toolStripStatusLabel.BackColor = System.Drawing.Color.Red;
                toolStripStatusLabel.Text = String.Format("Error Logging Message: {0}: {1}", loggingEvent.Level.Name, loggingEvent.MessageObject.ToString());
            }
            else
            {
                toolStripStatusLabel.BackColor = System.Drawing.Color.SpringGreen;
                toolStripStatusLabel.Text = String.Format("Status Logging Message: {0}: {1}", loggingEvent.Level.Name, loggingEvent.MessageObject.ToString());
            }
        }

        // Handler to clear status bar message and reset color
        private void resetStatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.BackColor = System.Drawing.Color.SpringGreen;
            toolStripStatusLabel.Text = "Status Logging Message: Statusbar reset";
        }
        #endregion

        #region Main form init, activation & close
        /// <summary>
        /// Main form init, activation and close
        /// </summary>
        
        public frmMain()
        {
            InitializeComponent();

            try
            {
                // Update status
                toolStripStatusLabel.Text = "Starting program initialization.";

                // Set current show label
                lblCurrentShow.Text = currentShowName;

                // Enable handling of function keys; setup method for function keys and assign delegate
                KeyPreview = true;
                this.KeyUp += new System.Windows.Forms.KeyEventHandler(KeyEvent);

                timerStatusUpdate.Enabled = true;

                // Make entry into applications log
                //ApplicationSettingsFlagsAccess applicationSettingsFlagsAccess = new ApplicationSettingsFlagsAccess();
                string ipAddress = string.Empty;
                string hostName = string.Empty;
                ipAddress = HostIPNameFunctions.GetLocalIPAddress();
                hostName = HostIPNameFunctions.GetHostName(ipAddress);
                lblIpAddress.Text = ipAddress;
                lblHostName.Text = hostName; 

                // Set version number
                var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                this.Text = String.Format("Election Graphics Stack Builder Application  Version {0}", version);
            }
            catch (Exception ex)
            {
                // Log error
                log.Error("frmMain Exception occurred during program init: " + ex.Message);
                log.Debug("frmMain Exception occurred during program init", ex);
            }

            // Update status labels
            toolStripStatusLabel.Text = "Program initialization complete.";
            lblPlaylistName.Text = ProducerElementsPlaylistName;
        }

        // Handler for main form load
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Read in config settings - default to Media Sequencer #1
            mseEndpoint1 = Properties.Settings.Default.MSEEndpoint1;
            mseEndpoint2 = Properties.Settings.Default.MSEEndpoint2;
            topLevelShowsDirectoryURI = Properties.Settings.Default.MSEEndpoint1 + Properties.Settings.Default.TopLevelShowsDirectory;
            masterPlaylistsDirectoryURI = Properties.Settings.Default.MSEEndpoint1 + Properties.Settings.Default.MasterPlaylistsDirectory;
            currentShowName = Properties.Settings.Default.CurrentShowName;
            ProducerElementsPlaylistName = Properties.Settings.Default.ProducerElementsPlaylistName;

            // Populate grid/list of shows
            // Gets the URI's for available shows
            MANAGE_SHOWS getShowList = new MANAGE_SHOWS();

            showNames = getShowList.GetListOfShows(mseEndpoint1 + Properties.Settings.Default.TopLevelShowsDirectory);

            // Setup the available stacks grid
            availableShowsGrid.AutoGenerateColumns = false;
            var availableShowsGridDataSource = new BindingSource(showNames, null);
            availableShowsGrid.DataSource = availableShowsGridDataSource;

            // Log application start
            log.Info("Starting Stack Builder application");
        }

        // Handler for main menu program exit button click
        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Method for main form close - confirm with operator
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are you sure you want to exit the MultiPlay Playlist Utility?", "Warning",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {

            }
        }

        // Handler for main form closed - log info
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Log application quit
            log.Info("Quitting Multi-Play Playlist Utility");
        }
        #endregion

        #region General Form related methods
        // General update timer
        private void timerStatusUpdate_Tick(object sender, EventArgs e)
        {
            referenceTime = DateTime.Now;

            //label1.Text = Convert.ToString(referenceTime);
            timeLabel.Text = String.Format("{0:h:mm:ss tt  MMM dd, yyyy}", referenceTime);

        }
        #endregion 
        
        #region General dialogs
        /// <summary>
        /// GENERAL DIALOGS
        /// </summary>
        // Launch About box
        private void miAboutBox_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.frmAbout aboutBox = new Forms.frmAbout();

                // Show the dialog
                aboutBox.ShowDialog();
            }
            catch (Exception ex)
            {
                // Log error
                log.Error("frmMain Exception occurred: " + ex.Message);
                log.Debug("frmMain Exception occurred", ex);
            }
        }
        #endregion

        #region UI widget data validation methods
        /// <summary>
        /// UI widget data validation methods
        /// </summary>

        // Method to handle function keys for race boards
        private void KeyEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    //rbPresident.Checked = true;
                    break;
            }
        }
        #endregion

        // Handler for Select Show button
        private void btnSelectShow_Click(object sender, EventArgs e)
        {
            try
            {
                // Set the sublist ID
                if (showNames.Count > 0)
                {
                    //Get the playlist ID from the grid
                    int currentShowIndex = availableShowsGrid.CurrentCell.RowIndex;
                    string ShowName = showNames[currentShowIndex].title.ToString();

                    //DialogResult result1 = MessageBox.Show("Are you sure you want to switch to the new show: " + ShowName + "?", "Confirmation",
                    //                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (result1 != DialogResult.Yes)
                    //{
                    //    return;
                    //}

                    // Set new show name
                    selectedShow = ShowName;
                    lblCurrentShow.Text = selectedShow;
                }
            }
            catch (Exception ex)
            {
                // Log error
                log.Error("Select Show exception occurred: " + ex.Message);
                log.Debug("Select Show exception occurred", ex);
            }

        }

        // Handler for button to refresh list of shows
        private void btnRefreshShowList_Click(object sender, EventArgs e)
        {
            showNames.Clear();

            // Gets the URI's for available shows
            MANAGE_SHOWS getShowList = new MANAGE_SHOWS();

            showNames = getShowList.GetListOfShows(mseEndpoint1 + Properties.Settings.Default.TopLevelShowsDirectory);

            // Setup the available stacks grid
            availableShowsGrid.AutoGenerateColumns = false;
            var availableShowsGridDataSource = new BindingSource(showNames, null);
            availableShowsGrid.DataSource = availableShowsGridDataSource;
        }
    }
}
