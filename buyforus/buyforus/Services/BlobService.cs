using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace buyforus.Services
{
    public class BlobService : IBlobService
    {
        private readonly string blobContainerName = "photos";
        private CloudBlobClient blobClient;
        private CloudBlobContainer blobContainer;
        private string accessKey = string.Empty;
        private readonly CloudStorageAccount account;

        public BlobService(IConfiguration configuration)
        {
            this.accessKey = configuration.GetConnectionString("AzureStorageKey");
            this.account = CloudStorageAccount.Parse(accessKey);
        }

        public async Task<CloudBlobContainer> GetBlobContainer()
        {
            var blobClient = GetClient();
            blobContainer = blobClient.GetContainerReference(blobContainerName);
            if (await blobContainer.CreateIfNotExistsAsync())
            {
                await blobContainer.SetPermissionsAsync(new BlobContainerPermissions
                { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            return blobContainer;
        }

        private CloudBlobClient GetClient()
        {
            if (blobClient != null)
            {
                return blobClient;
            }

            blobClient = account.CreateCloudBlobClient();
            return blobClient;
        }
    }
}