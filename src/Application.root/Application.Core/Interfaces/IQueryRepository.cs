using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Core.Interfaces
{
    public interface IQueryRepository
    {
        Task<TModel> Find<TModel>(string id);

        Task<IList<TModel>> All<TModel>();
    }
}
