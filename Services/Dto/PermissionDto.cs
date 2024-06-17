namespace ServicesQueries.Dto
{
    public class PermissionDto
    {
        public int PermissionId { get; set; }
        public string Name { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public ICollection<UserPermissionDto>? UserPermissions { get; set; } = new List<UserPermissionDto>();

        //public ICollection<User>? Users { get; set; } = new List<User>();

    }
}