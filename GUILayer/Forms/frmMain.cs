//////////////////////////////////////////////////////////////////////////////
// MULTI-PLAY PLAYLIST UTILITY - MAIN APPLICATION FORM
// Version 1.0.0
// M. Dilworth  Rev: 01/17/2017
//////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using DataInterface.DataAccess;
using DataInterface.DataModel;
using log4net.Appender;
using LogicLayer.Collections;
using LogicLayer.CommonClasses;
using MSEInterface;
using MSEInterface.Constants;
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

        //string elementCollectionURIShow;
        //string templateCollectionURIShow;
        //string elementCollectionURIPlaylist;
        //string templateModel;

        //Int16 conceptID;
        //string conceptName;

        public Boolean enableShowSelectControls = false;

        #endregion

        #region Collection & binding list definitions
        /// <summary>
        /// Define classes for collections and logic
        /// </summary>

        // Define the binding list object for the list of available shows
        //BindingList<ShowObject> showNames;
        
        internal static readonly XNamespace Atom = "http://www.w3.org/2005/Atom";

        // Instantiate MSE classes
        MANAGE_GROUPS group = new MANAGE_GROUPS();
        MANAGE_PLAYLISTS playlist = new MANAGE_PLAYLISTS();
        MANAGE_TEMPLATES template = new MANAGE_TEMPLATES();
        MANAGE_SHOWS show = new MANAGE_SHOWS();
        MANAGE_ELEMENTS element = new MANAGE_ELEMENTS();

        // Read in MSE settings from config file and set default directories and parameters
        Boolean usingPrimaryMediaSequencer = true;
        Boolean mseEndpoint1_Enable = false;
        string mseEndpoint1 = string.Empty;
        Boolean mseEndpoint2_Enable = false;
        string mseEndpoint2 = string.Empty;
        string topLevelShowsDirectoryURI = string.Empty;
        string masterPlaylistsDirectoryURI = string.Empty;
        string profilesURI = string.Empty;
        string currentShowName = string.Empty;
        string currentPlaylistName = string.Empty;

        // Read in database connection strings
        string LoggingDBConnectionString = Properties.Settings.Default.LoggingDBConnectionString;

        //Read in default Trio profile and channel
        string defaultTrioProfile = Properties.Settings.Default.DefaultTrioProfile;
        string defaultTrioChannel = Properties.Settings.Default.DefaultTrioChannel;                        
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
                // Setup show controls
                if (Properties.Settings.Default.EnableShowSelectControls)
                    enableShowSelectControls = true;
                else
                    enableShowSelectControls = false;
                if (enableShowSelectControls)
                {
                    miSelectDefaultShow.Enabled = true;
                }
                else
                {
                    miSelectDefaultShow.Enabled = false;
                }

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
            lblPlaylistName.Text = currentPlaylistName;
            lblTrioChannel.Text = defaultTrioChannel;
        }

        // Handler for main form load
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Read in config settings - default to Media Sequencer #1
            mseEndpoint1 = Properties.Settings.Default.MSEEndpoint1;
            mseEndpoint2 = Properties.Settings.Default.MSEEndpoint2;
            mseEndpoint1_Enable = Properties.Settings.Default.MSEEndpoint1_Enable;
            mseEndpoint2_Enable = Properties.Settings.Default.MSEEndpoint2_Enable;
            topLevelShowsDirectoryURI = Properties.Settings.Default.MSEEndpoint1 + Properties.Settings.Default.TopLevelShowsDirectory;
            masterPlaylistsDirectoryURI = Properties.Settings.Default.MSEEndpoint1 + Properties.Settings.Default.MasterPlaylistsDirectory;
            profilesURI = Properties.Settings.Default.MSEEndpoint1 + "profiles";
            currentShowName = Properties.Settings.Default.CurrentShowName;
            currentPlaylistName = Properties.Settings.Default.CurrentSelectedPlaylist;
            usingPrimaryMediaSequencer = true;

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

        // Handler from main menu to launch show selection dialog
        private void miSelectDefaultShow_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            string mseEndpoint = string.Empty;
            if (usingPrimaryMediaSequencer)
            {
                mseEndpoint = mseEndpoint1;
            }
            else
            {
                mseEndpoint = mseEndpoint2;
            }
            frmSelectShow selectShow = new frmSelectShow(mseEndpoint);
            dr = selectShow.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // Set the new show
                currentShowName = selectShow.selectedShow;
                lblCurrentShow.Text = currentShowName;

                // Write the new default show out to the config file
                Properties.Settings.Default.CurrentShowName = currentShowName;
                Properties.Settings.Default.Save();
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

    }
}
