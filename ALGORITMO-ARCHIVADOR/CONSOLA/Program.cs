using System;
using MesaPartesCajamarca.Entidad;
using MesaPartesCajamarca.Gestores;

namespace ALGORITMO_ARCHIVADOR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestorExpedientes gestor = new GestorExpedientes();

            int opcion = 0;

            do
            {
                Console.Clear();

                Console.WriteLine("=================================="); Console.WriteLine(" SISTEMA DE MESA DE PARTES"); Console.WriteLine("=================================="); Console.WriteLine("1. Registrar expediente"); Console.WriteLine("2. Buscar expediente"); Console.WriteLine("3. Listar expedientes"); Console.WriteLine("4. Salir"); Console.WriteLine("=================================="); Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) { opcion = 0; }

                switch (opcion)
                {
                    case 1: RegistrarExpediente(gestor); break;

                    case 2: Console.WriteLine("La búsqueda la conectaremos después."); Console.ReadKey(); break;

                    case 3: Console.WriteLine("El listado lo conectaremos después."); Console.ReadKey(); break;

                    case 4: Console.WriteLine("Gracias por utilizar el sistema."); break;

                    default: Console.WriteLine("Opción no válida."); Console.ReadKey(); break;
                }

            } while (opcion != 4);
        }

        static void RegistrarExpediente(GestorExpedientes gestor)
        {
            Console.Clear(); Console.WriteLine("=== REGISTRAR EXPEDIENTE ===");

            Expediente exp = new Expediente();

            Console.Write("Código: "); exp.Codigo = Console.ReadLine();

            Console.Write("DNI o RUC: "); exp.DniRuc = Console.ReadLine();

            Console.Write("Nombres: "); exp.Nombres = Console.ReadLine();

            Console.Write("Apellidos: "); exp.Apellidos = Console.ReadLine();

            Console.Write("Teléfono: "); exp.Telefono = Console.ReadLine();

            Console.Write("Correo: "); exp.Correo = Console.ReadLine();

            Console.Write("Tipo de documento: "); exp.TipoDocumento = Console.ReadLine();

            Console.Write("Número de documento: "); exp.NumeroDocumento = Console.ReadLine();

            Console.Write("Cantidad de folios: "); if (!int.TryParse(Console.ReadLine(), out int folios)) { Console.WriteLine("La cantidad de folios no es válida."); Console.ReadKey(); return; }
            exp.Folios = folios;

            Console.Write("Asunto: "); exp.Asunto = Console.ReadLine();

            Console.Write("Área de destino: "); exp.AreaDestino = Console.ReadLine();

            exp.FechaRegistro = DateTime.Now;

            bool registrado = gestor.Registrar(exp, out string mensaje);

            Console.WriteLine(); Console.WriteLine(mensaje);

            Console.WriteLine("Presione una tecla para continuar..."); Console.ReadKey();
        }
    }
}