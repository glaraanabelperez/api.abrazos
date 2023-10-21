using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class WaitList 
    {
        public int WaitListId { get; set; }
        public int UserId_FK { get; set; }
        public int EventId_FK { get; set; }
        public int State { get; set; }
    }
}