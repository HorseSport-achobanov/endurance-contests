using EnduranceContestManager.Application.Contests;
using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Contests;
using EnduranceContestManager.Domain.Entities.Phases;
using EnduranceContestManager.Domain.Entities.Trials;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Test
{
    public class Test : IRequest, IMapTo<Contest>
    {
        public string Name { get; set; }

        public class TestHandler : Handler<Test>
        {
            private readonly IContestCommands contestCommands;
            private readonly IContestFactory factory;

            public TestHandler(IContestCommands contestCommands, IContestFactory factory)
            {
                this.contestCommands = contestCommands;
                this.factory = factory;
            }

            protected override async Task Handle(Test request, CancellationToken cancellationToken)
            {
                var contest = new Contest(
                    Guid.NewGuid().ToString(),
                    "Name",
                    "Populated place",
                    "Country",
                    "President Ground Jury",
                    "Fei Tech Delegate",
                    "Fei Vet Delegate",
                    "President Vet Commission",
                    "Foreign Judge",
                    "Active Vet");

                // var firstPhase = new Phase(Guid.NewGuid().ToString(), 20);

                var trial = new Trial(Guid.NewGuid().ToString(), 100, 2);
                    // .AddPhase(firstPhase);

                contest.AddTrial(trial);

                await this.contestCommands.Save(contest, cancellationToken);

                var result = await this.contestCommands.All<Contest>();
                var newContest = result.FirstOrDefault();

                var trial2 = new Trial(Guid.NewGuid().ToString(), 333, 10);
                // var trial3 = new Trial(Guid.NewGuid().ToString(), 444, 2);

                // var phase2 = new Phase(Guid.NewGuid().ToString(), 50);
                // var phase3 = new Phase(Guid.NewGuid().ToString(), 60);
                //
                // trial2.AddPhase(phase2);
                // trial3.AddPhase(phase3);

                newContest.AddTrial(trial2);

                await this.contestCommands.Save(newContest, cancellationToken);
                ;
            }
        }
    }
}
