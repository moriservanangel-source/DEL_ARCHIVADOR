using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MesaPartesCajamarca.Validaciones.EsDniRuc
{
    public class ValidadorEsDniRuc
    {
        public static bool ContieneSoloNumeros(string dniRuc)
        {
            if (string.IsNullOrWhiteSpace(dniRuc))
                return false;

            return Regex.IsMatch(dniRuc, @"^\d+$");
        }

        public static bool EsLongitudValida(string dniRuc)
        {
            if (string.IsNullOrWhiteSpace(dniRuc))
                return false;

            return dniRuc.Length == 8 || dniRuc.Length == 11;
        }

        public static bool EsDniRucValido(string dniRuc)
        {
            return ContieneSoloNumeros(dniRuc)
                && EsLongitudValida(dniRuc);
        }
    }
}