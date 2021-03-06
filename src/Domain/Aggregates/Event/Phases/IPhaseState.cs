using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Event.Phases
{
    public interface IPhaseState : IDomainModelState
    {
        int LengthInKilometers { get; }

        bool IsFinal { get; }
    }
}
