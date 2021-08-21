using SalesContextAPI.Core.Interfaces.Services.Domain;
using SalesContextAPI.Core.Services.Standard;
using SalesContextAPI.Domain.Entities;
using SalesContextAPI.Infraestructure.Interfaces.Repositories.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesContextAPI.Core.Services.Domain
{
    public class SellerService : ServiceBase<Seller>,
                               ISellerService
    {
        private readonly ISellerRepository _repository;

        public SellerService(ISellerRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Seller>> GetAllIncludingTasksAsync()
        {
            return await _repository.GetAllIncludingTasksAsync();
        }

        public async Task<Seller> GetByIdIncludingTasksAsync(int id)
        {
            return await _repository.GetByIdIncludingTasksAsync(id);
        }
    }
}
