using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ExpedienteEntidad = MesaPartesCajamarca.Entidad.Expediente;

namespace MesaPartesCajamarca.Gestores.Persistencia
{
    public class GestorPersistencia
    {
        public static bool Guardar(
            List<ExpedienteEntidad> expedientes,
            string rutaArchivo,
            out string mensaje)
        {
            mensaje = "";

            try
            {
                string directorio = Path.GetDirectoryName(
                    Path.GetFullPath(rutaArchivo));

                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                using (StreamWriter sw =
                    new StreamWriter(rutaArchivo, false))
                {
                    foreach (ExpedienteEntidad exp in expedientes)
                    {
                        sw.WriteLine(exp.ToFileLine());
                    }
                }

                mensaje = "Información guardada correctamente.";

                return true;
            }
            catch (Exception ex)
            {
                mensaje =
                    "Error al guardar los datos: " + ex.Message;

                return false;
            }
        }

        public static List<ExpedienteEntidad> Cargar(
            string rutaArchivo,
            out string mensaje)
        {
            List<ExpedienteEntidad> lista =
                new List<ExpedienteEntidad>();

            mensaje = "";

            if (!File.Exists(rutaArchivo))
            {
                mensaje = "No existe archivo previo. Se iniciará vacío.";
                return lista;
            }

            try
            {
                using (StreamReader sr =
                    new StreamReader(rutaArchivo))
                {
                    string linea;

                    int numeroLinea = 0;

                    while ((linea = sr.ReadLine()) != null)
                    {
                        numeroLinea++;

                        if (string.IsNullOrWhiteSpace(linea))
                            continue;

                        try
                        {
                            lista.Add(
                                 ExpedienteEntidad.FromFileLine(linea));
                        }
                        catch (FormatException ex)
                        {
                            mensaje +=
                                $"Línea {numeroLinea} ignorada: {ex.Message}\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje =
                    "Error al cargar los datos: " + ex.Message;
            }

            return lista;
        }
    }
}
