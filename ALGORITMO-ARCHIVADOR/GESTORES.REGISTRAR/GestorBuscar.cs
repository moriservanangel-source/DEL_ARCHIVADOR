using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpedienteEntidad = MesaPartesCajamarca.Entidad.Expediente;

namespace MesaPartesCajamarca.Gestores.Buscar
{
    public class GestorBuscar
    {
        public static ExpedienteEntidad BuscarPorCodigo(
            List<ExpedienteEntidad> expedientes,
            string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                return null;
            }

            foreach (ExpedienteEntidad expediente in expedientes)
            {
                if (expediente.Codigo.Equals(
                    codigo.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                {
                    return expediente;
                }
            }

            return null;
        }
    }
}
