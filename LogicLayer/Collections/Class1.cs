using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterface.DataModel;
using DataInterface.DataAccess;
using System.Data.SqlClient;
using System.ComponentModel;

namespace LogicLayer.Collections
{
    /// <summary>
    /// Class for operations related to the available races
    /// </summary>
    public class ExitPollQuestionsCollection
    {
        #region Logger instantiation - uses reflection to get module name
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Properties and Members
        public BindingList<ExitPollQuestionsModel> ExitPollQuestions;
        public string ElectionsDBConnectionString { get; set; }
        #endregion

        #region Public Methods
        // Constructor - instantiates list collection
        public ExitPollQuestionsCollection()
        {
            // Create list
            exitPollQuestions = new BindingList<ExitPollQuestionsModel>();
        }

        /// <summary>
        /// Get the Exit Poll Questions list from the SQL DB; clears out existing collection first
        /// </summary>
        public BindingList<ExitPollQuestionsModel> GetExitPollQuestionsCollection()
        {
            DataTable dataTable;

            // Clear out the current collection
            exitPollQuestions.Clear();

            try
            {
                ExitPollAccess exitPollAccess = new ExitPollAccess();
                exitPollAccess.ElectionsDBConnectionString = ElectionsDBConnectionString;
                dataTable = exitPollAccess.GetExitPollQuestions();

                foreach (DataRow row in dataTable.Rows)
                {
                    var newExitPollQuestion = new ExitPollQuestionsModel()
                    {
                        
                        //Specific to exit polls
                        ExitPoll_mxID = row[mxID] ?? 0,
                        //ExitPoll_BoardID = row[BoardID] ?? 0,
                        ExitPoll_ShortMxLabel = row[shortMxLabel] ?? "",
                        ExitPoll_NumRows = row[Rows] ?? 0,
                        ExitPoll_xRow = row[Row] ?? 0,
                        ExitPoll_BaseQuestion = row[BaseOnAir] ?? false,
                        ExitPoll_RowQuestion = row[RowOnAir] ?? false,
                        ExitPoll_Subtitle = row[BaseOnAir] ?? false,
                        ExitPoll_Suffix { get; set; }
                        ExitPoll_HeaderText_1 { get; set; }
                        ExitPoll_HeaderText_2 { get; set; }
                        ExitPoll_SubsetName { get; set; }
                        ExitPoll_SubsetID { get; set; }
    
                        
                        
                        
                        
                        //Race_ID = Convert.ToInt16(row["Race_ID"] ?? 0),
                        //Election_Type = row["Race_ElectionType"].ToString() ?? "",
                        //Race_Description = row["Race_Description"].ToString() ?? "",
                        //State_Number = Convert.ToInt16(row["State_ID"] ?? 0),
                       // State_Mnemonic = row["State_Abbv"].ToString() ?? "",
                        //State_Name = row["State_Name"].ToString() ?? "",
                        //CD = Convert.ToInt16(row["Race_District"] ?? 0),
                        //Race_Office = row["Race_OfficeCode"].ToString() ?? "",
                        //Race_OfficeSortOrder = Convert.ToInt16(row["Race_OfficeSortOrder"] ?? 0),
                        //Race_PollClosingTime = Convert.ToDateTime(row["Race_PollClosingTime_DateTime"] ?? 0),
                        //Race_UseAPRaceCall = Convert.ToBoolean(row["Use_AP_Race_Call"] ?? 0),
                    };
                    exitPollQuestions.Add(exitPollQuestions);
                }
            }
            catch (Exception ex)
            {
                // Log error
                log.Error("ExitPollsCollection Exception occurred: " + ex.Message);
                log.Debug("ExitPollsCollection Exception occurred", ex);
            }

            // Return 
            return exitPollQuestions;
        }

        /// <summary>
        /// Get the specified race from the collection
        /// </summary>
        public AvailableRaceModel GetRace(BindingList<AvailableRaceModel> AvailableRaces, int itemIndex)
        {
            AvailableRaceModel availableRace = null;
            try
            {
                availableRace = AvailableRaces[itemIndex];
            }
            catch (Exception ex)
            {
                // Log error
                log.Error("AvailableRacesCollection Exception occurred: " + ex.Message);
                log.Debug("AvailableRacesCollection Exception occurred", ex);
            }

            return availableRace;
        }
        #endregion
    }
}
