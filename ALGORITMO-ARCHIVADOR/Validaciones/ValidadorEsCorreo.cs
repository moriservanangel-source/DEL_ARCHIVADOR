
using System.Net.Mail;

namespace MesaPartesCajamarca.Validaciones.EsCorreo
{
    public class ValidadorEsCorreo
    {
        public static bool EsCorreoValido(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
                return false;

            try
            {
                MailAddress direccion = new MailAddress(correo);
                return direccion.Address == correo.Trim();
            }
            catch
            {
                return false;
            }
        }
    }
}
