using Microsoft.Extensions.DependencyInjection;
using SalesContextAPI.Infraestructure.DBConfiguration.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnection = SalesContextAPI.UnitTest.Integration.DBConfiguration.DatabaseConnection;
using Microsoft.EntityFrameworkCore;

namespace SalesContextAPI.UnitTest.Integration.Repositories.DBConfiguration.EFCore
{
    public class EntityFrameworkConnection
    {
        private IServiceProvider _provider;

        public ApplicationContext DataBaseConfiguration()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(DatabaseConnection.ConnectionConfiguration.Value.DefaultConnection));
            _provider = services.BuildServiceProvider();
            return _provider.GetService<ApplicationContext>();
        }
    }
}
