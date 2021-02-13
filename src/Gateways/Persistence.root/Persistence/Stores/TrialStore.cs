using AutoMapper;
using EnduranceContestManager.Core.Extensions;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Phases;
using EnduranceContestManager.Domain.Entities.Trials;
using EnduranceContestManager.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Gateways.Persistence.Stores
{
    public class TrialStore : EntityStore<Trial>, ITrialState
    {
        public TrialStore()
        {
        }

        [JsonConstructor]
        public TrialStore(string id, int lengthInKilometers, int durationInDays, string contestId)
            : base(id)
        {
            this.LengthInKilometers = lengthInKilometers;
            this.DurationInDays = durationInDays;
            this.ContestId = contestId;
        }

        public int LengthInKilometers { get; internal set; }

        public int DurationInDays { get; internal set; }

        public string ContestId { get; internal set; }

        [JsonIgnore]
        public ContestStore Contest { get; internal set; }

        [JsonIgnore]
        public IList<PhaseStore> Phases { get; internal set; }
    }
}
