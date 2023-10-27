using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TypeEvent_User 
    {
        public int TypeEventUser_Id { get; set; }
        public int TypeEventId_FK { get; set; }
        public int UserId_FK { get; set; }

        public User User { get; set; }
        public TypeEvent TypeEvent { get; set; }

    }
}