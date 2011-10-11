using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Container;
using Alfa.Pet.Model.Services;

namespace Alfa.Pet.Simul
{
    class Program
    {
        static void Main(string[] args)
        {
            CadastroService service = Locator.GetComponet<CadastroService>();
        }
    }
}
