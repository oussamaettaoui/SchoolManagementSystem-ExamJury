using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Application.IServices;

namespace SchoolManagementSystem.Application.Services
{
    public class FileService : IFileService
    {
        private IWebHostEnvironment _env;
        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<string> UploadFile(IFormFile file)
        {
            var path = _env.WebRootPath + "/" + "Files" + "/";
            var extention = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString().Replace("-", string.Empty) + extention;
            if (file.Length >= 0)
            {
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = File.Create(path + fileName))
                    {
                        await file.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                        return $"/Resources/{fileName}";
                    }
                }
                catch (Exception)
                {
                    return "FaildToUploadImage";
                }
            }
            else
            {
                return "NoImage";
            }
        }
        public async Task DeleteFile(string filepath)
        {
            var fullPath = Path.Combine(_env.WebRootPath, filepath.TrimStart('/'));

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
