using Demo.API.Files.Interfaces;
using Demo.API.Files.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.API.Files.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        private readonly IArquivoBusiness _arquivoBusiness;

        public ArquivoController(IConfiguration configuration, IArquivoBusiness arquivoBusiness)
        {
            _arquivoBusiness = arquivoBusiness ?? throw new ArgumentNullException(nameof(arquivoBusiness));
        }

        [HttpPost("upload")]
        public async Task<ActionResult<StatusView>> UploadAsync([FromForm]  List<IFormFile> arquivos)
        {
            return await _arquivoBusiness.Salvar(arquivos);
        }

    }


}
