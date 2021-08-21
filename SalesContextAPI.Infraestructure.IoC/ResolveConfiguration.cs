using Microsoft.Extensions.Configuration;
using SalesContextAPI.Infraestructure.DBConfiguration.EFCore;

namespace SalesContextAPI.Infraestructure.IoC
{
    internal class ResolveConfiguration
    {
        public static IConfiguration GetConnectionSettings(IConfiguration configuration)
        {
            return configuration ?? DatabaseConnection.ConnectionConfiguration;
        }
    }
}
