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
