namespace Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public ICollection<UserPermission> Permissions { get; set;}= new List<UserPermission>();
    }
}