using buyforus.Models;
using buyforus.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace buyforus.Services
{
    public interface IImageService
    {
        Task UploadAsync(IFormFile file, string userId, string blobContainerName);
        List<string> Validate(IFormFile file, List<string> errorMessages);
        Task<List<ImageDetails>> ListAsync(string userId, string blobContainerName);
    }
}