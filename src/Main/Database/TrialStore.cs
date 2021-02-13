namespace Main.Database
{
    public class TrialStore : EntityStore
    {
        public TrialStore(int id, int length, int contestId)
            : base(id)
        {
            this.Length = length;
            this.ContestId = contestId;
        }

        public int Length { get; set; }

        public int ContestId { get; set; }

        public ContestStore Contest { get; set; }
    }
}
