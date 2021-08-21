using SalesContextAPI.Core.Interfaces.Services.Standard;
using SalesContextAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesContextAPI.Core.Interfaces.Services.Domain
{
    public interface ISellerService : IServiceBase<Seller>
    {
        Task<IEnumerable<Seller>> GetAllIncludingTasksAsync();
        Task<Seller> GetByIdIncludingTasksAsync(int id);
    }
}
