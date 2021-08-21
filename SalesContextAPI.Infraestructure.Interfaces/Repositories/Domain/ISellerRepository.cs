using Infrastructure.Interfaces.Repositories.Domain.Standard;
using SalesContextAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesContextAPI.Infraestructure.Interfaces.Repositories.Domain
{
    public interface ISellerRepository : IDomainRepository<Seller>
    {
        Task<IEnumerable<Seller>> GetAllIncludingTasksAsync();
        Task<Seller> GetByIdIncludingTasksAsync(int id);
    }
}
