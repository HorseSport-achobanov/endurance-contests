﻿using EnduranceJudge.Application.Contracts.Events;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Events.Factories;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Events.Commands.Competitions
{
    public class SaveCompetition : IRequest, ICompetitionState
    {
        public int EnduranceEventId { get; set; }
        public int Id { get; set; }
        public CompetitionType Type { get; set; }

        public class SaveCompetitionHandler : Handler<SaveCompetition>
        {
            private readonly IEnduranceEventCommands commands;
            private readonly ICompetitionFactory competitionFactory;

            public SaveCompetitionHandler(IEnduranceEventCommands commands, ICompetitionFactory competitionFactory)
            {
                this.commands = commands;
                this.competitionFactory = competitionFactory;
            }

            protected override async Task Handle(SaveCompetition request, CancellationToken cancellationToken)
            {
                var competition = this.competitionFactory.Create(request);

                var enduranceEvent = await this.commands.Find(request.EnduranceEventId);
                enduranceEvent.AddOrUpdate(competition);

                await this.commands.Save(enduranceEvent, cancellationToken);
            }
        }
    }
}