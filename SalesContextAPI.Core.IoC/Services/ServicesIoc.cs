using Microsoft.Extensions.DependencyInjection;
using SalesContextAPI.Core.Interfaces.Services.Domain;
using SalesContextAPI.Core.Interfaces.Services.Standard;
using SalesContextAPI.Core.Services.Domain;
using SalesContextAPI.Core.Services.Standard;

namespace SalesContextAPI.Core.IoC.Services
{
    public static class ServicesIoc
    {
        public static void ApplicationServicesIoC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            services.AddScoped<ISellerService, SellerService>();
        }
    }
}