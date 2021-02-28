using EnduranceContestManager.Domain.Aggregates.Ranking.Participations;
using EnduranceContestManager.Domain.Core.Validation;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Ranking.Trials
{
    public class Trial : DomainModel<RankingTrialException>
    {
        private readonly List<Participation> participations = new();

        public Trial() : base(default)
        {
        }

        public int LengthInKilometers { get; private set; }
        public IReadOnlyList<Participation> Participations => this.participations.AsReadOnly();
    }
}