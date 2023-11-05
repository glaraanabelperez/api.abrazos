using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.Services.Dto
{
    public class UserPermissionDto
    {
        public int UserPermissionId { get; set; }
        public int UserId_FK { get; set; }
        public int Permission_FK { get; set; }
        public UserDto? User { get; set; }
        public PermissionDto? Permission { get; set; }
    }
}