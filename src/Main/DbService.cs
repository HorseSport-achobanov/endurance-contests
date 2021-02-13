using AutoMapper;
using AutoMapper.QueryableExtensions;
using Main.Database;
using Main.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Main
{
    public class DbService
    {
        private readonly EcmDbContext db;
        private readonly IConfigurationProvider mapperConfig;
        private readonly IMapper mapper;

        public DbService(EcmDbContext db, IConfigurationProvider mapperConfig, IMapper mapper)
        {
            this.db = db;
            this.mapperConfig = mapperConfig;
            this.mapper = mapper;
        }

        public Contest Get()
        {
            return this.db
                .Contests
                .Include(x => x.Trials)
                .ProjectTo<Contest>(this.mapperConfig)
                .FirstOrDefault();
        }

        public void Save(Contest contest)
        {
            var existingContest = this.db.Contests.FirstOrDefault(x => x.Id == contest.Id);
            if (existingContest == null)
            {
                var store = this.mapper.Map<Contest, ContestStore>(contest);
                this.db.Contests.Add(store);
            }
            else
            {
                var kur = this.mapper.Map(contest, existingContest);
                // this.db.Contests.Update(existingContest);
            }

            this.db.SaveChanges();
            ;
        }
    }
}
