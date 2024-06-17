namespace Models
{
    public class ProfileDancer
    {
        public int ProfileDanceId { get; set; }
        public int DanceLevelId { get; set; }
        public int DanceRolId { get; set; }
        public int? DanceId { get; set; }

        public int UserId { get; set; }

        public Dance? Dance { get; set; }
        public DanceRol DanceRol { get; set; } 
        public DanceLevel DanceLevel { get; set; }
        public User User { get; set; }

    }
}