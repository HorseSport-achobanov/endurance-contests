using EnduranceContestManager.Gateways.Persistence;
using EnduranceContestManager.Gateways.Persistence.Stores;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Main
{
    public class DbService
    {
        private readonly EcmDbContext db;

        public DbService(EcmDbContext db)
        {
            this.db = db;
        }

        public ContestStore Get()
        {
            return this.db
                .Contests
                .Include(x => x.Trials)
                .FirstOrDefault();
        }

        public void Save(ContestStore contest)
        {
            var existingContest = this.db.Contests.FirstOrDefault(x => x.Id == contest.Id);
            if (existingContest == null)
            {
                this.db.Contests.Add(contest);
            }
            else
            {
                this.db.Contests.Update(contest);
            }

            this.db.SaveChanges();
            ;
        }
    }
}
