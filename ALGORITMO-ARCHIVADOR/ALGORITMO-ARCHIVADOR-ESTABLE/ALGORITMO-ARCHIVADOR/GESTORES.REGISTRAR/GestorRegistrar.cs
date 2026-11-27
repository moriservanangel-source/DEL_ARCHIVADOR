using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesaPartesCajamarca.Entidad;
using MesaPartesCajamarca.Validaciones;
using ExpedienteEntidad = MesaPartesCajamarca.Entidad.Expediente;

namespace MesaPartesCajamarca.Gestores.Registrar
{
    public class GestorRegistrar
    {
        public static bool Registrar(
            List<ExpedienteEntidad> expedientes,
            ExpedienteEntidad exp,
            out string mensaje)
        {
            mensaje = "";
            if (Validador.EsCampoVacio(exp.Codigo))
            {
                mensaje = "FALLA 1: El código es obligatorio.";
                return false;
            }
            if (exp.Codigo != exp.Codigo.Trim())
            {
                mensaje =
                    "FALLA 2: El código no debe tener espacios al inicio o final.";
                return false;
            }
            foreach (ExpedienteEntidad e in expedientes)
            {
                if (e.Codigo.Equals(
                    exp.Codigo,
                    StringComparison.OrdinalIgnoreCase))
                {
                    mensaje = "FALLA 3: El código ya existe.";
                    return false;
                }
            }
            if (Validador.EsCampoVacio(exp.DniRuc))
            {
                mensaje = "FALLA 4: El DNI/RUC es obligatorio.";
                return false;
            }
            if (!Validador.DniRucSoloNumeros(exp.DniRuc))
            {
                mensaje =
                    "FALLA 5: El DNI/RUC solo debe contener números.";
                return false;
            }
            if (!Validador.DniRucLongitudValida(exp.DniRuc))
            {
                mensaje =
                    "FALLA 6: El DNI debe tener 8 dígitos o el RUC 11 dígitos.";
                return false;
            }
            if (Validador.EsCampoVacio(exp.Nombres))
            {
                mensaje = "FALLA 7: Los nombres son obligatorios.";
                return false;
            }
            if (!Validador.EsNombreValido(exp.Nombres))
            {
                mensaje =
                    "FALLA 8: Los nombres solo deben contener letras.";
                return false;
            }
            if (Validador.EsCampoVacio(exp.Apellidos))
            {
                mensaje = "FALLA 9: Los apellidos son obligatorios.";
                return false;
            }
            if (!Validador.EsNombreValido(exp.Apellidos))
            {
                mensaje =
                    "FALLA 10: Los apellidos solo deben contener letras.";
                return false;
            }
            if (Validador.EsCampoVacio(exp.Telefono))
            {
                mensaje = "FALLA 11: El teléfono es obligatorio.";
                return false;
            }
            if (!Validador.TelefonoSoloNumeros(exp.Telefono))
            {
                mensaje =
                    "FALLA 12: El teléfono solo debe contener números.";
                return false;
            }
            if (!Validador.TelefonoLongitudValida(exp.Telefono))
            {
                mensaje =
                    "FALLA 13: El teléfono debe tener exactamente 9 dígitos.";
                return false;
            }
            if (Validador.EsCampoVacio(exp.Correo))
            {
                mensaje = "FALLA 14: El correo es obligatorio.";
                return false;
            }
            if (!Validador.EsCorreoValido(exp.Correo))
            {
                mensaje =
                    "FALLA 15: El correo electrónico no tiene un formato válido.";
                return false;
            }
            if (Validador.EsCampoVacio(exp.TipoDocumento))
            {
                mensaje =
                    "FALLA 16: El tipo de documento es obligatorio.";
                return false;
            }
            if (!Validador.EsTipoDocumentoValido(exp.TipoDocumento))
            {
                mensaje =
                    "FALLA 17: Tipo inválido. Use Solicitud, Carta u Oficio.";
                return false;
            }
            if (Validador.EsCampoVacio(exp.NumeroDocumento))
            {
                mensaje =
                    "FALLA 18: El número de documento es obligatorio.";
                return false;
            }
            if (!Validador.NumeroDocumentoSinCaracteresInvalidos(
                exp.NumeroDocumento))
            {
                mensaje =
                    "FALLA 19: El número de documento contiene caracteres inválidos.";
                return false;
            }
            if (!Validador.NumeroDocumentoLongitudValida(
                exp.NumeroDocumento))
            {
                mensaje =
                    "FALLA 20: El número de documento no puede superar 20 caracteres.";
                return false;
            }
            if (exp.Folios <= 0)
            {
                mensaje =
                    "FALLA 21: El número de folios debe ser mayor que cero.";
                return false;
            }
            if (Validador.EsCampoVacio(exp.Asunto))
            {
                mensaje = "FALLA 22: El asunto es obligatorio.";
                return false;
            }
            if (Validador.EsCampoVacio(exp.AreaDestino))
            {
                mensaje =
                    "FALLA 23: El área de destino es obligatoria.";
                return false;
            }
            if (!Validador.CodigoSinCaracteresEspeciales(exp.Codigo))
            {
                mensaje =
                    "FALLA 24: El código contiene el carácter | no permitido.";
                return false;
            }
            expedientes.Add(exp);
            mensaje = "Expediente registrado correctamente.";
            return true;
        }
    }
}
