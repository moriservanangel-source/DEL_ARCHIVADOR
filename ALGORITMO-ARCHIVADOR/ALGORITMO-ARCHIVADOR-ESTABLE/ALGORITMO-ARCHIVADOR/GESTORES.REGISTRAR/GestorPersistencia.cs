using System;
using System.Collections.Generic;
using System.IO;
using ExpedienteEntidad = MesaPartesCajamarca.Entidad.Expediente;

namespace MesaPartesCajamarca.Gestores.Persistencia
{
    public static class GestorPersistencia
    {
        private static string ResolverRuta(string rutaArchivo)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo))
                throw new ArgumentException("La ruta del archivo no es válida.", "rutaArchivo");

            return Path.IsPathRooted(rutaArchivo)
                ? rutaArchivo
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaArchivo);
        }

        private static void PrepararDirectorio(string rutaCompleta)
        {
            string directorio = Path.GetDirectoryName(rutaCompleta);
            if (!string.IsNullOrEmpty(directorio) && !Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);
        }

        public static bool Agregar(
            ExpedienteEntidad expediente,
            string rutaArchivo,
            out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                string ruta = ResolverRuta(rutaArchivo);
                PrepararDirectorio(ruta);
                File.AppendAllText(ruta, expediente.ATextoPlano() + Environment.NewLine);
                mensaje = "Expediente guardado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error al guardar el expediente: " + ex.Message;
                return false;
            }
        }

        public static bool Guardar(
            List<ExpedienteEntidad> expedientes,
            string rutaArchivo,
            out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                string ruta = ResolverRuta(rutaArchivo);
                PrepararDirectorio(ruta);
                List<string> lineas = new List<string>();
                foreach (ExpedienteEntidad expediente in expedientes)
                    lineas.Add(expediente.ATextoPlano());
                File.WriteAllLines(ruta, lineas.ToArray());
                mensaje = "Información guardada correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error al guardar los datos: " + ex.Message;
                return false;
            }
        }

        public static List<ExpedienteEntidad> Cargar(
            string rutaArchivo,
            out string mensaje)
        {
            List<ExpedienteEntidad> lista = new List<ExpedienteEntidad>();
            mensaje = string.Empty;
            try
            {
                string ruta = ResolverRuta(rutaArchivo);
                if (!File.Exists(ruta))
                {
                    mensaje = "No existe archivo previo. Se iniciará vacío.";
                    return lista;
                }

                string[] lineas = File.ReadAllLines(ruta);
                for (int i = 0; i < lineas.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lineas[i]))
                        continue;

                    try
                    {
                        lista.Add(ExpedienteEntidad.FromFileLine(lineas[i]));
                    }
                    catch (Exception ex)
                    {
                        mensaje += "Línea " + (i + 1) + " ignorada: " + ex.Message + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al cargar los datos: " + ex.Message;
            }
            return lista;
        }
    }
}
