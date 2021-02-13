using EnduranceContestManager.Domain.Entities.Phases;
using EnduranceContestManager.Domain.Entities.Trials;
using EnduranceContestManager.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceContestManager.Gateways.Persistence.Stores
{
    public class PhaseStore : EntityStore<Phase>, IPhaseState
    {
        public PhaseStore()
        {
        }

        [JsonConstructor]
        public PhaseStore(string id, int lengthInKilometers, string trialId)
            : base(id)
        {
            this.LengthInKilometers = lengthInKilometers;
            this.TrialId = trialId;
        }

        public int LengthInKilometers { get; internal set; }

        public bool IsFinal { get; internal set; }

        [JsonIgnore]
        public IList<PhaseForCategoryStore> PhasesForCategories { get; internal set; }

        public string TrialId { get; internal set; }

        [JsonIgnore]
        public Trial Trial { get; internal set; }
    }
}
