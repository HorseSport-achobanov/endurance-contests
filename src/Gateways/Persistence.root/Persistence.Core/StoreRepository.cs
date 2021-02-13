using EnduranceContestManager.Application.Core.Interfaces;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Gateways.Persistence.Core
{
    public abstract class StoreRepository<TDataStore, TEntityStore, TEntity> : ICommandRepository<TEntity>
        where TEntity : IAggregateRoot
        where TDataStore : IDataStore
        where TEntityStore : EntityStore<TEntity>
    {
        protected StoreRepository(TDataStore dataStore)
        {
            this.DataStore = dataStore;
        }

        protected TDataStore DataStore { get; }

        public virtual async Task<TModel> Find<TModel>(string id)
            => await this.DataStore
                .Set<TEntityStore>()
                .Where(x => x.Id == id)
                .MapQueryable<TModel>()
                .FirstOrDefaultAsync();

        public virtual async Task<IList<TModel>> All<TModel>()
            => await this.DataStore
                .Set<TEntityStore>()
                .MapQueryable<TModel>()
                .ToListAsync();

        public virtual async Task<TEntityStore> Find(string id)
            => await this.DataStore.FindAsync<TEntityStore>(id);

        public async Task<string> Save(TEntity entity, CancellationToken cancellationToken = default)
        {
            var dataEntry = await this.DataStore.FindAsync<TEntityStore>(entity.Id);
            if (dataEntry == null)
            {
                dataEntry = entity.Map<TEntityStore>();
                this.DataStore.Add(dataEntry);
            }
            else
            {
                dataEntry.MapFrom(entity);
                this.DataStore.Update(dataEntry);
            }

            await this.DataStore.Commit(cancellationToken);

            return dataEntry.Id;
        }
    }
}
