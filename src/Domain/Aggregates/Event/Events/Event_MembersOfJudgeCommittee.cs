using EnduranceJudge.Domain.Core.Extensions;
using EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Event.Events
{
    public partial class Event
    {
        private readonly List<Personnel> membersOfJudgeCommittee = new();

        public IReadOnlyList<Personnel> MembersOfJudgeCommittee => this.membersOfJudgeCommittee.AsReadOnly();

        public Event AddMembersOfJudgeCommittee(Personnel personnel)
        {
            this.Add(
                contest => contest.membersOfJudgeCommittee,
                personnel);

            return this;
        }

        public Event RemoveMemberOfJudgeCommittee(Func<Personnel, bool> filter)
        {
            var personnel = this.membersOfJudgeCommittee.FirstOrDefault(filter);
            this.Remove(
                contest => contest.membersOfJudgeCommittee,
                personnel);

            return this;
        }
    }
}
