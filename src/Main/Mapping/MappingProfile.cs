using AutoMapper;
using Main.Database;
using Main.Entities;

namespace Main.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Contest, ContestStore>();
            this.CreateMap<ContestStore, Contest>();

            this.CreateMap<Trial, TrialStore>();
            this.CreateMap<TrialStore, Trial>();
        }
    }
}
