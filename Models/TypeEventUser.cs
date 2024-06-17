using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TypeEventUser 
    {
        public int TypeEventUserId { get; set; }
        public int TypeEventId { get; set; }
        public int UserId { get; set; }

        public User? User { get; set; }
        public TypeEvent TypeEvent { get; set; } = new TypeEvent();

    }
}