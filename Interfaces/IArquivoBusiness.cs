using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Demo.API.Files.Views;


namespace Demo.API.Files.Interfaces
{
    public interface IArquivoBusiness
    {
        Task<StatusView> Salvar(List<IFormFile> arquivos);
    }
}
