using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace Demo.API.Files.Interfaces
{
    public interface IArquivoBusiness
    {
        Task<string> Salvar(List<IFormFile> arquivos);
    }
}
