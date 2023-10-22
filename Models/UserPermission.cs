using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UserPermission
    {
        public int UserPermissionId { get; set; }
        public int UserId_FK { get; set; }
        public int Permission_FK { get; set; }
        public User User { get; set; }
        public Permission Permission { get; set; }
    }
}