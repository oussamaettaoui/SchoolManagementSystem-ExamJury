using Microsoft.AspNetCore.Http;

namespace SchoolManagementSystem.Application.IServices
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile file);
        Task DeleteFile(string filepath);
    }
}
