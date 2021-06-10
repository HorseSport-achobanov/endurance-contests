﻿using EnduranceJudge.Domain.Aggregates.Event.Participants;
using EnduranceJudge.Gateways.Persistence.Core;
using EnduranceJudge.Gateways.Persistence.Entities.Athletes;
using EnduranceJudge.Gateways.Persistence.Entities.Horses;
using EnduranceJudge.Gateways.Persistence.Entities.ParticipantsInCompetitions;
using Newtonsoft.Json;
using System.Collections.Generic;
using ImportParticipant = EnduranceJudge.Domain.Aggregates.Import.Participants.Participant;

namespace EnduranceJudge.Gateways.Persistence.Entities.Participants
{
    public class ParticipantEntity : EntityBase, IParticipantState
    {
        public string RfId { get; set; }
        public int ContestNumber { get; set; }
        public int? MaxAverageSpeedInKpH { get; set; }

        [JsonIgnore]
        public HorseEntity Horse { get; set; }
        public int HorseId { get; set; }

        [JsonIgnore]
        public AthleteEntity Athlete { get; set; }
        public int AthleteId { get; set; }

        [JsonIgnore]
        public ICollection<ParticipantInCompetition> ParticipantsInCompetitions { get; set; }
    }
}