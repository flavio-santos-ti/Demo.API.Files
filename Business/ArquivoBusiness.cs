using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Configuration;
using Demo.API.Files.Interfaces;
using Demo.API.Files.Views;
using System;

namespace Demo.API.Files.Business
{
    public class ArquivoBusiness: IArquivoBusiness
    {
        private readonly string _filePathDefault;
        public ArquivoBusiness(IConfiguration configuration)
        {
            _filePathDefault = configuration.GetConnectionString("PathFilesDefault");
        }

        public async Task<StatusView> Salvar( List<IFormFile> arquivos )
        {
            StatusView status = new();
            status.Escopo = "Upload de Arquivos";
            status.Camada = "Business";

            if (arquivos.Count < 1)
            {
                status.IsOk = false;
                status.Message = "Nenhum arquivo recebido!";

                return status;
            }

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

            status.IsOk = false;
            status.Message = "Uplad de arquivo(s) realizado com sucesso!";

            return status;
        }

    }
}
