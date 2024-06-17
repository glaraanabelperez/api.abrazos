using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class CityCreateCommand
    {
        public string? CityName { get; set; }
        public string? CountryName { get; set; }
        public string? StateName { get; set; }

    }
}