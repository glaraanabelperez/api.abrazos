﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int UserId_FK { get; set; }
        public int CityId_FK { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string DetailAddress { get; set; }
        public bool StateAddress { get; set; }

       
    }
}