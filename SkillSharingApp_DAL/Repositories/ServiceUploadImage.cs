using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SkillSharingApp_DAL.Contracts;

namespace SkillSharingApp_BAL.Services
{
    public class ServiceUploadImage : IServiceUploadImage
    {
        private readonly IHostingEnvironment hostingEnviroment;
        public ServiceUploadImage(IHostingEnvironment hostingEnviroment)
        {
            this.hostingEnviroment = hostingEnviroment;
        }
        public string UploadImage(IFormFile file)
        {
            if (file != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var fileExtension = Path.GetExtension(file.FileName);
                var uniqueFileName = $"{fileName}_{DateTime.Now.Ticks}{fileExtension}";
                var filePath = Path.Combine(hostingEnviroment.ContentRootPath, "wwwroot", "images", uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.CreateNew);
                file.CopyTo(fileStream);
                return filePath.Replace(hostingEnviroment.ContentRootPath, string.Empty).Replace("\\", "/").Replace("wwwroot", string.Empty);
            }
            return null;
        }
        public void DeleteImage(string path)
        {
            var filename = path.Replace("/images/", string.Empty);
            var filePath = Path.Combine(hostingEnviroment.ContentRootPath, "wwwroot", "images", filename);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }
    }
}
