using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Demo.API.Files.Interfaces;

namespace Demo.API.Files.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {

        private readonly string _filePathDefault;
        private readonly IArquivoBusiness _arquivoBusiness;

        public ArquivoController(IConfiguration configuration, IArquivoBusiness arquivoBusiness)
        {
            _filePathDefault = configuration.GetConnectionString("PathFilesDefault");
            _arquivoBusiness = arquivoBusiness ?? throw new ArgumentNullException(nameof(arquivoBusiness));

        }


        [HttpPost("upload")]
        public async Task<string> Upload([FromForm] IFormFile arquivo)
        {

            if (arquivo.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_filePathDefault))
                    {
                        Directory.CreateDirectory(_filePathDefault);
                    }
                    using (FileStream filestream = System.IO.File.Create(_filePathDefault + arquivo.FileName))
                    {
                        await arquivo.CopyToAsync(filestream);
                        filestream.Flush();
                        return "\\imagens\\" + arquivo.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Ocorreu uma falha no envio do arquivo...";
            }
        }

        [HttpPost("uploads")]
        public async Task<string> OnPostUploadAsync([FromForm]  List<IFormFile> arquivos)
        {
            long size = arquivos.Sum(f => f.Length);


            return await _arquivoBusiness.Salvar(arquivos);

        }

    }


}
