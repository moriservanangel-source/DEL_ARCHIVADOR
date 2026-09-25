using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesaPartesCajamarca.Expediente.Base
{
    public class ExpedienteBase
    {
        public string Codigo { get; set; }
        public string DniRuc { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public int Folios { get; set; }
        public string Asunto { get; set; }
        public string AreaDestino { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
