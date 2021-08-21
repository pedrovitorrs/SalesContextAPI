using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesContextAPI.Infraestructure.DBConfiguration.EFCore;
using SalesContextAPI.Infraestructure.Interfaces.Repositories.BaseRepository;
using SalesContextAPI.Infraestructure.Interfaces.Repositories.Domain;
using SalesContextAPI.Infraestructure.Repositories.Domain.EFCore;
using SalesContextAPI.Infraestructure.Repositories.Standard.EFCore;

namespace SalesContextAPI.Infraestructure.IoC.ORMs.EFCore
{
    public class EntityFrameworkIoC : ORMTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfiguration dbConnectionSettings = ResolveConfiguration.GetConnectionSettings(configuration);
            string conn = dbConnectionSettings.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(conn));

            services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddScoped<ISellerRepository, SellerRepository>();
           
            return services;
        }
    }
}
