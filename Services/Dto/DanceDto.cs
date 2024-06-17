using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System.ComponentModel.DataAnnotations;

namespace ServicesQueries.Dto
{
    public class DanceDto
    {
        public int DanceId { get; set; }
        public string Name { get; set; }

    }
}