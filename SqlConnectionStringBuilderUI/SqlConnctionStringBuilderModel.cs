using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel;
using System.Data.Common;

namespace SqlConnectionStringBuilderUI
{
    /// <summary>
    /// Provides a simple way to create and manage the contents of connection strings used by the <seealso cref="SqlConnection"/> class.
    /// </summary>
    [DisplayName("SqlConnectionStringBuilder")]
    [Description(Class_desc)]
    [RefreshProperties(RefreshProperties.All)]
    public class SqlConnctionStringBuilderModel
    {
        private const string Class_desc =
            "Provides a simple way to create and manage the contents of connection strings used by the SqlConnection class.";

        private readonly SqlConnectionStringBuilder builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlConnectionStringBuilder"/> class.
        /// </summary>
        public SqlConnctionStringBuilderModel()
        {
            builder = new SqlConnectionStringBuilder();

            // get the default values
            ApplicationIntent_default = builder.ApplicationIntent;
            ApplicationName_default = builder.ApplicationName;
            AttachDBFilename_default = builder.AttachDBFilename;
            ConnectRetryCount_default = builder.ConnectRetryCount;
            ConnectRetryInterval_default = builder.ConnectRetryInterval;
            ConnectTimeout_default = builder.ConnectTimeout;
            CurrentLanguage_default = builder.CurrentLanguage;
            DataSource_default = builder.DataSource;
            Encrypt_default = builder.Encrypt;
            Enlist_default = builder.Enlist;
            FailoverPartner_default = builder.FailoverPartner;
            InitialCatalog_default = builder.InitialCatalog;
            IntegratedSecurity_default = builder.IntegratedSecurity;
            LoadBalanceTimeout_default = builder.LoadBalanceTimeout;
            MaxPoolSize_default = builder.MaxPoolSize;
            MinPoolSize_default = builder.MinPoolSize;
            MultipleActiveResultSets_default = builder.MultipleActiveResultSets;
            MultiSubnetFailover_default = builder.MultiSubnetFailover;
            PacketSize_default = builder.PacketSize;
            Password_default = builder.Password;
            PersistSecurityInfo_default = builder.PersistSecurityInfo;
            PoolBlockingPeriod_default = builder.PoolBlockingPeriod;
            Pooling_default = builder.Pooling;
            Replication_default = builder.Replication;
            TransactionBinding_default = builder.TransactionBinding;
            TrustServerCertificate_default = builder.TrustServerCertificate;
            TypeSystemVersion_default = builder.TypeSystemVersion;
            UserID_default = builder.UserID;
            UserInstance_default = builder.UserInstance;
            WorkstationID_default = builder.WorkstationID;
        }

        public void Clear()
        {
            builder.Clear();
        }

        private const string CatBasic = "Basic";
        private const string CatExtended = "Extended";

        private const string ApplicationIntent_desc =
            "Declares the application workload type when connecting to a database in an SQL Server Availability Group." +
            " You can set the value of this property with System.Data.SqlClient.ApplicationIntent." +
            " For more information about SqlClient support for Always On Availability Groups," +
            " see SqlClient Support for High Availability, Disaster Recovery.";

        /// <summary>
        /// Declares the application workload type when connecting to a database in an SQL Server Availability Group.
        /// You can set the value of this property with <see cref="ApplicationIntent"/>.
        /// For more information about SqlClient support for Always On Availability Groups,
        /// see SqlClient Support for High Availability, Disaster Recovery.
        /// </summary>
        /// <returns>
        /// Returns the current value of the property (a value of type <see cref="ApplicationIntent"/>).
        /// </returns>
        [DisplayName("ApplicationIntent")]
        [Description(ApplicationIntent_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public ApplicationIntent ApplicationIntent
        {
            get { return builder.ApplicationIntent; }
            set
            {
                if (value == ApplicationIntent_default)
                    builder.Remove("Application Intent");
                else
                    builder.ApplicationIntent = value;
            }
        }
        private readonly ApplicationIntent ApplicationIntent_default;

        private const string ApplicationName_desc =
            "The name of the application associated with the connection string." +
            "\r\n" +
            " \".NET SqlClient Data Provider\" by default.";

        /// <summary>
        /// Gets or sets the name of the application associated with the connection string.
        /// </summary>
        /// <returns>
        /// The name of the application, or ".NET SqlClient Data Provider" if no name has been supplied.
        /// </returns>
        [DisplayName("ApplicationName")]
        [Description(ApplicationName_desc)]
        [Category(CatBasic)]
        [RefreshProperties(RefreshProperties.All)]
        public string ApplicationName
        {
            get { return builder.ApplicationName; }
            set
            {
                if (value == ApplicationName_default || string.IsNullOrEmpty(value))
                    builder.Remove("Application Name");
                else
                    builder.ApplicationName = value;
            }
        }
        private readonly string ApplicationName_default;

        private const string AttachDBFilename_desc =
            "The name of the primary data file. This includes" +
            " the full path name of an attachable database." +
            "\r\n" +
            "String.Empty by default.";

        /// <summary>
        /// Gets or sets a string that contains the name of the primary data file. This includes
        /// the full path name of an attachable database.
        /// </summary>
        /// <returns>
        /// The value of the AttachDBFilename property, or <see cref="string.Empty"/> if no value has been supplied.
        /// </returns>
        [DisplayName("AttachDBFilename")]
        [Description(AttachDBFilename_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public string AttachDBFilename
        {
            get { return builder.AttachDBFilename; }
            set
            {
                if (value == AttachDBFilename_default)
                    builder.Remove("AttachDbFilename");
                else
                    builder.AttachDBFilename = value;
            }
        }
        private readonly string AttachDBFilename_default;

        private const string ConnectionString_desc =
            "The current connection string, created from the key/value pairs that are contained" +
            " within the System.Data.Common.DbConnectionStringBuilder." +
            "\r\n" +
            "String.Empty by default.";

        /// <summary>
        /// Gets or sets the connection string associated with the <see cref="DbConnectionStringBuilder"/>.
        /// </summary>
        /// <returns>
        /// The current connection string, created from the key/value pairs that are contained
        /// within the <see cref="DbConnectionStringBuilder"/>. The default value is
        /// an empty string.
        /// </returns>
        [DisplayName("ConnectionString")]
        [Description(ConnectionString_desc)]
        [Category(CatBasic)]
        [RefreshProperties(RefreshProperties.All)]
        public string ConnectionString
        {
            get { return builder.ConnectionString; }
            set { builder.ConnectionString = value; }
        }

        [DisplayName("LegacyConnectionString")]
        [Description("The current Connection String using legacy property names")]
        [Category(CatBasic)]
        [RefreshProperties(RefreshProperties.All)]
        public string LegacyConnectionString
        {
            get { return LegacyCsUtil.ToLegacyConnectionString(builder.ConnectionString); }
            set { builder.ConnectionString = LegacyCsUtil.FromLegacyConnectionString(value); }
        }

        [DisplayName("ConnectionStringXML")]
        [Description("XML encoded Connection String")]
        [Category(CatBasic)]
        [RefreshProperties(RefreshProperties.All)]
        public string ConnectionStringXML
        {
            get { return XmlUtil.Escape(builder.ConnectionString); }
            set { builder.ConnectionString = XmlUtil.Unescape(value); }
        }

        [DisplayName("LegacyConnectionStringXML")]
        [Description("XML encoded Legacy Connection String")]
        [Category(CatBasic)]
        [RefreshProperties(RefreshProperties.All)]
        public string LegacyConnectionStringXML
        {
            get
            {
                var legacyCs = LegacyCsUtil.ToLegacyConnectionString(builder.ConnectionString);
                return XmlUtil.Escape(legacyCs);
            }
            set
            {
                var legacyCs = XmlUtil.Unescape(value);
                builder.ConnectionString = LegacyCsUtil.FromLegacyConnectionString(legacyCs);
            }
        }

        private const string ConnectRetryCount_desc =
            "The number of reconnections attempted after identifying that there was an idle" +
            " connection failure. This must be an integer between 0 and 255. Default is 1." +
            " Set to 0 to disable reconnecting on idle connection failures. An System.ArgumentException" +
            " will be thrown if set to a value outside of the allowed range.";

        /// <summary>
        /// The number of reconnections attempted after identifying that there was an idle
        /// connection failure. This must be an integer between 0 and 255. Default is 1.
        /// Set to 0 to disable reconnecting on idle connection failures. <see cref="ArgumentException"/>
        /// will be thrown if set to a value outside of the allowed range.
        /// </summary>
        /// <returns>
        /// The number of reconnections attempted after identifying that there was an idle
        /// connection failure.
        /// </returns>
        [DisplayName("ConnectRetryCount")]
        [Description(ConnectRetryCount_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public int ConnectRetryCount
        {
            get { return builder.ConnectRetryCount; }
            set
            {
                if (value == ConnectRetryCount_default)
                    builder.Remove("Connect Retry Count");
                else
                    builder.ConnectRetryCount = value;
            }
        }
        private readonly int ConnectRetryCount_default;

        private const string ConnectRetryInterval_desc =
            "Amount of time (in seconds) between each reconnection attempt after identifying" +
            " that there was an idle connection failure. This must be an integer between 1" +
            " and 60. The default is 10 seconds. An System.ArgumentException will be thrown" +
            " if set to a value outside of the allowed range.";

        /// <summary>
        /// Amount of time (in seconds) between each reconnection attempt after identifying
        /// that there was an idle connection failure. This must be an integer between 1
        /// and 60. The default is 10 seconds. An <see cref="ArgumentException"/> will be thrown
        /// if set to a value outside of the allowed range.
        /// </summary>
        /// <returns>
        /// Amount of time (in seconds) between each reconnection attempt after identifying
        /// that there was an idle connection failure.
        /// </returns>
        [DisplayName("ConnectRetryInterval")]
        [Description(ConnectRetryInterval_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public int ConnectRetryInterval
        {
            get { return builder.ConnectRetryInterval; }
            set
            {
                if (value == ConnectRetryInterval_default)
                    builder.Remove("Connect Retry Interval");
                else
                    builder.ConnectRetryInterval = value;
            }
        }
        private readonly int ConnectRetryInterval_default;

        private const string ConnectTimeout_desc =
            "The length of time (in seconds) to wait for a connection to the" +
            " server before terminating the attempt and generating an error." +
            "\r\n" +
            "15 seconds by default.";

        /// <summary>
        /// Gets or sets the length of time (in seconds) to wait for a connection to the
        /// server before terminating the attempt and generating an error.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.ConnectTimeout"/>
        /// property, or 15 seconds if no value has been supplied.
        /// </returns>
        [DisplayName("ConnectTimeout")]
        [Description(ConnectTimeout_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public int ConnectTimeout
        {
            get { return builder.ConnectTimeout; }
            set
            {
                if (value == ConnectTimeout_default)
                    builder.Remove("Connect Timeout");
                else
                    builder.ConnectTimeout = value;
            }
        }
        private readonly int ConnectTimeout_default;

        //public int Count { get { return builder.Count; } set { builder.Count = value; } }

        private const string CurrentLanguage_desc =
            "The SQL Server Language record name." +
            "\r\n" +
            "String.Empty by default.";

        /// <summary>
        /// Gets or sets the SQL Server Language record name.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.CurrentLanguage"/>
        /// property, or <see cref="string.Empty"/> if no value has been supplied.
        /// </returns>
        [DisplayName("CurrentLanguage")]
        [Description(CurrentLanguage_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public string CurrentLanguage
        {
            get { return builder.CurrentLanguage; }
            set
            {
                if (value == CurrentLanguage_default)
                    builder.Remove("Current Language");
                else
                    builder.CurrentLanguage = value;
            }
        }
        private readonly string CurrentLanguage_default;

        private const string DataSource_desc =
            "The name or network address of the instance of SQL Server to connect to." +
            "\r\n" +
            "String.Empty by default.";

        /// <summary>
        /// Gets or sets the name or network address of the instance of SQL Server to connect to.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.DataSource"/>
        /// property, or <see cref="string.Empty"/> if none has been supplied.
        /// </returns>
        [DisplayName("DataSource")]
        [Description(DataSource_desc)]
        [Category(CatBasic)]
        [RefreshProperties(RefreshProperties.All)]
        public string DataSource
        {
            get { return builder.DataSource; }
            set
            {
                if (value == DataSource_default)
                    builder.Remove("Data Source");
                else
                    builder.DataSource = value;
            }
        }
        private readonly string DataSource_default;

        private const string Encrypt_desc =
            "Indicates whether SQL Server uses SSL encryption" +
            " for all data sent between the client and server if the server has a certificate" +
            " installed." +
            "\r\n" +
            "False by default.";

        /// <summary>
        /// Gets or sets a Boolean value that indicates whether SQL Server uses SSL encryption
        /// for all data sent between the client and server if the server has a certificate
        /// installed.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.Encrypt"/> property,
        /// or false if none has been supplied.
        /// </returns>
        [DisplayName("Encrypt")]
        [Description(Encrypt_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public bool Encrypt
        {
            get { return builder.Encrypt; }
            set
            {
                if (value == Encrypt_default)
                    builder.Remove("Encrypt");
                else
                    builder.Encrypt = value;
            }
        }
        private readonly bool Encrypt_default;

        private const string Enlist_desc =
            "Indicates whether the SQL Server connection" +
            " pooler automatically enlists the connection in the creation thread's current" +
            " transaction context." +
            "\r\n" +
            "True by default.";

        /// <summary>
        /// Gets or sets a Boolean value that indicates whether the SQL Server connection
        /// pooler automatically enlists the connection in the creation thread's current
        /// transaction context.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.Enlist"/> property,
        /// or true if none has been supplied.
        /// </returns>
        [DisplayName("Enlist")]
        [Description(Enlist_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public bool Enlist
        {
            get { return builder.Enlist; }
            set
            {
                if (value == Enlist_default)
                    builder.Remove("Enlist");
                else
                    builder.Enlist = value;
            }
        }
        private readonly bool Enlist_default;

        private const string FailoverPartner_desc =
            "The name or address of the partner server to connect to if the primary" +
            " server is down." +
            "\r\n" +
            "String.Empty by default.";

        /// <summary>
        /// Gets or sets the name or address of the partner server to connect to if the primary
        /// server is down.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.FailoverPartner"/>
        /// property, or <see cref="string.Empty"/> if none has been supplied.
        /// </returns>
        [DisplayName("FailoverPartner")]
        [Description(FailoverPartner_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public string FailoverPartner
        {
            get { return builder.FailoverPartner; }
            set
            {
                if (value == FailoverPartner_default)
                    builder.Remove("Failover Partner");
                else
                    builder.FailoverPartner = value;
            }
        }
        private readonly string FailoverPartner_default;

        private const string InitialCatalog_desc =
            "The name of the database associated with the connection." +
            "\r\n" +
            "String.Empty by default.";

        /// <summary>
        /// Gets or sets the name of the database associated with the connection.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.InitialCatalog"/>
        /// property, or <see cref="string.Empty"/> String.Empty if none has been supplied.
        /// </returns>
        [DisplayName("InitialCatalog")]
        [Description(InitialCatalog_desc)]
        [Category(CatBasic)]
        [RefreshProperties(RefreshProperties.All)]
        public string InitialCatalog
        {
            get { return builder.InitialCatalog; }
            set
            {
                if (value == InitialCatalog_default)
                    builder.Remove("Initial Catalog");
                else
                    builder.InitialCatalog = value;
            }
        }
        private readonly string InitialCatalog_default;

        private const string IntegratedSecurity_desc =
            "Indicates whether User ID and Password are" +
            " specified in the connection (when false) or whether the current Windows account" +
            " credentials are used for authentication (when true)." +
            "\r\n" +
            "False by default.";

        /// <summary>
        /// Gets or sets a Boolean value that indicates whether User ID and Password are
        /// specified in the connection (when false) or whether the current Windows account
        /// credentials are used for authentication (when true).
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.IntegratedSecurity"/>
        /// property, or false if none has been supplied.
        /// </returns>
        [DisplayName("IntegratedSecurity")]
        [Description(IntegratedSecurity_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public bool IntegratedSecurity
        {
            get { return builder.IntegratedSecurity; }
            set
            {
                if (value == IntegratedSecurity_default)
                    builder.Remove("Integrated Security");
                else
                    builder.IntegratedSecurity = value;
            }
        }
        private readonly bool IntegratedSecurity_default;

        // skipping the indexer property since it wouldn't show up in a PropertyGrid anyway
        /*
        private const string ThisIndexer_desc =
            "Gets or sets the value associated with the specified key. In C#, this property is the indexer.";

        /// <summary>
        /// Gets or sets the value associated with the specified key. In C#, this property is the indexer.
        /// </summary>
        /// <param name="keyword">The key of the item to get or set.</param>
        /// <returns>The value associated with the specified key.</returns>
        [DisplayName("LoadBalanceTimeout")]
        [Description(LoadBalanceTimeout_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public object this[string keyword]
        {
            get { return builder[keyword]; }
            set { builder[keyword] = value; }
        }
        */

        private const string LoadBalanceTimeout_desc =
            "The minimum time, in seconds, for the connection to live in the" +
            " connection pool before being destroyed." +
            "\r\n" +
            "0 by default.";

        /// <summary>
        /// Gets or sets the minimum time, in seconds, for the connection to live in the
        /// connection pool before being destroyed.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.LoadBalanceTimeout"/>
        /// property, or 0 if none has been supplied.
        /// </returns>
        [DisplayName("LoadBalanceTimeout")]
        [Description(LoadBalanceTimeout_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public int LoadBalanceTimeout
        {
            get { return builder.LoadBalanceTimeout; }
            set
            {
                if (value == LoadBalanceTimeout_default)
                    builder.Remove("Load Balance Timeout");
                else
                    builder.LoadBalanceTimeout = value;
            }
        }
        private readonly int LoadBalanceTimeout_default;

        private const string MaxPoolSize_desc =
            "The maximum number of connections allowed in the connection pool" +
            " for this specific connection string." +
            "\r\n" +
            "100 by default.";

        /// <summary>
        /// Gets or sets the maximum number of connections allowed in the connection pool
        /// for this specific connection string.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.MaxPoolSize"/>
        /// property, or 100 if none has been supplied.
        /// </returns>
        [DisplayName("MaxPoolSize")]
        [Description(MaxPoolSize_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public int MaxPoolSize
        {
            get { return builder.MaxPoolSize; }
            set
            {
                if (value == MaxPoolSize_default)
                    builder.Remove("Max Pool Size");
                else
                    builder.MaxPoolSize = value;
            }
        }
        private readonly int MaxPoolSize_default;

        private const string MinPoolSize_desc =
            "The minimum number of connections allowed in the connection pool" +
            " for this specific connection string." +
            "\r\n" +
            "0 by default.";

        /// <summary>
        /// Gets or sets the minimum number of connections allowed in the connection pool
        /// for this specific connection string.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.MinPoolSize"/>
        /// property, or 0 if none has been supplied.
        /// </returns>
        [DisplayName("MinPoolSize")]
        [Description(MinPoolSize_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public int MinPoolSize
        {
            get { return builder.MinPoolSize; }
            set
            {
                if (value == MinPoolSize_default)
                    builder.Remove("Min Pool Size");
                else
                    builder.MinPoolSize = value;
            }
        }
        private readonly int MinPoolSize_default;

        private const string MultipleActiveResultSets_desc =
            "When true, an application can maintain multiple active result sets (MARS). When" +
            " false, an application must process or cancel all result sets from one batch before" +
            " it can execute any other batch on that connection. For more information, see" +
            " Multiple Active Result Sets (MARS)." +
            "\r\n" +
            "False by default.";

        /// <summary>
        /// When true, an application can maintain multiple active result sets (MARS). When
        /// false, an application must process or cancel all result sets from one batch before
        /// it can execute any other batch on that connection. For more information, see
        /// Multiple Active Result Sets (MARS).
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.MultipleActiveResultSets"/>
        /// property, or false if none has been supplied.
        /// </returns>
        [DisplayName("MultipleActiveResultSets")]
        [Description(MultipleActiveResultSets_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public bool MultipleActiveResultSets
        {
            get { return builder.MultipleActiveResultSets; }
            set
            {
                if (value == MultipleActiveResultSets_default)
                    builder.Remove("Multiple Active Result Sets");
                else
                    builder.MultipleActiveResultSets = value;
            }
        }
        private readonly bool MultipleActiveResultSets_default;

        private const string MultiSubnetFailover_desc =
            "If your application is connecting to an AlwaysOn availability group (AG) on different" +
            " subnets, setting MultiSubnetFailover=true provides faster detection of and connection" +
            " to the (currently) active server. For more information about SqlClient support" +
            " for Always On Availability Groups, see SqlClient Support for High Availability," +
            " Disaster Recovery.";

        /// <summary>
        /// If your application is connecting to an AlwaysOn availability group (AG) on different
        /// subnets, setting MultiSubnetFailover=true provides faster detection of and connection
        /// to the (currently) active server. For more information about SqlClient support
        /// for Always On Availability Groups, see SqlClient Support for High Availability,
        /// Disaster Recovery.
        /// </summary>
        /// <returns>
        /// Returns <see cref="Boolean"/> indicating the current value of the property.
        /// </returns>
        [DisplayName("MultiSubnetFailover")]
        [Description(MultiSubnetFailover_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public bool MultiSubnetFailover
        {
            get { return builder.MultiSubnetFailover; }
            set
            {
                if (value == MultiSubnetFailover_default)
                    builder.Remove("Multi Subnet Failover");
                else
                    builder.MultiSubnetFailover = value;
            }
        }
        private readonly bool MultiSubnetFailover_default;

        private const string PacketSize_desc =
            "The size in bytes of the network packets used to communicate with" +
            " an instance of SQL Server." +
            "\r\n" +
            "8000 by default.";

        /// <summary>
        /// Gets or sets the size in bytes of the network packets used to communicate with
        /// an instance of SQL Server.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.PacketSize"/>
        /// property, or 8000 if none has been supplied.
        /// </returns>
        [DisplayName("PacketSize")]
        [Description(PacketSize_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public int PacketSize
        {
            get { return builder.PacketSize; }
            set
            {
                if (value == PacketSize_default)
                    builder.Remove("Packet Size");
                else
                    builder.PacketSize = value;
            }
        }
        private readonly int PacketSize_default;

        private const string Password_desc =
            "The password for the SQL Server account." +
            "\r\n" +
            "String.Empty by default.";

        /// <summary>
        /// Gets or sets the password for the SQL Server account.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.Password"/> property,
        /// or <see cref="string.Empty"/> if none has been supplied.
        /// </returns>
        [DisplayName("Password")]
        [Description(Password_desc)]
        [Category(CatBasic)]
        [RefreshProperties(RefreshProperties.All)]
        public string Password
        {
            get { return builder.Password; }
            set
            {
                if (value == Password_default)
                    builder.Remove("Password");
                else
                    builder.Password = value;
            }
        }
        private readonly string Password_default;

        private const string PersistSecurityInfo_desc =
            "Indicates if security-sensitive information," +
            " such as the password, is not returned as part of the connection if the connection" +
            " is open or has ever been in an open state." +
            "\r\n" +
            "False by default.";

        /// <summary>
        /// Gets or sets a Boolean value that indicates if security-sensitive information,
        /// such as the password, is not returned as part of the connection if the connection
        /// is open or has ever been in an open state.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.PersistSecurityInfo"/>
        /// property, or false if none has been supplied.
        /// </returns>
        [DisplayName("PersistSecurityInfo")]
        [Description(PersistSecurityInfo_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public bool PersistSecurityInfo
        {
            get { return builder.PersistSecurityInfo; }
            set
            {
                if (value == PersistSecurityInfo_default)
                    builder.Remove("Persist Security Info");
                else
                    builder.PersistSecurityInfo = value;
            }
        }
        private readonly bool PersistSecurityInfo_default;

        private const string PoolBlockingPeriod_desc =
            "The blocking period behavior for a connection pool.";

        /// <summary>
        /// The blocking period behavior for a connection pool.
        /// </summary>
        /// <returns>
        /// The available blocking period settings.
        /// </returns>
        [DisplayName("PoolBlockingPeriod")]
        [Description(PoolBlockingPeriod_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public PoolBlockingPeriod PoolBlockingPeriod
        {
            get { return builder.PoolBlockingPeriod; }
            set
            {
                if (value == PoolBlockingPeriod_default)
                    builder.Remove("Pool Blocking Period");
                else
                    builder.PoolBlockingPeriod = value;
            }
        }
        private readonly PoolBlockingPeriod PoolBlockingPeriod_default;

        private const string Pooling_desc =
            "Indicates whether the connection will be pooled" +
            " or explicitly opened every time that the connection is requested." +
            "\r\n" +
            "True by default.";

        /// <summary>
        /// Gets or sets a Boolean value that indicates whether the connection will be pooled
        /// or explicitly opened every time that the connection is requested.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.Pooling"/> property,
        /// or true if none has been supplied.
        /// </returns>
        [DisplayName("Pooling")]
        [Description(Pooling_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public bool Pooling
        {
            get { return builder.Pooling; }
            set
            {
                if (value == Pooling_default)
                    builder.Remove("Pooling");
                else
                    builder.Pooling = value;
            }
        }
        private readonly bool Pooling_default;

        private const string Replication_desc =
            "Indicates whether replication is supported" +
            " using the connection." +
            "\r\n" +
            "False by default.";

        /// <summary>
        /// Gets or sets a Boolean value that indicates whether replication is supported
        /// using the connection.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.Replication"/>
        /// property, or false if none has been supplied.
        /// </returns>
        [DisplayName("Replication")]
        [Description(Replication_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public bool Replication
        {
            get { return builder.Replication; }
            set
            {
                if (value == Replication_default)
                    builder.Remove("Replication");
                else
                    builder.Replication = value;
            }
        }
        private readonly bool Replication_default;

        private const string TransactionBinding_desc =
            "Indicates how the connection maintains its association" +
            " with an enlisted System.Transactions transaction." +
            "\r\n" +
            "String.Empty by default.";

        /// <summary>
        /// Gets or sets a string value that indicates how the connection maintains its association
        /// with an enlisted <see cref="System.Transactions"/> transaction.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.TransactionBinding"/>
        /// property, or String.Empty if none has been supplied.
        /// </returns>
        [DisplayName("TransactionBinding")]
        [Description(TransactionBinding_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public string TransactionBinding
        {
            get { return builder.TransactionBinding; }
            set
            {
                if (value == TransactionBinding_default)
                    builder.Remove("Transaction Binding");
                else
                    builder.TransactionBinding = value;
            }
        }
        private readonly string TransactionBinding_default;

        private const string TrustServerCertificate_desc =
            "Indicates whether the channel will be encrypted while" +
            " bypassing walking the certificate chain to validate trust.";

        /// <summary>
        /// Gets or sets a value that indicates whether the channel will be encrypted while
        /// bypassing walking the certificate chain to validate trust.
        /// </summary>
        /// <returns>
        /// A <see cref="Boolean"/>. Recognized values are true, false, yes, and no.
        /// </returns>
        [DisplayName("TrustServerCertificate")]
        [Description(TrustServerCertificate_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public bool TrustServerCertificate
        {
            get { return builder.TrustServerCertificate; }
            set
            {
                if (value == TrustServerCertificate_default)
                    builder.Remove("Trust Server Certificate");
                else
                    builder.TrustServerCertificate = value;
            }
        }
        private readonly bool TrustServerCertificate_default;

        private const string TypeSystemVersion_desc =
            "Indicates the type system the application expects.\r\n" +
            "\"SQL Server 2005\": Uses the SQL Server 2005 type system. No conversions are made for the current version of ADO.NET.\r\n" +
            "\"SQL Server 2008\": Uses the SQL Server 2008 type system.\r\n" +
            "\"Latest\": Use the latest version than this client-server" +
            " pair can handle. This will automatically move forward as the client and server" +
            " components are upgraded.";

        /// <summary>
        /// Gets or sets a string value that indicates the type system the application expects.
        /// </summary>
        /// <returns>
        /// The following table shows the possible values for the <see cref="SqlConnectionStringBuilder.TypeSystemVersion"/>
        /// property: Value Description SQL Server 2005 Uses the SQL Server 2005 type system.
        /// No conversions are made for the current version of ADO.NET. SQL Server 2008 Uses
        /// the SQL Server 2008 type system. Latest Use the latest version than this client-server
        /// pair can handle. This will automatically move forward as the client and server
        /// components are upgraded.
        /// </returns>
        [DisplayName("TypeSystemVersion")]
        [Description(TypeSystemVersion_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public string TypeSystemVersion
        {
            get { return builder.TypeSystemVersion; }
            set
            {
                if (value == TypeSystemVersion_default)
                    builder.Remove("Type System Version");
                else
                    builder.TypeSystemVersion = value;
            }
        }
        private readonly string TypeSystemVersion_default;

        private const string UserID_desc =
            "The user ID to be used when connecting to SQL Server." +
            "\r\n" +
            "String.Empty by default.";

        /// <summary>
        /// Gets or sets the user ID to be used when connecting to SQL Server.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.UserID"/> property,
        /// or <see cref="string.Empty"/> if none has been supplied.
        /// </returns>
        [DisplayName("UserID")]
        [Description(UserID_desc)]
        [Category(CatBasic)]
        [RefreshProperties(RefreshProperties.All)]
        public string UserID
        {
            get { return builder.UserID; }
            set
            {
                if (value == UserID_default)
                    builder.Remove("User ID");
                else
                    builder.UserID = value;
            }
        }
        private readonly string UserID_default;

        private const string UserInstance_desc =
            "Indicates whether to redirect the connection from the" +
            " default SQL Server Express instance to a runtime-initiated instance running under" +
            " the account of the caller." +
            "\r\n" +
            "False by default.";

        /// <summary>
        /// Gets or sets a value that indicates whether to redirect the connection from the
        /// default SQL Server Express instance to a runtime-initiated instance running under
        /// the account of the caller.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.UserInstance"/>
        /// property, or False if none has been supplied.
        /// </returns>
        [DisplayName("UserInstance")]
        [Description(UserInstance_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public bool UserInstance
        {
            get { return builder.UserInstance; }
            set
            {
                if (value == UserInstance_default)
                    builder.Remove("User Instance");
                else
                    builder.UserInstance = value;
            }
        }
        private readonly bool UserInstance_default;

        //public ICollection Values { get { return builder.Values; } set { builder.Values = value; } }

        private const string WorkstationID_desc =
            "The name of the workstation connecting to SQL Server." +
            "\r\n" +
            "String.Empty by default.";

        /// <summary>
        /// Gets or sets the name of the workstation connecting to SQL Server.
        /// </summary>
        /// <returns>
        /// The value of the <see cref="SqlConnectionStringBuilder.WorkstationID"/>
        /// property, or <see cref="string.Empty"/> if none has been supplied.
        /// </returns>
        [DisplayName("WorkstationID")]
        [Description(WorkstationID_desc)]
        [Category(CatExtended)]
        [RefreshProperties(RefreshProperties.All)]
        public string WorkstationID
        {
            get { return builder.WorkstationID; }
            set
            {
                if (value == WorkstationID_default)
                    builder.Remove("Workstation ID");
                else
                    builder.WorkstationID = value;
            }
        }
        private readonly string WorkstationID_default;
    }
}
