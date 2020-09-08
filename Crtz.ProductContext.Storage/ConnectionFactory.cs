using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crtz.ProductContext.Infra.Storage
{
    public static class ConnectionFactory
    {
        public const string connectionStringName = "MainConnection";

        public static SqlConnection GetConnection()
        {
            try
            {
                ConnectionStringSettings connectionStringSetting = ConfigurationManager.ConnectionStrings[connectionStringName];

                if (connectionStringSetting == null)
                    throw new InvalidOperationException($"Connection string '{connectionStringName}' cannot be found");

                string connectionString = connectionStringSetting.ConnectionString;
                return new SqlConnection(connectionString);
            }
            catch (InvalidOperationException iEx)
            {
                throw iEx;
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Error on trying to perform {nameof(GetConnection)} for connection string named: '{connectionStringName}'");
            }
        }

        public static SqlConnection GetConnection(string connectionString)
        {
            try
            {
                return new SqlConnection(connectionString);
            }
            catch (InvalidOperationException iEx)
            {
                throw iEx;
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Error on trying to perform {nameof(GetConnection)} for connection string '{connectionString}'");
            }
        }
    }
}
