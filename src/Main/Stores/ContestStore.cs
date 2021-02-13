using EnduranceContestManager.Gateways.Persistence.Core;
using System.Collections.Generic;

namespace EnduranceContestManager.Gateways.Persistence.Stores
{
    public class ContestStore : EntityStore
    {
        public ContestStore(int id, string name)
            : base(id)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public IList<TrialStore> Trials { get; set; } = new List<TrialStore>();
    }
}
