﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.CreateCommand
{
    public class CityCreateCommand
    {
        [Required]
        public int CountryId_FK { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 8)]
        public string Name { get; set; } = string.Empty;

    }
}