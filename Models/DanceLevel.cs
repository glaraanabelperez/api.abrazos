namespace Models
{
    public class DanceLevel
    {
        public int DanceLevelId { get; set; }
        public string Name { get; set; } = null!;
        
        //public ICollection<ProfileDancer>? ProfileDancers { get; set; } = new List<ProfileDancer>();
        //public ICollection<DanceRol>? DanceRols { get; }

    }
}