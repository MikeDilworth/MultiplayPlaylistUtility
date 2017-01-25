namespace DataInterface.SQL
{
    /// <summary>
    /// Class for static SQL command strings
    /// </summary>
    public static class SQLCommands
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Stack related functions
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Sql to get the top-level stack metadata
        /// </summary>
        public static readonly string sqlGetStacksList = "SELECT * FROM MSE_Stacks";

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Application log related functions
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Sql to make an entry in the applications log
        /// </summary>
        public static readonly string sqlSetMSELogEntry = "setMSECopyLogEntry " +
                                                                       "@Application_Name, " +
                                                                       "@Application_Description, " +
                                                                       "@HostPC_Name, " +
                                                                       "@HostPC_IP_Address, " +
                                                                       "@Source_MSE_IP_Address, " +
                                                                       "@Destination_MSE_IP_Address, " +
                                                                       "@Entry_Text, " +
                                                                       "@Comments, " + 
                                                                       "@CurrentSystemTime";
    }
}
