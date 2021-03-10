using EnduranceContestManager.Application.Core.Factories;
using EnduranceContestManager.Domain.Aggregates.Event.Contests;

namespace EnduranceContestManager.Application.Contests
{
    public interface IContestFactory : IFactory<Contest>
    {
        Contest Update(Contest contest, string name = null, string populatedPlace = null);
    }
}
