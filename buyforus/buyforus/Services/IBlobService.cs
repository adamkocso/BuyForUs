using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Storage.Blob;
using System.Threading.Tasks;


namespace buyforus.Services
{
    public interface IBlobService
    {
        Task<CloudBlobContainer> GetBlobContainer();
    }
}
