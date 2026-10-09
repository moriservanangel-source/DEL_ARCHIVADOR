using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesaPartesCajamarca.Entidad;
using ExpedienteEntidad = MesaPartesCajamarca.Entidad.Expediente;

namespace MesaPartesCajamarca.Gestores.Ordenar
{
    public class GestorOrdenar
    {
        public static List<ExpedienteEntidad> OrdenarPorCodigo(
            List<ExpedienteEntidad> expedientes)
        {
            return expedientes
                .OrderBy(e => e.Codigo)
                .ToList();
        }
    }
}
