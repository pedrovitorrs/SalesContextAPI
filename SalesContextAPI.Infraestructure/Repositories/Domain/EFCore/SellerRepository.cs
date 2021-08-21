using SalesContextAPI.Domain.Entities;
using SalesContextAPI.Infraestructure.DBConfiguration.EFCore;
using SalesContextAPI.Infraestructure.Interfaces.Repositories.Domain;
using SalesContextAPI.Infraestructure.Repositories.Standard.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesContextAPI.Infraestructure.Repositories.Domain.EFCore
{
    public class SellerRepository : DomainRepository<Seller>,
                                  ISellerRepository
    {
        public SellerRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Seller>> GetAllIncludingTasksAsync()
        {
            IQueryable<Seller> query = (IQueryable<Seller>) await Task.FromResult(
                GenerateQuery(
                    filter: null,
                    orderBy: null
                    )
                );
            return query.AsEnumerable();
        }

        public async Task<Seller> GetByIdIncludingTasksAsync(int id)
        {
            IQueryable<Seller> query = await Task.FromResult(
                GenerateQuery(
                    filter: (user => user.Id == id),
                    orderBy: null,
                    includeProperties: nameof(Seller)
                    )
                );
            return query.SingleOrDefault();
        }
    }
}