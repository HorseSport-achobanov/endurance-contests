using EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel;
using EnduranceContestManager.Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnduranceContestManager.Domain.Aggregates.Event.Events
{
    public partial class Event
    {
        [NotMapped]
        public Personnel FeiTechDelegate { get; private set; }

        public Event SetFeiTechDelegate(Personnel personnel)
        {
            this.Set(
                contest => contest.FeiTechDelegate,
                (contest, p) => contest.FeiTechDelegate = p,
                personnel);

            return this;
        }
    }
}
