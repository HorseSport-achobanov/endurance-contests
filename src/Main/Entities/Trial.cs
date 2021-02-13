namespace Main.Entities
{
    public class Trial
    {
        public Trial(int id, int length)
        {
            this.Id = id;
            this.Length = length;
        }

        public int Id { get; set; }

        public int Length { get; set; }

        public Contest Contest { get; set; }
    }
}
