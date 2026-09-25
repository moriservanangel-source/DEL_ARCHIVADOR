using ALGORITMO_ARCHIVADOR.EXPEDIENTE;
using MesaPartesCajamarca.Expediente.ToString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesaPartesCajamarca.Expediente.ToFileLine
{
    public class ExpedienteToFileLine : ExpedienteToString
    {
        public string ToFileLine()
        {
            return
                $"{Codigo}|" +
                $"{DniRuc}|" +
                $"{Nombres}|" +
                $"{Apellidos}|" +
                $"{Telefono}|" +
                $"{Correo}|" +
                $"{TipoDocumento}|" +
                $"{NumeroDocumento}|" +
                $"{Folios}|" +
                $"{Asunto}|" +
                $"{AreaDestino}|" +
                $"{FechaRegistro:yyyy-MM-dd HH:mm:ss}";
        }
    }
}
