namespace Models
{
    public class ProfileDancer
    {
        public int ProfileDanceId { get; set; }
        public int DanceLevel_FK { get; set; }
        public int DanceRol_FK { get; set; }
        public decimal? Height { get; set; }
        //public DanceRol? DanceRol { get; set; } = new DanceRol();
        //public DanceLevel? DanceLevel { get; set; } = new DanceLevel();

        public ICollection<User>? Users { get; set; } = new List<User>();

    }
}