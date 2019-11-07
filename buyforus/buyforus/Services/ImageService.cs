using buyforus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buyforus.Services
{
    public class ImageService:IImageService
    {
        private readonly IBlobService blobService;
        private int fourMegaByte = 4 * 1024 * 1024;
        private readonly string[] validExtensions = { "jpg", "png", "jpeg" };

        public ImageService(IBlobService blobService)
        {
            this.blobService = blobService;
        }

        public List<string> Validate(IFormFileCollection files, ViewModel newHotel)
        {
            foreach (var file in files)
            {
                if (CheckImageExtension(file))
                {
                    if (file.Length < fourMegaByte)
                    {
                        return newHotel.ErrorMessages;
                    }
                    else
                    {
                        newHotel.ErrorMessages.Add("The image max 4 MB");
                        return newHotel.ErrorMessages;
                    }
                }
                else
                {
                    newHotel.ErrorMessages.Add("Please add only image formats!");
                    return newHotel.ErrorMessages;
                }
            }

            return newHotel.ErrorMessages;
        }

        public async Task UploadAsync(IFormFileCollection files, long hotelId)
        {
            var blobcontainer = await blobService.GetBlobContainer();
            for (int i = 0; i < files.Count; i++)
            {
                var blob = blobcontainer.GetBlockBlobReference(hotelId + "/" + files[i].FileName);
                using (var stream = files[i].OpenReadStream())
                {
                    await blob.UploadFromStreamAsync(stream);
                }
            }
        }

        private bool CheckImageExtension(IFormFile file)
        {
            var fileNameSegments = file.FileName.Split(".");
            var extensions = new List<string>(validExtensions);
            return extensions.Contains(fileNameSegments[fileNameSegments.Length - 1]);
        }

        public async Task<List<ImageDetails>> ListAllFoldersAsync()
        {
            var imageList = new List<ImageDetails>();
            BlobContinuationToken blobContinuationToken = null;
            do
            {
                var blobContainer = await blobService.GetBlobContainer();
                var response = await blobContainer.ListBlobsSegmentedAsync(null, blobContinuationToken);
                blobContinuationToken = response.ContinuationToken;
                await GetAllBlobDirectoryAsync(imageList);
            } while (blobContinuationToken != null);

            return imageList;
        }

        private async Task GetAllBlobDirectoryAsync(List<ImageDetails> imageList)
        {
            var blobContainer = await blobService.GetBlobContainer();
            foreach (var item in blobContainer.ListBlobs())
            {
                if (item is CloudBlobDirectory)
                {
                    GetAllImagesFromBlobs(item, imageList);
                }
            }
        }

        private void GetAllImagesFromBlobs(IListBlobItem item, List<ImageDetails> imageList)
        {
            CloudBlobDirectory directory = (CloudBlobDirectory)item;
            IEnumerable<IListBlobItem> blobs = directory.ListBlobs();
            var blob = blobs.First();
            imageList.Add(new ImageDetails
            {
                Name = blob.Uri.Segments[blob.Uri.Segments.Length - 1],
                Path = blob.Uri.ToString()
            });
        }
    }
}
