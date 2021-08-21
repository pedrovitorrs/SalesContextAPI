using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SalesContextAPI.Infraestructure.IoC.ORMs
{
    public abstract class ORMTypes : IOrmTypes
    {
        internal abstract IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null);

        public IServiceCollection ResolveOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            return AddOrm(services, configuration);
        }
    }
}
