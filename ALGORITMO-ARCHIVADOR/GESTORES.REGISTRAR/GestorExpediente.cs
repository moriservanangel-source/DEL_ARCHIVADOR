using ALGORITMO_ARCHIVADOR.GESTORES.REGISTRAR;
using MesaPartesCajamarca.Gestores.Buscar;
using MesaPartesCajamarca.Gestores.Ordenar;
using MesaPartesCajamarca.Gestores.Persistencia;
using MesaPartesCajamarca.Gestores.Registrar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpedienteEntidad = MesaPartesCajamarca.Entidad.Expediente;

namespace MesaPartesCajamarca.Gestores
{
    public class GestorExpedientes
    {
        private List<ExpedienteEntidad> expedientes;

        private readonly string rutaArchivo;

        public string MensajeCarga { get; private set; }

        public GestorExpedientes(
            string rutaArchivo = "datos/expedientes.txt")
        {
            this.rutaArchivo = rutaArchivo;

            expedientes =
                GestorPersistencia.Cargar(
                    rutaArchivo,
                    out string mensaje);

            MensajeCarga = mensaje;
        }

        public bool Registrar(
            ExpedienteEntidad exp,
            out string mensaje)
        {
            bool registrado =
                GestorRegistrar.Registrar(
                    expedientes,
                    exp,
                    out mensaje);

            if (registrado)
            {
                GestorPersistencia.Guardar(
                    expedientes,
                    rutaArchivo,
                    out string mensajeGuardado);
            }

            return registrado;
        }

        public ExpedienteEntidad BuscarPorCodigo(string codigo)
        {
            return GestorBuscar.BuscarPorCodigo(
                expedientes,
                codigo);
        }

        public List<ExpedienteEntidad> ObtenerTodos()
        {
            return new List<ExpedienteEntidad>(expedientes);
        }

        public void OrdenarPorCodigo()
        {
            expedientes =
                GestorOrdenar.OrdenarPorCodigo(
                    expedientes);

            GestorPersistencia.Guardar(
                expedientes,
                rutaArchivo,
                out string mensaje);
        }
    }
}
