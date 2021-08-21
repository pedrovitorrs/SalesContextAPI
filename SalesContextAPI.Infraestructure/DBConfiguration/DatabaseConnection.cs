using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesContextAPI.Infraestructure.DBConfiguration.EFCore
{
    public class DatabaseConnection
    {
        public static IConfiguration ConnectionConfiguration
        {
            get
            {
                var path = $"{Directory.GetCurrentDirectory()}";
                IConfigurationRoot Configuration = new ConfigurationBuilder()
                    .SetBasePath(path)
                    .AddJsonFile("appsettings.json")
                    .Build();
                return Configuration;
            }
        }
    }
}
