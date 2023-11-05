using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.Services.Dto
{
    public class WaitListDto 
    {
        public int WaitListId { get; set; }
        public int UserId_FK { get; set; }
        public int EventId_FK { get; set; }
        public int State { get; set; }

        public EventDto Event { get; set; } = new EventDto();

        public UserDto User { get; set; } = new UserDto();


    }
}