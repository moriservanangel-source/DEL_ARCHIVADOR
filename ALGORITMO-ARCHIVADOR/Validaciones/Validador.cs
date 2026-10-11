using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MesaPartesCajamarca.Validaciones.EsCampoVacio;
using MesaPartesCajamarca.Validaciones.EsCorreo;
using MesaPartesCajamarca.Validaciones.EsDniRuc;

namespace MesaPartesCajamarca.Validaciones
{
    public static class Validador
    {
        // ==============================
        // CAMPOS VACÍOS
        // ==============================

        public static bool EsCampoVacio(string valor)
        {
            return ValidadorEsCampoVacio.EsCampoVacio(valor);
        }

        // ==============================
        // DNI / RUC
        // ==============================

        public static bool DniRucSoloNumeros(string dniRuc)
        {
            return ValidadorEsDniRuc.ContieneSoloNumeros(dniRuc);
        }

        public static bool DniRucLongitudValida(string dniRuc)
        {
            return ValidadorEsDniRuc.EsLongitudValida(dniRuc);
        }

        public static bool EsDniRucValido(string dniRuc)
        {
            return ValidadorEsDniRuc.EsDniRucValido(dniRuc);
        }

        // ==============================
        // CORREO
        // ==============================

        public static bool EsCorreoValido(string correo)
        {
            return ValidadorEsCorreo.EsCorreoValido(correo);
        }

        // ==============================
        // NOMBRES Y APELLIDOS
        // ==============================

        public static bool EsNombreValido(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return false;

            return Regex.IsMatch(
                nombre.Trim(),
                @"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$");
        }

        // ==============================
        // TELÉFONO
        // ==============================

        public static bool TelefonoSoloNumeros(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return false;

            return Regex.IsMatch(telefono, @"^\d+$");
        }

        public static bool TelefonoLongitudValida(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return false;

            return telefono.Length == 9;
        }

        // ==============================
        // CÓDIGO
        // ==============================

        public static bool CodigoSinCaracteresEspeciales(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return false;

            return !codigo.Contains("|");
        }

        // ==============================
        // TIPO DE DOCUMENTO
        // ==============================

        public static bool EsTipoDocumentoValido(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                return false;

            string valor = tipo.Trim().ToUpper();

            return valor == "SOLICITUD"
                || valor == "CARTA"
                || valor == "OFICIO";
        }

        // ==============================
        // NÚMERO DE DOCUMENTO
        // ==============================

        public static bool NumeroDocumentoSinCaracteresInvalidos(
            string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                return false;

            return Regex.IsMatch(numero, @"^[A-Za-z0-9\-]+$");
        }

        public static bool NumeroDocumentoLongitudValida(
            string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                return false;

            return numero.Length <= 20;
        }
    }
}