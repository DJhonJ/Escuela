using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    class Evaluacion: EscuelaBase
    {
        public float Nota { get; set; }

        public override string ToString()
        {
            return $"Evaluación: {Nombre}";
        }
    }
}
