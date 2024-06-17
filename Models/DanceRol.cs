namespace Models
{
    public class DanceRol
    {
        public int DanceRolId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Event>? Events { get; set; } = new List<Event>();
    }
}