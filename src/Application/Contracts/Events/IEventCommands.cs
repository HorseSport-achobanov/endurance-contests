using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;

namespace EnduranceJudge.Application.Contracts.Events
{
    public interface IEventCommands : ICommandsBase<Event>
    {
    }
}
