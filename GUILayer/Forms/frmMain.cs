//////////////////////////////////////////////////////////////////////////////
// MULTI-PLAY PLAYLIST UTILITY - MAIN APPLICATION FORM
// Version 1.0.0
// M. Dilworth  Rev: 01/26/2017
//////////////////////////////////////////////////////////////////////////////

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Linq;
using log4net.Appender;
using LogicLayer.CommonClasses;
using MSEInterface;
using MSEInterface.DataModel;
using DataInterface.DataAccess;
using AsyncClientSocket;

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
        //MANAGE_GROUPS group = new MANAGE_GROUPS();
        MANAGE_PLAYLISTS playlistSource = new MANAGE_PLAYLISTS();
        MANAGE_PLAYLISTS playlistDestination = new MANAGE_PLAYLISTS();
        //MANAGE_TEMPLATES template = new MANAGE_TEMPLATES();
        MANAGE_SHOWS showSource = new MANAGE_SHOWS();
        MANAGE_SHOWS showDestination = new MANAGE_SHOWS();
        //MANAGE_ELEMENTS element = new MANAGE_ELEMENTS();

        // Read in MSE settings from config file and set default directories and parameters
        string mseIpAddressSource = string.Empty;
        string mseIpAddressDestination = string.Empty;
        int msePortRest = 0;
        int msePortPepTalk = 0;
        string mseRestEndpointSource = string.Empty;
        string mseRestEndpointDestination = string.Empty;
        string topLevelShowsDirectoryURIFNC = string.Empty;
        string topLevelShowsDirectoryURIFBN = string.Empty;
        string topLevelShowsDirectoryURIActiveSource = string.Empty;
        string topLevelShowsDirectoryURIActiveDestination = string.Empty;
        string masterPlaylistsDirectoryURIFNC = string.Empty;
        string masterPlaylistsDirectoryURIFBN = string.Empty;
        string masterPlaylistsDirectoryURIActiveSource = string.Empty;
        string masterPlaylistsDirectoryURIActiveDestination = string.Empty;
        string ProducerElementsPlaylistNameFNC = string.Empty;
        string ProducerElementsPlaylistNameFBN = string.Empty;
        string ProducerElementsPlaylistNameActive = string.Empty;
        bool mseConnectedSource = false;
        bool mseConnectedDestination = false;
        string networkSelection = string.Empty;

        // Read in database connection strings
        string LoggingDBConnectionString = Properties.Settings.Default.LoggingDBConnectionString;
        string hostIpAddress = string.Empty;
        string hostName = string.Empty;

        // Define the binding list object for the list of available shows
        private BindingList<ShowObject> showNames;
        // The sublist ID to be returned 
        public string selectedShow { get; set; }

        // Declare TCP client sockets for MSE communications
        public ClientSocket sourceMSEClientSocket;
        public ClientSocket destinationMSEClientSocket;

        // Global for storing the playlist path - used to push to destination MSE
        string playlistPath = string.Empty;

        // For debug
        bool showDebugWindow = false;

        #endregion

        #region Logger instantiation - uses reflection to get module name
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Logging & status setup
        // This method used to implement IAppender interface from log4net; to support custom appends to status strip
        public void DoAppend(log4net.Core.LoggingEvent loggingEvent)
        {
            // Set text on status bar only if logging level is DEBUG or ERROR
            if (loggingEvent.Level.Name == "ERROR")
            {
                //toolStripStatusLabel.BackColor = System.Drawing.Color.Red;
                //toolStripStatusLabel.Text = String.Format("Error Logging Message: {0}: {1}", loggingEvent.Level.Name, loggingEvent.MessageObject.ToString());
            }
            else
            {
                //toolStripStatusLabel.BackColor = System.Drawing.Color.SpringGreen;
                //toolStripStatusLabel.Text = String.Format("Status Logging Message: {0}: {1}", loggingEvent.Level.Name, loggingEvent.MessageObject.ToString());
            }
        }

        // Handler to clear status bar message and reset color
        private void resetStatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.BackColor = System.Drawing.Color.SpringGreen;
            toolStripStatusLabel.Text = "Status Logging Message: Statusbar reset @" + DateTime.Now.ToString();
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
        }

        // Handler for main form load
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                // Read in config settings
                mseIpAddressSource = Properties.Settings.Default.MSEIPAddressSource;
                mseIpAddressDestination = Properties.Settings.Default.MSEIPAddressDestination;
                msePortRest = Properties.Settings.Default.MSEPortRest;
                msePortPepTalk = Properties.Settings.Default.MSEPortPepTalk;

                // Set REST end-points
                mseRestEndpointSource = "http://" + mseIpAddressSource + ":" + Convert.ToInt32(msePortRest) + "/";
                mseRestEndpointDestination = "http://" + mseIpAddressDestination + ":" + Convert.ToInt32(msePortRest) + "/";

                // Read in show & playlist info based on network selected
                networkSelection = Properties.Settings.Default.NetworkSelection;
                if (networkSelection == "FNC")
                {
                    // Set UI widgets
                    rbSelectFNC.Checked = true;
                    rbSelectFBN.Checked = false;
                    // Set paths
                    topLevelShowsDirectoryURIActiveSource = mseRestEndpointSource + Properties.Settings.Default.TopLevelShowsDirectoryFNC;
                    topLevelShowsDirectoryURIActiveDestination = mseRestEndpointDestination + Properties.Settings.Default.TopLevelShowsDirectoryFNC;
                    masterPlaylistsDirectoryURIActiveSource = mseRestEndpointSource + Properties.Settings.Default.MasterPlaylistsDirectoryFNC;
                    masterPlaylistsDirectoryURIActiveDestination = mseRestEndpointDestination + Properties.Settings.Default.MasterPlaylistsDirectoryFNC;
                    ProducerElementsPlaylistNameActive = Properties.Settings.Default.ProducerElementsPlaylistNameFNC;
                    // Set show directory & playlist name labels
                    lblShowDirectory.Text = Properties.Settings.Default.TopLevelShowsDirectoryFNC;
                    lblPlaylistName.Text = Properties.Settings.Default.ProducerElementsPlaylistNameFNC;
                }
                else if (networkSelection == "FBN")
                {
                    // Set UI widgets
                    rbSelectFNC.Checked = false;
                    rbSelectFBN.Checked = true;
                    // Set paths
                    topLevelShowsDirectoryURIActiveSource = mseRestEndpointSource + Properties.Settings.Default.TopLevelShowsDirectoryFBN;
                    topLevelShowsDirectoryURIActiveDestination = mseRestEndpointDestination + Properties.Settings.Default.TopLevelShowsDirectoryFBN;
                    masterPlaylistsDirectoryURIActiveSource = mseRestEndpointSource + Properties.Settings.Default.MasterPlaylistsDirectoryFBN;
                    masterPlaylistsDirectoryURIActiveDestination = mseRestEndpointDestination + Properties.Settings.Default.MasterPlaylistsDirectoryFBN;
                    ProducerElementsPlaylistNameActive = Properties.Settings.Default.ProducerElementsPlaylistNameFBN;
                    // Set show directory & playlist name labels
                    lblShowDirectory.Text = Properties.Settings.Default.TopLevelShowsDirectoryFBN;
                    lblPlaylistName.Text = Properties.Settings.Default.ProducerElementsPlaylistNameFBN;
                }

                // Populate grid/list of shows
                showNames = showSource.GetListOfShows(topLevelShowsDirectoryURIActiveSource);

                // Setup the available shows grid
                availableShowsGrid.AutoGenerateColumns = false;
                var availableShowsGridDataSource = new BindingSource(showNames, null);
                availableShowsGrid.DataSource = availableShowsGridDataSource;

                // Clear selected row for startup
                availableShowsGrid.CurrentCell = null;
                availableShowsGrid.ClearSelection();

                // Display host name and IP address
                hostIpAddress = HostIPNameFunctions.GetLocalIPAddress();
                hostName = HostIPNameFunctions.GetHostName(hostIpAddress);
                lblIpAddress.Text = hostIpAddress;
                lblHostName.Text = hostName;

                // Log application start
                log.Info("Starting Multi-Play Playlist utility");
            }
            catch (Exception ex)
            {
                // Log error
                log.Error("frmMain Exception occurred during main form load: " + ex.Message);
                log.Debug("frmMain Exception occurred during main form load", ex);
            }
        }


        private void frmMain_Activated(object sender, EventArgs e)
        {
            // Clear selected row for startup
            availableShowsGrid.CurrentCell = null;
            availableShowsGrid.ClearSelection();

            // Clear selected show at startup
            selectedShow = String.Empty;
            lblCurrentShow.BackColor = System.Drawing.Color.Yellow;
            lblCurrentShow.Text = "N/A";
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
        }

        // Handler for main form closed - log info
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Log application quit
            log.Info("Quitting Multi-Play Playlist Utility");
        }
        #endregion

        #region Functions related to getting playlist XML payload from source MSE
        // Method to sends request for data to source MSE. Once callback for data received is hit, the data is formatted and sent to the destination MSE.
        private void copyPlaylistXMLSourceToDestination()
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
                try
                {
                    // Clear debug text box
                    this.tbDebug.Text = "";

                    // Instantiate and setup the client sockets
                    // Establish the remote endpoints for the sockets
                    System.Net.IPAddress mseSourceIpAddress = System.Net.IPAddress.Parse(mseIpAddressSource);
                    System.Net.IPAddress mseDestinationIpAddress = System.Net.IPAddress.Parse(mseIpAddressDestination);

                    // Instantiate the MSE client sockets
                    sourceMSEClientSocket = new ClientSocket(mseSourceIpAddress, Convert.ToInt32(msePortPepTalk));
                    destinationMSEClientSocket = new ClientSocket(mseDestinationIpAddress, Convert.ToInt32(msePortPepTalk));

                    // Initialize event handlers for the sockets
                    sourceMSEClientSocket.DataReceived += sourceMSEDataReceived;
                    destinationMSEClientSocket.DataReceived += destinationMSEDataReceived;
                    sourceMSEClientSocket.ConnectionStatusChanged += sourceMSEConnectionStatusChanged;
                    destinationMSEClientSocket.ConnectionStatusChanged += destinationMSEConnectionStatusChanged;

                    // Connect to the source & destination MSE's; call-backs for connection status will indicate status of client sockets
                    sourceMSEClientSocket.AutoReconnect = true;
                    sourceMSEClientSocket.Connect();
                    destinationMSEClientSocket.AutoReconnect = true;
                    destinationMSEClientSocket.Connect();
                }
                catch (Exception ex)
                {
                    // Log error
                    log.Error("Error occurred while trying to setup MSE client sockets for PepTalk: " + ex.Message);
                    log.Debug("Error occurred while trying to setup MSE client sockets for PepTalk", ex);
                }

                // Set the sublist ID
                if (showNames.Count > 0)
                {
                    // Operation now done when show is selected in grid
                    // Get the playlist ID from the grid
                    // int currentShowIndex = availableShowsGrid.CurrentCell.RowIndex;
                    // string ShowName = showNames[currentShowIndex].title.ToString();

                    // Operation now done when show is selected in grid
                    // Set new show name
                    // selectedShow = ShowName;
                    // lblCurrentShow.Text = selectedShow;

                    // Get the URI to the playlist
                    // Check for a playlist in the VDOM with the specified name & return the Down link
                    // Delete the group so it can be re-created
                    // MSE OPERATION
                    string playlistAltLink = string.Empty;

                    // Get playlists directory URI based on current show
                    string showPlaylistsDirectoryURISource = showSource.GetPlaylistDirectoryFromShow(topLevelShowsDirectoryURIActiveSource, selectedShow);
                    string showPlaylistsDirectoryURIDestination = showSource.GetPlaylistDirectoryFromShow(topLevelShowsDirectoryURIActiveDestination, selectedShow);

                    // Check to make sure playlist exists on destination MSE; if not, alert operator
                    bool playlistExistsOnDestinationMSE = playlistDestination.CheckIfPlaylistExists(showPlaylistsDirectoryURIDestination, ProducerElementsPlaylistNameActive);
                    if (!playlistExistsOnDestinationMSE)
                    {
                        toolStripStatusLabel.BackColor = System.Drawing.Color.Red;
                        toolStripStatusLabel.Text = "Specified playlist ID from the source MSE does not exist on the destination MSE";
                        return;
                    }

                    playlistAltLink = playlistSource.GetPlaylistAltLink(showPlaylistsDirectoryURISource, ProducerElementsPlaylistNameActive);
                    if (playlistAltLink != string.Empty)
                    {
                        // Do the PepTalk operations
                        // Extract the playlist URI from the playlist path; also converts the escaped { & } characters
                        // Note that playlist name has application scope
                        playlistPath = getPlaylistPathFromURI(removeEscapeSequences(playlistAltLink));

                        // Frame and send the commands
                        // Send leading command
                        string cmd1 = "1 protocol peptalk noevents";
                        if (mseConnectedSource)
                        {
                            sourceMSESendCommand(cmd1);

                            if (showDebugWindow)
                            {
                                tbDebug.AppendText("SEND TO SOURCE MSE: " + cmd1 + "\r\n\r\n");
                            }
                        }

                        // Send command to get playlist XML
                        string cmd2 = "2 get {" + Convert.ToString(getByteCount(playlistPath)) + "}" + playlistPath;
                        if (mseConnectedSource)
                        {
                            sourceMSESendCommand(cmd2);

                            if (showDebugWindow)
                            {
                                tbDebug.AppendText("SEND TO SOURCE MSE: " + cmd2 + "\r\n\r\n");
                            }
                        }

                        // Update time label
                        timeOfLastCopyLabel.Text = String.Format("{0:h:mm:ss tt  MMM dd, yyyy}", DateTime.Now);

                        // Upate status bar
                        toolStripStatusLabel.BackColor = System.Drawing.Color.SpringGreen;
                        toolStripStatusLabel.Text = "Playlist successfully copied from source MSE to destination MSE @" +
                            String.Format("{0:h:mm:ss tt  MMM dd, yyyy}", DateTime.Now);

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

                // Upate status bar
                toolStripStatusLabel.BackColor = System.Drawing.Color.Red;
                toolStripStatusLabel.Text = "Error occurred while trying to copy playlist from source MSE to destination MSE";
            }
        }
        #endregion

        #region MSE PepTalk connection & send/receive methods
        // Handler for source & destination MSE connection status change
        public void sourceMSEConnectionStatusChanged(ClientSocket sender, ClientSocket.ConnectionStatus status)
        {
            // Set status
            if (status == ClientSocket.ConnectionStatus.Connected)
            {
                mseConnectedSource = true;
            }
            else
            {
                mseConnectedSource = false;
            }
            // Send to log - DEBUG ONLY
            log.Debug("Source MSE Connection Status: " + status.ToString());
        }

        public void destinationMSEConnectionStatusChanged(ClientSocket sender, ClientSocket.ConnectionStatus status)
        {
            // Set status
            if (status == ClientSocket.ConnectionStatus.Connected)
            {
                mseConnectedDestination = true;
            }
            else
            {
                mseConnectedDestination = false;
            }
            // Send to log - DEBUG ONLY
            log.Debug("Destination MSE Connection Status: " + status.ToString());
        }

        // Send a command to the source MSE
        public void sourceMSESendCommand(String dataString)
        {
            try
            {
                // Send the data; terminiate with CRLF
                sourceMSEClientSocket.Send(dataString + "\n");

                // Log if debug mode
                log.Debug("Command sent to source MSE: " + dataString);
            }
            catch (Exception ex)
            {
                // Log error
                log.Error("Error occurred while trying to send data to source MSE client port: " + ex.Message);
                log.Debug("Error occurred while trying to send data to source MSE client port", ex);
            }
        }

        // Send a command to the destination MSE; terminiate with CRLF
        public void destinationMSESendCommand(String dataString)
        {
            try
            {
                // Send the data
                destinationMSEClientSocket.Send(dataString + "\n");

                // Log if debug mode
                log.Debug("Command sent to destination MSE: " + dataString);
            }
            catch (Exception ex)
            {
                // Log error
                log.Error("Error occurred while trying to send data to destination MSE client port: " + ex.Message);
                log.Debug("Error occurred while trying to send data to destination MSE client port", ex);
            }
        }

        // This delegate enables asynchronous calls for processing the data received from the source MSE
        delegate void sendPayloadCallback(string text);
        // This method makes thread-safe calls on the debug windows textbox and sends the payload to the destination MSE. 
        // If the calling thread is different from the thread that created the debug TextBox control, this method creates a SetTextCallback 
        // and calls itself asynchronously using the Invoke method. If the calling thread is the same as the thread that created the TextBox 
        // control, the Text property is set directly. 
        private void sendPayload(string playlistXMLReceived)
        {
            try
            {
                // Send protocol command
                string cmd1 = "1 protocol peptalk noevents";

                if (mseConnectedDestination)
                {
                    destinationMSESendCommand(cmd1);
                }

                // Strip off first part of response from source MSE e.g. 2 get {102}; look for first right-hand curly bracket
                playlistXMLReceived = playlistXMLReceived.Trim();
                int startPos = playlistXMLReceived.IndexOf("}");
                playlistXMLReceived = playlistXMLReceived.Substring(startPos + 1);

                // Append path to playlist then space as field delimiter; last processed playlist path is stored in a global variable
                string cmd2 = "2 replace {" + Convert.ToString(getByteCount(playlistPath)) + "}" + playlistPath + " ";
                // Now, append XML payload preceded by byte count
                cmd2 = cmd2 + "{" + Convert.ToString(getByteCount(playlistXMLReceived)) + "}" + playlistXMLReceived;
                // Send the payload to the destination MSE
                if (mseConnectedDestination)
                {
                    destinationMSESendCommand(cmd2);
                }

                // Set the debug text
                // DISABLED FOR NOW - NEED TO RE-DO AS WORKER THREAD
                // InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if ((this.tbDebug.InvokeRequired) && (showDebugWindow))
                {
                    //sendPayloadCallback callback = new sendPayloadCallback(sendPayload);
                    //this.Invoke(callback, new object[] { "SEND TO DESTINATON MSE: " + cmd2 + "\r\n\r\n" });
                }
                else if (showDebugWindow)
                {
                    //this.tbDebug.AppendText("SEND TO DESTINATON MSE: " + cmd2 + "\r\n\r\n");
                }

                // Post application log entry
                ApplicationLogsAccess applicationLogsAccess = new ApplicationLogsAccess();
                applicationLogsAccess.DBConnectionString = LoggingDBConnectionString;
                applicationLogsAccess.PostApplicationLogEntry(
                    Properties.Settings.Default.ApplicationName,
                    "Copied XML payload for specified " + networkSelection + " show/playlist from source MSE to destination MSE",
                    hostName,
                    hostIpAddress,
                    mseIpAddressSource,
                    mseIpAddressDestination,
                    "Copied playlist XML payload",
                    "Show/Playlist Path: " + topLevelShowsDirectoryURIActiveSource + ProducerElementsPlaylistNameActive,
                    System.DateTime.Now
                );
            }
            catch (Exception ex)
            {
                // Log error
                log.Error("Error occurred while trying to send payload to destination MSE: " + ex.Message);
                log.Debug("Error occurred while trying to send payload to destination MSE", ex);
            }
        }

        // Handler for data received back from source MSE PepTalkclient socket; this will be the playlist data XML payload
        private void sourceMSEDataReceived(ClientSocket sender, object data)
        {
            // Make call to format and send the data to the destination MSE
            // Only send if it's the XML payload => command ID = 2
            string inStr = data.ToString();
            string payloadStr = string.Empty;

            // Check for, and strip out echoed protocol command
            if (inStr[0] == '1')
            {
                
                // Strip out any echoed protocol command 
                int startPos = inStr.IndexOf("\r\n") + 2;
                payloadStr = inStr.Substring(startPos);
                //payloadStr = payloadStr.Substring(0, payloadStr.Length - 1);

                if ((payloadStr.Length > 0) && (payloadStr[0] == '2'))
                {
                    //this.sendPayload(data.ToString());
                    this.sendPayload(payloadStr);
                    // Log if debug mode
                    log.Debug("Command data received from source MSE: " + data);
                }
                
            }
            else if (inStr[0] == '2')
            {         
                payloadStr = inStr;
                this.sendPayload(payloadStr);
                // Log if debug mode
                log.Debug("Command data received from source MSE: " + data);
            }
        }

        // This delegate enables asynchronous calls for setting the text for the debug textbox; shows status info received from
        // destination MSE.
        delegate void setTextCallback(string text);
        // This method makes thread-safe calls on the debug windows textbox. If the calling thread is different from the thread that
        // created the TextBox control, this method creates a SetTextCallback and calls itself asynchronously using the Invoke method.
        // If the calling thread is the same as the thread that created the TextBox control, the Text property is set directly. 
        private void setText(string text)
        {
            // Set the debug text
            // InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if ((this.tbDebug.InvokeRequired) && (showDebugWindow))
            {
                setTextCallback callback = new setTextCallback(setText);
                this.Invoke(callback, new object[] { "RECEIVED FROM DESTINATION MSE: " + text + "\r\n\r\n" });
            }
            else if (showDebugWindow)
            {
                //this.tbDebug.AppendText("RECEIVED FROM DESTINATION MSE: " + text + "\r\n\r\n");
                this.tbDebug.AppendText(text);
            }
        }

        // Handler for data received back from destination MSE PepTalkclient socket
        public void destinationMSEDataReceived(ClientSocket sender, object data)
        {
            //Interpret the received data object as a string & post to debug textbox
            setText(data.ToString());
            // Log error
            if (data.ToString().IndexOf("error") > -1)
            {
                log.Error("Error message received from Destination PepTalk client socket: " + data.ToString());
            }
            // Add the received data to the log - DEBUG ONLY
            log.Debug("Data received - Destination PepTalk client socket: " + data.ToString());
        }
        #endregion

        #region General Form related methods
        // General update timer
        private void timerStatusUpdate_Tick(object sender, EventArgs e)
        {
            referenceTime = DateTime.Now;

            //label1.Text = Convert.ToString(referenceTime);
            timeOfDayLabel.Text = String.Format("{0:h:mm:ss tt  MMM dd, yyyy}", referenceTime);

            // Update MSE connected indicators for source & destination MSE's
            if (mseConnectedSource)
            {
                indicatorSourceMSE.FillColor = System.Drawing.Color.Lime;
            }
            else
            {
                indicatorSourceMSE.FillColor = System.Drawing.Color.Gray;
            }
            if (mseConnectedDestination)
            {
                indicatorDestinationMSE.FillColor = System.Drawing.Color.Lime;
            }
            else
            {
                indicatorDestinationMSE.FillColor = System.Drawing.Color.Gray;
            }
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
                    // Call method to initiate copy of data from source to destination. Method sends request for data to source MSE. 
                    // Once callback for data received is hit, the data is formatted and sent to the destination MSE.
                    copyPlaylistXMLSourceToDestination();
                    break;
            }
        }
        #endregion

        #region PepTalk utility functions
        // Method to do string replace of escape sequences for "{", "}", "#"
        private string removeEscapeSequences(string inString)
        {
            string outString;
            outString = inString.Replace("%7B", "{").Replace("%7D", "}").Replace("%23", "#");
            return outString;
        }

        // Method to return byte count for string
        private int getByteCount(string inString)
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

        #region Action button handlers
        // Handler for Select & Copy Show button
        private void btnSelectShow_Click(object sender, EventArgs e)
        {
            // Call method to initiate copy of data from source to destination. Method sends request for data to source MSE. 
            // Once callback for data received is hit, the data is formatted and sent to the destination MSE.
            copyPlaylistXMLSourceToDestination();
        }

        // Handler for double-click on show select grid
        private void availableShowsGrid_DoubleClick(object sender, EventArgs e)
        {
            // Call method to initiate copy of data from source to destination. Method sends request for data to source MSE. 
            // Once callback for data received is hit, the data is formatted and sent to the destination MSE.
            copyPlaylistXMLSourceToDestination();
        }

        // Handler for button to refresh list of shows
        private void btnRefreshShowList_Click(object sender, EventArgs e)
        {
            showNames.Clear();

            // Gets the URI's for available shows
            showNames = showSource.GetListOfShows(mseRestEndpointSource + topLevelShowsDirectoryURIActiveSource);

            // Setup the available stacks grid
            availableShowsGrid.AutoGenerateColumns = false;
            var availableShowsGridDataSource = new BindingSource(showNames, null);
            availableShowsGrid.DataSource = availableShowsGridDataSource;

            // Clear the show selection
            availableShowsGrid.CurrentCell = null;
            availableShowsGrid.ClearSelection();
        }
        #endregion

        private void availableShowsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region UI event handlers
        // Handler for select FNC as network
        private void rbSelectFNC_CheckedChanged(object sender, EventArgs e)
        {
            // Set controls background color
            rbSelectFNC.BackColor = System.Drawing.Color.SpringGreen;
            rbSelectFBN.BackColor = System.Drawing.Color.Gray;

            // Set active variables
            topLevelShowsDirectoryURIActiveSource = topLevelShowsDirectoryURIFNC;
            masterPlaylistsDirectoryURIActiveSource = masterPlaylistsDirectoryURIFNC;
            ProducerElementsPlaylistNameActive = ProducerElementsPlaylistNameFNC;
            // Set show directory & playlist name labels
            lblShowDirectory.Text = Properties.Settings.Default.TopLevelShowsDirectoryFNC;
            lblPlaylistName.Text = Properties.Settings.Default.ProducerElementsPlaylistNameFNC;

            // Set & save out the network selection
            networkSelection = "FNC";
            Properties.Settings.Default.NetworkSelection = networkSelection;
            Properties.Settings.Default.Save();
        }

        // Handler for select FBN as network
        private void rbSelectFBN_CheckedChanged(object sender, EventArgs e)
        {
            // Set controls background color
            rbSelectFBN.BackColor = System.Drawing.Color.SpringGreen;
            rbSelectFNC.BackColor = System.Drawing.Color.Gray;

            // Set active variables
            topLevelShowsDirectoryURIActiveSource = topLevelShowsDirectoryURIFBN;
            masterPlaylistsDirectoryURIActiveSource = masterPlaylistsDirectoryURIFBN;
            ProducerElementsPlaylistNameActive = ProducerElementsPlaylistNameFBN;
            // Set show directory & playlist name labels
            lblShowDirectory.Text = Properties.Settings.Default.TopLevelShowsDirectoryFBN;
            lblPlaylistName.Text = Properties.Settings.Default.ProducerElementsPlaylistNameFBN;

            // Set & save out the network selection
            networkSelection = "FBN";
            Properties.Settings.Default.NetworkSelection = networkSelection;
            Properties.Settings.Default.Save();
        }

        private void availableShowsGrid_SelectionChanged(object sender, EventArgs e)
        {
            // Set the sublist ID
            if (showNames.Count > 0)
            {
                //Get the playlist ID from the grid
                int currentShowIndex = availableShowsGrid.CurrentCell.RowIndex;
                string ShowName = showNames[currentShowIndex].title.ToString();

                // Set new show name
                selectedShow = ShowName;
                lblCurrentShow.BackColor = System.Drawing.Color.Gray;
                lblCurrentShow.Text = selectedShow;
            }
        }
    }
    #endregion
}
