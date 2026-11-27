using System;
using ExpedienteEntidad = MesaPartesCajamarca.Entidad.Expediente;
using MesaPartesCajamarca.Gestores;
using MesaPartesCajamarca.Vistas.Comun;

namespace MesaPartesCajamarca.Vistas.Menu
{
    public static class MenuPrincipal
    {
        private static GestorExpedientes gestor = new GestorExpedientes();
        private const string VerdeAgua = "\x1b[38;2;0;255;213m";
        private const string Borde = "\x1b[38;2;35;115;165m";
        private const string Titulo = "\x1b[38;2;150;230;255m";
        private const string Texto = "\x1b[38;2;225;242;250m";
        private const string Error = "\x1b[38;2;235;105;105m";
        private const string Reset = "\x1b[0m";
        private const string G1 = "\x1b[38;2;145;225;255m";
        private const string G2 = "\x1b[38;2;118;202;242m";
        private const string G3 = "\x1b[38;2;92;180;228m";
        private const string G4 = "\x1b[38;2;68;158;212m";
        private const string G5 = "\x1b[38;2;48;136;195m";

        public static void Ejecutar()
        {
            Console.CursorVisible = false;
            MostrarBienvenida();
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.CursorVisible = false;
                MostrarMenu();
                char op = Console.ReadKey(true).KeyChar;
                try { Console.Beep(420, 20); } catch { }
                Console.Clear();
                Console.CursorVisible = true;
                switch (op)
                {
                    case '1': RegistrarExpediente(); Pausar(); break;
                    case '2': BuscarExpediente(); Pausar(); break;
                    case '3': OrdenarYMostrar(); Pausar(); break;
                    case '4': MostrarTodos(); Pausar(); break;
                    case '5':
                        salir = true;
                        Console.CursorTop = Math.Max(0, (Console.WindowHeight - 3) / 2);
                        Encabezado("SALIENDO DEL SISTEMA...", 40);
                        break;
                    default:
                        try { Console.Beep(250, 75); } catch { }
                        Console.CursorTop = Math.Max(0, Console.WindowHeight / 2);
                        Console.CursorLeft = Math.Max(0, (Console.WindowWidth - 48) / 2);
                        Console.WriteLine(Error + "Opción inválida. Presione una tecla del 1 al 5." + Reset);
                        Pausar();
                        break;
                }
            }
        }

        public static void MostrarBienvenida()
        {
            Console.Clear();
            string[] banner = {
                "███╗   ███╗███████╗███████╗ █████╗     ██████╗ ███████╗    ██████╗  █████╗ ██████╗ ████████╗███████╗███████╗",
                "████╗ ████║██╔════╝██╔════╝██╔══██╗    ██╔══██╗██╔════╝    ██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔════╝██╔════╝",
                "██╔████╔██║█████╗  ███████╗███████║    ██║  ██║█████╗      ██████╔╝███████║██████╔╝   ██║   █████╗  ███████╗",
                "██║╚██╔╝██║██╔══╝  ╚════██║██╔══██║    ██║  ██║██╔══╝      ██╔═══╝ ██╔══██║██╔══██╗   ██║   ██╔══╝  ╚════██║",
                "██║ ╚═╝ ██║███████╗███████║██║  ██║    ██████╔╝███████╗    ██║     ██║  ██║██║  ██║   ██║   ███████╗███████║",
                "╚═╝     ╚═╝╚══════╝╚══════╝╚═╝  ╚═╝    ╚═════╝ ╚══════╝    ╚═╝     ╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝   ╚══════╝╚══════╝",
                "",
                "                         D I G I T A L   -   M U N I C I P A L I D A D   P R O V I N C I A L",
                "                                              D E   C A J A M A R C A"
            };
            int m = Math.Max(0, (Console.WindowWidth - 108) / 2);
            Console.CursorTop = Math.Max(0, (Console.WindowHeight - 13) / 2);
            foreach (string l in banner)
            {
                if (m < Console.WindowWidth) Console.CursorLeft = m;
                Console.WriteLine(VerdeAgua + l + Reset);
            }
            string msg = "[ Presiona cualquier tecla para ingresar al sistema ]";
            Console.WriteLine("\n");
            Console.CursorLeft = Math.Max(0, (Console.WindowWidth - msg.Length) / 2);
            Console.WriteLine(Texto + msg + Reset);
            Console.ReadKey(true);
            try { Console.Beep(420, 20); } catch { }
        }

        private static void MostrarMenu()
        {
            int m = Math.Max(0, (Console.WindowWidth - 48) / 2);
            Console.CursorTop = Math.Max(0, (Console.WindowHeight - 11) / 2);
            Console.CursorLeft = m; Console.WriteLine(Borde + "╔══════════════════════════════════════════════╗");
            Console.CursorLeft = m; Console.WriteLine(Borde + "║" + Titulo + "               MENÚ DE OPCIONES               " + Borde + "║");
            Console.CursorLeft = m; Console.WriteLine(Borde + "╠══════════════════════════════════════════════╣");
            Console.CursorLeft = m; Console.WriteLine(Borde + "║" + G1 + "  1. Registrar expediente                     " + Borde + "║");
            Console.CursorLeft = m; Console.WriteLine(Borde + "║" + G2 + "  2. Buscar expediente por código             " + Borde + "║");
            Console.CursorLeft = m; Console.WriteLine(Borde + "║" + G3 + "  3. Ordenar expedientes por código           " + Borde + "║");
            Console.CursorLeft = m; Console.WriteLine(Borde + "║" + G4 + "  4. Mostrar todos los expedientes            " + Borde + "║");
            Console.CursorLeft = m; Console.WriteLine(Borde + "║" + G5 + "  5. Salir                                    " + Borde + "║");
            Console.CursorLeft = m; Console.WriteLine(Borde + "╚══════════════════════════════════════════════╝" + Reset);
            Console.WriteLine();
            Console.CursorLeft = m; Console.Write(Texto + "Seleccione una opción (1-5): " + Reset);
        }

        private static void RegistrarExpediente()
        {
            int m = Math.Max(0, (Console.WindowWidth - 52) / 2);
            Console.CursorTop = 2;
            Encabezado("REGISTRO DE EXPEDIENTE", 52);
            ExpedienteEntidad exp = new ExpedienteEntidad();
            exp.Codigo = Leer("Código: ", m);
            exp.DniRuc = Leer("DNI/RUC: ", m);
            exp.Nombres = Leer("Nombres: ", m);
            exp.Apellidos = Leer("Apellidos: ", m);
            exp.Telefono = Leer("Teléfono: ", m);
            exp.Correo = Leer("Correo electrónico: ", m);
            exp.TipoDocumento = Leer("Tipo doc. (Solicitud/Carta/Oficio): ", m);
            exp.NumeroDocumento = Leer("Número de documento: ", m);
            int folios;
            if (!int.TryParse(Leer("Número de folios: ", m), out folios))
            {
                try { Console.Beep(250, 75); } catch { }
                Console.CursorLeft = m; Console.WriteLine(Error + "\nFALLA 21: Los folios deben ser un número entero." + Reset);
                return;
            }
            exp.Folios = folios;
            exp.Asunto = Leer("Asunto: ", m);
            exp.AreaDestino = Leer("Área de destino: ", m);
            Console.WriteLine();
            Console.CursorLeft = m; Console.WriteLine(G2 + "VALIDANDO INFORMACIÓN..." + Reset);
            string msg;
            bool ok = gestor.Registrar(exp, out msg);
            try { if (ok) Console.Beep(420, 20); else Console.Beep(250, 75); } catch { }
            Console.CursorLeft = m; Console.WriteLine((ok ? Titulo : Error) + msg + Reset);
        }

        private static void BuscarExpediente()
        {
            int m = Math.Max(0, (Console.WindowWidth - 52) / 2);
            Console.CursorTop = 3;
            Encabezado("BUSCAR EXPEDIENTE", 52);
            ExpedienteEntidad exp = gestor.BuscarPorCodigo(Leer("Ingrese el código: ", m));
            if (exp != null) VistaComun.MostrarExpediente(exp);
            else { try { Console.Beep(250, 75); } catch { } Console.CursorLeft = m; Console.WriteLine(Error + "No se encontró ningún expediente con ese código." + Reset); }
        }

        private static void OrdenarYMostrar()
        {
            gestor.OrdenarPorCodigo();
            Console.CursorTop = 2;
            Encabezado("EXPEDIENTES ORDENADOS", 52);
            VistaComun.MostrarLista(gestor.ObtenerTodos());
        }

        private static void MostrarTodos()
        {
            Console.CursorTop = 2;
            Encabezado("TODOS LOS EXPEDIENTES", 52);
            VistaComun.MostrarLista(gestor.ObtenerTodos());
        }

        private static void Pausar()
        {
            Console.CursorVisible = false;
            string txt = "[ Presione cualquier tecla para volver al menú ]";
            Console.WriteLine("\n");
            Console.CursorLeft = Math.Max(0, (Console.WindowWidth - txt.Length) / 2);
            Console.WriteLine(G2 + txt + Reset);
            Console.ReadKey(true);
            try { Console.Beep(420, 20); } catch { }
        }

        private static void Encabezado(string titulo, int ancho)
        {
            int m = Math.Max(0, (Console.WindowWidth - ancho) / 2);
            int intAncho = ancho - 2;
            string pad = titulo.PadLeft((intAncho + titulo.Length) / 2).PadRight(intAncho);
            Console.CursorLeft = m; Console.WriteLine(Borde + "╔" + new string('═', intAncho) + "╗");
            Console.CursorLeft = m; Console.WriteLine(Borde + "║" + Titulo + pad + Borde + "║");
            Console.CursorLeft = m; Console.WriteLine(Borde + "╚" + new string('═', intAncho) + "╝\n" + Reset);
        }

        private static string Leer(string etiqueta, int m)
        {
            Console.CursorLeft = m; Console.Write(G2 + etiqueta + Texto);
            string v = Console.ReadLine();
            Console.Write(Reset);
            return v;
        }
    }
}