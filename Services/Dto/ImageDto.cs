using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.Services.Dto
{
    public class ImageDto
    {
        public int ImageId { get; set; }
        public int UserId_fk { get; set; }
        public string Name { get; set; } = null!;

    }
}