using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesaPartesCajamarca.Validaciones.EsCampoVacio
{
    public class ValidadorEsCampoVacio
    {
        public static bool EsCampoVacio(string valor)
        {
            return string.IsNullOrWhiteSpace(valor);
        }
    }
}