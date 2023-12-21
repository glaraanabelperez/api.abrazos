using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class EventCreateCommand
    {
        [Required]// data anotation not equal zero agregar!!

        public int UserIdCreator_FK { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? AddressId_fk { get; set; }//validar uno u otro
        public string? Image { get; set; }
        public DateTime DateInit { get; set; }
        public DateTime DateFinish { get; set; }
        public int EventStateId_fk { get; set; }
        public int TypeEventId_fk { get; set; }

        public int eventState { get; set; }
        public AddressCreateCommand? Address { get; set; }




    }
}