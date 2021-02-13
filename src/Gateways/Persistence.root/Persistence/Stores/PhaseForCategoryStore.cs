using EnduranceContestManager.Domain.Entities.PhasesForCategory;
using EnduranceContestManager.Domain.Enums;
using EnduranceContestManager.Gateways.Persistence.Core;
using Newtonsoft.Json;

namespace EnduranceContestManager.Gateways.Persistence.Stores
{
    public class PhaseForCategoryStore : EntityStore<PhaseForCategory>, IPhaseForCategoryState
    {
        public PhaseForCategoryStore()
        {
        }

        [JsonConstructor]
        public PhaseForCategoryStore(
            string id,
            int maxRecoveryTimeInMinutes,
            int restTimeInMinutes,
            int? minSpeedInKilometersPerHour,
            int? maxSpeedInKilometersPerHour,
            Category category,
            string phaseId)
            : base(id)
        {
            this.MaxRecoveryTimeInMinutes = maxRecoveryTimeInMinutes;
            this.RestTimeInMinutes = restTimeInMinutes;
            this.MinSpeedInKilometersPerHour = minSpeedInKilometersPerHour;
            this.MaxSpeedInKilometersPerHour = maxSpeedInKilometersPerHour;
            this.Category = category;
            this.PhaseId = phaseId;
        }

        public int MaxRecoveryTimeInMinutes { get; internal set;}

        public int RestTimeInMinutes { get; internal set;}

        public int? MinSpeedInKilometersPerHour { get; internal set;}

        public int? MaxSpeedInKilometersPerHour { get; internal set;}

        public Category Category { get; internal set; }

        public string PhaseId { get; internal set; }

        [JsonIgnore]
        public PhaseStore Phase { get; internal set; }
    }
}
