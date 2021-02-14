using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Application.Core.Requests;
using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Models.Contests;
using EnduranceContestManager.Domain.Models.Trials;
using System.Collections.Generic;

namespace EnduranceContestManager.Application.Contests.Commands
{
    public class UpdateContest : IIdentifiableRequest, IContestState, IMapTo<Contest>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PopulatedPlace { get; set; }

        public string Country { get; set; }

        public string PresidentGroundJury { get; set; }

        public string FeiTechDelegate { get; set; }

        public string PresidentVetCommission { get; set; }

        public string FeiVetDelegate { get; set; }

        public string ForeignJudge { get; set; }

        public string ActiveVet { get; set; }

        public IList<string> MembersOfVetCommittee { get; set; }

        public IList<string> MembersOfJudgeCommittee { get; set; }

        public IList<string> Stewards { get; set; }

        public IList<Trial> Trials { get; set; }

        public class UpdateContestHandler : UpdateHandler<UpdateContest, Contest>
        {
            public UpdateContestHandler(IContestCommands commands)
                : base(commands)
            {
            }
        }
    }
}