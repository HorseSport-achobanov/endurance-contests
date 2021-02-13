using EnduranceContestManager.Domain.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Core.Interfaces
{
    public interface ICommandRepository<in TEntity> : IQueryRepository
        where TEntity : IAggregateRoot
    {
        Task<string> Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
