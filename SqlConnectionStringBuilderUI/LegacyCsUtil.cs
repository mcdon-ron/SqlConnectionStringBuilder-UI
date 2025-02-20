using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnectionStringBuilderUI
{
    // For supporting Legacy Connection Strings
    // based on https://github.com/dotnet/SqlClient/issues/811

    public class LegacyCsUtil
    {
        // from https://github.com/dotnet/SqlClient/blob/master/release-notes/2.0/2.0.0.md#new-connection-string-property-synonyms
        private static readonly (string @new, string old)[] SqlPropertyRenames = new (string, string)[]
        {
            ("Application Intent", "ApplicationIntent"),
            ("Connect Retry Count", "ConnectRetryCount"),
            ("Connect Retry Interval", "ConnectRetryInterval"),
            ("Pool Blocking Period", "PoolBlockingPeriod"),
            ("Multiple Active Result Sets", "MultipleActiveResultSets"),
            ("Multi Subnet Failover", "MultiSubnetFailover"),
            ("Transparent Network IP Resolution", "TransparentNetworkIPResolution"),
            ("Trust Server Certificate", "TrustServerCertificate")
        };

        public static string ToLegacyConnectionString(string connectionString)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                foreach (var replacement in SqlPropertyRenames)
                {
                    connectionString = connectionString.Replace(replacement.@new, replacement.old, StringComparison.OrdinalIgnoreCase);
                }
            }

            return connectionString;
        }

        public static string FromLegacyConnectionString(string connectionString)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                foreach (var replacement in SqlPropertyRenames)
                {
                    connectionString = connectionString.Replace(replacement.old, replacement.@new, StringComparison.OrdinalIgnoreCase);
                }
            }

            return connectionString;
        }
    }
}
