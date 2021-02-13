using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnduranceContestManager.Gateways.Persistence.Core
{
    public abstract class EntityStore<TEntity> : IMapFrom<TEntity>, IMapTo<TEntity>
        where TEntity : IEntity
    {
        protected EntityStore()
        {
        }

        protected EntityStore(string id)
        {
            this.Id = id;
        }

        [Key]
        public string Id { get; set; }
    }
}
