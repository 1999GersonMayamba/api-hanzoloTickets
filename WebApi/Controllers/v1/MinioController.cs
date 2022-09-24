using Infrastructure.Shared.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{

    [ApiVersion("1.0")]
    public class MinioController : BaseApiController
    {

        private readonly IMinioService _minioService;


        public MinioController(IMinioService minioService)
        {
            this._minioService = minioService;
        }

        [HttpGet("Teste")]
        public async Task<IActionResult> Teste()
        {
            _minioService.ConnectMinio();
           await _minioService.ListBuckets();

            return Ok();
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> Teste(IFormFile file)
        {
            //var stream = file.o();
            await _minioService.UploadFile(null, file.FileName, file);
            return Ok();
        }
    }
}
