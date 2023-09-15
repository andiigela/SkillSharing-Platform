using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSharingApp_DAL.Models
{
    public class Image
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string Path { get; set; }
        public int WorkshopId { get; set; }
        public Workshop Workshop { get; set; }
    }
}
