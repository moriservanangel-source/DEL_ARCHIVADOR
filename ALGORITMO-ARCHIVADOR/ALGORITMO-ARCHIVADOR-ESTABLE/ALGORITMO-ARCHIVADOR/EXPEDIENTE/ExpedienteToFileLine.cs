using MesaPartesCajamarca.Expediente.FromFileLine;
using MesaPartesCajamarca.Expediente.ToString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesaPartesCajamarca.Expediente.ToFileLine
{
    public class ExpedienteToFileLine : ExpedienteToString
    {
        public string ToFileLine()
        {
            return ATextoPlano();
        }
    }
}
