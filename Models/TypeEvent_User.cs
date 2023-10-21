using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TypeEvent_User 
    {
        public int TypeEventUserId { get; set; }
        public int TypeEventId_FK { get; set; }
        public int UserId_FK { get; set; }
       
    }
}