using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpedienteEntidad = MesaPartesCajamarca.Entidad.Expediente;
using MesaPartesCajamarca.Gestores;
using MesaPartesCajamarca.Vistas.Comun;

namespace MesaPartesCajamarca.Vistas.Menu
{
    public static class MenuPrincipal
    {
        private static GestorExpedientes gestor =
            new GestorExpedientes();

        public static void Ejecutar()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();

                MostrarMenu();

                string opcion = Console.ReadLine();

                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        RegistrarExpediente();
                        Pausar();
                        break;

                    case "2":
                        BuscarExpediente();
                        Pausar();
                        break;

                    case "3":
                        OrdenarYMostrar();
                        Pausar();
                        break;

                    case "4":
                        MostrarTodos();
                        Pausar();
                        break;

                    case "5":
                        salir = true;

                        Console.WriteLine(
                            "======================================");

                        Console.WriteLine(
                            " Saliendo del sistema...");

                        Console.WriteLine(
                            "======================================");

                        break;

                    default:
                        Console.WriteLine(
                            "❌ Opción inválida. Seleccione del 1 al 5.");

                        Pausar();
                        break;
                }
            }
        }

        private static void MostrarMenu()
        {
            Console.WriteLine(
                "==========================================");

            Console.WriteLine(
                "       MESA DE PARTES DIGITAL");

            Console.WriteLine(
                "          MUNICIPALIDAD DE CAJAMARCA");

            Console.WriteLine(
                "==========================================");

            Console.WriteLine(
                "1. Registrar expediente");

            Console.WriteLine(
                "2. Buscar expediente por código");

            Console.WriteLine(
                "3. Ordenar expedientes por código");

            Console.WriteLine(
                "4. Mostrar todos los expedientes");

            Console.WriteLine(
                "5. Salir");

            Console.WriteLine(
                "==========================================");

            Console.Write(
                "Seleccione una opción: ");
        }

        private static void RegistrarExpediente()
        {
            Console.WriteLine(
                "==========================================");

            Console.WriteLine(
                "       REGISTRO DE EXPEDIENTE");

            Console.WriteLine(
                "==========================================");

            ExpedienteEntidad exp =
                new ExpedienteEntidad();

            Console.Write("Código: ");
            exp.Codigo = Console.ReadLine();

            Console.Write("DNI/RUC: ");
            exp.DniRuc = Console.ReadLine();

            Console.Write("Nombres: ");
            exp.Nombres = Console.ReadLine();

            Console.Write("Apellidos: ");
            exp.Apellidos = Console.ReadLine();

            Console.Write("Teléfono: ");
            exp.Telefono = Console.ReadLine();

            Console.Write("Correo electrónico: ");
            exp.Correo = Console.ReadLine();

            Console.Write(
                "Tipo de documento (Solicitud/Carta/Oficio): ");

            exp.TipoDocumento = Console.ReadLine();

            Console.Write("Número de documento: ");
            exp.NumeroDocumento = Console.ReadLine();

            Console.Write("Número de folios: ");

            string foliosInput =
                Console.ReadLine();

            int folios;

            if (!int.TryParse(
                foliosInput,
                out folios))
            {
                Console.WriteLine(
                    "\n❌ FALLA 21: Los folios deben ser un número entero.");

                return;
            }

            exp.Folios = folios;

            Console.Write("Asunto: ");
            exp.Asunto = Console.ReadLine();

            Console.Write("Área de destino: ");
            exp.AreaDestino = Console.ReadLine();

            Console.WriteLine(
                "\n------------------------------------------");

            Console.WriteLine(
                "       VALIDANDO INFORMACIÓN...");

            Console.WriteLine(
                "------------------------------------------");

            bool registrado =
                gestor.Registrar(
                    exp,
                    out string mensaje);

            if (registrado)
            {
                Console.WriteLine(
                    "\n✅ " + mensaje);
            }
            else
            {
                Console.WriteLine(
                    "\n❌ " + mensaje);
            }
        }

        private static void BuscarExpediente()
        {
            Console.WriteLine(
                "==========================================");

            Console.WriteLine(
                "       BUSCAR EXPEDIENTE");

            Console.WriteLine(
                "==========================================");

            Console.Write(
                "Ingrese el código: ");

            string codigo =
                Console.ReadLine();

            ExpedienteEntidad exp =
                gestor.BuscarPorCodigo(codigo);

            if (exp != null)
            {
                VistaComun.MostrarExpediente(exp);
            }
            else
            {
                Console.WriteLine(
                    "\n❌ No se encontró ningún expediente con ese código.");
            }
        }

        private static void OrdenarYMostrar()
        {
            gestor.OrdenarPorCodigo();

            Console.WriteLine(
                "==========================================");

            Console.WriteLine(
                "       EXPEDIENTES ORDENADOS");

            Console.WriteLine(
                "==========================================");

            VistaComun.MostrarLista(
                gestor.ObtenerTodos());
        }

        private static void MostrarTodos()
        {
            Console.WriteLine(
                "==========================================");

            Console.WriteLine(
                "       TODOS LOS EXPEDIENTES");

            Console.WriteLine(
                "==========================================");

            VistaComun.MostrarLista(
                gestor.ObtenerTodos());
        }

        private static void Pausar()
        {
            Console.WriteLine(
                "\nPresione ENTER para continuar...");

            Console.ReadLine();
        }
    }
}
