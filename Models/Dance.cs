namespace Models
{
    public class Dance
    {
        public int DanceId { get; set; }
        public string Name { get; set; }

        public ICollection<ProfileDancer>? ProfileDancers { get; set; } = new List<ProfileDancer>();

    }
}