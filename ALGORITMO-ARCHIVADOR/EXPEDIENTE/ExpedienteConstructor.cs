using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesaPartesCajamarca.Expediente.Base;

namespace MesaPartesCajamarca.Expediente.Constructor
{
    public class ExpedienteConstructor : ExpedienteBase
    {
        public ExpedienteConstructor()
        {
            FechaRegistro = DateTime.Now;
        }
    }
}

