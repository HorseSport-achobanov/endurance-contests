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
        private readonly List<Personnel> stewards = new();

        [NotMapped]
        public IReadOnlyList<Personnel> Stewards => this.stewards.AsReadOnly();

        public Event AddSteward(Personnel personnel)
        {
            this.Add(x => x.stewards, personnel);
            return this;
        }

        public Event RemoveSteward(Func<Personnel, bool> filter)
        {
            var steward = this.stewards.FirstOrDefault(filter);
            this.Remove(x => x.stewards, steward);
            return this;
        }
    }
}