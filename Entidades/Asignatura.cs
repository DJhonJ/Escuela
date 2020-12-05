using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    class Asignatura: EscuelaBase
    {
        public List<Evaluacion> Evaluciones { get; set; }
    }
}
