﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    class Alumno : EscuelaBase
    {
        public override string ToString()
        {
            return $"Alumno: {Nombre}";
        }
    }
}
