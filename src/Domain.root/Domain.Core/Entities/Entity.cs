namespace EnduranceContestManager.Domain.Core.Entities
{
    public abstract class Entity : IEntity
    {
        protected Entity(string id)
        {
            this.Id = id;
        }

        public string Id { get; private set; }

        // Add GetHashCode(), Equals(), etc.
    }
}
