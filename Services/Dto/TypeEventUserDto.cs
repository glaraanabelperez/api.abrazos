namespace ServicesQueries.Dto

{
    public class TypeEventUserDto 
    {
        public int TypeEventUserId { get; set; }
        public int TypeEventId { get; set; }
        public int UserId { get; set; }
        public TypeEventDto TypeEvent { get; set; } = new TypeEventDto();

    }
}