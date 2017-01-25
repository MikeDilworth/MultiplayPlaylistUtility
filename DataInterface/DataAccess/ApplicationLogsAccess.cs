
namespace DataInterface.DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    using DataInterface.SQL;

    public class ApplicationLogsAccess
    {
        #region Logger instantiation - uses reflection to get module name
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Properties and Members
        public string DBConnectionString { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Method to post an entry to the application log
        /// </summary>
        public void PostApplicationLogEntry(
                            string application_Name, 
                            string application_Description,
                            string hostPC_Name,
                            string hostPC_IP_Address,
                            string source_MSE_IP_Address,
                            string destination_MSE_IP_Address,
                            string entry_Text,
                            string comments,
                            DateTime currentSystemTime
                           )
        {
            try
            {
                // Instantiate the connection
                using (SqlConnection connection = new SqlConnection(DBConnectionString))
                {
                    connection.Open();

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {

                            SqlTransaction transaction;
                            // Start a local transaction.
                            transaction = connection.BeginTransaction("Post Application Log Entry");

                            // Must assign both transaction object and connection 
                            // to Command object for a pending local transaction
                            cmd.Connection = connection;
                            cmd.Transaction = transaction;

                            try
                            {
                                //Specify base command
                                cmd.CommandText = SQLCommands.sqlSetMSELogEntry;

                                //Set parameters
                                cmd.Parameters.Add("@Application_Name", SqlDbType.NVarChar).Value = application_Name;
                                cmd.Parameters.Add("@Application_Description", SqlDbType.NVarChar).Value = application_Description;
                                cmd.Parameters.Add("@HostPC_Name", SqlDbType.NVarChar).Value = hostPC_Name;
                                cmd.Parameters.Add("@HostPC_IP_Address", SqlDbType.NVarChar).Value = hostPC_IP_Address;
                                cmd.Parameters.Add("Source_MSE_IP_Address", SqlDbType.NVarChar).Value = source_MSE_IP_Address;
                                cmd.Parameters.Add("Destination_MSE_IP_Address", SqlDbType.NVarChar).Value = destination_MSE_IP_Address;
                                cmd.Parameters.Add("Entry_Text", SqlDbType.NVarChar).Value = entry_Text;
                                cmd.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = comments;
                                cmd.Parameters.Add("@CurrentSystemTime", SqlDbType.DateTime).Value = currentSystemTime;

                                sqlDataAdapter.SelectCommand = cmd;
                                sqlDataAdapter.SelectCommand.Connection = connection;
                                sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                                // Execute stored proc to store top-level metadata
                                sqlDataAdapter.SelectCommand.ExecuteNonQuery();

                                //Attempt to commit the transaction
                                transaction.Commit();
                            }
                            catch (Exception)
                            {
                                transaction.Rollback();
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Log error
                log.Error("ApplicationLogsAccess error while posting application log entry: " + ex.Message);
                log.Debug("ApplicationLogsAccess error while posting application log entry", ex);
            }
        }

        #endregion
    }
}