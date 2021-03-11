using EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInPhases;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Aggregates.Manager.DTOs;
using EnduranceContestManager.Domain.Core;
using EnduranceContestManager.Domain.Core.Models;
using EnduranceContestManager.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Manager.ParticipationsInCompetitions
{
    public class ParticipationInCompetition : DomainModel<ParticipationInCompetitionException>
    {
        private const string EmptyPhasesCollection = "cannot start - Phases collection is empty";
        private const string NextPhaseIsNullMessage = "cannot start - there is no Next Phase.";
        private const string CurrentPhaseIsNullMessage = "cannot complete - no current phase.";

        private readonly CompetitionDto competition;
        private readonly int? maxAverageSpeedInKpH;

        internal ParticipationInCompetition(CompetitionDto competition, int? maxAverageSpeedInKpH) : base(default)
        {
            this.Validate(() =>
            {
                competition.Phases.IsNotEmpty(EmptyPhasesCollection);
            });

            this.maxAverageSpeedInKpH = maxAverageSpeedInKpH;
            this.competition = competition;

            this.StartPhase();
        }


        public bool IsComplete
            => this.competition.Phases.Count == this.participationsInPhases.Count;

        public CompetitionType CompetitionType
            => this.competition.Type;

        public bool HasExceededSpeedRestriction
            => this.AverageSpeedInKpH > this.maxAverageSpeedInKpH;

        public double? AverageSpeedInKpH
        {
            get
            {
                var completedPhases = this.participationsInPhases
                    .Where(x => x.IsComplete)
                    .ToList();

                if (!completedPhases.Any())
                {
                    return null;
                }

                var averageSpeedInPhases = this.CompetitionType == CompetitionType.International
                    ? completedPhases.Select(x => x.AverageSpeedForPhaseInKpH!.Value)
                    : completedPhases.Select(x => x.AverageSpeedForLoopInKpH!.Value);

                var averageSpeedSum = averageSpeedInPhases.Aggregate(0d, (sum, average) => sum + average);
                var phasesCount = this.participationsInPhases.Count;

                return averageSpeedSum / phasesCount;
            }
        }

        private readonly List<ParticipationInPhase> participationsInPhases = new();
        public ParticipationInPhase CurrentPhase
            => this.participationsInPhases.SingleOrDefault(participation => !participation.IsComplete);
        private void StartPhase()
            => this.Validate(() =>
            {
                var nextPhase = this.competition.Phases
                    .OrderBy(x => x.OrderBy)
                    .Skip(this.participationsInPhases.Count)
                    .FirstOrDefault()
                    .IsNotDefault(NextPhaseIsNullMessage);

                var restTime = this.CurrentPhase?.Phase.RestTimeInMinutes;
                var nextStartTime = this.CurrentPhase?.ReInspectionTime?.AddMinutes(restTime!.Value)
                                ?? this.CurrentPhase?.InspectionTime?.AddMinutes(restTime!.Value)
                                ?? this.competition.StartTime;

                var participation = new ParticipationInPhase(nextPhase, nextStartTime);
                this.participationsInPhases.Add(participation);
            });
        internal void CompleteSuccessful()
            => this.Validate(() =>
            {
                this.CurrentPhase
                    .IsNotDefault(CurrentPhaseIsNullMessage)
                    .CompleteSuccessful();

                this.StartPhase();
            });
        internal void CompleteUnsuccessful(string code)
            => this.Validate(() =>
            {
                this.CurrentPhase
                    .IsNotDefault(CurrentPhaseIsNullMessage)
                    .CompleteUnsuccessful(code);

                this.StartPhase();
            });
    }
}
