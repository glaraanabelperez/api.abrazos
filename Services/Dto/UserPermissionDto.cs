namespace ServicesQueries.Dto

{
    public class UserPermissionDto
    {
        public int UserPermissionId { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        //public UserDto? User { get; set; }
        public PermissionDto? Permission { get; set; }
    }
}