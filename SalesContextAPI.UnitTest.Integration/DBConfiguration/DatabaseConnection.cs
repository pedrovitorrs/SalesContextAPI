using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using UnitTest.Integration.Repositories.DBConfiguration;

namespace SalesContextAPI.UnitTest.Integration.DBConfiguration
{
    public class DatabaseConnection
    {
        public static IOptions<DataOptionFactory> ConnectionConfiguration
        {
            get
            {
                IConfigurationRoot Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.test.json")
                    .Build();
                return Options.Create(Configuration.GetSection("ConnectionStrings").Get<DataOptionFactory>());
            }
        }
    }
}