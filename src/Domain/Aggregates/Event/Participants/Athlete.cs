using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Domain.Aggregates.Event.Participants
{
    public class Athlete : DomainModel<EventAthleteException>
    {
        private Athlete()
        {
        }

        public Athlete(Category category)
            => this.Validate(() =>
            {
                this.Category = category.IsRequired(nameof(category));
            });

        public Category Category { get; private set; }
    }
}
