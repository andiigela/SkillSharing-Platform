using Microsoft.AspNetCore.Http;
using SkillSharingApp_DAL.Contracts;
using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSharingApp_DAL.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Location { get; set; }
        public long Capacity { get; set; }
        public int isVisible { get; set; }
        public DateTime Availability { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }
        public virtual List<Attendance>? Attendances { get; set; } = new();
        public string? CreateApplicationUserDto_DALId { get; set; }
        public CreateApplicationUserDto_DAL? CreateApplicationUserDto_DAL { get; set; }
        public List<Bookmark>? Bookmarks { get; set; }

        public void AddImageToWorkshop(IServiceUploadImage _uploadImage)
        {
            var images = new List<Image>();
            if (ImageFiles == null) return;
            foreach (var file in ImageFiles)
            {
                if (file == null) break;
                var imagePath = _uploadImage.UploadImage(file);
                Images.Add(new Image
                {
                    ImageFile = file,
                    Path = imagePath,
                    WorkshopId = Id,
                    Workshop = this
                });
            }
            this.Images.AddRange(images);
        }

    }
}
