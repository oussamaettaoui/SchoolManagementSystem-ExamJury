using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.IServices
{
    public interface IBlobService
    {
        Task<string> UploadAsync(Guid fileId, IFormFile file);
        string DeleteAsync(string fileId);
        string GetFileUrl(Guid fileId);
    }
}
