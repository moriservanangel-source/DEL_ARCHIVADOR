using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpedienteEntidad = MesaPartesCajamarca.Entidad.Expediente;


namespace MesaPartesCajamarca.Vistas.Comun
{
    public static class VistaComun
    {
        public static void MostrarLista(
            List<ExpedienteEntidad> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine(
                    "No hay expedientes registrados.");
                return;
            }

            Console.WriteLine(
                "------------------------------------------------------------");

            foreach (ExpedienteEntidad exp in lista)
            {
                Console.WriteLine(exp.ToString());
            }

            Console.WriteLine(
                "------------------------------------------------------------");

            Console.WriteLine(
                $"Total: {lista.Count} expediente(s).");
        }

        public static void MostrarExpediente(
            ExpedienteEntidad exp)
        {
            Console.WriteLine(
                "\n==============================================");

            Console.WriteLine(
                "          EXPEDIENTE ENCONTRADO");

            Console.WriteLine(
                "==============================================");

            Console.WriteLine(
                $"Código:             {exp.Codigo}");

            Console.WriteLine(
                $"DNI/RUC:            {exp.DniRuc}");

            Console.WriteLine(
                $"Nombres:            {exp.Nombres}");

            Console.WriteLine(
                $"Apellidos:          {exp.Apellidos}");

            Console.WriteLine(
                $"Teléfono:           {exp.Telefono}");

            Console.WriteLine(
                $"Correo:             {exp.Correo}");

            Console.WriteLine(
                $"Tipo documento:     {exp.TipoDocumento}");

            Console.WriteLine(
                $"Número documento:   {exp.NumeroDocumento}");

            Console.WriteLine(
                $"Folios:             {exp.Folios}");

            Console.WriteLine(
                $"Asunto:             {exp.Asunto}");

            Console.WriteLine(
                $"Área destino:       {exp.AreaDestino}");

            Console.WriteLine(
                $"Fecha registro:     {exp.FechaRegistro}");

            Console.WriteLine(
                "==============================================");
        }
    }
}

