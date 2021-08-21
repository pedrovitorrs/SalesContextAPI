using Infrastructure.Interfaces.Repositories.Domain.Standard;
using Microsoft.EntityFrameworkCore;
using SalesContextAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesContextAPI.Infraestructure.Repositories.Standard.EFCore
{
    public class DomainRepository<TEntity> : RepositoryAsync<TEntity>,
                                             IDomainRepository<TEntity> where TEntity : class, IIdentityEntity
    {
        protected DomainRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
