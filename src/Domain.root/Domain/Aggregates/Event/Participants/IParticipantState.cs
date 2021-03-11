using EnduranceContestManager.Domain.Core.Models;

namespace EnduranceContestManager.Domain.Aggregates.Event.Participants
{
    public interface IParticipantState : IDomainModelState
    {
        public string RfId { get; }
        public int ContestNumber { get; }
        int? MaxAverageSpeedInKpH { get; }
    }
}
