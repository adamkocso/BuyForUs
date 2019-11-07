using Microsoft.Azure.Storage.Blob;
using System.Threading.Tasks;


namespace buyforus.Services
{
    public interface IBlobService
    {
        Task<CloudBlobContainer> GetBlobContainer();
    }
}