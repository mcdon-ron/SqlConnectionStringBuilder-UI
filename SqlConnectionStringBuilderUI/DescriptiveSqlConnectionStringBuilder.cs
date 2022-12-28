using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;

namespace SqlConnectionStringBuilderUI
{
    public class DescriptiveSqlConnectionStringBuilder
    {
        private SqlConnectionStringBuilder builder;

        public DescriptiveSqlConnectionStringBuilder()
        {
            builder = new SqlConnectionStringBuilder();
        }

        public DescriptiveSqlConnectionStringBuilder(string connectionString)
        {
            builder = new SqlConnectionStringBuilder(connectionString);

        }

        [DisplayName("ApplicationIntent")]
        [Description("Declares the application workload type when connecting to a server.")]
        public ApplicationIntent ApplicationIntent
        { get { return builder.ApplicationIntent; } set { builder.ApplicationIntent = value; } }

        [DisplayName("Application Name")]
        [Description("The name of the application, or \".NET SqlClient Data Provider\" if no name has been supplied.")]
        public string ApplicationName
        { get { return builder.ApplicationName; } set { builder.ApplicationName = value; } }

        [DisplayName("AttachDBFilename")]
        [Description("The name of the primary file, including the full path name, of an attachable database.")]
        public string AttachDBFilename
        { get { return builder.AttachDBFilename; } set { builder.AttachDBFilename = value; } }

        [DisplayName("ConnectionString")]
        [Description("The connection string used to connect to the Data Source.")]
        public string ConnectionString
        { get { return builder.ConnectionString; } set { builder.ConnectionString = value; } }

        [DisplayName("ConnectRetryCount")]
        [Description("Number of attempts to restore connection.")]
        public int ConnectRetryCount
        { get { return builder.ConnectRetryCount; } set { builder.ConnectRetryCount = value; } }

        [DisplayName("ConnectRetryInterval")]
        [Description("Delay between attempts to restore connection.")]
        public int ConnectRetryInterval
        { get { return builder.ConnectRetryInterval; } set { builder.ConnectRetryInterval = value; } }
    }
}
