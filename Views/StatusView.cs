using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Files.Views
{
    public class StatusView
    {
        public string Escopo { get; set; }
        public bool IsOk { get; set; }
        public string Camada { get; set; }
        public string Message { get; set; }
    }
}
