namespace Models
{
    public class DanceLevel
    {
        public int DanceLevelId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Event>? Events { get; set; } = new List<Event>();

    }
}