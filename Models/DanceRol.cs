namespace Models
{
    public class DanceRol
    {
        public int DanceRolId { get; set; }
        public int Name { get; set; }
        public ICollection<ProfileDancer> ProfileDancers { get; set; } = new List<ProfileDancer>();

    }
}