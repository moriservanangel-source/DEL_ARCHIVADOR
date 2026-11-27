using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesaPartesCajamarca.Expediente.Constructor;

namespace MesaPartesCajamarca.Expediente.ToString
{
    public class ExpedienteToString : ExpedienteConstructor
    {
        public string ATextoPlano()
        {
            return string.Join("|", new string[]
            {
                Sanitizar(Codigo),
                Sanitizar(DniRuc),
                Sanitizar(Nombres),
                Sanitizar(Apellidos),
                Sanitizar(Telefono),
                Sanitizar(Correo),
                Sanitizar(TipoDocumento),
                Sanitizar(NumeroDocumento),
                Folios.ToString(System.Globalization.CultureInfo.InvariantCulture),
                Sanitizar(Asunto),
                Sanitizar(AreaDestino),
                FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
            });
        }

        private static string Sanitizar(string valor)
        {
            return (valor ?? string.Empty)
                .Replace("|", " ")
                .Replace("\r", " ")
                .Replace("\n", " ")
                .Trim();
        }

        public override string ToString()
        {
            return
                $"Código: {Codigo} | " +
                $"Solicitante: {Nombres} {Apellidos} | " +
                $"Documento: {TipoDocumento} | " +
                $"Folios: {Folios} | " +
                $"Área: {AreaDestino}";
        }
    }
}
