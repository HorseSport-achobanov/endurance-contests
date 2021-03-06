﻿using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Import.Horses;
using EnduranceJudge.Gateways.Persistence.Core;
using Newtonsoft.Json;
using Horse = EnduranceJudge.Domain.Aggregates.Event.Participants.Horse;
using ImportHorse = EnduranceJudge.Domain.Aggregates.Import.Horses.Horse;

namespace EnduranceJudge.Gateways.Persistence.Entities
{
    public class HorseEntity : EntityModel, IHorseState,
        IMap<Horse>,
        IMap<ImportHorse>
    {
        public string FeiId { get; set; }
        public string Name { get; set; }
        public bool IsStallion { get; set; }
        public string Breed { get; set; }
        public string TrainerFeiId { get; set; }
        public string TrainerFirstName { get; set; }
        public string TrainerLastName { get; set; }

        [JsonIgnore]
        public ParticipantEntity Participant { get; set; }
        public int ParticipantId { get; set; }
    }
}
