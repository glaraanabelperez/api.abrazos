namespace Models
{
    public class ProfileDancer
    {
        public int ProfileDanceId { get; set; }
        public int DanceLevel_FK { get; set; }
        public int DanceRol_FK { get; set; }
        public decimal Height { get; set; }

    }
}