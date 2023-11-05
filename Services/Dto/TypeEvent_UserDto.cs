using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.Services.Dto
{
    public class TypeEvent_UserDto 
    {
        public int TypeEventUser_Id { get; set; }
        public int TypeEventId_FK { get; set; }
        public int UserId_FK { get; set; }

        public User? User { get; set; }
        public TypeEvent TypeEvent { get; set; } = new TypeEvent();


    }
}