//////////////////////////////////////////////////////////////////////////////
// MULTI-PLAY PLAYLIST UTILITY - MAIN APPLICATION FORM
// Version 1.0.0
// M. Dilworth  Rev: 01/17/2017
//////////////////////////////////////////////////////////////////////////////

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing;
using log4net.Appender;
using LogicLayer.CommonClasses;
using MSEInterface;
using MSEInterface.DataModel;
using AsyncClientSocket;
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
        string mseIpAddressSource = string.Empty;
        string mseIpAddressDestination = string.Empty;
        int msePortRest = 0;
        int msePortPepTalk = 0;
        string mseRestEndpointSource = string.Empty;
        string mseRestEndpointDestination = string.Empty;
        string topLevelShowsDirectoryURI = string.Empty;
        string masterPlaylistsDirectoryURI = string.Empty;
        string ProducerElementsPlaylistName = string.Empty;

        // Read in database connection strings
        string LoggingDBConnectionString = Properties.Settings.Default.LoggingDBConnectionString;

        // Define the binding list object for the list of available shows
        private BindingList<ShowObject> showNames;
        // The sublist ID to be returned 
        public string selectedShow { get; set; }

        // Declare TCP client sockets for MSE communications
        public ClientSocket sourceMSEClientSocket;
        public ClientSocket destinationMSEClientSocket;

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

                // Enable handling of function keys; setup method for function keys and assign delegate
                KeyPreview = true;
                this.KeyUp += new System.Windows.Forms.KeyEventHandler(KeyEvent);

                timerStatusUpdate.Enabled = true;

                // Make entry into applications log
                //ApplicationSettingsFlagsAccess applicationSettingsFlagsAccess = new ApplicationSettingsFlagsAccess();
                string hostIpAddress = string.Empty;
                string hostName = string.Empty;
                hostIpAddress = HostIPNameFunctions.GetLocalIPAddress();
                hostName = HostIPNameFunctions.GetHostName(hostIpAddress);
                lblIpAddress.Text = hostIpAddress;
                lblHostName.Text = hostName; 

                // Set version number
                var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                this.Text = String.Format("Multi-Play Playlist Utility  Version {0}", version);
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
            // Read in config settings
            mseIpAddressSource = Properties.Settings.Default.MSEIPAddressSource;
            mseIpAddressDestination = Properties.Settings.Default.MSEIPAddressDestination;
            msePortRest = Properties.Settings.Default.MSEPortRest;
            msePortPepTalk = Properties.Settings.Default.MSEPortPepTalk;

            // Set REST end-points
            mseRestEndpointSource = "http://" + mseIpAddressSource + ":" + Convert.ToInt32(msePortRest) + "/";
            mseRestEndpointDestination = "http://" + mseIpAddressDestination + ":" + Convert.ToInt32(msePortRest) + "/";

            // Read in show & playlist info
            topLevelShowsDirectoryURI = mseRestEndpointSource + Properties.Settings.Default.TopLevelShowsDirectory;
            masterPlaylistsDirectoryURI = mseRestEndpointSource + Properties.Settings.Default.MasterPlaylistsDirectory;
            ProducerElementsPlaylistName = Properties.Settings.Default.ProducerElementsPlaylistName;

            // Set show directory & playlist name labels
            lblShowDirectory.Text = Properties.Settings.Default.TopLevelShowsDirectory;
            lblPlaylistName.Text = ProducerElementsPlaylistName;

            // Populate grid/list of shows
            // Gets the URI's for available shows
            MANAGE_SHOWS getShowList = new MANAGE_SHOWS();
            showNames = getShowList.GetListOfShows(mseRestEndpointSource + Properties.Settings.Default.TopLevelShowsDirectory);

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


        #region MSE PepTalk connection methods
        // Method to setup the PepTalk connections to the source & destination MSE's
        public void setupMSEClientSockets()
        {
            // Instantiate and setup the client sockets
            // Establish the remote endpoint for the sockets
            System.Net.IPAddress mseSourceIpAddress = System.Net.IPAddress.Parse(mseIpAddressSource);
            System.Net.IPAddress mseDestinationIpAddress = System.Net.IPAddress.Parse(mseIpAddressDestination);
            sourceMSEClientSocket = new ClientSocket(mseSourceIpAddress, Convert.ToInt32(msePortPepTalk));
            destinationMSEClientSocket = new ClientSocket(mseDestinationIpAddress, Convert.ToInt32(msePortPepTalk));

            // Initialize the events
            //sourceMSEClientSocket.DataReceived += Source_MSE_DataReceived;
            //sourceMSEClientSocket.ConnectionStatusChanged += GraphicsChannel_ConnectionStatusChanged;

            // Connect
            sourceMSEClientSocket.AutoReconnect = true;
            sourceMSEClientSocket.Connect();
            destinationMSEClientSocket.AutoReconnect = true;
            destinationMSEClientSocket.Connect();
        }

        // Send graphics channel data - called when graphics channel first instantiated
        public void SendGraphicsChannelData(String dataString)
        {
            // Send the first data
            //GraphicsChannelClientSocket.Send(dataString);
        }

        // Handler for data received back from graphics channel
        public void Source_MSE_DataReceived(ClientSocket sender, object data)
        {
            //Interpret the received data object as a string

            //Add the received data to the log - DEBUG ONLY - no current function for returned data
            //log.Debug("Data received: " + strData);
        }

        // Handler for graphics channel connection status change
        public void GraphicsChannel_ConnectionStatusChanged(ClientSocket sender, ClientSocket.ConnectionStatus status)
        {
            // Set status
            if (status == ClientSocket.ConnectionStatus.Connected)
            {
                //GraphicsChannelConnected = true;
            }
            else
            {
                //GraphicsChannelConnected = false;
            }
            // Send to log - DEBUG ONLY
            //log.Debug("Connection Status: " + status.ToString());
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

        #region PepTalk utility functions
        // Method to do string replace of escape sequences for "{" & "}"
        private string removeEscapeSequences(string inString)
        {
            string outString;
            outString = inString.Replace("%7B", "{").Replace("%7D", "}");
            return outString;
        }

        // Method to return byte count for string
        private int getByteCount (string inString)
        {
            return System.Text.ASCIIEncoding.ASCII.GetByteCount(inString);
        }

        // Method to extract the playlist ID from the complete playlist URI
        string getPlaylistPathFromURI(string playlistURI)
        {
            string playlistPath = string.Empty;
            int startPos = 0;

            try
            {
                startPos = playlistURI.IndexOf("/element_collection/") + "/element_collection".Length;
                playlistPath = playlistURI.Substring(startPos);
                playlistPath = playlistPath.Substring(0, playlistPath.Length - 1);
            }
            catch (Exception ex)
            {
                // Log error
                log.Error("Exception occurred while trying to extract Playlist ID: " + ex.Message);
                log.Debug("Exception occurred while trying to extract Playlist ID", ex);
            }
            return playlistPath;
        }
        #endregion


        // Handler for Select & Copy Show button
        private void btnSelectShow_Click(object sender, EventArgs e)
        {
            // This is where the real work is done. Operations are as follows:
            // 1. MSE operations
            //    a. Connect to the source MSE and display available shows
            //    b. Operator selects desired show to copy from
            //    c. Get the URI for the specified (fixed name) playlist of the selected show
            // 2. PepTalk operations
            //    a. Connect to the source MSE on PepTalk port
            //    b. Get the XML for the show's playlist
            //    c. Connect to the destination MSE on PepTalk port
            //    d. Post the XML using REPLACE command 
            try
                {
                // Set the sublist ID
                if (showNames.Count > 0)
                {
                    //Get the playlist ID from the grid
                    int currentShowIndex = availableShowsGrid.CurrentCell.RowIndex;
                    string ShowName = showNames[currentShowIndex].title.ToString();

                    // Set new show name
                    selectedShow = ShowName;
                    lblCurrentShow.Text = selectedShow;

                    // Get the URI to the playlist
                    // Check for a playlist in the VDOM with the specified name & return the Down link
                    // Delete the group so it can be re-created
                    // MSE OPERATION
                    string playlistAltLink = string.Empty;

                    // Get playlists directory URI based on current show
                    string showPlaylistsDirectoryURI = show.GetPlaylistDirectoryFromShow(topLevelShowsDirectoryURI, selectedShow);

                    playlistAltLink = playlist.GetPlaylistAltLink(showPlaylistsDirectoryURI, ProducerElementsPlaylistName);
                    if (playlistAltLink != string.Empty)
                    {
                        // Show current show path - DEBUG ONLY
                        tbDebug.Text = playlistAltLink;

                        // Now, do the PepTalk operations
                        // Extract the playlist URI from the playlist path; also converts the escaped { & } characters
                        string playlistPath = getPlaylistPathFromURI(removeEscapeSequences(playlistAltLink));
                        //tbDebug.Text = playlistId + "\r\n" + Convert.ToString(getByteCount(playlistId));

                        // Frame and send the commands
                        // Send leading command
                        string cmd1 = "1 protocol peptalk noevents";
                        // Send command to get playlist XML
                        string cmd2 = "2 get {" + Convert.ToString(getByteCount(playlistPath)) + "}" + playlistPath;
                        tbDebug.Text = cmd1 + "\r\n\r\n" + cmd2;
                    }
                    // Log if the URI could not be resolved
                    else
                    {
                        log.Error("Could not resolve Playlist Alt link");
                        log.Debug("Could not resolve Playlist Alt link");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error
                log.Error("Error occurred while trying to select and copy playlist: " + ex.Message);
                log.Debug("Error occurred while trying to select and copy playlist", ex);
            }
        }

        // Handler for button to refresh list of shows
        private void btnRefreshShowList_Click(object sender, EventArgs e)
        {
            showNames.Clear();

            // Gets the URI's for available shows
            MANAGE_SHOWS getShowList = new MANAGE_SHOWS();

            showNames = getShowList.GetListOfShows(mseRestEndpointSource + Properties.Settings.Default.TopLevelShowsDirectory);

            // Setup the available stacks grid
            availableShowsGrid.AutoGenerateColumns = false;
            var availableShowsGridDataSource = new BindingSource(showNames, null);
            availableShowsGrid.DataSource = availableShowsGridDataSource;
        }

        private void availableShowsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
