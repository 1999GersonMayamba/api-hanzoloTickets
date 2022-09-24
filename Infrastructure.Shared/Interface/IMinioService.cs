using Microsoft.AspNetCore.Http;
using Minio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Shared.Interface
{
   public  interface IMinioService
    {
        public MinioClient ConnectMinio();
        Task ListBuckets();
        Task UploadFile(string Filebase64, string FileName, IFormFile Filestream);
        Task UploadFile(string Filebase64, string FileName);
    }
}
