using EnduranceContestManager.Domain.Aggregates.Common;
using EnduranceContestManager.Domain.Aggregates.Import.Competitions;
using EnduranceContestManager.Domain.Core.Models;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Import.Events
{
    public class Event : BaseEvent<ImportEventException>, IAggregateRoot
    {
        private readonly List<Competition> competitions;

        public Event(string name, string populatedPlace, List<Competition> competitions)
            : base(default, name, populatedPlace)
        {
            this.competitions = competitions;
        }

        public IReadOnlyList<Competition> Competitions => this.competitions.AsReadOnly();
    }
}
