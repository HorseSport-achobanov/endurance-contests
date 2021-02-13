using System.Collections.Generic;

namespace Main.Entities
{
    public class Contest
    {
        public Contest(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Trial> Trials { get; set; } = new List<Trial>();

        public void AddTrial(Trial trial)
        {
            this.Trials.Add(trial);
            trial.Contest = this;
        }
    }
}
