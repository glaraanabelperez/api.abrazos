using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;

    }
}