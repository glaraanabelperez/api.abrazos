namespace Models
{
    public class ProfileDancer
    {
        public int ProfileDanceId { get; set; }
        public int DanceLevel_FK { get; set; }
        public int DanceRol_FK { get; set; }
        public double? Height { get; set; }
        public DanceRol? DanceRol { get; set; } 
        public DanceLevel? DanceLevel { get; set; }

        public ICollection<User>? Users { get; set; }

    }
}