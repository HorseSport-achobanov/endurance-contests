using EnduranceJudge.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Interfaces.Core
{
    public interface IQueryRepository<TDomainModel>
        where TDomainModel : IDomainModel
    {
        Task<TDomainModel> Find(int id);

        Task<TModel> Find<TModel>(int id);

        Task<IList<TModel>> All<TModel>();
    }
}
