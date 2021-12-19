using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Core.DbModels;
using WebAPI.Core.Specifications;

namespace WebAPI.Core.Intefaces
{
    public interface IGenericRepository<T>  where T:BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);

    }
}
