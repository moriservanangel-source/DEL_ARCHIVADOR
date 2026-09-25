using ALGORITMO_ARCHIVADOR.EXPEDIENTE;
using MesaPartesCajamarca.Expediente.FromFileLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesaPartesCajamarca.Entidad
{
    public sealed class Expediente : ExpedienteFromFileLine
    {
        public new static Expediente FromFileLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                throw new FormatException("La línea está vacía.");

            string[] parts = line.Split('|');

            if (parts.Length != 12)
                throw new FormatException(
                    "La línea del archivo no contiene los 12 campos requeridos.");

            int folios;

            if (!int.TryParse(parts[8], out folios))
                throw new FormatException(
                    "El número de folios no es válido.");

            DateTime fecha;

            if (!DateTime.TryParse(parts[11], out fecha))
                throw new FormatException(
                    "La fecha de registro no es válida.");

            return new Expediente
            {
                Codigo = parts[0],
                DniRuc = parts[1],
                Nombres = parts[2],
                Apellidos = parts[3],
                Telefono = parts[4],
                Correo = parts[5],
                TipoDocumento = parts[6],
                NumeroDocumento = parts[7],
                Folios = folios,
                Asunto = parts[9],
                AreaDestino = parts[10],
                FechaRegistro = fecha
            };
        }
    }
}

