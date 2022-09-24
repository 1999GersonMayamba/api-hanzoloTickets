using Infrastructure.Shared.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Minio;
using Minio.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Shared.Services
{
    public class MinioService : IMinioService
    {

        private readonly IConfiguration configuration;
        public MinioService(IConfiguration _config)
        {
            configuration = _config;
        }

        public MinioClient ConnectMinio()
        {

            var session = configuration.GetSection("MinIO");
            var endpoint = session.GetValue<string>("endpoint"); // "localhost:9000"; configuration.GetSection("UseInMemoryDatabase");
            var accessKey = session.GetValue<string>("accessKey");//"mayamba";
            var secretKey = session.GetValue<string>("secretKey");  //"AIzaSyCKYKv-NXGY4z3Q-R1VkbIgoJlhifgPCN8";


            try
            {
                var minio = new MinioClient()
                                    .WithEndpoint(endpoint)
                                    .WithCredentials(accessKey, secretKey)
                                    .Build();


                return minio;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            return new MinioClient();
        }


        public async Task  ListBuckets ()
        {
            var minIO = this.ConnectMinio();

            // Create an async task for listing buckets.
            var getListBucketsTask = await minIO.ListBucketsAsync();


            // Iterate over the list of buckets.
            foreach (Bucket bucket in getListBucketsTask.Buckets)
            {
                Console.WriteLine(bucket.Name + " " + bucket.CreationDateDateTime);
            }
        }


        public async Task UploadFile(string Filebase64, string FileName, IFormFile Filestream)
        {

            try
            {
                var minIO = this.ConnectMinio();
                var session = configuration.GetSection("MinIO");
                //var stream = Filestream.OpenReadStream();
                System.IO.MemoryStream filestream = new System.IO.MemoryStream();
                Filestream.CopyTo(filestream);

                var args = new PutObjectArgs()
               .WithBucket(session.GetValue<string>("bucket"))
               .WithObject(Filestream.FileName)
               //.WithContentType("text/plain")
               .WithObjectSize(Filestream.Length)
               .WithStreamData(Filestream.OpenReadStream());
               //.WithFileName(FileName);
                await minIO.PutObjectAsync(args);



            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public async Task UploadFile(string Filebase64, string FileName)
        {

            try
            {
                var minIO = this.ConnectMinio();
                var session = configuration.GetSection("MinIO");
                var bytes = Convert.FromBase64String(Filebase64);
                var contents =  new MemoryStream(bytes);

                var args = new PutObjectArgs()
               .WithBucket(session.GetValue<string>("bucket"))
               .WithObject(FileName)
               //.WithContentType("text/plain")
               .WithObjectSize(contents.Length)
               .WithStreamData(contents);
                //.WithFileName(FileName);
                await minIO.PutObjectAsync(args);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
