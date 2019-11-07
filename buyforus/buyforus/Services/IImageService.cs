using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace buyforus.Services
{
    public interface IImageService
    {
        Task UploadAsync(IFormFileCollection files, long Id);
        //List<string> Validate(IFormFileCollection files, ViewModel newHotel);
    }
}