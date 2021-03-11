using EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel;
using EnduranceContestManager.Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Event.Events
{
    public partial class Event
    {
        [NotMapped]
        public Personnel ActiveVet { get; private set; }

        public Event SetActiveVet(Personnel personnel)
        {
            this.Set(
                contest => contest.ActiveVet,
                (contest, p) => contest.ActiveVet = p,
                personnel);

            return this;
        }
    }
}
