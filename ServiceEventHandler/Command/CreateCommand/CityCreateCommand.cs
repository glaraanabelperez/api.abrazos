using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class CityCreateCommand
    {
        public int? CountryId_FK { get; set; }//validar uno u otro
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        public CountryCreateCommand? Country_ { get; set; }
    }
}