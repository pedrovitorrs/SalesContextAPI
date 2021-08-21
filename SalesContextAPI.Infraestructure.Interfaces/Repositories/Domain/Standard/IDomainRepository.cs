
using SalesContextAPI.Domain.Entities;
using SalesContextAPI.Infraestructure.Interfaces.Repositories.BaseRepository;

namespace Infrastructure.Interfaces.Repositories.Domain.Standard
{
    public interface IDomainRepository<TEntity> : IBaseRepositoryAsync<TEntity> where TEntity : class, IIdentityEntity
    {
    }
}
