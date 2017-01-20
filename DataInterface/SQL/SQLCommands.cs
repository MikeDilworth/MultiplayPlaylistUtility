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
        public static readonly string sqlSetFGEApplicationLogEntry = "setFGEApplicationLogEntry " +
                                                                       "@Application_Name, " +
                                                                       "@Application_Description, " +
                                                                       "@HostPC_Name, " +
                                                                       "@HostPC_IP_Address, " +
                                                                       "@Engine_Enabled_1, " +
                                                                       "@Engine_IP_Address_1, " +
                                                                       "@Engine_Enabled_2, " +
                                                                       "@Engine_IP_Address_2, " +
                                                                       "@Entry_Text, " +
                                                                       "@Application_Version, " +
                                                                       "@Application_ID, " + 
                                                                       "@Comments, " + 
                                                                       "@CurrentSystemTime";


    }
}
