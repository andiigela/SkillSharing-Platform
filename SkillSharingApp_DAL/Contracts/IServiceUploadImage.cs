using Microsoft.AspNetCore.Http;

namespace SkillSharingApp_DAL.Contracts
{
    public interface IServiceUploadImage
    {
        string UploadImage(IFormFile file);
        void DeleteImage(string file);
    }
}
