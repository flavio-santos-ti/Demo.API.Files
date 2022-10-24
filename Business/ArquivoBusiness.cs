using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Configuration;
using Demo.API.Files.Interfaces;

namespace Demo.API.Files.Business
{
    public class ArquivoBusiness: IArquivoBusiness
    {
        private readonly string _filePathDefault;
        
        public ArquivoBusiness(IConfiguration configuration)
        {
            _filePathDefault = configuration.GetConnectionString("PathFilesDefault");
        }

        public async Task<string> Salvar( List<IFormFile> arquivos )
        {
            
          
            

            foreach (var formFile in arquivos)
            {
                if (formFile.Length > 0)
                {
                    if (!Directory.Exists(_filePathDefault))
                    {
                        Directory.CreateDirectory(_filePathDefault);
                    }

                    using (FileStream filestream = System.IO.File.Create(_filePathDefault + formFile.FileName))
                    {
                        await formFile.CopyToAsync(filestream);
                        filestream.Flush();
                    }

                }
            }

            return "ok";
        }

    }
}
