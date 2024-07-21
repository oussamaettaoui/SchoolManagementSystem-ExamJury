using Azure;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SchoolManagementSystem.Application.IServices;

namespace SchoolManagementSystem.Application.Services
{
    public class BlobService : IBlobService
    {
        #region Props
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerClient _blobContainerClient;
        private readonly IConfiguration _configuration;
        #endregion
        #region Constructor
        public BlobService(BlobServiceClient blobServiceClient,IConfiguration configuration)
        {
            _configuration = configuration;
            _blobServiceClient = blobServiceClient;
            _blobContainerClient = blobServiceClient.GetBlobContainerClient(_configuration.GetValue<string>("BlobStorage:ContainerName"));
            _blobContainerClient.CreateIfNotExists();
        }
        #endregion
        #region Methods
        public async Task<string> UploadAsync(Guid fileId, IFormFile file)
        {
            string uniqueFileName = $"{fileId}_{file.FileName}";
            BlobClient blobClient = _blobContainerClient.GetBlobClient(uniqueFileName);
            await blobClient.UploadAsync(file.OpenReadStream(), true);
            string res = GetFileUrl(fileId);
            return res;
        }
        public string GetFileUrl(Guid fileId)
        {
            try
            {
                List<string> urls = new List<string>();

                foreach (BlobItem blobItem in _blobContainerClient.GetBlobs(prefix: fileId.ToString()))
                {
                    string fileName = blobItem.Name;
                    BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
                    BlobSasBuilder sasBuilder = new BlobSasBuilder()
                    {
                        BlobContainerName = _blobContainerClient.Name,
                        BlobName = blobClient.Name,
                        Resource = "b",
                        StartsOn = DateTimeOffset.UtcNow,
                        ExpiresOn = DateTimeOffset.UtcNow.AddYears(10)
                    };
                    sasBuilder.SetPermissions(BlobSasPermissions.Read);
                    StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(_blobContainerClient.AccountName, _configuration.GetValue<string>("BlobStorage:Key"));
                    string sasToken = sasBuilder.ToSasQueryParameters(sharedKeyCredential).ToString();
                    Uri blobUrlWithSas = new Uri(blobClient.Uri, $"{fileName}?{sasToken}");
                    urls.Add(blobUrlWithSas.ToString());
                }
                if (urls.Count() == 0)
                {
                    return "NaN";
                }
                else
                {
                    return urls[0];
                }
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Error: {ex.ErrorCode} - {ex.Message}");
                return null;
            }
        }
        public string DeleteAsync(string fileId)
        {
            try
            {
                foreach (BlobItem blobItem in _blobContainerClient.GetBlobs(prefix: fileId))
                {
                    _blobContainerClient.DeleteBlobIfExists(blobItem.Name);
                }
                return $"Blobs with ID {fileId} deleted successfully.";
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Error: {ex.ErrorCode} - {ex.Message}");
                return "An error occurred while deleting blobs.";
            }
        }
        #endregion
    }
}
